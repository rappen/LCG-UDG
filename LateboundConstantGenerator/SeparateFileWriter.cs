using System.Collections.Generic;
using System.IO;

namespace Rappen.XTB.LCG
{
    public class SeparateFileWriter : IConstantFileWriter
    {
        public string OrgUrl { get; set; }
        private Template template;
        private readonly List<string> _savedFiles = new List<string>();

        public SeparateFileWriter(Template template, string orgUrl)
        {
            this.template = template;
            OrgUrl = orgUrl;
        }

        #region Implementation of IConstantFileWriter

        public string Finalize(Settings settings, string suffix = null)
        {
            return $"Saved files\n  {string.Join("\n  ", _savedFiles)}\nto folder\n  {settings.OutputFolder}";
        }

        public void WriteEntity(Settings settings, string entity, string filename)
        {
            entity.WriteFile(template, Path.Combine(settings.OutputFolder, filename), OrgUrl, settings);
            _savedFiles.Add(filename);
        }

        #endregion
    }
}
