using System.Collections.Generic;
using System.Linq;

namespace Rappen.XTB.LCG
{
    public class CommonSettings
    {
        public bool? UseLog { get; set; } = null;
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
        public string CamelCaseWords { get; set; } = "parent, customer, owner, state, status, name, phone, address, code, postal, mail, modified, created, type, method, verson, number, first, last, middle, contact, account, system, user, fullname, preferred, processing, annual, plugin, step, key, details, message, description, constructor, execution, secure, configuration, behalf, count, percent, internal, external, trace, entity, primary, secondary, lastused, credit, credited, donot, exchange, import, invoke, invoked, private, market, marketing, revenue, business, price, level, pricelevel, territory, version, conversion, workorder";
        public string CamelCaseWordEnds { get; set; } = "id";
        public Template Template { get; set; } = new Template();
    }

    public class Template
    {
        internal string IndentStr = "    ";
        internal string Header1 = @"// *********************************************************************
// Created by: Latebound Constant Generator {version} for XrmToolBox
// Author    : Jonas Rapp http://twitter.com/rappen
// Repo      : https://github.com/rappen/LateboundConstantGenerator
// Source Org: {organization}";
        internal string Header2 = "// *********************************************************************";
        internal string Namespace = "namespace {namespace}\n{\n{entities}\n}";
        public string Class { get; set; } = "public static class {classname}\n{\n{entity}\n{attributes}\n{relationships}\n{optionsets}\n}";
        public string Entity { get; set; } = "public const string EntityName = '{logicalname}';\npublic const string EntityCollectionName = '{logicalcollectionname}';";
        public string Attribute { get; set; } = "public const string {attribute} = '{logicalname}';";
        public string Relationship { get; set; } = "public const string {relationship} = '{schemaname}';";
        public string OptionSet { get; set; } = "public enum {name}\n{\n{values}\n}";
        public string OptionSetValue { get; set; } = "{name} = {value}";
        public string Region { get; set; } = "#region {region}\n{content}\n#endregion {region}";
    }
}
