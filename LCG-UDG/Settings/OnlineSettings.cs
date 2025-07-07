﻿using Rappen.XTB.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using XrmToolBox.Extensibility;
using XrmToolBox.ToolLibrary.AppCode;

namespace Rappen.XTB.LCG
{
    public class OnlineSettings
    {
        private const string FileName = "Rappen.XTB.LCG.Settings.xml";
        private static readonly Uri ToolSettingsURLPath = new Uri("https://rappen.github.io/Tools/");
        private static OnlineSettings instance;

        public int SettingsVersion = 1;
        public List<string> CamelCaseWords = new List<string>();
        public List<string> CamelCaseWordEnds = new List<string>();
        public List<string> InternalAttributes = new List<string>();
        public List<string> MicrosoftPrefixes = new List<string>();
        public List<string> PlantUMLThemes = new List<string>();
        public List<string> Encodings = new List<string>();

        private OnlineSettings()
        { }

        public static OnlineSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Uri(ToolSettingsURLPath, FileName).DownloadXml<OnlineSettings>() ?? new OnlineSettings();
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