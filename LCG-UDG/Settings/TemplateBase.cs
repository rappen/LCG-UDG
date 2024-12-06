namespace Rappen.XTB.LCG
{
    public abstract class TemplateBase
    {
        public TemplateBase()
        { }

        public int TemplateVersion { get; set; }

        public string IndentStr { get; set; } = "    ";
        public string FileContainer { get; set; } = "{header}\n{data}";

        public string FileHeader { get; set; } = @"// *********************************************************************
// Created by : {toolname} {version} for XrmToolBox
// Tool Author: Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : {organization}
// Filename   : {filename}
// Created    : {createdate}
// *********************************************************************";

        public string Legend { get; set; } = string.Empty;
        public string DataContainer { get; set; } = string.Empty;
        public string DefaultTheme { get; set; } = string.Empty;
        public string EntityGroup { get; set; } = string.Empty;
        public string EntityContainer { get; set; } = string.Empty;
        public string EntityDetail { get; set; } = string.Empty;
        public string Attribute { get; set; } = string.Empty;
        public string Relationship { get; set; } = string.Empty;
        public string RelationshipN_1 { get; set; } = string.Empty;
        public string Relationship1_N { get; set; } = string.Empty;
        public string RelationshipN_N { get; set; } = string.Empty;
        public string OptionSet { get; set; } = string.Empty;
        public string OptionSetValue { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
        public string PrimaryKeyName { get; set; } = string.Empty;
        public string PrimaryAttributeName { get; set; } = string.Empty;
        public string StandardAttribute { get; set; } = string.Empty;
        public string CustomAttribute { get; set; } = string.Empty;
        public string TableAttributeNameClashSuffix { get; set; } = "_";
        public string RequiredLevelRequired { get; set; } = string.Empty;
        public string RequiredLevelRecommended { get; set; } = string.Empty;
        public string RequiredLevelNone { get; set; } = string.Empty;
        public string ReadOnly { get; set; } = string.Empty;
        public bool AddAllRelationshipsAfterEntities { get; set; } = false;
        public TemplateFormat Format { get; set; } = TemplateFormat.Constants;
    }
}