using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using McTools.Xrm.Connection;

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
            if (CSharpUtils.GenerateClasses(entities, Settings, writer))
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
            }
        }
    }
}
