using System;
using System.Text;
using System.Windows.Forms;

namespace Rappen.XTB.LCG
{
    public partial class FormatDialogLCG : Form
    {
        public FormatDialogLCG()
        {
            InitializeComponent();
        }

        internal static bool GetSettings(LCG lcg, Settings settings)
        {
            using (var settingdlg = new FormatDialogLCG())
            {
                settingdlg.rbFileCommon.Checked = lcg.isUML || settings.UseCommonFile;
                settingdlg.rbFilePerEntity.Checked = !settingdlg.rbFileCommon.Checked;
                settingdlg.cmbFileName.SelectedIndex = (int)settings.FileName;
                settingdlg.chkFileIncludeSelection.Checked = settings.SaveConfigurationInCommonFile;
                settingdlg.txtNamespace.Text = settings.NameSpace;
                settingdlg.cmbCommonAttributes.SelectedIndex = (int)settings.CommonAttributes;
                settingdlg.cmbConstantName.SelectedIndex = (int)settings.ConstantName;
                settingdlg.chkConstCamelCased.Checked = settings.ConstantCamelCased && settings.ConstantName != NameType.DisplayName;
                settingdlg.chkConstStripPrefix.Checked = settings.DoStripPrefix && settings.ConstantName != NameType.DisplayName;
                settingdlg.txtConstStripPrefix.Text = settings.StripPrefix;
                settingdlg.chkXmlProperties.Checked = settings.XmlProperties;
                settingdlg.chkXmlDescription.Checked = settings.XmlDescription;
                settingdlg.chkRegions.Checked = settings.Regions;
                settingdlg.chkRelationships.Checked = settings.RelationShips;
                settingdlg.chkEnumsInclude.Checked = settings.OptionSets;
                settingdlg.chkEnumsGlobal.Checked = settings.GlobalOptionSets;
                settingdlg.cmbEncoding.Items.Clear();
                settingdlg.cmbEncoding.Items.AddRange(OnlineSettings.Instance.Encodings.ToArray());
                if (settingdlg.cmbEncoding.Items.Contains(settings.Encoding))
                {
                    settingdlg.cmbEncoding.SelectedItem = settings.Encoding;
                }
                else
                {
                    settingdlg.cmbEncoding.Text = settings.Encoding;
                }
                if (settingdlg.ShowDialog(lcg) == DialogResult.OK)
                {
                    settings.UseCommonFile = lcg.isUML || settingdlg.rbFileCommon.Checked;
                    settings.FileName = (NameType)Math.Max(settingdlg.cmbFileName.SelectedIndex, 0);
                    settings.SaveConfigurationInCommonFile = settingdlg.rbFileCommon.Checked && settingdlg.chkFileIncludeSelection.Checked;
                    settings.NameSpace = settingdlg.txtNamespace.Text;
                    settings.CommonAttributes = (CommonAttributesType)Math.Max(settingdlg.cmbCommonAttributes.SelectedIndex, 0);
                    settings.ConstantName = (NameType)Math.Max(settingdlg.cmbConstantName.SelectedIndex, 0);
                    settings.ConstantCamelCased = settingdlg.chkConstCamelCased.Checked;
                    settings.Encoding = settingdlg.cmbEncoding.Text.Trim();
                    settings.DoStripPrefix = settingdlg.chkConstStripPrefix.Checked;
                    settings.StripPrefix = settingdlg.txtConstStripPrefix.Text.ToLowerInvariant().TrimEnd('_') + "_";
                    settings.XmlProperties = settingdlg.chkXmlProperties.Checked;
                    settings.XmlDescription = settingdlg.chkXmlDescription.Checked;
                    settings.Regions = settingdlg.chkRegions.Checked;
                    settings.RelationShips = settingdlg.chkRelationships.Checked;
                    settings.OptionSets = settingdlg.chkEnumsInclude.Checked;
                    settings.GlobalOptionSets = settingdlg.chkEnumsGlobal.Checked;
                    settings.AttributeSortMode = AttributeSortMode.None;
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

        private void rbFileCommon_CheckedChanged(object sender, EventArgs e)
        {
            cmbFileName.Visible = rbFilePerEntity.Checked;
            chkFileIncludeSelection.Visible = rbFileCommon.Checked;
        }
    }
}