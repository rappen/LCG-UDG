using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Rappen.XTB.LCG
{
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "UML Diagram Generator"),
        ExportMetadata("Description", "Generate constant classes from metadata for late bound development on CDS / Microsoft Dynamics 365"),
        ExportMetadata("SmallImageBase64", null),
        ExportMetadata("BigImageBase64", null),
        ExportMetadata("BackgroundColor", "#FFFFC0"),
        ExportMetadata("PrimaryFontColor", "#0000C0"),
        ExportMetadata("SecondaryFontColor", "#0000FF")]
    public class UMLDescription : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new LCG(true);
        }
    }
}