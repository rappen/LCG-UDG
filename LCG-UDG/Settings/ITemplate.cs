namespace Rappen.XTB.LCG
{
    public interface ITemplate
    {
        TemplateFormat Format { get; set; }
        string IndentStr { get; set; }
        string FileContainer { get; set; }
        string FileHeader { get; set; }
        bool AddAllRelationshipsAfterEntities { get; set; }
        string Attribute { get; set; }
        string CustomAttribute { get; set; }
        string DataContainer { get; set; }
        string EntityContainer { get; set; }
        string EntityDetail { get; set; }
        string Legend { get; set; }
        string OptionSet { get; set; }
        string OptionSetValue { get; set; }
        string PrimaryAttributeName { get; set; }
        string PrimaryKeyName { get; set; }
        string TableAttributeNameClashSuffix { get; set; }
        string Region { get; set; }
        string Relationship { get; set; }
        string RelationshipN_N { get; set; }
        string Relationship1_N { get; set; }
        string RelationshipN_1 { get; set; }
        string Remarks { get; set; }
        string RequiredLevelNone { get; set; }
        string RequiredLevelRecommended { get; set; }
        string RequiredLevelRequired { get; set; }
        string StandardAttribute { get; set; }
        string Summary { get; set; }
        int TemplateVersion { get; set; }
        void SetFixedValues(TemplateFormat format);
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
}