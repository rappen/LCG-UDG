namespace Rappen.XTB.LCG
{
    public class CommonSettings
    {
        public CommonSettings() : this(false)
        {
        }

        public CommonSettings(TemplateFormat templateFormat)
        {
            SetFixedValues(templateFormat);
        }

        public CommonSettings(bool isUML)
        {
            var templateFormat = TemplateFormat.Constants;
            Template = new Template(isUML);

            if (isUML)
            {
                templateFormat = TemplateFormat.UML;
                // AttributeSeparatorAfterPK = "--";
            }
            SetFixedValues(templateFormat);
        }

        internal void MigrateFromOldConfig(bool isUML)
        {
            if (CamelCaseWords == null || CamelCaseWords.Length == 0)
            {
                CamelCaseWords = new CommonSettings(isUML).CamelCaseWords;
            }
            if (CamelCaseWordEnds == null || CamelCaseWordEnds.Length == 0)
            {
                CamelCaseWordEnds = new CommonSettings(isUML).CamelCaseWordEnds;
            }
            if (Template.TemplateVersion != new Template(isUML).TemplateVersion)
            {
                //MessageBox.Show("Template has been updated.\nAny customizations will need to be recreated.", "Template", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Template = new Template(isUML);
            }
        }

        internal void SetFixedValues(TemplateFormat templateFormat)
        {
            switch (templateFormat)
            {
                case TemplateFormat.Constants:
                    Template = new Template(false);
                    break;

                case TemplateFormat.DBML:
                    Template = new TemplateDBML();
                    ToolName = LCG.toolnameUDG;
                    FileType = TemplateBase.OutputFormatDBML;
                    FileSuffix = ".dbml";

                    AttributeSeparatorAfterPK = string.Empty;

                    break;

                case TemplateFormat.UML:
                    Template = new Template(true);

                    ToolName = LCG.toolnameUDG;
                    FileType = "PlantUML";
                    FileSuffix = ".plantuml";
                    InlineConfigBegin = InlineConfigBegin.Replace("/*", "/'").Replace("*/", "'/");
                    InlineConfigEnd = InlineConfigEnd.Replace("/*", "/'").Replace("*/", "'/");
                    AttributeSeparatorAfterPK = "--";
                    break;
            }
            Template.SetFixedValues(templateFormat);
        }

        internal string ToolName = LCG.toolnameLCG;
        internal string FileType = "C#";
        internal string FileSuffix = ".cs";
        internal string InlineConfigBegin = @"/***** LCG-configuration-BEGIN *****\";
        internal string InlineConfigEnd = @"\***** LCG-configuration-END   *****/";
        public string Version { get; set; }
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
        public string[] CamelCaseWords { get; set; } = new string[] { "parent", "customer", "owner", "state", "status", "name", "phone", "address", "code", "postal", "mail", "modified", "created", "permission", "type", "method", "verson", "number", "first", "last", "middle", "contact", "account", "system", "user", "fullname", "preferred", "processing", "annual", "plugin", "step", "key", "details", "message", "description", "constructor", "execution", "secure", "configuration", "behalf", "count", "percent", "internal", "external", "trace", "entity", "primary", "secondary", "lastused", "credit", "credited", "donot", "exchange", "import", "invoke", "invoked", "private", "market", "marketing", "revenue", "business", "price", "level", "pricelevel", "territory", "version", "conversion", "workorder", "team" };
        public string[] CamelCaseWordEnds { get; set; } = new string[] { "id" };
        public string[] InternalAttributes { get; set; } = new string[] { "importsequencenumber", "owneridname", "owneridtype", "owneridyominame", "createdbyname", "createdbyyominame", "createdonbehalfby", "createdonbehalfbyname", "createdonbehalfbyyominame", "modifiedbyname", "modifiedbyyominame", "modifiedonbehalfby", "modifiedonbehalfbyname", "modifiedonbehalfbyyominame", "overriddencreatedon", "owningbusinessunit", "owningteam", "owninguser", "regardingobjectidname", "regardingobjectidyominame", "regardingobjecttypecode", "timezoneruleversionnumber", "transactioncurrencyidname", "utcconversiontimezonecode", "versionnumber" };
        public string[] MicrosoftPrefixes { get; set; } = new string[] { "msdyn_", "msdynce_", "msdyncrm_", "msdynmkt_", "msfp_", "mspcat_", "mspp_", "sales_", "adx_", "bot_", "botcomponent_" };

        // changed to an accessor because serialization was failing with an Interface
        private ITemplate Template { get; set; }

        public ITemplate GetTemplate() => this.Template;
    }

    public class Template : TemplateBase
    {
        public Template() : this(false)
        {
        }

        public Template(bool isUML)
        {
            if (!isUML)
            {
                TemplateVersion = 4;    // Change this when LCG template is updated to revert customizations
            }
            else
            {
                TemplateVersion = 7;    // Change this when UML template is updated to revert customizations
                Legend = @"
entity **Legend** <<standard>> #CCFFEE {
    (PK) = Primary Key
    --
    (PN) = Primary Name
    * Required
    + Recommended
    Standard
    <color:blue>Custom</color>
}";
                DataContainer = @"
@startuml {namespace}

{theme}

skinparam Padding {paddingsize}
skinparam linetype ortho
hide circle
hide stereotype

{legend}

title {namespace} Entity Model
footer Generated %date(""yyyy-MM-dd"") by {toolname} {version} for XrmToolBox
{data}
@enduml";
                Theme = @"
skinparam RoundCorner 5
skinparam ArrowFontSize 12
skinparam ClassBorderColor Black
skinparam ClassBorderColor<<custom>> Blue";
                EntityGroup = "package \"{group}\" {color}\n{\n{entities}\n}";
                EntityContainer = "entity {entityname}{typedetails} {type}\n{\n{attributes}\n}";
                Attribute = "{attribute}: {type}{typedetails}";
                Relationship = "{entity1} {relationtype} {entity2}: {lookup}";
                PrimaryKeyName = "{attribute} (PK)";
                PrimaryAttributeName = "{attribute} (PN)";
                CustomAttribute = "<color:blue>{attribute}</color>";
                RequiredLevelRequired = "*{attribute}";
                RequiredLevelRecommended = "+{attribute}";
            }
        }
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