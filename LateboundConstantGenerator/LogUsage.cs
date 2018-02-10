using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rappen.XTB.LCG
{
    public class LogUsage
    {
        #region Public Methods

        public static async Task DoLog(string action)
        {
#if DEBUG
            return;
#endif
            try
            {
                var ass = Assembly.GetExecutingAssembly().GetName();
                var version = ass.Version.ToString();
                var name = ass.Name.Replace(" ", "");
                action = "LCG-" + action;

                var query = "t.php" +
                    "?sc_project=10396418" +
                    "&security=95f631d9" +
                    "&java=1" +
                    "&invisible=1" +
                    "&u={2}" +
                    "&camefrom={0} {1}";

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(name, version));
                    client.BaseAddress = new Uri("http://c.statcounter.com/");
                    var response = await client.GetAsync(string.Format(query, name, version, action)).ConfigureAwait(continueOnCapturedContext: false);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch { }
        }

        #endregion Public Methods

        #region Internal Methods

        internal static bool PromptToLog()
        {
            MessageBox.Show(@"The evolution of Latebound Constants Generator is based on feedback issues and anonymous statistics collected about usage.
The statistics are a valuable source of information for continuing the development to make the tool even easier to use and improve the most popular features.

Thank You,
Jonas", "Anonymous statistics", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        #endregion Internal Methods
    }
}