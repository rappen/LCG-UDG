namespace Rappen.XTB.LCG
{
    public enum TemplateFormat
    {
        Constants = 0,
        UML,
        DBML
    }
    public class TemplateBase : ITemplate
    {
        public const string OutputFormatConstants = "Constants";
        public const string OutputFormatUML = "PlantUML";
        public const string OutputFormatDBML = "DBML";

        public TemplateBase() : this(TemplateFormat.Constants) { }

        public TemplateBase(TemplateFormat type)
        {
            switch (type)
            {
                case TemplateFormat.DBML:
                case TemplateFormat.Constants:
                    TemplateVersion = 3;    // Change this when LCG template is updated to revert customizations
                    break;
                case TemplateFormat.UML:
                    TemplateVersion = 3;    // Change this when UML template is updated to revert customizations
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
hide circle
hide stereotype
skinparam linetype ortho
skinparam RoundCorner 5
skinparam Padding 1
skinparam ArrowFontSize 12
skinparam ClassBorderColor Black
skinparam ClassBorderColor<<custom>> Blue

{legend}

title {namespace} Entity Model
footer Generated %date(""yyyy-MM-dd"") by {toolname} {version} for XrmToolBox
{data}
@enduml";
                    EntityContainer = "entity {entityname} <<{type}>>\n{\n{attributes}\n}";
                    Attribute = "{attribute}: {type}";
                    Relationship = "{entity1} {relationtype} {entity2}: {lookup}";
                    PrimaryKeyName = "{attribute} (PK)";
                    PrimaryAttributeName = "{attribute} (PN)";
                    CustomAttribute = "<color:blue>{attribute}</color>";
                    RequiredLevelRequired = "*{attribute}";
                    RequiredLevelRecommended = "+{attribute}";

                    break;
            }
        }

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
        public string DataContainer { get; set; } = "namespace {namespace}\n{\n{data}\n}";
        public string EntityContainer { get; set; } = "{summary}\n{remarks}\npublic static class {entityname}\n{\n{entitydetail}\n{attributes}\n{relationships}\n{optionsets}\n}";
        public string EntityDetail { get; set; } = "public const string EntityName = '{logicalname}';\npublic const string EntityCollectionName = '{logicalcollectionname}';";
        public string Attribute { get; set; } = "{summary}\n{remarks}\npublic const string {attribute} = '{logicalname}';";
        public string Relationship { get; set; } = "{summary}\npublic const string {relationship} = '{schemaname}';";
        public string RelationshipN_1 { get; set; } = "";
        public string Relationship1_N { get; set; } = "";
        public string RelationshipN_N { get; set; } = "";
        public string OptionSet { get; set; } = "public enum {name}\n{\n{values}\n}";
        public string OptionSetValue { get; set; } = "{name} = {value}";
        public string Region { get; set; } = "#region {region}\n{content}\n#endregion {region}";
        public string Summary { get; set; } = "/// <summary>{summary}</summary>";
        public string Remarks { get; set; } = "/// <remarks>{remarks}</remarks>";
        public string PrimaryKeyName { get; set; } = "PrimaryKey";
        public string PrimaryAttributeName { get; set; } = "PrimaryName";
        public string StandardAttribute { get; set; } = string.Empty;
        public string CustomAttribute { get; set; } = string.Empty;
        public string TableAttributeNameClashSuffix { get; set; } = "_";
        public string RequiredLevelRequired { get; set; } = string.Empty;
        public string RequiredLevelRecommended { get; set; } = string.Empty;
        public string RequiredLevelNone { get; set; } = string.Empty;
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