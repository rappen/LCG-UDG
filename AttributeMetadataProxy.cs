using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
        public string DisplayName { get => Metadata?.DisplayName?.UserLocalizedLabel?.Label ?? Metadata?.LogicalName; }

        [DisplayName("Logical Name")]
        public string LogicalName { get => Metadata?.LogicalName; }

        public AttributeTypeCode? Type { get => Metadata?.AttributeType; }
        internal string AttributeDescription
        {
            get
            {
                var properties = new Dictionary<string, object>();
                // General properties
                properties.Add("Type", Type);
                properties.Add("RequiredLevel", Metadata?.RequiredLevel?.Value);
                // String properties
                properties.Add("MaxLength:string", (Metadata as StringAttributeMetadata)?.MaxLength);
                properties.Add("Format:string", (Metadata as StringAttributeMetadata)?.Format);
                properties.Add("AutoNumberFormat:string", (Metadata as StringAttributeMetadata)?.AutoNumberFormat);
                // Memo properties
                properties.Add("MaxLength::memo", (Metadata as MemoAttributeMetadata)?.MaxLength);
                // Integer properties
                properties.Add("MinValue:integer", (Metadata as IntegerAttributeMetadata)?.MinValue);
                properties.Add("MaxValue:integer", (Metadata as IntegerAttributeMetadata)?.MaxValue);
                // BigInt properties
                properties.Add("MinValue:bigint", (Metadata as BigIntAttributeMetadata)?.MinValue);
                properties.Add("MaxValue:bigint", (Metadata as BigIntAttributeMetadata)?.MaxValue);
                // Decimal properties
                properties.Add("MinValue:decimal", (Metadata as DecimalAttributeMetadata)?.MinValue);
                properties.Add("MaxValue:decimal", (Metadata as DecimalAttributeMetadata)?.MaxValue);
                properties.Add("Precision:decimal", (Metadata as DecimalAttributeMetadata)?.Precision);
                // Double properties
                properties.Add("MinValue:double", (Metadata as DoubleAttributeMetadata)?.MinValue);
                properties.Add("MaxValue:double", (Metadata as DoubleAttributeMetadata)?.MaxValue);
                properties.Add("Precision:double", (Metadata as DoubleAttributeMetadata)?.Precision);
                // Money properties
                properties.Add("MinValue:money", (Metadata as MoneyAttributeMetadata)?.MinValue);
                properties.Add("MaxValue:money", (Metadata as MoneyAttributeMetadata)?.MaxValue);
                properties.Add("Precision:money", (Metadata as MoneyAttributeMetadata)?.Precision);
                properties.Add("CalculationOf:money", (Metadata as MoneyAttributeMetadata)?.CalculationOf);
                // Enum general properties
                properties.Add("DisplayName:enum", (Metadata as EnumAttributeMetadata)?.OptionSet?.DisplayName?.UserLocalizedLabel?.Label);
                properties.Add("OptionSetType:enum", (Metadata as EnumAttributeMetadata)?.OptionSet?.OptionSetType);
                // Picklist properties
                properties.Add("DefaultFormValue:picklist", (Metadata as PicklistAttributeMetadata)?.DefaultFormValue);
                // Boolean properties
                properties.Add("True:bool", (Metadata as BooleanAttributeMetadata)?.OptionSet?.TrueOption?.Value);
                properties.Add("False:bool", (Metadata as BooleanAttributeMetadata)?.OptionSet?.FalseOption?.Value);
                properties.Add("DefaultValue:bool", (Metadata as BooleanAttributeMetadata)?.DefaultValue);
                // Lookup properties
                properties.Add("Targets:bool", string.Join(",", (Metadata as LookupAttributeMetadata)?.Targets ?? new string[0]));
                // DateTime properties
                properties.Add("Format:datetime", (Metadata as DateTimeAttributeMetadata)?.Format);
                properties.Add("DateTimeBehavior:datetime", (Metadata as DateTimeAttributeMetadata)?.DateTimeBehavior?.Value);

                return string.Join(", ", properties
                    .Where(p => p.Value != null && !string.IsNullOrEmpty(p.Value.ToString()))
                    .Select(p => p.Key.Split(':')[0] + ": " + p.Value));
            }
        }

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

        public string GetNameTechnical(Settings settings)
        {
            var name = string.Empty;
            switch (settings.ConstantName)
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
            if (settings.ConstantName != NameType.DisplayName &&
                settings.DoStripPrefix && !string.IsNullOrEmpty(settings.StripPrefix) &&
                name.ToLowerInvariant().StartsWith(settings.StripPrefix))
            {
                name = name.Substring(settings.StripPrefix.Length);
            }
            return name;
        }

        #endregion Public Methods
    }
}