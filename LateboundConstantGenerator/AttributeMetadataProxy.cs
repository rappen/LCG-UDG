using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Rappen.XTB.LCG
{
    public class AttributeMetadataProxy : MetadataProxy
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
        public bool Selected => IsSelected;

        [DisplayName("Name")]
        public string DisplayName => Metadata?.DisplayName?.UserLocalizedLabel?.Label ?? Metadata?.LogicalName;

        [DisplayName("Logical Name")]
        public string LogicalName => Metadata?.LogicalName;

        public AttributeTypeCode? Type => Metadata?.AttributeType;

        internal string AttributeProperties
        {
            get
            {
                var properties = new Dictionary<string, object>
                {
                    // General properties
                    {"Type", Type},
                    {"RequiredLevel", Metadata?.RequiredLevel?.Value},
                    // String properties
                    {"MaxLength:string", (Metadata as StringAttributeMetadata)?.MaxLength},
                    {"Format:string", (Metadata as StringAttributeMetadata)?.Format},
                    {"AutoNumberFormat:string", (Metadata as StringAttributeMetadata)?.AutoNumberFormat},
                    // Memo properties
                    {"MaxLength::memo", (Metadata as MemoAttributeMetadata)?.MaxLength},
                    // Integer properties
                    {"MinValue:integer", (Metadata as IntegerAttributeMetadata)?.MinValue},
                    {"MaxValue:integer", (Metadata as IntegerAttributeMetadata)?.MaxValue},
                    // BigInt properties
                    {"MinValue:bigint", (Metadata as BigIntAttributeMetadata)?.MinValue},
                    {"MaxValue:bigint", (Metadata as BigIntAttributeMetadata)?.MaxValue},
                    // Decimal properties
                    {"MinValue:decimal", (Metadata as DecimalAttributeMetadata)?.MinValue},
                    {"MaxValue:decimal", (Metadata as DecimalAttributeMetadata)?.MaxValue},
                    {"Precision:decimal", (Metadata as DecimalAttributeMetadata)?.Precision},
                    // Double properties
                    {"MinValue:double", (Metadata as DoubleAttributeMetadata)?.MinValue},
                    {"MaxValue:double", (Metadata as DoubleAttributeMetadata)?.MaxValue},
                    {"Precision:double", (Metadata as DoubleAttributeMetadata)?.Precision},
                    // Money properties
                    {"MinValue:money", (Metadata as MoneyAttributeMetadata)?.MinValue},
                    {"MaxValue:money", (Metadata as MoneyAttributeMetadata)?.MaxValue},
                    {"Precision:money", (Metadata as MoneyAttributeMetadata)?.Precision},
                    {"CalculationOf:money", (Metadata as MoneyAttributeMetadata)?.CalculationOf},
                    // Enum general properties
                    {"DisplayName:enum", (Metadata as EnumAttributeMetadata)?.OptionSet?.DisplayName?.UserLocalizedLabel?.Label},
                    {"OptionSetType:enum", (Metadata as EnumAttributeMetadata)?.OptionSet?.OptionSetType},
                    // Picklist properties
                    {"DefaultFormValue:picklist", (Metadata as PicklistAttributeMetadata)?.DefaultFormValue},
                    // Boolean properties
                    {"True:bool", (Metadata as BooleanAttributeMetadata)?.OptionSet?.TrueOption?.Value},
                    {"False:bool", (Metadata as BooleanAttributeMetadata)?.OptionSet?.FalseOption?.Value},
                    {"DefaultValue:bool", (Metadata as BooleanAttributeMetadata)?.DefaultValue},
                    // Lookup properties
                    {"Targets:bool", string.Join(",", (Metadata as LookupAttributeMetadata)?.Targets ?? new string[0])},
                    // DateTime properties
                    {"Format:datetime", (Metadata as DateTimeAttributeMetadata)?.Format},
                    {"DateTimeBehavior:datetime", (Metadata as DateTimeAttributeMetadata)?.DateTimeBehavior?.Value}
                };

                return string.Join(", ", properties
                    .Where(p => !string.IsNullOrEmpty(p.Value?.ToString()))
                    .Select(p => p.Key.Split(':')[0] + ": " + p.Value));
            }
        }

        internal string Description => Metadata?.Description?.UserLocalizedLabel?.Label;

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
                    name = settings.GetNonDisplayName(Metadata?.LogicalName);
                    break;
                case NameType.SchemaName:
                    name = settings.GetNonDisplayName(Metadata?.SchemaName);
                    break;
            }
            return name;
        }

        #endregion Public Methods
    }
}