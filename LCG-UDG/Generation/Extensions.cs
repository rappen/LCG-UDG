using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk.Metadata;

namespace Rappen.XTB.LCG
{
    public static class Extensions
    {
        public static AttributeMetadata GetAttribute(this Dictionary<string, EntityMetadata> entities, string entity, string attribute)
        {
            if (entities == null
                || !entities.TryGetValue(entity, out var metadata)
                || metadata.Attributes == null)
            {
                return null;
            }

            return metadata.Attributes.FirstOrDefault(metaattribute => metaattribute.LogicalName == attribute);
        }

        public static bool WriteFile(this string data, string filename, string orgurl, Settings settings)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            var header = GetFileHeader(filename, orgurl, settings, version);
            var content = GetDataContent(data, settings, version);
            content = header + "\r\n\r\n" + content;
            content = content.BeautifyContent(settings.commonsettings.Template.IndentStr);
            if (settings.SaveConfigurationInCommonFile)
            {
                string selection = GetInlineConfiguration(settings);
                content += "\r\n\r\n" + selection;
            }
            try
            {
                File.WriteAllText(filename, content);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Generate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static string GetInlineConfiguration(Settings settings)
        {
            var inlineconfig = Settings.GetBlankSettings();
            inlineconfig.CopyInlineConfiguration(settings);
            var selection = XmlSerializerHelper.Serialize(inlineconfig);
            var inlineconfigstr = new StringBuilder();
            inlineconfigstr.AppendLine(settings.commonsettings.InlineConfigBegin);
            inlineconfigstr.AppendLine(selection);
            inlineconfigstr.AppendLine(settings.commonsettings.InlineConfigEnd);
            return inlineconfigstr.ToString();
        }

        private static string GetFileHeader(string filename, string orgurl, Settings settings, string version)
        {
            var header = settings.commonsettings.Template.FileHeader
                .Replace("{toolname}", settings.commonsettings.ToolName)
                .Replace("{version}", version)
                .Replace("{organization}", orgurl)
                .Replace("{filename}", filename)
                .Replace("{createdate}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("{legend}", settings.Legend ? settings.commonsettings.Template.Legend : string.Empty)
                .Replace("{namespace}", settings.NameSpace)
                .Replace("\r\n\r\n", "\r\n");
            return header;
        }

        private static string GetDataContent(string data, Settings settings, string version)
        {
            return settings.commonsettings.Template.DataContainer
                .Replace("{toolname}", settings.commonsettings.ToolName)
                .Replace("{version}", version)
                .Replace("{namespace}", settings.NameSpace)
                .Replace("{legend}", settings.Legend ? settings.commonsettings.Template.Legend : string.Empty)
                .Replace("{paddingsize}", settings.TableSize.ToString())
                .Replace("{data}", data);
        }

        private static string BeautifyContent(this string content, string indentstr)
        {
            var fixedcontent = new StringBuilder();
            var lines = content.Split('\n').ToList();
            var lastline = string.Empty;
            var indent = 0;
            foreach (var line in lines.Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)))
            {
                if (AddBlankLineBetween(lastline, line))
                {
                    fixedcontent.AppendLine();
                }
                if (lastline.EndsWith("{"))
                {
                    indent++;
                }
                if (line.Equals("}") && indent > 0)
                {
                    indent--;
                }
                fixedcontent.AppendLine(string.Concat(Enumerable.Repeat(indentstr, indent)) + line);
                lastline = line;
            }
            return fixedcontent.ToString();
        }

        private static bool AddBlankLineBetween(string lastline, string line)
        {
            if (string.IsNullOrWhiteSpace(lastline) || lastline.Equals("{"))
            {   // Never two empty lines after each other
                return false;
            }
            if (lastline.StartsWith("#region") || line.StartsWith("#region") || line.StartsWith("#endregion"))
            {   // Empty lines around region statements
                return true;
            }
            if (lastline.StartsWith("using ") && !line.StartsWith("using "))
            {   // Empty lines after usings
                return true;
            }
            if (line.StartsWith("namespace "))
            {   // Empty lines before namespace
                return true;
            }
            if (line.StartsWith("public enum"))
            {   // Never empty line before enums, we keep it compact
                return false;
            }
            if (lastline.Equals("}") && !line.Equals("}") && !string.IsNullOrWhiteSpace(line))
            {   // Never empty line between end blocks
                return true;
            }
            // Following rules are UML specific
            if (line.StartsWith("@startuml") || lastline.StartsWith("@startuml") || line.StartsWith("@enduml"))
            {
                return true;
            }
            if (line.StartsWith("title") || line.StartsWith("header") || line.StartsWith("footer "))
            {
                return true;
            }
            if (line.StartsWith("skinparam") && !lastline.StartsWith("skinparam"))
            {
                return true;
            }
            if (line.StartsWith("entity "))
            {
                return true;
            }
            return false;
        }

        public static string CamelCaseIt(this string name, Settings settings)
        {
            bool WordBeginOrEnd(string text, int i)
            {
                var last = text.Substring(0, i).ToLowerInvariant();
                var next = text.Substring(i).ToLowerInvariant();
                foreach (var word in settings.commonsettings.CamelCaseWords.Where(word => last.EndsWith(word) || next.StartsWith(word)))
                {   // Found a "word" in the string (for example "count"
                    var isunbreakable = false;
                    foreach (var unbreak in settings.commonsettings.CamelCaseWords)
                    {   // Check that this word is not also part of a bigger word (for example "account"
                        var len = unbreak.Length;
                        var pos = text.ToLowerInvariant().IndexOf(unbreak);
                        if (pos >= 0 && pos < i & pos + len > i)
                        {   // Found word appears to split a bigger valid word, prevent that
                            isunbreakable = true;
                            break;
                        }
                    }
                    if (!isunbreakable)
                    {
                        return true;
                    }
                }
                return settings.commonsettings.CamelCaseWordEnds.Any(word => next.Equals(word));
            }

            var result = string.Empty;
            var nextCapital = true;
            for (var i = 0; i < name.Length; i++)
            {
                var chr = name[i];
                if ((chr < 'a') &&
                    (chr < 'A' || chr > 'Z') &&
                    (chr < '0' || chr > '9'))
                {   // Any non-letters/numbers are treated as word separators
                    nextCapital = true;
                }
                else if (chr > 'z')
                {   // Just ignore special character
                }
                else
                {
                    nextCapital = nextCapital || WordBeginOrEnd(name, i);
                    if (nextCapital)
                    {
                        result += chr.ToString().ToUpperInvariant();
                    }
                    else
                    {
                        result += chr;
                    }
                    nextCapital = false;
                }
            }
            return result;
        }

        public static string GetNonDisplayName(this Settings settings, string name)
        {
            if (settings.DoStripPrefix && !string.IsNullOrEmpty(settings.StripPrefix))
            {
                foreach (var prefix in settings.StripPrefix.Split(',')
                                               .Select(p => p.Trim())
                                               .Where(p => !string.IsNullOrWhiteSpace(p)
                                                      && name.ToLowerInvariant().StartsWith(p)))
                {
                    name = name.Substring(prefix.Length);
                }
            }
            if (settings.ConstantCamelCased)
            {
                name = name.CamelCaseIt(settings);
            }
            return name;
        }

        public static string ReplaceIfNotEmpty(this string template, string oldValue, string newValue)
        {
            return string.IsNullOrEmpty(template) ? newValue : template.Replace(oldValue, newValue);
        }

        public static string MessageDetails(this Exception ex, int level = 0)
        {
            if (ex == null)
            {
                return string.Empty;
            }
            return new string(' ', level * 2) + (ex.Message + Environment.NewLine + ex.InnerException.MessageDetails(level + 1)).Trim();
        }
    }
}