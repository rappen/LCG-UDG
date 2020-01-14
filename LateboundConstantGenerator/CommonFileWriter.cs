using System.IO;
using System.Text;

namespace Rappen.XTB.LCG
{
    public class CommonFileWriter : IConstantFileWriter
    {
        public string OrgUrl { get; set; }
        private readonly StringBuilder _blocks = new StringBuilder();

        public CommonFileWriter(string orgUrl)
        {
            OrgUrl = orgUrl;
        }

        #region Implementation of IConstantFileWriter

        public string Finalize(Settings settings)
        {
            var filename = Path.Combine(settings.OutputFolder, settings.CommonFile + settings.commonsettings.Template.FileSuffix);
            if (_blocks.ToString().WriteFile(filename, OrgUrl, settings))
            {
                return $"Saved file\n  {filename}";
            }
            else
            {
                return "Error";
            }
        }

        public void WriteBlock(Settings settings, string block, string fileName)
        {
            _blocks.AppendLine(block);
        }

        #endregion
    }
}
