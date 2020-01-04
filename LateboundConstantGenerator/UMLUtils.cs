using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rappen.XTB.LCG
{
    public class UMLUtils
    {
        private static Template template;
        public static string GenerateClasses(List<EntityMetadataProxy> entitiesmetadata, Settings settings, IConstantFileWriter fileWriter)
        {
            template = settings.commonsettings.Template;
            var selectedentities = entitiesmetadata.Where(e => e.Selected).ToList();
            foreach (var entitymetadata in selectedentities)
            {
                var entity = GetClass(selectedentities, entitymetadata, settings);
                var fileName = entitymetadata.GetNameTechnical(settings.FileName, settings) + ".plantuml";
                fileWriter.WriteEntity(settings, entity, fileName);
            }
            return fileWriter.Finalize(settings, ".plantuml");
        }

        public static string GetFile(Settings settings, string classes)
        {
            return template.Namespace
                .Replace("{namespace}", settings.NameSpace)
                .Replace("{entities}", classes);
        }

        private static string GetClass(List<EntityMetadataProxy> selectedentities, EntityMetadataProxy entitymetadata, Settings settings)
        {
            var name = entitymetadata.GetNameTechnical(settings.ConstantName, settings);
            name = settings.commonsettings.EntityPrefix + name + settings.commonsettings.EntitySuffix;
            var entity = new StringBuilder();
            entity.AppendLine(template.Class
                .Replace("{classname}", name)
                .Replace("{entity}", GetEntity(entitymetadata))
                .Replace("'", "\"")
                .Replace("{attributes}", GetAttributes(entitymetadata, settings))
                .Replace("{relationships}", GetRelationships(entitymetadata, selectedentities, settings)));
            return entity.ToString();
        }

        private static string GetEntity(EntityMetadataProxy entitymetadata)
        {
            return template.Entity.Replace("{logicalname}", entitymetadata.LogicalName).Replace("{logicalcollectionname}", entitymetadata.LogicalCollectionName);
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
                attributes.Add("--");
                if (entitymetadata.PrimaryName?.IsSelected == true)
                {   // Then Primary Name
                    attributes.Add(GetAttribute(entitymetadata.PrimaryName, settings));
                }
                foreach (var attributemetadata in entitymetadata.Attributes
                    .Where(a => a.Selected && a != entitymetadata.PrimaryKey && a != entitymetadata.PrimaryName)
                    .OrderBy(a => a.GetNameTechnical(settings))
                    .OrderBy(OrderByRequiredLevel))
                {   // Then all the rest
                    var attribute = GetAttribute(attributemetadata, settings);
                    attributes.Add(attribute);
                }
            }
            DeduplicateIdentifiers(ref attributes);
            var result = string.Join("\r\n", attributes);
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

        private static string GetAttribute(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            var name = attributemetadata.GetNameTechnical(settings);
            if (attributemetadata == attributemetadata.Entity.PrimaryKey)
            {
                name += " (PK)";
            }
            if (attributemetadata == attributemetadata.Entity.PrimaryName)
            {
                name += " (PA)";
            }
            name = settings.commonsettings.AttributePrefix + name + settings.commonsettings.AttributeSuffix;
            var entityname = attributemetadata.Entity.GetNameTechnical(settings.ConstantName, settings);
            if (name.Equals(entityname))
            {
                name += "_";
            }
            if (attributemetadata.Metadata.IsCustomAttribute.Value)
            {
                name = $"<color:blue>{name}</color>";
            }
            var required = "";
            switch (attributemetadata.Metadata.RequiredLevel.Value)
            {
                case AttributeRequiredLevel.ApplicationRequired:
                case AttributeRequiredLevel.SystemRequired:
                    required = "*";
                    break;
                case AttributeRequiredLevel.Recommended:
                    required = "+";
                    break;
            }
            var attribute = new StringBuilder();
            attribute.AppendLine(template.Attribute
                .Replace("{required}", required)
                .Replace("{attribute}", name)
                .Replace("{type}", attributemetadata.Type.ToString())
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
            relation.AppendLine(template.Relationship
                .Replace("{relationship}", name)
                .Replace("{schemaname}", relationship.Metadata.SchemaName)
                .Replace("'", "\""));
            return relation.ToString();
        }
    }
}