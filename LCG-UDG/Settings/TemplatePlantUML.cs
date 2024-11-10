namespace Rappen.XTB.LCG
{
    public class TemplatePlantUML : TemplateBase
    {
        public TemplatePlantUML()
        {
            TemplateVersion = 7;    // Change this when LCG template is updated to revert customizations
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
            Theme = @"
skinparam RoundCorner 5
skinparam ArrowFontSize 12
skinparam ClassBorderColor Black
skinparam ClassBorderColor<<custom>> Blue";
            EntityGroup = "package \"{group}\" {color}\n{\n{entities}\n}";
            EntityContainer = "entity {entityname} {type}\n{\n{attributes}\n}";
            Attribute = "{attribute}: {type}";
            Relationship = "{entity1} {relationtype} {entity2}: {lookup}";
            PrimaryKeyName = "{attribute} (PK)";
            PrimaryAttributeName = "{attribute} (PN)";
            CustomAttribute = "<color:blue>{attribute}</color>";
            RequiredLevelRequired = "*{attribute}";
            RequiredLevelRecommended = "+{attribute}";
        }
    }
}