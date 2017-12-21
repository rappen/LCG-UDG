using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Rappen.XTB.LCG
{
    internal class CSharpUtils
    {
        #region Templates

        private const string indentstr = "    ";
        private const string header1 = @"// *********************************************************************
// Created by: Latebound Constant Generator {version} for XrmToolBox
// Author    : Jonas Rapp http://twitter.com/rappen
// Repo      : https://github.com/rappen/LateboundConstantGenerator
// Source Org: {organization}";
        private const string header2 = @"// *********************************************************************";

        private const string namespacetemplate = "namespace {namespace}\n{\n{entities}\n}";
        private const string entitytemplate = "public static class {entity}\n{\npublic const string EntityName = '{logicalname}';\n{attributes}\n{optionsets}\n}";
        private const string attributetemplate = "public const string {attribute} = '{logicalname}';";
        private const string optionsettemplate = "public enum {name}\n{\n{values}\n}";
        private const string optionsetvaluetemplate = "{name} = {value}";

        #endregion Templates

        internal static void GenerateClasses(List<EntityMetadataProxy> entitiesmetadata, Settings settings, string orgurl)
        {
            var savefiles = new List<string>();
            var file = namespacetemplate.Replace("{namespace}", settings.NameSpace);

            var entities = new StringBuilder();
            foreach (var entitymetadata in entitiesmetadata.Where(e => e.Selected))
            {
                var entity = GetEntity(entitymetadata, settings);
                if (!settings.UseCommonFile)
                {
                    var filename = entitymetadata.GetNameTechnical(settings.FileName, settings) + ".cs";
                    var entityfile = file.Replace("{entities}", entity);
                    WriteFile(Path.Combine(settings.OutputFolder, filename), entityfile, orgurl, settings);
                    savefiles.Add(filename);
                }
                else
                {
                    entities.AppendLine(entity);
                }
            }
            file = file.Replace("{entities}", entities.ToString());
            var message = string.Empty;
            if (settings.UseCommonFile)
            {
                var filename = Path.Combine(settings.OutputFolder, settings.CommonFile + ".cs");
                WriteFile(filename, file, orgurl, settings);
                message = $"Saved constants to\n  {filename}";
            }
            else
            {
                message = $"Saved files\n  {string.Join("\n  ", savefiles)}\nto folder\n  {settings.OutputFolder}";
            }
            MessageBox.Show(message, "Latebound Constant Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void WriteFile(string filename, string content, string orgurl, Settings settings)
        {
            content = BeautifyContent(content);
            var header = header1
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
            header += "\r\n" + header2;
            File.WriteAllText(filename, header + "\r\n\r\n" + content);
        }

        private static string BeautifyContent(string content)
        {
            var fixedcontent = new StringBuilder();
            var lines = content.Split('\n').ToList();
            var lastline = string.Empty;
            var indent = 0;
            foreach (var line in lines.Select(l => l.Trim()))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    if (lastline.Equals("}") && !line.Equals("}") && !line.StartsWith("public enum"))
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
                    fixedcontent.AppendLine(string.Concat(Enumerable.Repeat(indentstr, indent)) + line);
                    lastline = line;
                }
            }
            return fixedcontent.ToString();
        }

        private static string GetEntity(EntityMetadataProxy entitymetadata, Settings settings)
        {
            var name = entitymetadata.GetNameTechnical(settings.ConstantName, settings);
            name = settings.commonsettings.EntityPrefix + name + settings.commonsettings.EntitySuffix;
            var description = entitymetadata.Description?.Replace("\n", "\n/// ");
            var summary = settings.XmlProperties ? entitymetadata.GetEntityProperties(settings) : settings.XmlDescription ? description : string.Empty;
            var remarks = settings.XmlProperties && settings.XmlDescription ? description : string.Empty;
            var entity = new StringBuilder();
            if (!string.IsNullOrEmpty(summary))
            {
                entity.AppendLine($"/// <summary>{summary}</summary>");
            }
            if (!string.IsNullOrEmpty(remarks))
            {
                entity.AppendLine($"/// <remarks>{remarks}</remarks>");
            }
            entity.AppendLine(entitytemplate
                .Replace("{entity}", name)
                .Replace("{logicalname}", entitymetadata.LogicalName)
                .Replace("'", "\"")
                .Replace("{attributes}", GetAttributes(entitymetadata, settings))
                .Replace("{optionsets}", GetOptionSets(entitymetadata, settings)));
            return entity.ToString();
        }

        private static string GetAttributes(EntityMetadataProxy entitymetadata, Settings settings)
        {
            var attributes = new List<string>();
            if (entitymetadata.Attributes != null)
            {
                if (entitymetadata.PrimaryKey?.IsSelected == true)
                {   // First Primary Key
                    attributes.Add(GetAttribute(entitymetadata.PrimaryKey, settings));
                }
                if (entitymetadata.PrimaryName?.IsSelected == true)
                {   // Then Primary Name
                    attributes.Add(GetAttribute(entitymetadata.PrimaryName, settings));
                }
                foreach (var attributemetadata in entitymetadata.Attributes
                    .Where(a => a.Selected && a.Metadata.IsPrimaryId != true && a.Metadata.IsPrimaryName != true))
                {   // Then all the rest
                    var attribute = GetAttribute(attributemetadata, settings);
                    attributes.Add(attribute);
                }
            }
            return string.Join("\r\n", attributes);
        }

        private static string GetOptionSets(EntityMetadataProxy entitymetadata, Settings settings)
        {
            var optionsets = new StringBuilder();
            if (settings.OptionSets && entitymetadata.Attributes != null)
            {
                foreach (var attributemetadata in entitymetadata.Attributes.Where(a => a.Selected && (a.Metadata is EnumAttributeMetadata)))
                {
                    string optionset = GetOptionSet(attributemetadata, settings);
                    optionsets.AppendLine(optionset);
                }
            }
            return optionsets.ToString();
        }

        private static string GetAttribute(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            var name = attributemetadata.Metadata.IsPrimaryId == true ? "PrimaryKey" :
                attributemetadata.Metadata.IsPrimaryName == true ? "PrimaryName" :
                attributemetadata.GetNameTechnical(settings);
            name = settings.commonsettings.AttributePrefix + name + settings.commonsettings.AttributeSuffix;
            var description = attributemetadata.Description?.Replace("\n", "\n/// ");
            var summary = settings.XmlProperties ? attributemetadata.AttributeProperties : settings.XmlDescription ? description : string.Empty;
            var remarks = settings.XmlProperties && settings.XmlDescription ? description : string.Empty;
            var attribute = new StringBuilder();
            if (!string.IsNullOrEmpty(summary))
            {
                attribute.AppendLine($"/// <summary>{summary}</summary>");
            }
            if (!string.IsNullOrEmpty(remarks))
            {
                attribute.AppendLine($"/// <remarks>{remarks}</remarks>");
            }
            attribute.AppendLine(attributetemplate
                .Replace("{attribute}", name)
                .Replace("{logicalname}", attributemetadata.LogicalName)
                .Replace("'", "\""));
            return attribute.ToString();
        }

        private static string GetOptionSet(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            var name = settings.commonsettings.OptionSetEnumPrefix + attributemetadata.GetNameTechnical(settings) + settings.commonsettings.OptionSetEnumSuffix;
            var optionset = optionsettemplate.Replace("{name}", name);
            var options = new List<string>();
            var optionsetmetadata = attributemetadata.Metadata as EnumAttributeMetadata;
            if (optionsetmetadata != null && optionsetmetadata.OptionSet != null)
            {
                foreach (var optionmetadata in optionsetmetadata.OptionSet.Options)
                {
                    var label = MetadataProxy.StringToCSharpIdentifier(optionmetadata.Label.UserLocalizedLabel.Label);
                    if (settings.ConstantCamelCased)
                    {
                        label = CamelCaseIt(label);
                    }
                    if (string.IsNullOrEmpty(label) || int.TryParse(label[0].ToString(), out int tmp))
                    {
                        label = "_" + label;
                    }
                    var option = optionsetvaluetemplate
                        .Replace("{name}", label)
                        .Replace("{value}", optionmetadata.Value.ToString());
                    options.Add(option);
                }
            }
            optionset = optionset.Replace("{values}", string.Join(",\r\n", options));
            return optionset;
        }

        internal static string CamelCaseIt(string name)
        {
            bool wordBeginOrEnd(string text, int i)
            {
                var words = new string[] { "parent", "customer", "owner", "state", "status", "name", "phone", "address", "code", "postal", "mail", "modified", "created", "type", "method", "verson", "number", "first", "last", "middle", "contact", "account", "system", "user", "fullname", "preferred", "processing", "annual", "plugin", "step", "key", "details", "message", "description", "constructor", "execution", "secure", "configuration", "behalf", "count", "percent", "internal", "external", "trace", "entity", "primary", "secondary" };
                var endwords = new string[] { "id" };
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
                    nextCapital = nextCapital || wordBeginOrEnd(name, i);
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

        private static void AlignSplitters(List<string> lines, string splitter)
        {
            var attlen = lines.Count > 0 ? lines.Max(a => a.IndexOf(splitter)) : 0;
            for (var i = 0; i < lines.Count; i++)
            {
                var attribute = lines[i];
                var equal = attribute.IndexOf(splitter);
                lines[i] = attribute.Substring(0, equal) + new string(' ', attlen - equal) + attribute.Substring(equal);
            }
        }
    }
}