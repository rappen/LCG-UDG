using System.Collections.Generic;
using System.IO;

namespace Rappen.XTB.LCG
{
    public class SeparateFileWriter : IConstantFileWriter
    {
        public string OrgUrl { get; set; }
        private readonly List<string> _savedFiles = new List<string>();

        public SeparateFileWriter(string orgUrl) { OrgUrl = orgUrl; }

        #region Implementation of IConstantFileWriter

        public string GetCompleteMessage(Settings settings)
        {
            return $"Saved files\n  {string.Join("\n  ", _savedFiles)}\nto folder\n  {settings.OutputFolder}";
        }

        public void WriteEntity(Settings settings, string entity, string filename)
        {
            var entityfile = CSharpUtils.GetFile(settings, entity);
            entityfile.WriteFile(Path.Combine(settings.OutputFolder, filename), OrgUrl, settings);
            _savedFiles.Add(filename);
        }

        #endregion
    }
}
