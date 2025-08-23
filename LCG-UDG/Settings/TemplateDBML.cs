namespace Rappen.XTB.LCG
{
    internal class TemplateDBML : TemplateBase
    {
        // reference: https://dbdiagram.io/d

        public TemplateDBML()
        {
            Format = TemplateFormat.DBML;
            TemplateVersion = 4;
            DataContainer = "{data}";
            EntityGroup = "\n{entities}\n";
            EntityContainer = "\nTable {entityname} {\n{attributes}\n}\n{relationships}\n\n";
            Attribute = "{attribute} {type}{typedetails} [note: '{logicalname}']";
            PrimaryKeyName = "{attribute}";
            PrimaryAttributeName = "{attribute}";
            RelationshipN_1 = "Ref:{entity2}.{referencingName} > {entity1}.{referencedName}";
            Relationship1_N = "Ref:{entity1}.{referencedName} < {entity2}.{referencingName}";
            RelationshipN_N = "\n\nTable {schemaname} {\n    {referencingName} Uniqueidentifier [ref: > {entity2}.{referencingName}]\n    {referencedName} Uniqueidentifier [ref: > {entity1}.{referencedName}]\n}\n";
            OptionSet = "Enum {name}\n{\n{values}\n}";
            OptionSetValue = "{name}\n";
            TableAttributeNameClashSuffix = string.Empty;
        }
    }
}