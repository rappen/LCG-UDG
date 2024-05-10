namespace Rappen.XTB.LCG
{
    internal class TemplateDBML : TemplateBase
    {
        // reference: https://dbdiagram.io/d

        public TemplateDBML() {
            DataContainer = "{data}";
            EntityContainer = "\nTable {entityname} {\n{attributes}\n}\n{relationships}\n\n";
            Attribute = "{attribute} {type} [note: '{logicalname}']";

            Relationship = "";
            
            // allow for multiple relationships
            RelationshipN_1 = "Ref:{entity2}.{referencingName} > {entity1}.{referencedName}";
            Relationship1_N = "Ref:{entity1}.{referencedName} > {entity2}.{referencingName}";

            // N:N, many-to-many relationship shown by a join table
            RelationshipN_N = "\n\nTable {schemaname} {\n    {referencingName} Uniqueidentifier [ref: > {entity2}.{referencingName}]\n    {referencedName} Uniqueidentifier [ref: > {entity1}.{referencedName}]\n}\n";

            PrimaryKeyName = "{attribute}";
            PrimaryAttributeName = "{attribute}";

            OptionSet = "Enum {name}\n{\n{values}\n}";
            OptionSetValue = "{name}\n";
            TableAttributeNameClashSuffix = string.Empty;
        }
    }
}