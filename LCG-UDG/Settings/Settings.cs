using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

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
        internal static int FilterCollapseHeight = 20;

        public static bool IsUML(TemplateFormat templateFormat) => templateFormat == TemplateFormat.PlantUML || templateFormat == TemplateFormat.DBML;

        public static string FileType(TemplateFormat format) => format == TemplateFormat.PlantUML ? "PlantUML" : format == TemplateFormat.DBML ? "DBML" : "C#";

        public static string FileSuffix(TemplateFormat format) => format == TemplateFormat.PlantUML ? ".plantuml" : format == TemplateFormat.DBML ? ".dbml" : ".cs";

        public static string FileFilter(TemplateFormat format) => $"{FileType(format)} file (*{FileSuffix(format)})|*{FileSuffix(format)}";

        public Settings() : this(TemplateFormat.Constants)
        { }

        public Settings(bool uml) : this(uml ? TemplateFormat.PlantUML : TemplateFormat.Constants)
        { }

        public Settings(TemplateFormat templateFormat)
        {
            TemplateFormat = templateFormat;
            var isUML = templateFormat == TemplateFormat.PlantUML || templateFormat == TemplateFormat.DBML;
            if (!SettingsManager.Instance.TryLoad(GetType(), out TemplateSettings, LCG.SettingsFileName(isUML, "[Common]")))
            {
                TemplateSettings = new TemplateSettings(templateFormat);
            }
            TemplateSettings.TemplateFormat = TemplateFormat;
        }

        public TemplateFormat TemplateFormat
        {
            get => templateFormat;
            set
            {
                var isuml = IsUML(value);
                if (isuml != IsUML(templateFormat) || TemplateSettings == null)
                {
                    TemplateSettings = new TemplateSettings(value);
                }
                templateFormat = value;
                TemplateSettings.TemplateFormat = templateFormat;
            }
        }

        public string Version { get; set; }
        public string OutputFolder { get; set; }
        public string NameSpace { get; set; }
        public string Theme { get; set; }
        public bool ColorByType { get; set; } = true;
        public bool UseCommonFile { get => useCommonFile || templateFormat != TemplateFormat.Constants; set => useCommonFile = value; }
        public bool SaveConfigurationInCommonFile { get; set; } = true;
        public string CommonFile { get; set; }
        public NameType FileName { get => templateFormat == TemplateFormat.Constants ? fileName : NameType.DisplayName; set => fileName = value; }
        public NameType ConstantName { get; set; } = NameType.DisplayName;
        public bool ConstantCamelCased { get; set; }
        public bool DoStripPrefix { get; set; }
        public string StripPrefix { get; set; }
        public bool XmlProperties { get => xmlProperties && templateFormat == TemplateFormat.Constants; set => xmlProperties = value; }
        public bool XmlDescription { get => xmlDescription && templateFormat == TemplateFormat.Constants; set => xmlDescription = value; }
        public bool TypeDetails { get => typeDetails && templateFormat != TemplateFormat.Constants; set => typeDetails = value; }
        public bool Regions { get => regions && templateFormat == TemplateFormat.Constants; set => regions = value; }
        public bool RelationShips { get => relationShips || templateFormat != TemplateFormat.Constants; set => relationShips = value; }
        public bool RelationshipLabels { get => relationshipLabels && templateFormat != TemplateFormat.Constants; set => relationshipLabels = value; }
        public bool OptionSets { get => optionSets && templateFormat == TemplateFormat.Constants; set => optionSets = value; }
        public bool GlobalOptionSets { get => globalOptionSets && templateFormat == TemplateFormat.Constants; set => globalOptionSets = value; }
        public bool Legend { get => legend && templateFormat != TemplateFormat.Constants; set => legend = value; }
        public int TableSize { get; set; } = 1;
        public int RelationShipSize { get; set; } = 2;
        public CommonAttributesType CommonAttributes { get => templateFormat == TemplateFormat.Constants ? commonAttributes : CommonAttributesType.None; set => commonAttributes = value; }
        public AttributeSortMode AttributeSortMode { get => templateFormat == TemplateFormat.Constants ? AttributeSortMode.None : attributeSortMode; set => attributeSortMode = value; }
        public List<string> Selection { get; set; } = new List<string>();
        public List<EntityGroup> Groups { get; set; } = new List<EntityGroup>();
        public List<SelectedEntity> SelectedEntities { get; set; }
        public EntityFilter EntityFilter { get; set; } = new EntityFilter();
        public AttributeFilter AttributeFilter { get; set; } = new AttributeFilter();
        public RelationshipFilter RelationshipFilter { get; set; } = new RelationshipFilter();

        internal TemplateSettings TemplateSettings;
        internal string CommonFilePath => Path.Combine(OutputFolder, CommonFile + FileSuffix(TemplateFormat));

        internal bool ValidateIdentifiers => templateFormat == TemplateFormat.Constants;

        private TemplateFormat templateFormat;
        private bool useCommonFile;
        private NameType fileName = NameType.DisplayName;
        private CommonAttributesType commonAttributes = CommonAttributesType.None;
        private bool xmlProperties = true;
        private bool xmlDescription;
        private bool regions = true;
        private bool relationShips = true;
        private bool optionSets = true;
        private bool globalOptionSets;
        private bool legend;
        private AttributeSortMode attributeSortMode = AttributeSortMode.AlphabeticalAndRequired;
        private bool relationshipLabels = false;
        private bool typeDetails;

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
            Theme = source.Theme;
            ColorByType = source.ColorByType;
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
            Groups = source.Groups;
            SelectedEntities = source.SelectedEntities;
        }

        internal static Settings GetBlankSettings(TemplateFormat templateFormat)
        {
            var result = new Settings(templateFormat);
            result.TemplateFormat = templateFormat;
            result.OutputFolder = null;
            result.NameSpace = null;
            result.Theme = null;
            result.CommonFile = null;
            result.StripPrefix = null;
            result.Selection = null;
            result.SelectedEntities = null;
            result.EntityFilter = null;
            result.AttributeFilter = null;
            result.RelationshipFilter = null;
            return result;
        }

        internal string GetTheme()
        {
            if (Theme.ToLowerInvariant().StartsWith("http"))
            {
                return $"!include {Theme}";
            }
            if (!string.IsNullOrWhiteSpace(Theme))
            {
                return $"!theme {Theme}";
            }
            return "";
        }
    }

    public class EntityFilter
    {
        public bool Expanded { get; set; } = false;
        public CheckState Custom { get; set; } = CheckState.Checked;
        public CheckState Managed { get; set; } = CheckState.Checked;
        public bool ExcludeIntersect { get; set; }
        internal CheckState Selected { get; set; }
        public CheckState Records { get; set; } = CheckState.Checked;
        public bool Uncountable { get; set; }
    }

    public class AttributeFilter
    {
        public bool Expanded { get; set; } = false;
        public bool CheckAll { get; set; }
        public CheckState Custom { get; set; } = CheckState.Checked;
        public CheckState Managed { get; set; } = CheckState.Checked;
        public CheckState PrimaryKeyName { get; set; } = CheckState.Checked;
        public CheckState Required { get; set; } = CheckState.Checked;
        public CheckState Logical { get; set; } = CheckState.Unchecked;
        public CheckState Internal { get; set; } = CheckState.Unchecked;
        public bool ExcludeCreMod { get; set; } = true;
        public bool ExcludeOwner { get; set; } = true;
        internal bool AreUsed { get; set; } = false;
        internal bool UniqueValues { get; set; } = false;
    }

    public class RelationshipFilter
    {
        public bool Expanded { get; set; } = false;
        public bool CheckAll { get; set; }
        public CheckState Custom { get; set; } = CheckState.Checked;
        public CheckState Managed { get; set; } = CheckState.Checked;
        public bool Type1N { get; set; } = false;
        public bool TypeN1 { get; set; } = true;
        public bool TypeNN { get; set; } = true;
        public bool Owner { get; set; } = true;
        public bool Orphans { get; set; } = true;
        public bool Regarding { get; set; } = true;
        public bool ExcludeOrphans { get; set; }
        public bool ExcludeOwner { get; set; } = true;
        public bool ExcludeRegarding { get; set; } = true;
        public bool ExcludeCreMod { get; set; } = true;
        public bool ExcludeDupRecords { get; set; } = true;
        public bool RequireLookups { get; set; }
    }

    public enum TemplateFormat
    {
        Constants,
        PlantUML,
        DBML
    }

    public enum NameType
    {
        DisplayName = 0,
        SchemaName = 1,
        LogicalName = 2,
        DisplayNameAndLogicalName = 3
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
        public string Group { get; set; }
        public List<string> Attributes { get; set; }
        public List<string> Relationships { get; set; }
    }
}