using Microsoft.Xrm.Sdk.Metadata;
using System.ComponentModel;

namespace Rappen.XTB.LCG
{
    internal class AttributeMetadataProxy : MetadataProxy
    {
        #region Public Fields

        public AttributeMetadata Metadata;

        #endregion Public Fields

        #region Private Fields

        private EntityMetadataProxy entity;

        #endregion Private Fields

        #region Public Constructors

        public AttributeMetadataProxy(EntityMetadataProxy entity, AttributeMetadata attributeMetadata)
        {
            this.entity = entity;
            Metadata = attributeMetadata;
        }

        #endregion Public Constructors

        #region Public Properties

        [DisplayName(" \n ")]
        public bool Selected { get => IsSelected; }

        [DisplayName("Name")]
        public string DisplayName { get { return Metadata?.DisplayName?.UserLocalizedLabel?.Label; } }

        [DisplayName("Logical Name")]
        public string LogicalName { get { return Metadata?.LogicalName; } }

        public AttributeTypeCode? Type { get { return Metadata?.AttributeType; } }

        #endregion Public Properties

        #region Public Methods

        public override void SetSelected(bool value)
        {
            var wasSelected = IsSelected;
            base.SetSelected(value);
            if (value != wasSelected && value && !entity.IsSelected)
            {
                entity.SetSelected(true);
            }
        }

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