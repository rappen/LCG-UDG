using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Rappen.XTB.LCG
{
    internal class EntityMetadataProxy : MetadataProxy
    {
        #region Public Fields

        public List<AttributeMetadataProxy> Attributes;
        public EntityMetadata Metadata;

        [DisplayName(" \n ")]
        public bool Selected { get => IsSelected; }

        [DisplayName("Name")]
        public string DisplayName { get => Metadata?.DisplayName?.UserLocalizedLabel?.Label ?? Metadata?.LogicalName; }

        [DisplayName("Logical Name")]
        public string LogicalName { get => Metadata?.LogicalName; }

        internal AttributeMetadataProxy PrimaryKey { get => Attributes?.FirstOrDefault(a => a.Metadata.IsPrimaryId == true); }

        internal AttributeMetadataProxy PrimaryName { get => Attributes?.FirstOrDefault(a => a.Metadata.IsPrimaryName == true); }

        #endregion Public Fields

        #region Public Constructors

        public EntityMetadataProxy(EntityMetadata entityMetadata)
        {
            Metadata = entityMetadata;
        }

        #endregion Public Constructors

        #region Public Methods

        public override string ToString()
        {
            if (Metadata != null)
            {
                if (!string.IsNullOrEmpty(Metadata?.DisplayName?.UserLocalizedLabel?.Label))
                {
                    return $"{Metadata.DisplayName.UserLocalizedLabel.Label} ({Metadata.LogicalName})";
                }
                return Metadata.LogicalName;
            }
            return base.ToString();
        }

        public string GetNameTechnical(NameType constantName)
        {
            switch (constantName)
            {
                case NameType.DisplayName:
                    return StringToCSharpIdentifier(DisplayName);
                case NameType.LogicalName:
                    return Metadata?.LogicalName;
                case NameType.SchemaName:
                    return Metadata?.SchemaName;
                default:
                    return null;
            }
        }

        #endregion Public Methods
    }
}