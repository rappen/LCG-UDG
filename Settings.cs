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
        public bool EntitiesCustomAll { get; set; } = true;
        public bool EntitiesCustomFalse { get; set; }
        public bool EntitiesCustomTrue { get; set; }
        public bool EntitiesManagedAll { get; set; } = true;
        public bool EntitiesManagedTrue { get; set; }
        public bool EntitiesManagedFalse { get; set; }
        public bool EntitiesIntersect { get; set; }
        public bool AttributesCustomAll { get; set; } = true;
        public bool AttributesCustomFalse { get; set; }
        public bool AttributesCustomTrue { get; set; }
        public bool AttributesManagedAll { get; set; } = true;
        public bool AttributesManagedTrue { get; set; }
        public bool AttributesManagedFalse { get; set; }
        public bool OptionsExpanded { get; set; } = true;
        public string OutputFolder { get; set; }
    }
}