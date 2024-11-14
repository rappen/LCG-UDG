namespace Rappen.XTB.LCG
{
    public class TemplateSettings
    {
        private TemplateFormat templateFormat;

        public TemplateSettings() : this(false)
        {
        }

        public TemplateSettings(bool isUML) : this(isUML ? TemplateFormat.PlantUML : TemplateFormat.Constants)
        { }

        public TemplateSettings(TemplateFormat templateFormat)
        {
            TemplateFormat = templateFormat;
        }

        public TemplateFormat TemplateFormat
        {
            get => templateFormat;
            set
            {
                if (templateFormat == value)
                {
                    return;
                }
                templateFormat = value;
                switch (templateFormat)
                {
                    case TemplateFormat.Constants:
                        Template = new TemplateLCG();
                        break;

                    case TemplateFormat.DBML:
                        Template = new TemplateDBML();
                        AttributeSeparatorAfterPK = string.Empty;

                        break;

                    case TemplateFormat.PlantUML:
                        Template = new TemplatePlantUML();
                        AttributeSeparatorAfterPK = "--";
                        break;
                }
            }
        }

        internal string ToolName => templateFormat == TemplateFormat.PlantUML || templateFormat == TemplateFormat.DBML
            ? LCG.toolnameUDG
            : LCG.toolnameLCG;

        internal string FileType =>
            templateFormat == TemplateFormat.PlantUML ? "PlantUML" :
            templateFormat == TemplateFormat.DBML ? "DBML" : "C#";

        internal string FileSuffix =>
            templateFormat == TemplateFormat.PlantUML ? ".plantuml" :
            templateFormat == TemplateFormat.DBML ? ".dbml" : ".cs";

        internal string InlineConfigBegin =>
            templateFormat == TemplateFormat.PlantUML
            ? @"/'**** LCG-configuration-BEGIN ****"
            : @"/***** LCG-configuration-BEGIN *****";

        internal string InlineConfigEnd =>
            templateFormat == TemplateFormat.PlantUML
            ? @"***** LCG-configuration-END   ****'/"
            : @"***** LCG-configuration-END   *****/";

        internal TemplateBase Template;

        public string EntityPrefix { get; set; } = string.Empty;
        public string EntitySuffix { get; set; } = string.Empty;
        public string AttributePrefix { get; set; } = string.Empty;
        public string AttributeSuffix { get; set; } = string.Empty;
        public string AttributeSeparatorAfterPK { get; set; } = string.Empty;
        public string OneManyRelationshipPrefix { get; set; } = "Rel1M_";
        public string ManyOneRelationshipPrefix { get; set; } = "RelM1_";
        public string ManyManyRelationshipPrefix { get; set; } = "RelMM_";
        public string OptionSetEnumPrefix { get; set; } = string.Empty;
        public string OptionSetEnumSuffix { get; set; } = "_OptionSet";
    }
}

/*

    FileContainer
        FileHeader
        DataContainer
          [Theme]
          [Group]
            EntityContainer
                EntityDetails
                Attributes
                Relationships
                OptionSets
                    OptionSetValues

  */