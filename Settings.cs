using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool OptionsExpanded { get; set; } = true;
        public bool EntityFilterExpanded { get; set; } = true;
        public bool AttributeFilterExpanded { get; set; } = true;
        public string OutputFolder { get; set; }
        public string NameSpace { get; set; }
        public bool UseCommonFile { get; set; }
        public string CommonFile { get; set; }
        public bool UseCommonFileDisplay { get; set; }
        public bool UseConstNameDisplay { get; set; }
        public List<string> Selection { get; set; }
        public EntityFilter EntityFilter { get; set; }
        public AttributeFilter AttributeFilter { get; set; }
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
        public bool CustomAll { get; set; } = true;
        public bool CustomFalse { get; set; }
        public bool CustomTrue { get; set; }
        public bool ManagedAll { get; set; } = true;
        public bool ManagedTrue { get; set; }
        public bool ManagedFalse { get; set; }
        public bool PrimaryKey { get; set; }
        public bool PrimaryAttribute { get; set; }
    }
}