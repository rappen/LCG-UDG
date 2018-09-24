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
    }
}
