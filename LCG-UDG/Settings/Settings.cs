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
        public static bool IsUML(TemplateFormat templateFormat) => templateFormat == TemplateFormat.PlantUML || templateFormat == TemplateFormat.DBML;

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
                if (isuml != IsUML(templateFormat))
                {
                    if (isuml)
                    {
                        TemplateSettings = new TemplateSettings(true);
                        AttributeSortMode = AttributeSortMode.AlphabeticalAndRequired;
                        Legend = true;

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
                        TemplateSettings = new TemplateSettings(false);
                        AttributeSortMode = AttributeSortMode.None;
                        Legend = false;

                        RelationshipLabels = false;
                        AttributeSortMode = AttributeSortMode.None;
                        TypeDetails = false;
                        Legend = false;
                    }
                }
                templateFormat = value;
                if (TemplateSettings == null)
                {
                    TemplateSettings = new TemplateSettings(templateFormat);
                }
                TemplateSettings.TemplateFormat = templateFormat;
            }
        }

        public string Version { get; set; }
        public string OutputFolder { get; set; }
        public string NameSpace { get; set; }
        public string Theme { get; set; }
        public bool ColorByType { get; set; } = true;
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
        public int TableSize { get; set; } = 1;
        public int RelationShipSize { get; set; } = 2;
        public CommonAttributesType CommonAttributes { get; set; } = CommonAttributesType.None;
        public AttributeSortMode AttributeSortMode { get; set; } = AttributeSortMode.None;
        public List<string> Selection { get; set; } = new List<string>();
        public List<EntityGroup> Groups { get; set; } = new List<EntityGroup>();
        public List<SelectedEntity> SelectedEntities { get; set; }
        public EntityFilter EntityFilter { get; set; } = new EntityFilter();
        public AttributeFilter AttributeFilter { get; set; } = new AttributeFilter();
        public RelationshipFilter RelationshipFilter { get; set; } = new RelationshipFilter();

        internal TemplateSettings TemplateSettings;
        internal string CommonFilePath => Path.Combine(OutputFolder, CommonFile + TemplateSettings.FileSuffix);

        internal bool ValidateIdentifiers = true;

        private TemplateFormat templateFormat;

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
        public CheckState Custom { get; set; } = CheckState.Indeterminate;
        public CheckState Managed { get; set; } = CheckState.Indeterminate;
        public bool ExcludeIntersect { get; set; }
        internal CheckState Selected { get; set; }
        public CheckState Records { get; set; } = CheckState.Indeterminate;
        public bool Uncountable { get; set; }
    }

    public class AttributeFilter
    {
        public bool Expanded { get; set; } = false;
        public bool CheckAll { get; set; }
        public CheckState Custom { get; set; } = CheckState.Indeterminate;
        public CheckState Managed { get; set; } = CheckState.Indeterminate;
        public bool PrimaryKey { get; set; }
        public bool PrimaryAttribute { get; set; }
        public bool Required { get; set; }
        public bool ExcludeLogical { get; set; }
        public bool ExcludeInternal { get; set; }
        public bool ExcludeCreMod { get; set; } = true;
        public bool ExcludeOwner { get; set; } = true;
        public bool ExcludeUnrequired { get; set; }
        internal bool AreUsed { get; set; } = false;
        internal bool UniqueValues { get; set; } = false;
    }

    public class RelationshipFilter
    {
        public bool Expanded { get; set; } = false;
        public bool CheckAll { get; set; }
        public CheckState Custom { get; set; } = CheckState.Indeterminate;
        public CheckState Managed { get; set; } = CheckState.Indeterminate;
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
    }

    public enum TemplateFormat
    {
        Constants = 0,
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