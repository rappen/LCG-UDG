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

        public bool Finalize(Settings settings)
        {
            return _blocks.ToString().WriteFile(settings.CommonFilePath, OrgUrl, settings);
        }

        public void WriteBlock(Settings settings, string block, string fileName)
        {
            _blocks.AppendLine(block);
        }

        public string GetResult(Settings settings)
        {
            return $"Saved file: {settings.CommonFilePath}";
        }

        #endregion
    }
}
