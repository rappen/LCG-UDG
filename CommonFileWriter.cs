using System.IO;
using System.Text;

namespace Rappen.XTB.LCG
{
    public class CommonFileWriter : IConstantFileWriter
    {
        public string OrgUrl { get; set; }
        private readonly StringBuilder _entities = new StringBuilder();

        public CommonFileWriter(string orgUrl) { OrgUrl = orgUrl; }

        #region Implementation of IConstantFileWriter

        public string GetCompleteMessage(Settings settings)
        {
            var filename = Path.Combine(settings.OutputFolder, settings.CommonFile + ".cs");
            var file = CSharpUtils.GetFile(settings, _entities.ToString());
            file.WriteFile(filename, OrgUrl, settings);
            return $"Saved constants to\n  {filename}";
        }

        public void WriteEntity(Settings settings, string entity, string fileName)
        {
            _entities.AppendLine(entity);
        }

        #endregion
    }
}
