namespace Rappen.XTB.LCG
{
    public class CommonSettings
    {
        public bool? UseLog { get; set; } = null;
        public string Version { get; set; }

        public string OptionSetEnumSuffix { get; set; } = "_OptionSet";
        public bool HeaderTimestamp { get; set; } = true;
        public bool HeaderLocalPath { get; set; } = true;
    }
}
