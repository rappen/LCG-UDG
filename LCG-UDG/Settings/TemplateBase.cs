namespace Rappen.XTB.LCG
{
    public enum TemplateFormat
    {
        Constants = 0,
        UML,
        DBML
    }

    public abstract class TemplateBase
    {
        public const string OutputFormatConstants = "Constants";
        public const string OutputFormatUML = "PlantUML";
        public const string OutputFormatDBML = "DBML";

        public TemplateBase()
        { }

        public int TemplateVersion { get; set; }

        public string IndentStr { get; set; } = "    ";
        public string FileContainer { get; set; } = "{header}\n{data}";

        public string FileHeader { get; set; } = @"// *********************************************************************

// Created by : {toolname} {version} for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : {organization}
// Filename   : {filename}
// Created    : {createdate}
// *********************************************************************";

        public string Legend { get; set; }
        public string DataContainer { get; set; }
        public string Theme { get; set; }
        public string EntityGroup { get; set; }
        public string EntityContainer { get; set; }
        public string EntityDetail { get; set; }
        public string Attribute { get; set; }
        public string Relationship { get; set; }
        public string RelationshipN_1 { get; set; }
        public string Relationship1_N { get; set; }
        public string RelationshipN_N { get; set; }
        public string OptionSet { get; set; }
        public string OptionSetValue { get; set; }
        public string Region { get; set; }
        public string Summary { get; set; }
        public string Remarks { get; set; }
        public string PrimaryKeyName { get; set; }
        public string PrimaryAttributeName { get; set; }
        public string StandardAttribute { get; set; }
        public string CustomAttribute { get; set; }
        public string TableAttributeNameClashSuffix { get; set; } = "_";
        public string RequiredLevelRequired { get; set; }
        public string RequiredLevelRecommended { get; set; }
        public string RequiredLevelNone { get; set; }
        public bool AddAllRelationshipsAfterEntities { get; set; } = false;
        public TemplateFormat Format { get => TemplateFormat.Constants; set => Format = value; }

        public virtual void SetFixedValues(TemplateFormat templateFormat)
        {
            switch (templateFormat)
            {
                case TemplateFormat.Constants:
                    StandardAttribute = string.Empty;
                    CustomAttribute = string.Empty;
                    RequiredLevelRequired = string.Empty;
                    RequiredLevelRecommended = string.Empty;
                    RequiredLevelNone = string.Empty;
                    AddAllRelationshipsAfterEntities = false;
                    break;

                case TemplateFormat.UML:
                    FileHeader = "/'" + FileHeader.Replace("// ", "") + "'/";
                    EntityDetail = string.Empty;
                    OptionSet = string.Empty;
                    OptionSetValue = string.Empty;
                    Region = string.Empty;
                    Summary = string.Empty;
                    Remarks = string.Empty;
                    AddAllRelationshipsAfterEntities = true;
                    break;
            }
        }
    }
}