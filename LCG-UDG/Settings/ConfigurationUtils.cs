using McTools.Xrm.Connection;
using System.IO;

namespace Rappen.XTB.Helper
{
    public static class ConfigurationUtils
    {
        public static T GetEmbeddedConfiguration<T>(string filename, string begintoken, string endtoken)
        {
            string GetTextBetween(string text, string begin, string end, bool includebeginend)
            {
                var beginpos = text.IndexOf(begin);
                if (beginpos < 0)
                {
                    return string.Empty;
                }
                text = text.Substring(beginpos + (includebeginend ? 0 : begin.Length));
                var endpos = text.IndexOf(end);
                if (endpos < 0)
                {
                    return string.Empty;
                }
                text = text.Substring(0, endpos + (includebeginend ? end.Length : 0)).Trim();
                return text;
            }

            var csfile = File.ReadAllText(filename);
            var settingname = typeof(T).ToString();
            var settingnameparts = settingname.Split('.');
            settingname = settingnameparts[settingnameparts.Length - 1];
            var configstr = GetTextBetween(csfile, begintoken, endtoken, false);
            if (string.IsNullOrEmpty(configstr))
            {
                throw new FileLoadException("Could not find configuration token in file.", filename);
            }
            configstr = GetTextBetween(configstr, $"<{settingname}", $"</{settingname}>", true);
            if (string.IsNullOrEmpty(configstr))
            {
                throw new FileLoadException($"Could not find {settingname} XML in file.", filename);
            }
            var inlinesettings = (T)XmlSerializerHelper.Deserialize(configstr, typeof(T));
            return inlinesettings;
        }
    }
}
