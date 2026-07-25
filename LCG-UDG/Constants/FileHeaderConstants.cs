namespace Rappen.XTB.LCG
{
    /// <summary>
    /// Constants used for file header generation and template placeholders
    /// </summary>
    public static class FileHeaderConstants
    {
        /// <summary>
        /// Template placeholder for tool name
        /// </summary>
        public const string ToolName = "{toolname}";

        /// <summary>
        /// Template placeholder for version
        /// </summary>
        public const string Version = "{version}";

        /// <summary>
        /// Template placeholder for organization URL
        /// </summary>
        public const string Organization = "{organization}";

        /// <summary>
        /// Template placeholder for filename
        /// </summary>
        public const string Filename = "{filename}";

        /// <summary>
        /// Template placeholder for creation date
        /// </summary>
        public const string CreateDate = "{createdate}";

        /// <summary>
        /// Template placeholder for legend
        /// </summary>
        public const string Legend = "{legend}";

        /// <summary>
        /// Template placeholder for namespace
        /// </summary>
        public const string Namespace = "{namespace}";

        /// <summary>
        /// Template placeholder for theme
        /// </summary>
        public const string Theme = "{theme}";

        /// <summary>
        /// Template placeholder for padding size
        /// </summary>
        public const string PaddingSize = "{paddingsize}";

        /// <summary>
        /// Template placeholder for data content
        /// </summary>
        public const string Data = "{data}";

        /// <summary>
        /// Label used for the "Created" line in file headers
        /// </summary>
        public const string CreatedLabel = "Created";

        /// <summary>
        /// Label used for the "Filename" line in file headers
        /// </summary>
        public const string FilenameLabel = "Filename";

        /// <summary>
        /// Double line ending used in file headers
        /// </summary>
        public const string LineEnding = "\r\n\r\n";

        /// <summary>
        /// Single line ending used in file headers
        /// </summary>
        public const string SingleLineEnding = "\r\n";
    }
}
