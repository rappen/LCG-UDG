using System;
using System.Windows.Forms;

namespace Rappen.XTB.LCG
{
    public partial class OptionsDialogUML : Form
    {
        public OptionsDialogUML()
        {
            InitializeComponent();
        }

        internal static GenerationSettings GetSettings(LCG lcg, Settings settings)
        {
            GenerationSettings result = null;
            using (var settingdlg = new OptionsDialogUML())
            {
                settingdlg.cmbConstantName.SelectedIndex = (int)settings.ConstantName;
                settingdlg.chkConstCamelCased.Checked = settings.ConstantCamelCased && settings.ConstantName != NameType.DisplayName;
                settingdlg.chkConstStripPrefix.Checked = settings.DoStripPrefix && settings.ConstantName != NameType.DisplayName;
                settingdlg.txtConstStripPrefix.Text = settings.StripPrefix;
                settingdlg.cmbSortAttributes.SelectedIndex = (int)settings.GenerationSettings.AttributeSortMode;
                settingdlg.chkRelationshipLabels.Checked = settings.GenerationSettings.RelationshipLabels;
                if (settingdlg.ShowDialog(lcg) == DialogResult.OK)
                {
                    result = new GenerationSettings
                    {
                        ConstantName = (NameType)Math.Max(settingdlg.cmbConstantName.SelectedIndex, 0),
                        ConstantCamelCased = settingdlg.chkConstCamelCased.Checked,
                        DoStripPrefix = settingdlg.chkConstStripPrefix.Checked,
                        StripPrefix = settingdlg.txtConstStripPrefix.Text.ToLowerInvariant().TrimEnd('_') + "_",
                        AttributeSortMode = (AttributeSortMode)Math.Max(settingdlg.cmbSortAttributes.SelectedIndex, 0),
                        RelationshipLabels = settingdlg.chkRelationshipLabels.Checked,
                        XmlProperties = false,
                        XmlDescription = false,
                        Regions = false,
                        RelationShips = true,
                        OptionSets = false,
                        GlobalOptionSets = false
                    };
                }
            }
            return result;
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
