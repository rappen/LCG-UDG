using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Rappen.XTB.LCG
{
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Latebound Constants Generator"),
        ExportMetadata("Description", "Generate constant classes from metadata for late bound development on Microsoft Dynamics 365/CRM."),
        ExportMetadata("SmallImageBase64", null),
        ExportMetadata("BigImageBase64", null),
        ExportMetadata("BackgroundColor", "#ffffff"), // Use a HTML color name
        ExportMetadata("PrimaryFontColor", "#000000"), // Or an hexadecimal code
        ExportMetadata("SecondaryFontColor", "Blue")]
    public class LCGDescription : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new LCG();
        }
    }
}