using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;
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

        private AttributeMetadataProxy lookupAttribute;

        #endregion Private Fields

        #region Public Constructors

        public RelationshipMetadataProxy(List<EntityMetadataProxy> entities, OneToManyRelationshipMetadata relationshipMetadata)
        {
            Parent = entities.FirstOrDefault(e => e.LogicalName == relationshipMetadata.ReferencedEntity);
            Child = entities.FirstOrDefault(e => e.LogicalName == relationshipMetadata.ReferencingEntity);
            Metadata = relationshipMetadata;
        }

        public RelationshipMetadataProxy(List<EntityMetadataProxy> entities, ManyToManyRelationshipMetadata relationshipMetadata)
        {
            Parent = entities.FirstOrDefault(e => e.LogicalName == relationshipMetadata.Entity1LogicalName);
            Child = entities.FirstOrDefault(e => e.LogicalName == relationshipMetadata.Entity2LogicalName);
            Metadata = relationshipMetadata;
        }

        #endregion Public Constructors

        #region Public Properties

        public AttributeMetadataProxy LookupAttribute
        {
            get
            {
                if (Metadata is OneToManyRelationshipMetadata && lookupAttribute == null)
                {
                    lookupAttribute = Child?.Attributes?.FirstOrDefault(a => a.LogicalName == (Metadata as OneToManyRelationshipMetadata)?.ReferencingAttribute);
                }
                return lookupAttribute;
            }
        }

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