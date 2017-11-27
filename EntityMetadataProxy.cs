using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;
using System.ComponentModel;

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
        public string DisplayName { get { return Metadata?.DisplayName?.UserLocalizedLabel?.Label; } }

        [DisplayName("Logical Name")]
        public string LogicalName { get { return Metadata?.LogicalName; } }

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

        #endregion Public Methods
    }
}