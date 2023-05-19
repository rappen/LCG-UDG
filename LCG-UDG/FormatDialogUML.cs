using System;
using System.Linq;
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
                settingdlg.chkFileIncludeSelection.Checked = settings.SaveConfigurationInCommonFile;
                settingdlg.txtNamespace.Text = settings.NameSpace;
                settingdlg.cmbConstantName.SelectedIndex = (int)settings.ConstantName;
                settingdlg.chkConstCamelCased.Checked = settings.ConstantCamelCased && settings.ConstantName != NameType.DisplayName;
                settingdlg.chkConstStripPrefix.Checked = settings.DoStripPrefix && settings.ConstantName != NameType.DisplayName;
                settingdlg.txtConstStripPrefix.Text = settings.StripPrefix;
                settingdlg.cmbSortAttributes.SelectedIndex = (int)settings.AttributeSortMode;
                settingdlg.chkTypeDetails.Checked = settings.TypeDetails;
                settingdlg.chkRelationshipLabels.Checked = settings.RelationshipLabels;
                settingdlg.chkShowLegend.Checked = settings.Legend;
                if (settingdlg.panTableSizes.Controls.Cast<Control>().FirstOrDefault(c => c.Name == $"rbTableSize{settings.TableSize}") is RadioButton table)
                {
                    table.Checked = true;
                }
                else
                {
                    settingdlg.rbTableSize1.Checked = true;
                }
                if (settingdlg.panRelSizes.Controls.Cast<Control>().FirstOrDefault(c => c.Name == $"rbRelSize{settings.RelationShipSize}") is RadioButton rel)
                {
                    rel.Checked = true;
                }
                else
                {
                    settingdlg.rbRelSize1.Checked = true;
                }
                if (settingdlg.ShowDialog(lcg) == DialogResult.OK)
                {
                    settings.SaveConfigurationInCommonFile = settingdlg.chkFileIncludeSelection.Checked;
                    settings.NameSpace = settingdlg.txtNamespace.Text;
                    settings.ConstantName = (NameType)Math.Max(settingdlg.cmbConstantName.SelectedIndex, 0);
                    settings.ConstantCamelCased = settingdlg.chkConstCamelCased.Checked;
                    settings.DoStripPrefix = settingdlg.chkConstStripPrefix.Checked;
                    settings.StripPrefix = settingdlg.txtConstStripPrefix.Text.ToLowerInvariant().TrimEnd('_') + "_";
                    settings.AttributeSortMode = (AttributeSortMode)Math.Max(settingdlg.cmbSortAttributes.SelectedIndex, 0);
                    settings.TypeDetails = settingdlg.chkTypeDetails.Checked;
                    settings.RelationshipLabels = settingdlg.chkRelationshipLabels.Checked;
                    settings.Legend = settingdlg.chkShowLegend.Checked;
                    settings.TableSize =
                        settingdlg.rbTableSize10.Checked ? 10 :
                        settingdlg.rbTableSize20.Checked ? 20 :
                        settingdlg.rbTableSize50.Checked ? 50 : 1;
                    settings.RelationShipSize =
                        settingdlg.rbRelSize1.Checked ? 1 :
                        settingdlg.rbRelSize3.Checked ? 3 :
                        settingdlg.rbRelSize4.Checked ? 4 : 2;
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