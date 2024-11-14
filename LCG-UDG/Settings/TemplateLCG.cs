namespace Rappen.XTB.LCG
{
    public class TemplateLCG : TemplateBase
    {
        public TemplateLCG()
        {
            TemplateVersion = 5;    // Change this when LCG template is updated to revert customizations
            DataContainer = "namespace {namespace}\n{\n{data}\n}";
            EntityGroup = "#region {group}\n{entities}\n#endregion {group}\n";
            EntityContainer = "{summary}\n{remarks}\npublic static class {entityname}\n{\n{entitydetail}\n{attributes}\n{relationships}\n{optionsets}\n}";
            EntityDetail = "public const string EntityName = '{logicalname}';\npublic const string EntityCollectionName = '{logicalcollectionname}';";
            Attribute = "{summary}\n{remarks}\npublic const string {attribute} = '{logicalname}';";
            Relationship = "{summary}\npublic const string {relationship} = '{schemaname}';";
            OptionSet = "public enum {name}\n{\n{values}\n}";
            OptionSetValue = "{name} = {value}";
            Region = "#region {region}\n{content}\n#endregion {region}";
            Summary = "/// <summary>{summary}</summary>";
            Remarks = "/// <remarks>{remarks}</remarks>";
            PrimaryKeyName = "PrimaryKey";
            PrimaryAttributeName = "PrimaryName";
        }
    }
}