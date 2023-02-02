using System.Collections.Generic;
using System.IO;

namespace Rappen.XTB.LCG
{
    /// <summary>
    /// This class can help you to store settings for your plugin
    /// </summary>
    /// <remarks>
    /// This class must be XML serializable
    /// </remarks>
    public class Settings
    {
        public Settings() : this(false)
        {
        }

        public Settings(bool isUML)
        {
            commonsettings = new CommonSettings(isUML);
            AttributeSortMode = isUML ? AttributeSortMode.AlphabeticalAndRequired : AttributeSortMode.None;
            Legend = isUML;
            SetFixedValues(isUML);
        }

        internal void SetFixedValues(bool isUML)
        {
            if (isUML)
            {
                UseCommonFile = true;
                FileName = NameType.DisplayName;
                CommonAttributes = CommonAttributesType.None;
                XmlProperties = false;
                XmlDescription = false;
                Regions = false;
                RelationShips = true;
                OptionSets = false;
                GlobalOptionSets = false;
                ValidateIdentifiers = false;
            }
            else
            {
                RelationshipLabels = false;
                AttributeSortMode = AttributeSortMode.None;
                TypeDetails = false;
                Legend = false;
            }
            commonsettings?.SetFixedValues(isUML);
        }

        public string Version { get; set; }
        public string OutputFolder { get; set; }
        public string NameSpace { get; set; }
        public bool UseCommonFile { get; set; }
        public bool SaveConfigurationInCommonFile { get; set; } = true;
        public string CommonFile { get; set; }
        public NameType FileName { get; set; } = NameType.DisplayName;
        public NameType ConstantName { get; set; } = NameType.DisplayName;
        public bool ConstantCamelCased { get; set; }
        public bool DoStripPrefix { get; set; }
        public string StripPrefix { get; set; }
        public bool XmlProperties { get; set; } = true;
        public bool XmlDescription { get; set; }
        public bool TypeDetails { get; set; }
        public bool Regions { get; set; } = true;
        public bool RelationShips { get; set; } = true;
        public bool RelationshipLabels { get; set; } = false;
        public bool OptionSets { get; set; } = true;
        public bool GlobalOptionSets { get; set; }
        public bool Legend { get; set; }
        public CommonAttributesType CommonAttributes { get; set; } = CommonAttributesType.None;
        public AttributeSortMode AttributeSortMode { get; set; } = AttributeSortMode.None;
        public List<string> Selection { get; set; } = new List<string>();
        public List<SelectedEntity> SelectedEntities { get; set; }
        public EntityFilter EntityFilter { get; set; } = new EntityFilter();
        public AttributeFilter AttributeFilter { get; set; } = new AttributeFilter();
        public RelationshipFilter RelationshipFilter { get; set; } = new RelationshipFilter();

        internal CommonSettings commonsettings;
        internal string CommonFilePath => Path.Combine(OutputFolder, CommonFile + commonsettings.FileSuffix);
        internal bool ValidateIdentifiers = true;

        public IConstantFileWriter GetWriter(string orgUrl)
        {
            return UseCommonFile
                ? (IConstantFileWriter)new CommonFileWriter(orgUrl)
                : new SeparateFileWriter(orgUrl);
        }

        internal void CopyInlineConfiguration(Settings source)
        {
            Version = source.Version;
            NameSpace = source.NameSpace;
            UseCommonFile = source.UseCommonFile;
            FileName = source.FileName;
            ConstantName = source.ConstantName;
            ConstantCamelCased = source.ConstantCamelCased;
            DoStripPrefix = source.DoStripPrefix;
            StripPrefix = source.StripPrefix;
            XmlProperties = source.XmlProperties;
            XmlDescription = source.XmlDescription;
            Regions = source.Regions;
            RelationShips = source.RelationShips;
            RelationshipLabels = source.RelationshipLabels;
            OptionSets = source.OptionSets;
            GlobalOptionSets = source.GlobalOptionSets;
            Legend = source.Legend;
            CommonAttributes = source.CommonAttributes;
            AttributeSortMode = source.AttributeSortMode;
            SelectedEntities = source.SelectedEntities;
        }

        internal static Settings GetBlankSettings()
        {
            var result = new Settings();
            result.OutputFolder = null;
            result.NameSpace = null;
            result.CommonFile = null;
            result.StripPrefix = null;
            result.Selection = null;
            result.SelectedEntities = null;
            result.EntityFilter = null;
            result.AttributeFilter = null;
            result.RelationshipFilter = null;
            return result;
        }
    }

    public class EntityFilter
    {
        public bool Expanded { get; set; } = false;
        public bool CustomAll { get; set; } = true;
        public bool CustomFalse { get; set; }
        public bool CustomTrue { get; set; }
        public bool ManagedAll { get; set; } = true;
        public bool ManagedTrue { get; set; }
        public bool ManagedFalse { get; set; }
        public bool Intersect { get; set; }
        public bool SelectedOnly { get; set; }
    }

    public class AttributeFilter
    {
        public bool Expanded { get; set; } = false;
        public bool CheckAll { get; set; }
        public bool CustomAll { get; set; } = true;
        public bool CustomFalse { get; set; }
        public bool CustomTrue { get; set; }
        public bool ManagedAll { get; set; } = true;
        public bool ManagedTrue { get; set; }
        public bool ManagedFalse { get; set; }
        public bool PrimaryKey { get; set; }
        public bool PrimaryAttribute { get; set; }
        public bool Logical { get; set; }
        public bool Internal { get; set; }
        public bool CreMod { get; set; } = true;
        public bool Owner { get; set; } = true;
    }

    public class RelationshipFilter
    {
        public bool Expanded { get; set; } = false;
        public bool CheckAll { get; set; }
        public bool CustomAll { get; set; } = true;
        public bool CustomFalse { get; set; }
        public bool CustomTrue { get; set; }
        public bool ManagedAll { get; set; } = true;
        public bool ManagedTrue { get; set; }
        public bool ManagedFalse { get; set; }
        public bool Type1N { get; set; } = true;
        public bool TypeN1 { get; set; } = true;
        public bool TypeNN { get; set; } = true;
        public bool Orphans { get; set; }
        public bool Owner { get; set; } = true;
        public bool Regarding { get; set; } = true;
        public bool CreMod { get; set; } = true;
        public bool DupRecords { get; set; } = true;
    }

    public enum NameType
    {
        DisplayName = 0,
        SchemaName = 1,
        LogicalName = 2
    }

    public enum CommonAttributesType
    {
        None = 0,
        CommonInAny = 1,
        CommonInAll = 2
    }

    public enum AttributeSortMode
    {
        None = 0,
        Alphabetical = 1,
        AlphabeticalAndRequired = 2
    }

    public class SelectedEntity
    {
        public string Name { get; set; }
        public List<string> Attributes { get; set; }
        public List<string> Relationships { get; set; }
    }
}