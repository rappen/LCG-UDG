using System;
using System.Windows.Forms;

namespace Rappen.XTB.LCG
{
    public partial class GenerateDialog : Form
    {
        public GenerateDialog()
        {
            InitializeComponent();
        }

        internal static FileSettings GetSettings(LCG lcg, Settings settings)
        {
            FileSettings result = null;
            using (var settingdlg = new GenerateDialog())
            {
                settingdlg.pnFileStructure.Visible = !lcg.isUML;
                settingdlg.pnCommonAttributes.Visible = !lcg.isUML;
                settingdlg.txtCommonFileSuffix.Text = lcg.isUML ? ".plantuml" : ".cs";
                settingdlg.lblNamespace.Text = lcg.isUML ? "Header" : "Namespace";
                settingdlg.txtOutputFolder.Text = settings.OutputFolder;
                settingdlg.txtNamespace.Text = settings.NameSpace;
                settingdlg.rbFileCommon.Checked = lcg.isUML || settings.UseCommonFile;
                settingdlg.rbFilePerEntity.Checked = !settingdlg.rbFileCommon.Checked;
                settingdlg.txtCommonFilename.Text = settings.CommonFile;
                settingdlg.cmbFileName.SelectedIndex = (int)settings.FileName;
                settingdlg.cmbCommonAttributes.SelectedIndex = (int)settings.CommonAttributes;
                if (settingdlg.ShowDialog(lcg) == DialogResult.OK)
                {
                    result = new FileSettings
                    {
                        OutputFolder = settingdlg.txtOutputFolder.Text,
                        NameSpace = settingdlg.txtNamespace.Text,
                        UseCommonFile = lcg.isUML || settingdlg.rbFileCommon.Checked,
                        CommonFile = settingdlg.txtCommonFilename.Text,
                        FileName = (NameType)Math.Max(settingdlg.cmbFileName.SelectedIndex, 0),
                        CommonAttributes = (CommonAttributesType)Math.Max(settingdlg.cmbCommonAttributes.SelectedIndex, 0)
                    };
                }
            }
            return result;
        }

        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            var fldr = new FolderBrowserDialog
            {
                Description = "Select folder where generated constant files will be generated.",
                SelectedPath = txtOutputFolder.Text,
                ShowNewFolderButton = true
            };
            if (fldr.ShowDialog(this) == DialogResult.OK)
            {
                txtOutputFolder.Text = fldr.SelectedPath;
            }
        }

        private void rbFileCommon_CheckedChanged(object sender, EventArgs e)
        {
            pnFileCommonName.Visible = rbFileCommon.Checked;
            cmbFileName.Visible = rbFilePerEntity.Checked;
        }
    }
}
