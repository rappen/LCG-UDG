using System.Collections.Generic;

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
        public bool EntityFilterExpanded { get; set; } = true;
        public bool AttributeFilterExpanded { get; set; } = true;
        public FileSettings FileSettings { get; set; } = new FileSettings();
        public GenerationSettings GenerationSettings { get; set; } = new GenerationSettings();
        public EntityFilter EntityFilter { get; set; } = new EntityFilter();
        public AttributeFilter AttributeFilter { get; set; } = new AttributeFilter();
        public List<string> Selection { get; set; } = new List<string>();

        internal CommonSettings commonsettings;

        #region Shortcuts
        internal string OutputFolder => FileSettings.OutputFolder;
        internal string NameSpace => FileSettings.NameSpace;
        internal bool UseCommonFile => FileSettings.UseCommonFile;
        internal string CommonFile => FileSettings.CommonFile;
        internal NameType FileName => FileSettings.FileName;
        internal CommonAttributesType CommonAttributes => FileSettings.CommonAttributes;
        internal NameType ConstantName => GenerationSettings.ConstantName;
        internal bool ConstantCamelCased => GenerationSettings.ConstantCamelCased;
        internal bool DoStripPrefix => GenerationSettings.DoStripPrefix;
        internal string StripPrefix => GenerationSettings.StripPrefix;
        internal bool XmlProperties => GenerationSettings.XmlProperties;
        internal bool XmlDescription => GenerationSettings.XmlDescription;
        internal bool Regions => GenerationSettings.Regions;
        internal bool RelationShips => GenerationSettings.RelationShips;
        internal bool OptionSets => GenerationSettings.OptionSets;
        internal bool GlobalOptionSets => GenerationSettings.GlobalOptionSets;
        #endregion Shortcuts

        public IConstantFileWriter GetWriter(string orgUrl)
        {
            return UseCommonFile
                ? (IConstantFileWriter)new CommonFileWriter(orgUrl)
                : new SeparateFileWriter(orgUrl);
        }

        public void InitalizeCommonSettings(bool isUML)
        {
            commonsettings = new CommonSettings(isUML);
        }
    }

    public class FileSettings
    {
        public string OutputFolder { get; set; }
        public string NameSpace { get; set; }
        public bool UseCommonFile { get; set; }
        public string CommonFile { get; set; }
        public NameType FileName { get; set; } = NameType.DisplayName;
        public CommonAttributesType CommonAttributes { get; set; } = CommonAttributesType.None;
    }

    public class GenerationSettings
    {
        public NameType ConstantName { get; set; } = NameType.DisplayName;
        public bool ConstantCamelCased { get; set; }
        public bool DoStripPrefix { get; set; }
        public string StripPrefix { get; set; }
        public AttributeSortMode AttributeSortMode { get; set; } = AttributeSortMode.None;
        public bool XmlProperties { get; set; } = true;
        public bool XmlDescription { get; set; }
        public bool Regions { get; set; } = true;
        public bool RelationShips { get; set; } = true;
        public bool OptionSets { get; set; } = true;
        public bool GlobalOptionSets { get; set; }

        internal void SetDefaults(bool isUML)
        {
            AttributeSortMode = isUML ? AttributeSortMode.AlphabeticalAndRequired : AttributeSortMode.None;
        }

    }

    public class EntityFilter
    {
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
}