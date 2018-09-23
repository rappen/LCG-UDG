using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rappen.XTB.LCG
{
    public class CSharpUtils
    {
        #region Templates

        public struct Template
        {
            public const string IndentStr = "    ";
            public const string Header1 = @"// *********************************************************************
// Created by: Latebound Constant Generator {version} for XrmToolBox
// Author    : Jonas Rapp http://twitter.com/rappen
// Repo      : https://github.com/rappen/LateboundConstantGenerator
// Source Org: {organization}";

            public const string Header2 = "// *********************************************************************";
            public const string Namespace = "namespace {namespace}\n{\n{entities}\n}";
            public const string Entity = "public static class {entity}\n{\npublic const string EntityName = '{logicalname}';\n{attributes}\n{relationships}\n{optionsets}\n}";
            public const string Attribute = "public const string {attribute} = '{logicalname}';";
            public const string Relationship = "public const string {relationship} = '{schemaname}';";
            public const string OptionSet = "public enum {name}\n{\n{values}\n}";
            public const string OptionSetValue = "{name} = {value}";
            public const string Region = "#region {region}\n{content}\n#endregion {region}";
        }

        #endregion Templates

        public static string GenerateClasses(List<EntityMetadataProxy> entitiesmetadata, Settings settings, IConstantFileWriter fileWriter)
        {
            var selectedentities = entitiesmetadata.Where(e => e.Selected).ToList();
            foreach (var entitymetadata in selectedentities)
            {
                var entity = GetEntity(selectedentities, entitymetadata, settings);
                var fileName = entitymetadata.GetNameTechnical(settings.FileName, settings) + ".cs";
                fileWriter.WriteEntity(settings, entity, fileName);
            }
            return fileWriter.GetCompleteMessage(settings);
        }

        public static string GetFile(Settings settings, string classes)
        {
            return Template.Namespace
                .Replace("{namespace}", settings.NameSpace)
                .Replace("{entities}", classes);
        }

        private static string GetEntity(List<EntityMetadataProxy> selectedentities, EntityMetadataProxy entitymetadata, Settings settings)
        {
            var name = entitymetadata.GetNameTechnical(settings.ConstantName, settings);
            name = settings.commonsettings.EntityPrefix + name + settings.commonsettings.EntitySuffix;
            var description = entitymetadata.Description?.Replace("\n", "\n/// ");
            var summary = settings.XmlProperties ? entitymetadata.GetEntityProperties(settings) : settings.XmlDescription ? description : string.Empty;
            var remarks = settings.XmlProperties && settings.XmlDescription ? description : string.Empty;
            var entity = new StringBuilder();
            if (!string.IsNullOrEmpty(summary))
            {
                entity.AppendLine($"/// <summary>{summary}</summary>");
            }
            if (!string.IsNullOrEmpty(remarks))
            {
                entity.AppendLine($"/// <remarks>{remarks}</remarks>");
            }
            entity.AppendLine(Template.Entity
                .Replace("{entity}", name)
                .Replace("{logicalname}", entitymetadata.LogicalName)
                .Replace("'", "\"")
                .Replace("{attributes}", GetAttributes(entitymetadata, settings))
                .Replace("{relationships}", GetRelationships(entitymetadata, selectedentities, settings))
                .Replace("{optionsets}", GetOptionSets(entitymetadata, settings)));
            return entity.ToString();
        }

        private static string GetAttributes(EntityMetadataProxy entitymetadata, Settings settings)
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
                foreach (var attributemetadata in entitymetadata.Attributes
                    .Where(a => a.Selected && a.Metadata.IsPrimaryId != true && a.Metadata.IsPrimaryName != true))
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
            if (settings.RelationShips)
            {
                if (entitymetadata?.Metadata?.ManyToOneRelationships != null)
                {
                    foreach (var relationship in entitymetadata.Relationships.Where(r => r.Parent != entitymetadata && includedentities.Contains(r.Parent)).Distinct())
                    {
                        relationships.Add(GetRelationShip(relationship, settings, settings.commonsettings.ManyOneRelationshipPrefix));
                    }
                    foreach (var relationship in entitymetadata.Relationships.Where(r => r.Parent == entitymetadata && includedentities.Contains(r.Child)).Distinct())
                    {
                        relationships.Add(GetRelationShip(relationship, settings, settings.commonsettings.OneManyRelationshipPrefix));
                    }
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
            var l = 0;
            var newlist = new List<string>();
            foreach (var line in constantdeclarations)
            {
                var newline = line;
                if (line.Contains("="))
                {
                    var identifier = line.Split('=')[0].Trim();
                    var identorig = identifier;
                    var value = line.Split('=')[1].Trim();
                    var i = 0;
                    while (identifiers.Contains(identifier))
                    {
                        i++;
                        identifier = identorig + i.ToString();
                    }
                    if (i > 0)
                    {
                        newline = identifier + " = " + value;
                    }
                    identifiers.Add(identifier);
                }
                newlist.Add(newline);
            }
            constantdeclarations = newlist;
        }

        private static string GetOptionSets(EntityMetadataProxy entitymetadata, Settings settings)
        {
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
            var relationstr = Template.Relationship
                .Replace("{relationship}", name)
                .Replace("{schemaname}", relationship.Metadata.SchemaName)
                .Replace("'", "\"");
            return relationstr;
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
                        label = label.CamelCaseIt();
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