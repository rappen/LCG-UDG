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

        internal string GetEntityProperties(Settings settings)
        {
            var properties = new Dictionary<string, object>();
            if (DisplayName != GetNameTechnical(settings.ConstantName, settings.DoStripPrefix, settings.StripPrefix))
            {
                properties.Add("DisplayName", DisplayName);
            }
            properties.Add("OwnershipType", Metadata.OwnershipType);
            properties.Add("IntroducedVersion", Metadata.IntroducedVersion);
            return string.Join(", ", properties
                .Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString()))
                .Select(p => p.Key.Split(':')[0] + ": " + p.Value));
        }

        internal string Description { get => Metadata?.Description?.UserLocalizedLabel?.Label; }

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

        public string GetNameTechnical(NameType nametype, bool dostripprefix, string stripprefix)
        {
            var name = string.Empty;
            switch (nametype)
            {
                case NameType.DisplayName:
                    name = StringToCSharpIdentifier(DisplayName);
                    break;
                case NameType.LogicalName:
                    name = Metadata?.LogicalName;
                    break;
                case NameType.SchemaName:
                    name = Metadata?.SchemaName;
                    break;
            }
            if (nametype != NameType.DisplayName &&
                dostripprefix && !string.IsNullOrEmpty(stripprefix) &&
                name.ToLowerInvariant().StartsWith(stripprefix))
            {
                name = name.Substring(stripprefix.Length);
            }
            return name;
        }

        #endregion Public Methods
    }
}