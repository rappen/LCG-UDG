using System.IO;
using System.Text;

namespace Rappen.XTB.LCG
{
    public class CommonFileWriter : IConstantFileWriter
    {
        public string OrgUrl { get; set; }
        private readonly StringBuilder _entities = new StringBuilder();

        public CommonFileWriter(string orgUrl)
        {
            OrgUrl = orgUrl;
        }

        #region Implementation of IConstantFileWriter

        public string Finalize(Settings settings)
        {
            var filename = Path.Combine(settings.OutputFolder, settings.CommonFile + settings.commonsettings.Template.FileSuffix);
            if (_entities.ToString().WriteFile(filename, OrgUrl, settings))
            {
                return $"Saved constants to\n  {filename}";
            }
            else
            {
                return "Error";
            }
        }

        public void WriteEntity(Settings settings, string entity, string fileName)
        {
            _entities.AppendLine(entity);
        }

        #endregion
    }
}
