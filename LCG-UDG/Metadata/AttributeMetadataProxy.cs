using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Rappen.XTB.LCG
{
    public class AttributeMetadataProxy : MetadataProxy, IComparable
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
        public string DisplayName => (Required ? "* " : "") + Metadata?.DisplayName?.UserLocalizedLabel?.Label ?? Metadata?.LogicalName;

        [DisplayName("Logical Name")]
        public string LogicalName => Metadata?.LogicalName;

        [DisplayName("Type")]
        public AttributeTypeCode? Type => Metadata?.AttributeType;

        [DisplayName("Values")]
        public int? Values { get => WithValues; }

        [DisplayName("Uniques")]
        public int? Uniques { get => UniqueValues; }

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

                if (Metadata.IsLogical == true && properties.ContainsKey("Type"))
                {
                    properties["Type"] += " (Logical)";
                }

                return (string.Join(", ", properties
                    .Where(p => !string.IsNullOrEmpty(p.Value?.ToString()))
                    .Select(p => p.Key.Split(':')[0] + ": " + p.Value)) +
                    "\n" + AdditionalProperties).Trim();
            }
        }

        internal string AttributeTypeDetails
        {
            get
            {
                string lookupdetails(LookupAttributeMetadata lookup)
                {
                    if (lookup.Targets == null && lookup.Targets.Count() == 0)
                    {
                        return "*NONE*";
                    }
                    var lookupstring = string.Join(", ", lookup.Targets);
                    if (lookup.Targets.Count() > 1)
                    {
                        return "[" + lookupstring + "]";
                    }
                    return lookupstring;
                }
                string decimaldetails(DecimalAttributeMetadata decimalmeta)
                {
                    var decimalstring = decimalmeta.MinValue <= (decimal)DecimalAttributeMetadata.MinSupportedValue ? "Min" : decimalmeta.MinValue.ToString();
                    decimalstring += "/";
                    decimalstring += decimalmeta.MaxValue >= (decimal)DecimalAttributeMetadata.MaxSupportedValue ? "Max" : decimalmeta.MaxValue.ToString();
                    decimalstring += " Prc:" + decimalmeta.Precision;
                    return decimalstring;
                }
                string doubledetails(DoubleAttributeMetadata doublemeta)
                {
                    var decimalstring = doublemeta.MinValue <= DoubleAttributeMetadata.MinSupportedValue ? "Min" : doublemeta.MinValue.ToString();
                    decimalstring += "/";
                    decimalstring += doublemeta.MaxValue >= DoubleAttributeMetadata.MaxSupportedValue ? "Max" : doublemeta.MaxValue.ToString();
                    decimalstring += " Prc:" + doublemeta.Precision;
                    return decimalstring;
                }
                string integerdetails(IntegerAttributeMetadata integermeta)
                {
                    if (integermeta.Format == IntegerFormat.None)
                    {
                        return
                            (integermeta.MinValue <= IntegerAttributeMetadata.MinSupportedValue ? "Min" : integermeta.MinValue.ToString()) +
                            "/" +
                            (integermeta.MaxValue >= IntegerAttributeMetadata.MaxSupportedValue ? "Max" : integermeta.MaxValue.ToString());
                    }
                    return integermeta.Format.ToString();
                }
                string moneydetails(MoneyAttributeMetadata money)
                {
                    if (money == null)
                    {
                        return string.Empty;
                    }
                    var moneystring = money.MinValue <= MoneyAttributeMetadata.MinSupportedValue ? "Min" : money.MinValue.ToString();
                    moneystring += "/";
                    moneystring += money.MaxValue >= MoneyAttributeMetadata.MaxSupportedValue ? "Max" : money.MaxValue.ToString();
                    moneystring += money.IsBaseCurrency == true ? " IsBase" : string.Empty;
                    moneystring += " Prc:" + money.Precision;
                    moneystring += !string.IsNullOrWhiteSpace(money.CalculationOf) ? " Clc:" + money.CalculationOf : string.Empty;
                    return moneystring;
                }
                var result = string.Empty;
                switch (Type)
                {
                    case AttributeTypeCode.Customer:
                    case AttributeTypeCode.Lookup:
                    case AttributeTypeCode.Owner:
                        result = lookupdetails(Metadata as LookupAttributeMetadata);
                        break;

                    case AttributeTypeCode.DateTime:
                        result = Metadata is DateTimeAttributeMetadata dateTime ? dateTime.DateTimeBehavior.Value : string.Empty;
                        break;

                    case AttributeTypeCode.Decimal:
                        result = decimaldetails(Metadata as DecimalAttributeMetadata);
                        break;

                    case AttributeTypeCode.Double:
                        result = doubledetails(Metadata as DoubleAttributeMetadata);
                        break;

                    case AttributeTypeCode.Integer:
                        result = integerdetails(Metadata as IntegerAttributeMetadata);
                        break;

                    case AttributeTypeCode.Money:
                        result = moneydetails(Metadata as MoneyAttributeMetadata);
                        break;

                    case AttributeTypeCode.String:
                        result = Metadata is StringAttributeMetadata str ? $"({str.MaxLength}) {str.Format.ToString().Replace("Text", "")}".Trim() : string.Empty;
                        break;
                }
                if (!string.IsNullOrWhiteSpace(result) && result[0] != '(')
                {
                    result = " " + result;
                }
                return result;
            }
        }

        internal string Description => Metadata?.Description?.UserLocalizedLabel?.Label;

        internal bool PrimaryId => Metadata?.IsPrimaryId.Value == true && Metadata?.IsLogical.Value == false;
        internal bool PrimaryName => Metadata?.IsPrimaryName.Value == true;

        internal bool Required =>
            (Metadata?.RequiredLevel?.Value == AttributeRequiredLevel.SystemRequired
             || Metadata?.RequiredLevel?.Value == AttributeRequiredLevel.ApplicationRequired)
            && string.IsNullOrEmpty(Metadata?.AttributeOf);

        internal EntityMetadataProxy Entity => entity;

        internal string AdditionalProperties;
        internal int? WithValues;
        internal int? UnDefaultValues;
        internal int? UniqueValues;

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

        public int CompareTo(object y)
        {
            if (!(y is AttributeMetadataProxy yattr)) return -1;
            if (PrimaryId && !yattr.PrimaryId) return -1;
            if (yattr.PrimaryId && !PrimaryId) return 1;
            if (PrimaryName && !yattr.PrimaryName) return -1;
            if (yattr.PrimaryName && !PrimaryName) return 1;
            if (Required && !yattr.Required) return -1;
            if (yattr.Required && !Required) return 1;
            return Metadata?.ColumnNumber ?? 0 - yattr.Metadata?.ColumnNumber ?? 0;
        }

        #endregion Public Methods
    }
}