namespace Rappen.XTB.LCG
{
    public class CommonSettings
    {
        public bool? UseLog { get; set; } = null;
        public string Version { get; set; }

        public string EntityPrefix { get; set; } = string.Empty;
        public string EntitySuffix { get; set; } = string.Empty;
        public string AttributePrefix { get; set; } = string.Empty;
        public string AttributeSuffix { get; set; } = string.Empty;
        public string OptionSetEnumPrefix { get; set; } = string.Empty;
        public string OptionSetEnumSuffix { get; set; } = "_OptionSet";
        public bool HeaderTimestamp { get; set; } = true;
        public bool HeaderLocalPath { get; set; } = true;
    }
}
