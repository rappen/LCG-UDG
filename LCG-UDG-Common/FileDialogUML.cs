using System;
using System.Windows.Forms;

namespace Rappen.XTB.LCG
{
    public partial class FileDialogUML : Form
    {
        public FileDialogUML()
        {
            InitializeComponent();
        }

        internal static FileSettings GetSettings(LCG lcg, Settings settings)
        {
            FileSettings result = null;
            using (var settingdlg = new FileDialogUML())
            {
                settingdlg.txtOutputFolder.Text = settings.OutputFolder;
                settingdlg.txtNamespace.Text = settings.NameSpace;
                settingdlg.txtCommonFilename.Text = settings.CommonFile;
                if (settingdlg.ShowDialog(lcg) == DialogResult.OK)
                {
                    result = new FileSettings
                    {
                        OutputFolder = settingdlg.txtOutputFolder.Text,
                        NameSpace = settingdlg.txtNamespace.Text,
                        UseCommonFile = true,
                        CommonFile = settingdlg.txtCommonFilename.Text,
                        FileName = NameType.DisplayName,
                        CommonAttributes = CommonAttributesType.None
                    };
                }
            }
            return result;
        }

        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            var fldr = new FolderBrowserDialog
            {
                Description = "Select folder where generated UML file will be generated.",
                SelectedPath = txtOutputFolder.Text,
                ShowNewFolderButton = true
            };
            if (fldr.ShowDialog(this) == DialogResult.OK)
            {
                txtOutputFolder.Text = fldr.SelectedPath;
            }
        }

        private void txtCommonFilename_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
