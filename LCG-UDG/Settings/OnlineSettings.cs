using Rappen.XTB.Helpers;
using System.Collections.Generic;
using System.IO;
using XrmToolBox.Extensibility;
using XrmToolBox.ToolLibrary.AppCode;

namespace Rappen.XTB.LCG
{
    public class OnlineSettings
    {
        private const string FileName = "Rappen.XTB.LCG.Settings.xml";
        private static readonly string ToolSettingsURLPath = "https://rappen.github.io/Tools/";
        private static OnlineSettings instance;

        public int SettingsVersion = 1;
        public List<string> CamelCaseWords = new List<string>();
        public List<string> CamelCaseWordEnds = new List<string>();
        public List<string> InternalAttributes = new List<string>();
        public List<string> MicrosoftPrefixes = new List<string>();
        public List<string> PlantUMLThemes = new List<string>();
        public List<string> Encodings = new List<string>();

        public OnlineSettings()
        { }

        public static OnlineSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    var folder = Path.Combine(Paths.SettingsPath, "LCG-UDG");
                    instance = XmlAtomicStore.DownloadXml<OnlineSettings>(ToolSettingsURLPath, FileName, folder);
                }
                return instance;
            }
        }

        public void Save()
        {
            if (!Directory.Exists(Paths.SettingsPath))
            {
                Directory.CreateDirectory(Paths.SettingsPath);
            }
            string path = Path.Combine(Paths.SettingsPath, FileName);
            XmlSerializerHelper.SerializeToFile(this, path);
        }
    }
}