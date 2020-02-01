using System;
using System.Windows.Forms;

namespace Rappen.XTB.LCG
{
    public partial class FormatDialogUML : Form
    {
        public FormatDialogUML()
        {
            InitializeComponent();
        }

        internal static bool GetSettings(LCG lcg, Settings settings)
        {
            using (var settingdlg = new FormatDialogUML())
            {
                settingdlg.txtNamespace.Text = settings.NameSpace;
                settingdlg.cmbConstantName.SelectedIndex = (int)settings.ConstantName;
                settingdlg.chkConstCamelCased.Checked = settings.ConstantCamelCased && settings.ConstantName != NameType.DisplayName;
                settingdlg.chkConstStripPrefix.Checked = settings.DoStripPrefix && settings.ConstantName != NameType.DisplayName;
                settingdlg.txtConstStripPrefix.Text = settings.StripPrefix;
                settingdlg.cmbSortAttributes.SelectedIndex = (int)settings.AttributeSortMode;
                settingdlg.chkRelationshipLabels.Checked = settings.RelationshipLabels;
                settingdlg.chkShowLegend.Checked = settings.Legend;
                if (settingdlg.ShowDialog(lcg) == DialogResult.OK)
                {
                    settings.NameSpace = settingdlg.txtNamespace.Text;
                    settings.ConstantName = (NameType)Math.Max(settingdlg.cmbConstantName.SelectedIndex, 0);
                    settings.ConstantCamelCased = settingdlg.chkConstCamelCased.Checked;
                    settings.DoStripPrefix = settingdlg.chkConstStripPrefix.Checked;
                    settings.StripPrefix = settingdlg.txtConstStripPrefix.Text.ToLowerInvariant().TrimEnd('_') + "_";
                    settings.AttributeSortMode = (AttributeSortMode)Math.Max(settingdlg.cmbSortAttributes.SelectedIndex, 0);
                    settings.RelationshipLabels = settingdlg.chkRelationshipLabels.Checked;
                    settings.Legend = settingdlg.chkShowLegend.Checked;
                    settings.CommonAttributes = CommonAttributesType.None;
                    settings.XmlProperties = false;
                    settings.XmlDescription = false;
                    settings.Regions = false;
                    settings.RelationShips = true;
                    settings.OptionSets = false;
                    settings.GlobalOptionSets = false;
                    return true;
                }
            }
            return false;
        }

        private void cmbConstantName_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkConstCamelCased.Visible = cmbConstantName.SelectedIndex != (int)NameType.DisplayName;
            chkConstStripPrefix.Enabled = cmbConstantName.SelectedIndex != (int)NameType.DisplayName;
            txtConstStripPrefix.Enabled = chkConstStripPrefix.Enabled && chkConstStripPrefix.Checked;
        }

        private void chkConstStripPrefix_CheckedChanged(object sender, EventArgs e)
        {
            txtConstStripPrefix.Enabled = chkConstStripPrefix.Enabled && chkConstStripPrefix.Checked;
        }

        private void txtConstStripPrefix_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtConstStripPrefix.Text))
            {
                txtConstStripPrefix.Text = txtConstStripPrefix.Text.ToLowerInvariant().TrimEnd('_') + "_";
            }
        }
    }
}
