using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Rappen.XTB.LCG
{
    public class RelationshipMetadataProxy : MetadataProxy
    {
        #region Public Fields

        public EntityMetadataProxy Child;
        public RelationshipMetadataBase Metadata;
        public EntityMetadataProxy Parent;

        #endregion Public Fields

        #region Private Fields

        private EntityMetadataProxy originatingentity;
        private AttributeMetadataProxy lookupAttribute;

        #endregion Private Fields

        #region Public Constructors

        public RelationshipMetadataProxy(List<EntityMetadataProxy> entities, EntityMetadataProxy originatingentity, OneToManyRelationshipMetadata relationshipMetadata)
        {
            this.originatingentity = originatingentity;
            Parent = entities.FirstOrDefault(e => e.LogicalName == relationshipMetadata.ReferencedEntity);
            Child = entities.FirstOrDefault(e => e.LogicalName == relationshipMetadata.ReferencingEntity);
            Metadata = relationshipMetadata;
        }

        public RelationshipMetadataProxy(List<EntityMetadataProxy> entities, EntityMetadataProxy originatingentity, ManyToManyRelationshipMetadata relationshipMetadata)
        {
            this.originatingentity = originatingentity;
            Parent = entities.FirstOrDefault(e => e.LogicalName == relationshipMetadata.Entity1LogicalName);
            Child = entities.FirstOrDefault(e => e.LogicalName == relationshipMetadata.Entity2LogicalName);
            Metadata = relationshipMetadata;
        }

        #endregion Public Constructors

        [Browsable(false)]
        public OneToManyRelationshipMetadata OneToManyRelationshipMetadata => Metadata as OneToManyRelationshipMetadata;
        [Browsable(false)]
        public ManyToManyRelationshipMetadata ManyToManyRelationshipMetadata => Metadata as ManyToManyRelationshipMetadata;
        internal EntityMetadataProxy OtherEntity => originatingentity == Parent ? Child : Parent;
        internal AttributeMetadataProxy LookupAttribute
        {
            get
            {
                if (Metadata is OneToManyRelationshipMetadata omrel && lookupAttribute == null)
                {
                    lookupAttribute = Child?.Attributes?.FirstOrDefault(a => a.LogicalName == omrel.ReferencingAttribute);
                }
                return lookupAttribute;
            }
        }

        #region Public Properties

        [DisplayName(" \n ")]
        public bool Selected => IsSelected;

        [DisplayName("Type")]
        public string Type => Metadata.RelationshipType == RelationshipType.ManyToManyRelationship ? "N : N" : originatingentity == Parent ? "1 : N" : originatingentity == Child ? "N : 1" : "?";

        [DisplayName("Related Entity")]
        public string RelatedEntityName => OtherEntity?.DisplayName;

        [DisplayName("Lookup")]
        public string LookupName
        {
            get
            {
                var result = LookupAttribute?.DisplayName;
                if (Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    result = Child?.DisplayName;
                }
                if (string.IsNullOrWhiteSpace(result) && OneToManyRelationshipMetadata != null)
                {
                    result = OneToManyRelationshipMetadata.ReferencingAttribute;
                }
                return result;
            }
        }

        [DisplayName("Schema Name")]
        public string LogicalName => Metadata?.SchemaName;

        // Two nice to have properties for debugging
        // public string Referenced => Metadata.RelationshipType == RelationshipType.ManyToManyRelationship ? ManyToManyRelationshipMetadata.Entity1LogicalName : OneToManyRelationshipMetadata.ReferencedEntity + "/" + OneToManyRelationshipMetadata.ReferencedAttribute;
        // public string Referencing => Metadata.RelationshipType == RelationshipType.ManyToManyRelationship ? ManyToManyRelationshipMetadata.Entity2LogicalName : OneToManyRelationshipMetadata.ReferencingEntity + "/" + OneToManyRelationshipMetadata.ReferencingAttribute;

        [DisplayName("Referenced")]
        [Browsable(false)]
        public string Referenced => Metadata.RelationshipType == RelationshipType.ManyToManyRelationship ? ManyToManyRelationshipMetadata.Entity1IntersectAttribute : OneToManyRelationshipMetadata.ReferencedAttribute;

        [DisplayName("Referencing")]
        [Browsable(false)]
        public string Referencing => Metadata.RelationshipType == RelationshipType.ManyToManyRelationship ? ManyToManyRelationshipMetadata.Entity2IntersectAttribute: OneToManyRelationshipMetadata.ReferencingAttribute;

        public string Summary(Settings settings)
        {
            if (Metadata is ManyToManyRelationshipMetadata)
            {
                return
                    $"Entity 1: \"{Parent?.GetNameTechnical(settings.ConstantName, settings)}\" " +
                    $"Entity 2: \"{Child?.GetNameTechnical(settings.ConstantName, settings)}\"";
            }
            return
                $"Parent: \"{Parent?.GetNameTechnical(settings.ConstantName, settings)}\" " +
                $"Child: \"{Child?.GetNameTechnical(settings.ConstantName, settings)}\" " +
                $"Lookup: \"{LookupAttribute?.GetNameTechnical(settings)}\"";
        }

        #endregion Public Properties

        #region Public Methods

        public override void SetSelected(bool value)
        {
            var wasSelected = IsSelected;
            base.SetSelected(value);
            if (value != wasSelected && value && !originatingentity.IsSelected)
            {
                originatingentity.SetSelected(true);
            }
        }

        public override string ToString()
        {
            return $"{Parent?.DisplayName} {Type} {Child?.DisplayName}";
        }

        public string GetNameTechnical(Settings settings)
        {
            var name = settings.GetNonDisplayName(Metadata.SchemaName);
            if (settings.ConstantName == NameType.DisplayName && LookupAttribute != null)
            {
                name = StringToCSharpIdentifier(Child.DisplayName + lookupAttribute.DisplayName);
            }
            return name;
        }

        #endregion Public Methods
    }
}