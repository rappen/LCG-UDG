using System.IO;
using System.Text;

namespace Rappen.XTB.LCG
{
    public class CommonFileWriter : IConstantFileWriter
    {
        public string OrgUrl { get; set; }
        private Template template;
        private readonly StringBuilder _entities = new StringBuilder();

        public CommonFileWriter(Template template, string orgUrl)
        {
            this.template = template;
            OrgUrl = orgUrl;
        }

        #region Implementation of IConstantFileWriter

        public string Finalize(Settings settings, string suffix)
        {
            var filename = Path.Combine(settings.OutputFolder, settings.CommonFile + suffix);
            if (_entities.ToString().WriteFile(template, filename, OrgUrl, settings))
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
