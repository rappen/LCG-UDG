using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rappen.XTB.LCG
{
    public class GenerationUtils
    {
        public static bool GenerateFiles(List<EntityMetadataProxy> selectedentities, Settings settings, IConstantFileWriter fileWriter)
        {
            var addedrelationships = new List<string>();
            var commonentity = GetCommonEntity(selectedentities, settings);
            var suffix = Settings.FileSuffix(settings.TemplateFormat);
            if (commonentity != null)
            {
                var entity = GetClass(commonentity, null, settings, addedrelationships);
                var fileName = commonentity.GetNameTechnical(settings.FileName, settings) + suffix;
                fileWriter.WriteBlock(settings, entity, fileName);
            }
            if (settings.Groups?.Count > 0)
            {
                foreach (var group in settings.Groups.Where(g => selectedentities.Any(e => e.Group == g)))
                {
                    var groupstr = GetGroup(group, selectedentities.Where(e => e.Group == group).ToList(), settings, addedrelationships);
                    fileWriter.WriteBlock(settings, groupstr, group.Name);
                }
            }
            foreach (var entitymetadata in selectedentities.Where(e => e.Group == null))
            {
                var entity = GetClass(entitymetadata, commonentity, settings, addedrelationships);
                var fileName = entitymetadata.GetNameTechnical(settings.FileName, settings) + suffix;
                fileWriter.WriteBlock(settings, entity, fileName);
            }
            if (settings.TemplateSettings.Template.AddAllRelationshipsAfterEntities)
            {
                var relationships = selectedentities.SelectMany(e => e.Relationships.Where(r => r.IsSelected));
                relationships = relationships.GroupBy(r => r.LogicalName).Select(r => r.FirstOrDefault());    // This will make it distinct by LogicalName
                var allrelationshipsstring = GetRelationships(relationships, settings, addedrelationships);
                fileWriter.WriteBlock(settings, allrelationshipsstring, "Relationships" + suffix);
            }
            return fileWriter.Finalize(settings);
        }

        private static EntityMetadataProxy GetCommonEntity(List<EntityMetadataProxy> selectedentities, Settings settings)
        {
            if (settings.CommonAttributes == CommonAttributesType.None)
            {
                return null;
            }
            var attributes = new List<AttributeMetadataProxy>();
            var selectedentitiesattributes = selectedentities.Select(e => e.Attributes?.Where(a => a.IsSelected && a != e.PrimaryKey && a != e.PrimaryName));
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

        private static string GetGroup(EntityGroup group, List<EntityMetadataProxy> selectedentities, Settings settings, List<string> addedrelationships)
        {
            var template = settings.TemplateSettings.Template;

            var entities = new StringBuilder();
            foreach (var entitymetadata in selectedentities)
            {
                var entity = GetClass(entitymetadata, null, settings, addedrelationships);
                entities.AppendLine(entity);
            }
            var color = group.ColorToString ?? "";
            if (!string.IsNullOrEmpty(color))
            {
                color = "#" + color;
            }
            return template.EntityGroup?
                .Replace("{group}", group.Name)
                .Replace("{color}", color)
                .Replace("{entities}", entities.ToString());
        }

        private static string GetClass(EntityMetadataProxy entitymetadata, EntityMetadataProxy commonentity, Settings settings, List<string> addedrelationships)
        {
            var template = settings.TemplateSettings.Template;
            var name = entitymetadata.GetNameTechnical(settings.ConstantName, settings);
            name = settings.TemplateSettings.EntityPrefix + name + settings.TemplateSettings.EntitySuffix;
            var description = entitymetadata.Description?.Replace("\n", "\n/// ");
            var summary = settings.XmlProperties && entitymetadata.LogicalName != "[common]" ? entitymetadata.GetEntityProperties(settings) : settings.XmlDescription ? description : string.Empty;
            var remarks = settings.XmlProperties && entitymetadata.LogicalName != "[common]" && settings.XmlDescription ? description : string.Empty;
            if (!string.IsNullOrEmpty(summary))
            {
                summary = template.Summary?.Replace("{summary}", summary);
            }
            if (!string.IsNullOrEmpty(remarks))
            {
                remarks = template.Remarks?.Replace("{remarks}", remarks);
            }
            var entity = template.EntityContainer
                .Replace("{entityname}", name)
                .Replace("{entitydetail}", GetEntity(entitymetadata, template))
                .Replace("{typedetails}", settings.TypeDetails ? entitymetadata.EntityTypeDetails : "")
                .Replace("{type}", settings.ColorByType ? entitymetadata.Metadata.IsCustomEntity == true ? "<<custom>>" : "<<standard>>" : "")
                .Replace("{summary}", summary)
                .Replace("{remarks}", remarks)
                .Replace("'", "\"")
                .Replace("{attributes}", GetAttributes(entitymetadata, commonentity, settings))
                .Replace("{relationships}", GetRelationships(entitymetadata, settings, addedrelationships))
                .Replace("{optionsets}", GetOptionSets(entitymetadata, settings));
            return entity;
        }

        private static string GetEntity(EntityMetadataProxy entitymetadata, TemplateBase template)
        {
            if (entitymetadata.LogicalName == "[common]")
            {
                return string.Empty;
            }
            return template.EntityDetail?.Replace("{logicalname}", entitymetadata.LogicalName).Replace("{logicalcollectionname}", entitymetadata.Metadata.LogicalCollectionName);
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
                attributes.Add(settings.TemplateSettings.AttributeSeparatorAfterPK);
                if (entitymetadata.PrimaryName?.IsSelected == true)
                {   // Then Primary Name
                    attributes.Add(GetAttribute(entitymetadata.PrimaryName, settings));
                }
                var commonattributes = commonentity?.Attributes?.Select(a => a.LogicalName) ?? new List<string>();
                var entityattributes = entitymetadata.Attributes
                    .Where(a => (entitymetadata.LogicalName == "[common]") || (a.Selected && !commonattributes.Contains(a.LogicalName) && a != entitymetadata.PrimaryKey && a != entitymetadata.PrimaryName));
                switch (settings.AttributeSortMode)
                {
                    case AttributeSortMode.Alphabetical:
                        entityattributes = entityattributes.OrderBy(a => a.GetNameTechnical(settings));
                        break;

                    case AttributeSortMode.AlphabeticalAndRequired:
                        entityattributes = entityattributes
                            .OrderBy(a => a.GetNameTechnical(settings))
                            .OrderBy(OrderByRequiredLevel);
                        break;
                }
                foreach (var attributemetadata in entityattributes)
                {   // Then all the rest
                    var attribute = GetAttribute(attributemetadata, settings);
                    attributes.Add(attribute);
                }
            }
            DeduplicateIdentifiers(ref attributes);
            var result = string.Join("\r\n", attributes);
            if (settings.Regions && !string.IsNullOrWhiteSpace(result))
            {
                return settings.TemplateSettings.Template.Region?.ReplaceIfNotEmpty("{region}", "Attributes").Replace("{content}", result);
            }
            return result;
        }

        private static int OrderByRequiredLevel(AttributeMetadataProxy attribute)
        {
            switch (attribute.Metadata.RequiredLevel.Value)
            {
                case AttributeRequiredLevel.ApplicationRequired:
                case AttributeRequiredLevel.SystemRequired:
                    return 10;

                case AttributeRequiredLevel.Recommended:
                    return 20;

                default:
                    return 100;
            }
        }

        private static string GetRelationships(EntityMetadataProxy entitymetadata, Settings settings, List<string> addedrelationships)
        {
            if (settings.TemplateSettings.Template.AddAllRelationshipsAfterEntities)
            {
                return string.Empty;
            }
            var relationships = new List<string>();
            var relation = string.Empty;
            if (settings.RelationShips && entitymetadata.Relationships != null)
            {
                foreach (var relationship in entitymetadata.Relationships.Where(r => r.Parent != entitymetadata && r.IsSelected && !addedrelationships.Contains(r.LogicalName)).Distinct())
                {
                    relation = GetRelationShip(relationship, settings,
                        (relationship.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship) ?
                            settings.TemplateSettings.ManyManyRelationshipPrefix :
                            settings.TemplateSettings.ManyOneRelationshipPrefix, addedrelationships);
                    // N : 1 and 1 : N are the same, so we only add one of them
                    if (!relationships.Contains(relation))
                    {
                        relationships.Add(relation);
                    }
                }
                foreach (var relationship in entitymetadata.Relationships.Where(r => r.Parent == entitymetadata && r.IsSelected && !addedrelationships.Contains(r.LogicalName)).Distinct())
                {
                    relation = GetRelationShip(relationship, settings,
                        (relationship.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship) ?
                            settings.TemplateSettings.ManyManyRelationshipPrefix :
                            settings.TemplateSettings.OneManyRelationshipPrefix, addedrelationships);
                    // N : 1 and 1 : N are the same, so we only add one of them
                    if (!relationships.Contains(relation))
                    {
                        relationships.Add(relation);
                    }
                }
            }
            DeduplicateIdentifiers(ref relationships);
            var result = string.Join("\r\n", relationships);
            if (settings.Regions && !string.IsNullOrEmpty(result))
            {
                return settings.TemplateSettings.Template.Region?.Replace("{region}", "Relationships").Replace("{content}", result);
            }
            return result;
        }

        private static string GetRelationships(IEnumerable<RelationshipMetadataProxy> relationshipslist, Settings settings, List<string> addedrelationships)
        {
            var relationships = new List<string>();
            foreach (var relationship in relationshipslist.Where(r => !addedrelationships.Contains(r.LogicalName)))
            {
                relationships.Add(GetRelationShip(relationship, settings,
                    (relationship.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship) ?
                        settings.TemplateSettings.ManyManyRelationshipPrefix :
                        settings.TemplateSettings.OneManyRelationshipPrefix, addedrelationships));
            }
            var result = string.Join("\r\n", relationships);
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
                return settings.TemplateSettings.Template.Region?.Replace("{region}", "OptionSets").Replace("{content}", result);
            }
            return result;
        }

        private static string GetAttribute(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            var template = settings.TemplateSettings.Template;
            var type = attributemetadata.Type.ToString();
            var name = attributemetadata.GetNameTechnical(settings);
            if (attributemetadata == attributemetadata.Entity.PrimaryKey)
            {
                name = template.PrimaryKeyName.Replace("{attribute}", name);
            }
            if (attributemetadata == attributemetadata.Entity.PrimaryName)
            {
                name = template.PrimaryAttributeName.Replace("{attribute}", name);
            }
            name = settings.TemplateSettings.AttributePrefix + name + settings.TemplateSettings.AttributeSuffix;
            var entityname = attributemetadata.Entity.GetNameTechnical(settings.ConstantName, settings);
            if (name.Equals(entityname))
            {
                name += template.TableAttributeNameClashSuffix;
            }
            name = attributemetadata.Metadata.IsCustomAttribute.Value && string.IsNullOrEmpty(settings.Theme) && settings.ColorByType ?
                template.CustomAttribute.ReplaceIfNotEmpty("{attribute}", name) :
                template.StandardAttribute.ReplaceIfNotEmpty("{attribute}", name);
            switch (attributemetadata.Metadata.RequiredLevel.Value)
            {
                case AttributeRequiredLevel.ApplicationRequired:
                case AttributeRequiredLevel.SystemRequired:
                    name = template.RequiredLevelRequired.ReplaceIfNotEmpty("{attribute}", name);
                    break;

                case AttributeRequiredLevel.Recommended:
                    name = template.RequiredLevelRecommended.ReplaceIfNotEmpty("{attribute}", name);
                    break;

                case AttributeRequiredLevel.None:
                    name = template.RequiredLevelNone.ReplaceIfNotEmpty("{attribute}", name);
                    break;
            }
            if (settings.ValidateIdentifiers)
            {
                name = UnicodeCharacterUtilities.MakeValidIdentifier(name, true);
            }
            var description = attributemetadata.Description?.Replace("\n", "\n/// ");
            var summary = settings.XmlProperties ? attributemetadata.AttributeProperties : settings.XmlDescription ? description : string.Empty;
            var remarks = settings.XmlProperties && settings.XmlDescription ? description : string.Empty;
            if (!string.IsNullOrEmpty(summary))
            {
                summary = template.Summary?.Replace("{summary}", summary.Replace("\n", "\n/// "));
            }
            if (!string.IsNullOrEmpty(remarks))
            {
                remarks = template.Remarks?.Replace("{remarks}", remarks);
            }
            var attribute = template.Attribute
                .Replace("{attribute}", name)
                .Replace("{logicalname}", attributemetadata.LogicalName)
                .Replace("{type}", attributemetadata.Type.ToString())
                .Replace("{typedetails}", settings.TypeDetails ? attributemetadata.AttributeTypeDetails : "")
                .Replace("{summary}", summary)
                .Replace("{remarks}", remarks)
                .Replace("'", "\"");
            return attribute;
        }

        private static string GetRelationShip(RelationshipMetadataProxy relationship, Settings settings, string prefix, List<string> addedrelationships)
        {
            var template = settings.TemplateSettings.Template;
            if (relationship.Child == null || relationship.Parent == null)
            {
                return string.Empty;
            }
            var name = prefix + relationship.GetNameTechnical(settings);
            var summary = settings.XmlProperties ? relationship.Summary(settings) : string.Empty;
            if (!string.IsNullOrEmpty(summary))
            {
                summary = template.Summary?.Replace("{summary}", summary);
            }
            // default to Relationship if no specific template is defined
            var relationTemplate = template.Relationship;

            var parentAttrib = relationship.Parent.Attributes.Where(a => a.LogicalName == relationship.Referenced).FirstOrDefault();
            var childAttrib = relationship.Child.Attributes.Where(a => a.LogicalName == relationship.Referencing).FirstOrDefault();
            var referencedName = parentAttrib?.GetNameTechnical(settings) ?? relationship.Referenced;
            var referencingName = childAttrib?.GetNameTechnical(settings) ?? relationship.Referencing;

            if (relationTemplate == string.Empty)
            {
                switch (relationship.Type)
                {
                    case "1 : M":
                        relationTemplate = template.Relationship1_N;
                        break;

                    case "M : M":
                        relationTemplate = template.RelationshipN_N;
                        break;

                    case "M : 1":
                        relationTemplate = template.RelationshipN_1;
                        break;
                }
            }
            var relation = relationTemplate
                .Replace("{relationship}", name)
                .Replace("{schemaname}", relationship.Metadata.SchemaName)
                .Replace("{entity1}", relationship.Parent.GetNameTechnical(settings.ConstantName, settings))
                .Replace("{referenced}", relationship.Referenced)
                .Replace("{referencing}", relationship.Referencing)
                .Replace("{referencedName}", referencedName)
                .Replace("{referencingName}", referencingName)
                .Replace("{referencedAttribute}", relationship.LookupName)
                .Replace("{entity2}", relationship.Child.GetNameTechnical(settings.ConstantName, settings))
                .Replace("{relationtype}", GetRelationUMLNotation(relationship, settings.RelationShipSize, settings.TemplateFormat))
                .Replace("{lookup}", settings.RelationshipLabels ? relationship.LookupAttribute?.GetNameTechnical(settings) : "")
                .Replace("{summary}", summary)
                .Replace("'", "\"")
                .TrimEnd(' ', ':');
            if (!string.IsNullOrWhiteSpace(relation))
            {
                addedrelationships.Add(relationship.LogicalName);
            }
            return relation;
        }

        private static string GetRelationUMLNotation(RelationshipMetadataProxy relationship, int size, TemplateFormat templateFormat)
        {
            switch (templateFormat)
            {
                case TemplateFormat.PlantUML:
                    var sizestr = new string('-', size);
                    if (relationship.Metadata is ManyToManyRelationshipMetadata)
                    {
                        return "}" + sizestr + "{";
                    }
                    else if (relationship.Metadata is OneToManyRelationshipMetadata)
                    {
                        if (relationship.LookupAttribute?.Metadata.RequiredLevel.Value == AttributeRequiredLevel.ApplicationRequired ||
                            relationship.LookupAttribute?.Metadata.RequiredLevel.Value == AttributeRequiredLevel.SystemRequired)
                        {
                            return "||" + sizestr + "{";
                        }
                        return sizestr + "{";
                    }
                    return sizestr;

                case TemplateFormat.DBML:
                    if (relationship.Metadata is ManyToManyRelationshipMetadata)
                    {
                        return "<>";
                    }
                    return ">";

                default:
                    return string.Empty;
            }
        }

        private static string GetOptionSet(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            var name = settings.TemplateSettings.OptionSetEnumPrefix + attributemetadata.GetNameTechnical(settings) + settings.TemplateSettings.OptionSetEnumSuffix;
            var optionset = settings.TemplateSettings.Template.OptionSet?.Replace("{name}", name);
            var options = new List<string>();
            if (attributemetadata.Metadata is EnumAttributeMetadata optionsetmetadata && optionsetmetadata.OptionSet != null)
            {
                foreach (var optionmetadata in optionsetmetadata.OptionSet.Options)
                {
                    var label = MetadataProxy.StringToCSharpIdentifier(optionmetadata.Label.UserLocalizedLabel.Label);
                    if (settings.ConstantCamelCased)
                    {
                        label = label.CamelCaseIt(settings);
                    }
                    if (string.IsNullOrEmpty(label) || !UnicodeCharacterUtilities.IsIdentifierStartCharacter(label[0]) || !label.IsValidIdentifier())
                    {
                        label = "_" + label;
                    }
                    var option = settings.TemplateSettings.Template.OptionSetValue?
                        .Replace("{name}", label)?
                        .Replace("{value}", optionmetadata.Value.ToString());
                    options.Add(option);
                }
            }
            DeduplicateIdentifiers(ref options);
            optionset = optionset?.Replace("{values}", string.Join(",\r\n", options));
            return optionset;
        }
    }
}