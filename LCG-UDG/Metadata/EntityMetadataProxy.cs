using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Rappen.XTB.LCG
{
    public class EntityMetadataProxy : MetadataProxy
    {
        #region Public Fields

        public List<AttributeMetadataProxy> Attributes;
        public List<RelationshipMetadataProxy> Relationships;
        public EntityMetadata Metadata;
        public EntityGroup Group;

        [DisplayName(" \n ")]
        public bool Selected { get => IsSelected; }

        [DisplayName("Name")]
        public string DisplayName { get => Metadata?.DisplayName?.UserLocalizedLabel?.Label ?? Metadata?.LogicalName; }

        [DisplayName("Logical Name")]
        public string LogicalName { get => Metadata?.LogicalName; }

        [DisplayName("Group")]
        public string GroupName { get => Group?.Name; }

        //[DisplayName("Logical Collection Name")]
        //public string LogicalCollectionName { get => Metadata?.LogicalCollectionName; }

        [DisplayName("Records")]
        public int? RecordCount { get => Records == -1 ? null : Records; }

        internal AttributeMetadataProxy PrimaryKey { get => Attributes?.FirstOrDefault(a => a.Metadata.IsPrimaryId == true && a.Metadata.IsLogical == false); }

        internal AttributeMetadataProxy PrimaryName { get => Attributes?.FirstOrDefault(a => a.Metadata.IsPrimaryName == true); }

        internal string EntityTypeDetails
        {
            get
            {
                return string.Empty;

                // This breaks the entity names. Currently not implemented.
                var types = new List<string>();
                if (Metadata.IsActivity == true)
                {
                    types.Add("Activity");
                }
                if (Metadata.IsActivityParty == true)
                {
                    types.Add("ActivityParty");
                }
                if (Metadata.DataProviderId?.Equals(Guid.Empty) == false)
                {
                    types.Add("Virtual");
                }
                if (types.Count == 0)
                {
                    return string.Empty;
                }
                return "\n(" + string.Join(", ", types) + ")";
            }
        }

        internal string GetEntityProperties(Settings settings)
        {
            var properties = new Dictionary<string, object>();
            if (DisplayName != GetNameTechnical(settings.ConstantName, settings))
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
        internal int? Records;
        internal bool CountedAttributes = false;

        #endregion Public Fields

        #region Public Constructors

        public EntityMetadataProxy(EntityMetadata entityMetadata)
        {
            Metadata = entityMetadata;
        }

        #endregion Public Constructors

        #region Public Methods

        public override void SetSelected(bool value)
        {
            var wasSelected = IsSelected;
            base.SetSelected(value);
            if (value != wasSelected && !value)
            {
                Attributes?.Where(a => a.IsSelected).ToList().ForEach(a => a.SetSelected(false));
                Relationships?.Where(r => r.IsSelected).ToList().ForEach(r => r.SetSelected(false));
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

        public string GetNameTechnical(NameType nametype, Settings settings)
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
            if (nametype != NameType.DisplayName)
            {
                if (settings.DoStripPrefix && !string.IsNullOrEmpty(settings.StripPrefix))
                {
                    foreach (var prefix in settings.StripPrefix.Split(',').Select(p => p.Trim()).Where(p => !string.IsNullOrEmpty(p)))
                    {
                        if (name.ToLowerInvariant().StartsWith(prefix))
                        {
                            name = name.Substring(prefix.Length);
                        }
                    }
                }
                if (settings.ConstantCamelCased)
                {
                    name = name.CamelCaseIt(settings);
                }
            }
            return name;
        }

        #endregion Public Methods
    }
}