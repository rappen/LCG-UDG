namespace Rappen.XTB.LCG
{
    public class CommonSettings
    {
        public CommonSettings() : this(false) { }

        public CommonSettings(bool isUML)
        {
            Template = new Template(isUML);
        }

        public string Version { get; set; }
        public string EntityPrefix { get; set; } = string.Empty;
        public string EntitySuffix { get; set; } = string.Empty;
        public string AttributePrefix { get; set; } = string.Empty;
        public string AttributeSuffix { get; set; } = string.Empty;
        public string OneManyRelationshipPrefix { get; set; } = "Rel1M_";
        public string ManyOneRelationshipPrefix { get; set; } = "RelM1_";
        public string ManyManyRelationshipPrefix { get; set; } = "RelMM_";
        public string OptionSetEnumPrefix { get; set; } = string.Empty;
        public string OptionSetEnumSuffix { get; set; } = "_OptionSet";
        public bool HeaderTimestamp { get; set; } = true;
        public bool HeaderLocalPath { get; set; } = true;
        public string CamelCaseWords { get; set; } = "parent, customer, owner, state, status, name, phone, address, code, postal, mail, modified, created, type, method, verson, number, first, last, middle, contact, account, system, user, fullname, preferred, processing, annual, plugin, step, key, details, message, description, constructor, execution, secure, configuration, behalf, count, percent, internal, external, trace, entity, primary, secondary, lastused, credit, credited, donot, exchange, import, invoke, invoked, private, market, marketing, revenue, business, price, level, pricelevel, territory, version, conversion, workorder, team";
        public string CamelCaseWordEnds { get; set; } = "id";
        public Template Template { get; set; }
    }

    public class Template
    {
        public Template() : this(false) { }

        public Template(bool isUML)
        {
            SetDefaults(isUML);
        }

        public int TemplateVersion { get; set; }
        internal string IndentStr = "    ";
        internal string ToolName = LCG.toolnameLCG;
        internal string FileSuffix = ".cs";
        internal string FileContainer = "{header}\n{data}";
        internal string FileHeader = @"// *********************************************************************
// Created by : {toolname} {version} for XrmToolBox
// Author     : Jonas Rapp https://twitter.com/rappen
// GitHub     : https://github.com/rappen/LateboundConstantGenerator
// Source Org : {organization}
{filedetails}
// *********************************************************************";
        internal string AttributeSeparatorAfterPK = string.Empty;
        public string DataContainer { get; set; } = "namespace {namespace}\n{\n{data}\n}";
        public string EntityContainer { get; set; } = "{summary}\n{remarks}\npublic static class {entityname}\n{\n{entitydetail}\n{attributes}\n{relationships}\n{optionsets}\n}";
        public string EntityDetail { get; set; } = "public const string EntityName = '{logicalname}';\npublic const string EntityCollectionName = '{logicalcollectionname}';";
        public string Attribute { get; set; } = "{summary}\n{remarks}\npublic const string {attribute} = '{logicalname}';";
        public string Relationship { get; set; } = "{summary}\npublic const string {relationship} = '{schemaname}';";
        public string OptionSet { get; set; } = "public enum {name}\n{\n{values}\n}";
        public string OptionSetValue { get; set; } = "{name} = {value}";
        public string Region { get; set; } = "#region {region}\n{content}\n#endregion {region}";
        public string Summary { get; set; } = "/// <summary>{summary}</summary>";
        public string Remarks { get; set; } = "/// <remarks>{remarks}</remarks>";
        public string PrimaryKeyName { get; set; } = "PrimaryKey";
        public string PrimaryAttributeName { get; set; } = "PrimaryName";
        public string StandardAttribute { get; set; } = string.Empty;
        public string CustomAttribute { get; set; } = string.Empty;
        public string RequiredLevelRequired { get; set; } = string.Empty;
        public string RequiredLevelRecommended { get; set; } = string.Empty;
        public string RequiredLevelNone { get; set; } = string.Empty;

        private void SetDefaults(bool isUML)
        {
            if (!isUML)
            {
                TemplateVersion = 1;    // Change this when LCG template is updated to revert customizations
            }
            else
            {
                TemplateVersion = 1;    // Change this when UML template is updated to revert customizations
                EntityContainer = "entity {entityname} <<{type}>>\n{\n{attributes}\n}";
                Attribute = "{attribute}: {type}";
                Relationship = "{entity1} {relationtype} {entity2} {relationship}";
                PrimaryKeyName = "{attribute} (PK)";
                PrimaryAttributeName = "{attribute} (PN)";
                CustomAttribute = "<color:blue>{attribute}</color>";
                RequiredLevelRequired = "*{attribute}";
                RequiredLevelRecommended = "+{attribute}";
            }
        }

        internal void SetFixedValues(bool isUML)
        {
            if (!isUML)
            {
                StandardAttribute = string.Empty;
                CustomAttribute = string.Empty;
                RequiredLevelRequired = string.Empty;
                RequiredLevelRecommended = string.Empty;
                RequiredLevelNone = string.Empty;
            }
            else
            {
                ToolName = LCG.toolnameUDG;
                FileSuffix = ".plantuml";
                FileHeader = FileHeader.Replace("// ***", "/' ***") + @"'/
@startuml {namespace}
hide circle
hide stereotype
skinparam linetype ortho
skinparam class {
    BorderColor<<standard>> Black
    BorderColor<<custom>> Blue
}
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
title {namespace} Entity Model
footer Generated %date(""yyyy-MM-dd"") by {toolname} {version} for XrmToolBox
{data}
!include Relationships.plantuml
'{relationships}
@enduml";
                AttributeSeparatorAfterPK = "--";
                EntityDetail = string.Empty;
                OptionSet = string.Empty;
                OptionSetValue = string.Empty;
                Region = string.Empty;
                Summary = string.Empty;
                Remarks = string.Empty;
            }
        }
    }
}

/*
 
    FileContainer
        FileHeader
        DataContainer
            EntityContainer
                EntityDetails
                Attributes
                Relationships
                OptionSets
                    OptionSetValues


  */
