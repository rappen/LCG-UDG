using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace Rappen.XTB.LCG
{
    public class RelationshipMetadataProxy : MetadataProxy
    {
        #region Public Fields

        public EntityMetadataProxy Child;
        public OneToManyRelationshipMetadata Metadata;
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

        #endregion Public Constructors

        #region Public Properties

        public AttributeMetadataProxy LookupAttribute
        {
            get
            {
                if (lookupAttribute == null)
                {
                    lookupAttribute = Child?.Attributes?.FirstOrDefault(a => a.LogicalName == Metadata.ReferencingAttribute);
                }
                return lookupAttribute;
            }
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