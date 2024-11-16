using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Rappen.XTB.LCG.Cmd
{
    public class LCGHelper
    {
        private List<EntityMetadataProxy> entities;

        private CrmConnection crmConnection;

        public Settings Settings { get; private set; }

        public void ConnectCrm(CrmCredentials credentials)
        {
            this.crmConnection = CrmConnection.ConnectCrm(credentials);
        }

        public void ConnectCrm(string connectionString)
        {
            this.crmConnection = CrmConnection.ConnectCrm(connectionString);
        }

        public void LoadSettingsFromFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                var document = new XmlDocument();
                document.Load(path);
                this.Settings = (Settings)XmlSerializerHelper.Deserialize(document.OuterXml, typeof(Settings));
            }
            else
            {
                throw new FileNotFoundException(path);
            }
        }

        public void GenerateConstants()
        {
            // ToDo: Load CommonSettings
            LoadEntities();
            RestoreSelectedEntities();
            var writer = Settings.GetWriter(this.crmConnection.WebApplicationUrl);
            if (GenerationUtils.GenerateFiles(entities, Settings, writer))
            {
                Console.Write(writer.GetResult(Settings));
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        private void LoadEntities() // ToDo: Deduplicate with LCG.cs
        {
            var response = MetadataHelper.LoadEntities(this.crmConnection.OrganizationService, this.crmConnection.OrganizationMajorVersion);

            var metaresponse = response.EntityMetadata;
            entities = new List<EntityMetadataProxy>(
                metaresponse
                    .Select(m => new EntityMetadataProxy(m))
                    .OrderBy(e => e.ToString()));
            foreach (var entity in entities)
            {
                entity.Relationships = new List<RelationshipMetadataProxy>(
                    entity.Metadata.ManyToOneRelationships.Select(m => new RelationshipMetadataProxy(entities, entity, m)));
                entity.Relationships.AddRange(
                    entity.Metadata.OneToManyRelationships
                        .Where(r => !entity.Metadata.ManyToOneRelationships.Select(r1m => r1m.SchemaName).Contains(r.SchemaName))
                        .Select(r => new RelationshipMetadataProxy(entities, entity, r)));
                entity.Relationships.AddRange(
                    entity.Metadata.ManyToManyRelationships.Select(m => new RelationshipMetadataProxy(entities, entity, m)));
            }
        }

        private void LoadAttributes(EntityMetadataProxy entity)  // ToDo: Deduplicate with LCG.cs
        {
            entity.Attributes = null;

            var retreiveMetadataChangeResponse = MetadataHelper.LoadEntityDetails(this.crmConnection.OrganizationService, entity.LogicalName);
            if (retreiveMetadataChangeResponse != null
                && retreiveMetadataChangeResponse.EntityMetadata != null
                && retreiveMetadataChangeResponse.EntityMetadata.Count > 0)
            {
                var entityMetadata = retreiveMetadataChangeResponse.EntityMetadata[0];

                entity.Attributes = new List<AttributeMetadataProxy>(
                    retreiveMetadataChangeResponse.EntityMetadata[0]
                        .Attributes
                        .Select(m => new AttributeMetadataProxy(entity, m))
                        .OrderBy(a => a.ToString()));
            }
        }

        private void RestoreSelectedEntities() // ToDo: Deduplicate with LCG.cs
        {
            if (entities == null)
            {
                return;
            }
            if (Settings == null)
            {
                return;
            }
            if (Settings.SelectedEntities == null || Settings.SelectedEntities.Count == 0)
            {   // Loading old style selection configuration
                Settings.SelectedEntities = new List<SelectedEntity>();
                foreach (var entitystring in Settings.Selection)
                {
                    var entityname = entitystring.Split(':')[0];
                    var attributes = entitystring.Split(':')[1].Split(',').ToList();
                    Settings.SelectedEntities.Add(new SelectedEntity
                    {
                        Name = entityname,
                        Attributes = attributes,
                        Relationships = new List<string>()
                    });
                }
            }
            foreach (var selectedentity in Settings.SelectedEntities)
            {
                var entityname = selectedentity.Name;
                var attributes = selectedentity.Attributes;
                var entity = entities.FirstOrDefault(e => e.LogicalName == entityname);
                if (entity == null)
                {
                    continue;
                }
                if (!entity.Selected)
                {
                    entity.SetSelected(true);
                }

                foreach (var attributename in attributes)
                {
                    if (entity.Attributes == null)
                    {
                        LoadAttributes(entity);
                    }
                    var attribute = entity.Attributes.FirstOrDefault(a => a.LogicalName == attributename);
                    if (attribute != null && !attribute.Selected)
                    {
                        attribute.SetSelected(true);
                    }
                }

                if (selectedentity.Relationships == null)
                {   // Needs to be defaulted since it was not stored in config
                    selectedentity.Relationships = GetDefaultRelationships(entity);
                }

                foreach (var relationshipname in selectedentity.Relationships)
                {
                    var relatioship = entity.Relationships.FirstOrDefault(r => r.LogicalName == relationshipname);
                    if (relatioship != null && !relatioship.Selected)
                    {
                        relatioship.SetSelected(true);
                    }
                }
            }
        }

        private List<string> GetDefaultRelationships(EntityMetadataProxy entity)
        {
            var selectedrelationships = GetFilteredRelationships(entity, string.Empty);
            return selectedrelationships.Select(r => r.LogicalName).ToList();
        }

        private IEnumerable<RelationshipMetadataProxy> GetFilteredRelationships(EntityMetadataProxy entity, string search)
        {
            bool GetTypeFilter(RelationshipMetadataProxy r)
            {   // Exclude relationships where selected entity is just child of the relationship
                if (Settings.RelationshipFilter.Type1N &&
                    r.OneToManyRelationshipMetadata?.ReferencedEntity == entity?.LogicalName)
                {
                    return true;
                }
                if (Settings.RelationshipFilter.TypeN1 &&
                    r.OneToManyRelationshipMetadata?.ReferencingEntity == entity?.LogicalName &&
                    r.OneToManyRelationshipMetadata?.ReferencedEntity != entity?.LogicalName)   // Exclude self-referencing relationships, they are included as 1:N
                {
                    return true;
                }
                if (Settings.RelationshipFilter.TypeNN &&
                    r.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    return true;
                }
                return false;
            }
            bool GetCustomFilter(RelationshipMetadataProxy r)
            {
                return Settings.RelationshipFilter.Custom == CheckState.Indeterminate ||
                       (Settings.RelationshipFilter.Custom == CheckState.Unchecked && r.Metadata.IsCustomRelationship.GetValueOrDefault()) ||
                       (Settings.RelationshipFilter.Custom == CheckState.Checked && !r.Metadata.IsCustomRelationship.GetValueOrDefault());
            }
            bool GetManagedFilter(RelationshipMetadataProxy r)
            {
                return Settings.RelationshipFilter.Managed == CheckState.Indeterminate ||
                       (Settings.RelationshipFilter.Managed == CheckState.Unchecked && r.Metadata.IsManaged.GetValueOrDefault()) ||
                       (Settings.RelationshipFilter.Managed == CheckState.Checked && !r.Metadata.IsManaged.GetValueOrDefault());
            }
            bool GetSearchFilter(RelationshipMetadataProxy r)
            {
                return string.IsNullOrWhiteSpace(search) ||
                       r.Metadata.SchemaName.ToLowerInvariant().Contains(search) ||
                       r.Parent?.DisplayName?.ToLowerInvariant().Contains(search) == true;
            }

            bool GetOrphansFilter(RelationshipMetadataProxy r)
            {
                if (Settings.RelationshipFilter.Orphans)
                {
                    return true;
                }
                var selectedentities = entities.Where(e => e.Selected).Select(e => e.LogicalName).Union(new string[] { entity.LogicalName }).Distinct();
                if (r.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    return selectedentities.Contains(r.ManyToManyRelationshipMetadata.Entity1LogicalName)
                        && selectedentities.Contains(r.ManyToManyRelationshipMetadata.Entity2LogicalName);
                }
                return selectedentities.Contains(r.OneToManyRelationshipMetadata.ReferencedEntity)
                    && selectedentities.Contains(r.OneToManyRelationshipMetadata.ReferencingEntity);
            }
            bool GetOwnersFilter(RelationshipMetadataProxy r)
            {
                if (Settings.RelationshipFilter.Owner || r.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    return true;
                }
                return
                    r.OneToManyRelationshipMetadata.ReferencingAttribute != "ownerid" &&
                    r.OneToManyRelationshipMetadata.ReferencedAttribute != "ownerid";
            }
            bool GetRegardingFilter(RelationshipMetadataProxy r)
            {
                if (Settings.RelationshipFilter.Regarding || r.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    return true;
                }
                return
                    r.OneToManyRelationshipMetadata.ReferencingAttribute != "regardingobjectid";
            }

            return entity.Relationships
                    .Where(
                        r => GetTypeFilter(r)
                           && GetCustomFilter(r)
                           && GetManagedFilter(r)
                           && GetSearchFilter(r)
                           && GetOrphansFilter(r)
                           && GetOwnersFilter(r)
                           && GetRegardingFilter(r));
        }
    }
}