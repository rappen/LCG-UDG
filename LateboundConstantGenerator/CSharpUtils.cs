using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rappen.XTB.LCG
{
    public class CSharpUtils
    {
        private static Template Template;
        public static string GenerateClasses(List<EntityMetadataProxy> entitiesmetadata, Settings settings, IConstantFileWriter fileWriter)
        {
            Template = settings.commonsettings.Template;
            var selectedentities = entitiesmetadata.Where(e => e.Selected).ToList();
            var commonentity = GetCommonEntity(selectedentities, settings);
            if (commonentity != null)
            {
                var entity = GetClass(selectedentities, commonentity, null, settings);
                var fileName = commonentity.GetNameTechnical(settings.FileName, settings) + ".cs";
                fileWriter.WriteEntity(settings, entity, fileName);
            }
            foreach (var entitymetadata in selectedentities)
            {
                var entity = GetClass(selectedentities, entitymetadata, commonentity, settings);
                var fileName = entitymetadata.GetNameTechnical(settings.FileName, settings) + ".cs";
                fileWriter.WriteEntity(settings, entity, fileName);
            }
            return fileWriter.GetCompleteMessage(settings);
        }

        private static EntityMetadataProxy GetCommonEntity(List<EntityMetadataProxy> selectedentities, Settings settings)
        {
            if (settings.CommonAttributes == CommonAttributesType.None)
            {
                return null;
            }
            var attributes = new List<AttributeMetadataProxy>();
            var selectedentitiesattributes = selectedentities.Select(e => e.Attributes?.Where(a => a.IsSelected && a.Metadata.IsPrimaryId != true && a.Metadata.IsPrimaryName != true));
            switch (settings.CommonAttributes)
            {
                case CommonAttributesType.CommonInAny:
                    {
                        var alluniqueattributes = new List<string>();
                        foreach (var entityattributes in selectedentitiesattributes)
                        {
                            attributes.AddRange(entityattributes.Where(a => !attributes.Select(a2 => a2.LogicalName).Contains(a.LogicalName) && alluniqueattributes.Contains(a.LogicalName)));
                            alluniqueattributes.AddRange(entityattributes.Select(a => a.LogicalName).Where(a => !alluniqueattributes.Contains(a)));
                        }
                        break;
                    }
                case CommonAttributesType.CommonInAll:
                    {
                        attributes = selectedentitiesattributes.SelectMany(a => a).GroupBy(a => a.LogicalName).Select(a => a.First()).ToList();
                        foreach (var entityattributes in selectedentitiesattributes)
                        {
                            var entityattributenames = entityattributes.Select(a => a.LogicalName);
                            var pos = 0;
                            while (pos < attributes.Count)
                            {
                                if (entityattributenames.Contains(attributes[pos].LogicalName))
                                {
                                    pos++;
                                }
                                else
                                {
                                    attributes.RemoveAt(pos);
                                }
                            }
                        }
                        break;
                    }
            }
            var allselectedattributes = selectedentitiesattributes.SelectMany(a => a).ToList();
            foreach (var attribute in attributes)
            {
                var entities = string.Join(", ", allselectedattributes.Where(a => a.IsSelected && a.LogicalName == attribute.LogicalName).Select(a => a.Entity.LogicalName));
                attribute.AdditionalProperties = "Used by entities: " + entities;
            }
            var result = new EntityMetadataProxy(new EntityMetadata
            {
                LogicalName = "[common]"
            })
            {
                Attributes = attributes.OrderBy(a => a.LogicalName).ToList()
            };

            return result;
        }

        public static string GetFile(Settings settings, string classes)
        {
            return Template.Namespace
                .Replace("{namespace}", settings.NameSpace)
                .Replace("{entities}", classes);
        }

        private static string GetClass(List<EntityMetadataProxy> selectedentities, EntityMetadataProxy entitymetadata, EntityMetadataProxy commonentity, Settings settings)
        {
            var name = entitymetadata.GetNameTechnical(settings.ConstantName, settings);
            name = settings.commonsettings.EntityPrefix + name + settings.commonsettings.EntitySuffix;
            var description = entitymetadata.Description?.Replace("\n", "\n/// ");
            var summary = settings.XmlProperties && entitymetadata.LogicalName != "[common]" ? entitymetadata.GetEntityProperties(settings) : settings.XmlDescription ? description : string.Empty;
            var remarks = settings.XmlProperties && entitymetadata.LogicalName != "[common]" && settings.XmlDescription ? description : string.Empty;
            var entity = new StringBuilder();
            if (!string.IsNullOrEmpty(summary))
            {
                entity.AppendLine($"/// <summary>{summary}</summary>");
            }
            if (!string.IsNullOrEmpty(remarks))
            {
                entity.AppendLine($"/// <remarks>{remarks}</remarks>");
            }
            entity.AppendLine(Template.Class
                .Replace("{classname}", name)
                .Replace("{entity}", GetEntity(entitymetadata))
                .Replace("'", "\"")
                .Replace("{attributes}", GetAttributes(entitymetadata, commonentity, settings))
                .Replace("{relationships}", GetRelationships(entitymetadata, selectedentities, settings))
                .Replace("{optionsets}", GetOptionSets(entitymetadata, settings)));
            return entity.ToString();
        }

        private static string GetEntity(EntityMetadataProxy entitymetadata)
        {
            if (entitymetadata.LogicalName == "[common]")
            {
                return string.Empty;
            }
            return Template.Entity.Replace("{logicalname}", entitymetadata.LogicalName).Replace("{logicalcollectionname}", entitymetadata.LogicalCollectionName);
        }

        private static string GetAttributes(EntityMetadataProxy entitymetadata, EntityMetadataProxy commonentity, Settings settings)
        {
            var attributes = new List<string>();
            if (entitymetadata.Attributes != null)
            {
                if (entitymetadata.PrimaryKey?.IsSelected == true)
                {   // First Primary Key
                    attributes.Add(GetAttribute(entitymetadata.PrimaryKey, settings));
                }
                if (entitymetadata.PrimaryName?.IsSelected == true)
                {   // Then Primary Name
                    attributes.Add(GetAttribute(entitymetadata.PrimaryName, settings));
                }
                var commonattributes = commonentity?.Attributes?.Select(a => a.LogicalName) ?? new List<string>();
                foreach (var attributemetadata in entitymetadata.Attributes
                    .Where(a => (entitymetadata.LogicalName == "[common]") || (a.Selected && !commonattributes.Contains(a.LogicalName) && a.Metadata.IsPrimaryId != true && a.Metadata.IsPrimaryName != true)))
                {   // Then all the rest
                    var attribute = GetAttribute(attributemetadata, settings);
                    attributes.Add(attribute);
                }
            }
            DeduplicateIdentifiers(ref attributes);
            var result = string.Join("\r\n", attributes);
            if (settings.Regions && attributes.Count > 0)
            {
                return Template.Region.Replace("{region}", "Attributes").Replace("{content}", result);
            }
            return result;
        }

        private static string GetRelationships(EntityMetadataProxy entitymetadata, List<EntityMetadataProxy> includedentities, Settings settings)
        {
            var relationships = new List<string>();
            if (settings.RelationShips && entitymetadata.Relationships != null)
            {
                foreach (var relationship in entitymetadata.Relationships.Where(r => r.Parent != entitymetadata && includedentities.Contains(r.Parent)).Distinct())
                {
                    relationships.Add(GetRelationShip(relationship, settings,
                        (relationship.Metadata is ManyToManyRelationshipMetadata) ? settings.commonsettings.ManyManyRelationshipPrefix : settings.commonsettings.ManyOneRelationshipPrefix));
                }
                foreach (var relationship in entitymetadata.Relationships.Where(r => r.Parent == entitymetadata && includedentities.Contains(r.Child)).Distinct())
                {
                    relationships.Add(GetRelationShip(relationship, settings,
                        (relationship.Metadata is ManyToManyRelationshipMetadata) ? settings.commonsettings.ManyManyRelationshipPrefix : settings.commonsettings.OneManyRelationshipPrefix));
                }
            }
            DeduplicateIdentifiers(ref relationships);
            var result = string.Join("\r\n", relationships);
            if (settings.Regions && !string.IsNullOrEmpty(result))
            {
                return Template.Region.Replace("{region}", "Relationships").Replace("{content}", result);
            }
            return result;
        }

        private static void DeduplicateIdentifiers(ref List<string> constantdeclarations)
        {
            var identifiers = new List<string>();
            var newlist = new List<string>();
            foreach (var line in constantdeclarations)
            {
                var newline = line;
                if (line.Contains("="))
                {
                    var identifier = line.Split('=')[0].Trim();
                    var identorig = identifier;
                    // This removes possible comment lines in the "identifier"
                    identifier = string.Join("\n", identifier.Split('\n').Where(l => !l.Trim().StartsWith("//")));
                    var newIdenitifier = identorig;
                    var value = line.Split('=')[1].Trim();
                    var i = 0;
                    while (identifiers.Contains(identifier))
                    {
                        i++;
                        newIdenitifier = identorig + i.ToString();
                        identifier += i.ToString();
                    }
                    if (i > 0)
                    {
                        newline = newIdenitifier + " = " + value;
                    }
                    identifiers.Add(identifier);
                }
                newlist.Add(newline);
            }
            constantdeclarations = newlist;
        }

        private static string GetOptionSets(EntityMetadataProxy entitymetadata, Settings settings)
        {
            if (entitymetadata.LogicalName == "[common]")
            {
                return string.Empty;
            }
            var optionsets = new List<string>();
            if (settings.OptionSets && entitymetadata.Attributes != null)
            {
                foreach (var attributemetadata in entitymetadata.Attributes.Where(a => a.Selected && (a.Metadata is EnumAttributeMetadata)))
                {
                    var optionset = GetOptionSet(attributemetadata, settings);
                    optionsets.Add(optionset);
                }
            }
            DeduplicateIdentifiers(ref optionsets);
            var result = string.Join("\r\n", optionsets);
            if (settings.Regions && !string.IsNullOrEmpty(result))
            {
                return Template.Region.Replace("{region}", "OptionSets").Replace("{content}", result);
            }
            return result;
        }

        private static string GetAttribute(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            var name = attributemetadata.Metadata.IsPrimaryId == true ? "PrimaryKey" :
                attributemetadata.Metadata.IsPrimaryName == true ? "PrimaryName" :
                attributemetadata.GetNameTechnical(settings);
            name = settings.commonsettings.AttributePrefix + name + settings.commonsettings.AttributeSuffix;
            var description = attributemetadata.Description?.Replace("\n", "\n/// ");
            var summary = settings.XmlProperties ? attributemetadata.AttributeProperties : settings.XmlDescription ? description : string.Empty;
            summary = summary?.Replace("\n", "\n/// ");
            var remarks = settings.XmlProperties && settings.XmlDescription ? description : string.Empty;
            var attribute = new StringBuilder();
            if (!string.IsNullOrEmpty(summary))
            {
                attribute.AppendLine($"/// <summary>{summary}</summary>");
            }
            if (!string.IsNullOrEmpty(remarks))
            {
                attribute.AppendLine($"/// <remarks>{remarks}</remarks>");
            }
            attribute.AppendLine(Template.Attribute
                .Replace("{attribute}", name)
                .Replace("{logicalname}", attributemetadata.LogicalName)
                .Replace("'", "\""));
            return attribute.ToString();
        }

        private static string GetRelationShip(RelationshipMetadataProxy relationship, Settings settings, string prefix)
        {
            if (relationship.Child?.Attributes == null)
            {
                return string.Empty;
            }
            var name = prefix + relationship.GetNameTechnical(settings);
            var summary = settings.XmlProperties ? relationship.Summary(settings) : string.Empty;
            var relation = new StringBuilder();
            if (!string.IsNullOrEmpty(summary))
            {
                relation.AppendLine($"/// <summary>{summary}</summary>");
            }
            relation.AppendLine(Template.Relationship
                .Replace("{relationship}", name)
                .Replace("{schemaname}", relationship.Metadata.SchemaName)
                .Replace("'", "\""));
            return relation.ToString();
        }

        private static string GetOptionSet(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            var name = settings.commonsettings.OptionSetEnumPrefix + attributemetadata.GetNameTechnical(settings) + settings.commonsettings.OptionSetEnumSuffix;
            var optionset = Template.OptionSet.Replace("{name}", name);
            var options = new List<string>();
            var optionsetmetadata = attributemetadata.Metadata as EnumAttributeMetadata;
            if (optionsetmetadata != null && optionsetmetadata.OptionSet != null)
            {
                foreach (var optionmetadata in optionsetmetadata.OptionSet.Options)
                {
                    var label = MetadataProxy.StringToCSharpIdentifier(optionmetadata.Label.UserLocalizedLabel.Label);
                    if (settings.ConstantCamelCased)
                    {
                        label = label.CamelCaseIt(settings);
                    }
                    if (string.IsNullOrEmpty(label) || int.TryParse(label[0].ToString(), out int tmp))
                    {
                        label = "_" + label;
                    }
                    var option = Template.OptionSetValue
                        .Replace("{name}", label)
                        .Replace("{value}", optionmetadata.Value.ToString());
                    options.Add(option);
                }
            }
            optionset = optionset.Replace("{values}", string.Join(",\r\n", options));
            return optionset;
        }
    }
}