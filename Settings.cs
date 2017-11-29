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
        public bool DoStripPrefix { get; set; }
        public string StripPrefix { get; set; }
        public List<string> Selection { get; set; } = new List<string>();
        public bool OptionSets { get; set; }
        public bool GlobalOptionSets { get; set; }
        public EntityFilter EntityFilter { get; set; } = new EntityFilter();
        public AttributeFilter AttributeFilter { get; set; } = new AttributeFilter();
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
    }

    public enum NameType
    {
        DisplayName = 0,
        SchemaName = 1,
        LogicalName = 2
    }
}