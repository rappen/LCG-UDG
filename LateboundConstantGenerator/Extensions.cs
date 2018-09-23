
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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

        public static void WriteFile(this string content, string filename, string orgurl, Settings settings)
        {
            content = content.BeautifyContent();
            var header = CSharpUtils.Template.Header1
                .Replace("{version}", Assembly.GetExecutingAssembly().GetName().Version.ToString())
                .Replace("{organization}", orgurl);
            if (settings.commonsettings.HeaderLocalPath)
            {
                header += "\r\n// Filename  : " + filename;
            }
            if (settings.commonsettings.HeaderTimestamp)
            {
                header += "\r\n// Created   : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            header += "\r\n" + CSharpUtils.Template.Header2;
            File.WriteAllText(filename, header + "\r\n\r\n" + content);
        }

        public static string BeautifyContent(this string content)
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
                if (lastline.Equals("{"))
                {
                    indent++;
                }
                if (line.Equals("}"))
                {
                    indent--;
                }
                fixedcontent.AppendLine(string.Concat(Enumerable.Repeat(CSharpUtils.Template.IndentStr, indent)) + line);
                lastline = line;
            }
            return fixedcontent.ToString();
        }

        private static bool AddBlankLineBetween(string lastline, string line)
        {
            if (string.IsNullOrWhiteSpace(lastline))
            {   // Never two empty lines after each other
                return false;
            }
            if (lastline.StartsWith("#region") || line.StartsWith("#region") || line.StartsWith("#endregion"))
            {   // Empty lines around region statements
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
            return false;
        }

        public static string CamelCaseIt(this string name)
        {
            bool WordBeginOrEnd(string text, int i)
            {
                var words = new[] { "parent", "customer", "owner", "state", "status", "name", "phone", "address", "code", "postal", "mail", "modified", "created", "type", "method", "verson", "number", "first", "last", "middle", "contact", "account", "system", "user", "fullname", "preferred", "processing", "annual", "plugin", "step", "key", "details", "message", "description", "constructor", "execution", "secure", "configuration", "behalf", "count", "percent", "internal", "external", "trace", "entity", "primary", "secondary" };
                var endwords = new[] { "id" };
                var last = text.Substring(0, i).ToLowerInvariant();
                var next = text.Substring(i).ToLowerInvariant();
                foreach (var word in words)
                {
                    if (last.EndsWith(word) || next.StartsWith(word))
                    {
                        return true;
                    }
                }
                foreach (var word in endwords)
                {
                    if (next.Equals(word))
                    {
                        return true;
                    }
                }
                return false;
            }

            var result = string.Empty;
            var nextCapital = true;
            for (var i = 0; i < name.Length; i++)
            {
                var chr = name[i];
                if (chr == '_')
                {
                    nextCapital = true;
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
                name = name.CamelCaseIt();
            }
            return name;
        }
    }
}
