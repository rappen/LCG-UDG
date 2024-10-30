﻿using System.Collections.Generic;

namespace Rappen.XTB.LCG
{
    public class CommonSettings
    {
        public CommonSettings() : this(false)
        {
        }

        public CommonSettings(bool isUML)
        {
            Template = new Template(isUML);
            if (isUML)
            {
                AttributeSeparatorAfterPK = "--";
            }
            SetFixedValues(isUML);
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

        internal void SetFixedValues(bool isUML)
        {
            if (isUML)
            {
                ToolName = LCG.toolnameUDG;
                FileType = "PlantUML";
                FileSuffix = ".plantuml";
                InlineConfigBegin = InlineConfigBegin.Replace("/*", "/'").Replace("*/", "'/");
                InlineConfigEnd = InlineConfigEnd.Replace("/*", "/'").Replace("*/", "'/");
            }
            Template.SetFixedValues(isUML);
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

        public Template Template { get; set; }
    }

    public class Template
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
                EntityContainer = "entity {entityname}{typedetails} <<{type}>>\n{\n{attributes}\n}";
                Attribute = "{attribute}: {type}{typedetails}";
                Relationship = "{entity1} {relationtype} {entity2}: {lookup}";
                PrimaryKeyName = "{attribute} (PK)";
                PrimaryAttributeName = "{attribute} (PN)";
                CustomAttribute = "<color:blue>{attribute}</color>";
                RequiredLevelRequired = "*{attribute}";
                RequiredLevelRecommended = "+{attribute}";
            }
        }

        public int TemplateVersion { get; set; }
        internal string IndentStr = "    ";
        internal string FileContainer = "{header}\n{data}";

        internal string FileHeader = @"// *********************************************************************
// Created by : {toolname} {version} for XrmToolBox
// Author     : Jonas Rapp https://jonasr.app/
// GitHub     : https://github.com/rappen/LCG-UDG/
// Source Org : {organization}
// Filename   : {filename}
// Created    : {createdate}
// *********************************************************************";

        public string Legend { get; set; }
        public string DataContainer { get; set; } = "namespace {namespace}\n{\n{data}\n}";
        public string Theme { get; set; } = "";
        public string EntityGroup { get; set; } = "#region {group}\n{entities}\n#endregion {group}\n";
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
        public bool AddAllRelationshipsAfterEntities { get; set; } = false;

        internal void SetFixedValues(bool isUML)
        {
            if (!isUML)
            {
                StandardAttribute = string.Empty;
                CustomAttribute = string.Empty;
                RequiredLevelRequired = string.Empty;
                RequiredLevelRecommended = string.Empty;
                RequiredLevelNone = string.Empty;
                AddAllRelationshipsAfterEntities = false;
            }
            else
            {
                FileHeader = "/'" + FileHeader.Replace("// ", "") + "'/";
                EntityDetail = string.Empty;
                OptionSet = string.Empty;
                OptionSetValue = string.Empty;
                Region = string.Empty;
                Summary = string.Empty;
                Remarks = string.Empty;
                AddAllRelationshipsAfterEntities = true;
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