using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Rappen.XTB.LCG
{
    public partial class About : Form
    {
        #region Private Fields

        private LCG lcg;

        #endregion Private Fields

        #region Public Constructors

        public About(LCG lcg)
        {
            InitializeComponent();
            this.lcg = lcg;
            PopulateAssemblies();
        }

        #endregion Public Constructors

        #region Private Methods

        private void chkStatAllow_CheckedChanged(object sender, EventArgs e)
        {
            if (Visible && chkStatAllow.Checked)
            {
                MessageBox.Show("Thank You!\n\nHappy numbering :)\n\n/Jonas", "Statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lcg.LogUse("About-OpenHomepage");
            System.Diagnostics.Process.Start("http://lcg.xrmtoolbox.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lcg.LogUse("About-OpenBlog");
            System.Diagnostics.Process.Start("http://jonasrapp.innofactor.se");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lcg.LogUse("About-OpenInnofactor");
            System.Diagnostics.Process.Start("http://www.innofactor.se");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lcg.LogUse("About-OpenTwitter");
            System.Diagnostics.Process.Start("http://twitter.com/rappen");
        }

        private void PopulateAssemblies()
        {
            var assemblies = GetReferencedAssemblies();
            var items = assemblies.Select(a => GetListItem(a)).ToArray();
            listAssemblies.Items.Clear();
            listAssemblies.Items.AddRange(items);
        }

        private ListViewItem GetListItem(AssemblyName a)
        {
            var item = new ListViewItem(a.Name);
            item.SubItems.Add(a.Version.ToString());
            return item;
        }

        private List<AssemblyName> GetReferencedAssemblies()
        {
            var names = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                    .Where(a => !a.Name.Equals("mscorlib") && !a.Name.StartsWith("System") && !a.Name.Contains("CSharp")).ToList();
            names.Add(Assembly.GetEntryAssembly().GetName());
            names.Add(Assembly.GetExecutingAssembly().GetName());
            names = names.OrderBy(a => assemblyPrioritizer(a.Name)).ToList();
            return names;
        }

        private static string assemblyPrioritizer(string assemblyName)
        {
            return
                assemblyName.Equals("XrmToolBox") ? "AAAAAAAAAAAA" :
                assemblyName.Contains("XrmToolBox") ? "AAAAAAAAAAAB" :
                assemblyName.Equals(Assembly.GetExecutingAssembly().GetName().Name) ? "AAAAAAAAAAAC" :
                assemblyName.Contains("Jonas") ? "AAAAAAAAAAAD" :
                assemblyName.Contains("Innofactor") ? "AAAAAAAAAAAE" :
                assemblyName.Contains("Cinteros") ? "AAAAAAAAAAAF" :
                assemblyName;
        }

        #endregion Private Methods
    }
}