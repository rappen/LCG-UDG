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
        public bool FileOptionsExpanded { get; set; } = true;
        public bool ConstantOptionsExpanded { get; set; } = true;
        public bool EntityFilterExpanded { get; set; } = true;
        public bool AttributeFilterExpanded { get; set; } = true;
        public string OutputFolder { get; set; }
        public string NameSpace { get; set; }
        public bool UseCommonFile { get; set; }
        public string CommonFile { get; set; }
        public NameType FileName { get; set; } = NameType.DisplayName;
        public NameType ConstantName { get; set; } = NameType.DisplayName;
        public bool ConstantCamelCased { get; set; }
        public bool DoStripPrefix { get; set; }
        public string StripPrefix { get; set; }
        public bool XmlProperties { get; set; }
        public bool XmlDescription { get; set; }
        public bool Regions { get; set; } = true;
        public bool RelationShips { get; set; }
        public bool OptionSets { get; set; }
        public bool GlobalOptionSets { get; set; }
        public CommonAttributesType CommonAttributes { get; set; } = CommonAttributesType.None;
        public EntityFilter EntityFilter { get; set; } = new EntityFilter();
        public AttributeFilter AttributeFilter { get; set; } = new AttributeFilter();
        public List<string> Selection { get; set; } = new List<string>();
        internal CommonSettings commonsettings;

        public IConstantFileWriter GetWriter(string orgUrl)
        {
            return UseCommonFile
                ? (IConstantFileWriter)new CommonFileWriter(orgUrl)
                : new SeparateFileWriter(orgUrl);
        }

        public void InitalizeCommonSettings()
        {
            commonsettings = new CommonSettings();
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
}