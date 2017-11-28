using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rappen.XTB.LCG
{
    internal class CSharpUtils
    {
        #region Templates

        private const string copy = @"// ********************************************************************
// *** Created by: Latebound Constant Generator {version} for XrmToolBox
// *** Author    : Jonas Rapp http://twitter.com/rappen
// *** Repo      : https://github.com/rappen/LateboundConstantGenerator
// *** Created   : {timestamp}
// *** Location  : {location}
// *******************************************************************";

        private const string namespacetemplate = @"namespace {namespace}
{
{entities}
}";
        private const string entitytemplate = @"    public static class {entity}
    {
        public const string EntityName = '{logicalname}';
{attributes}
{optionsets}
    }";
        private const string attributetemplate = @"        public const string {attribute} = '{logicalname}';    // {type}";
        private const string optionsettemplate = @"        public enum {name}
        {
{values}
        }";
        private const string optionsetvaluetemplate = @"            {name} = {value}";

        #endregion Templates

        internal static void GenerateClasses(List<EntityMetadataProxy> entitiesmetadata, Settings settings)
        {
            var savefiles = new List<string>();
            var file = namespacetemplate.Replace("{namespace}", settings.NameSpace);

            var entities = new StringBuilder();
            foreach (var entitymetadata in entitiesmetadata.Where(e => e.Selected))
            {
                var entity = GetEntity(entitymetadata, settings);
                if (!settings.UseCommonFile)
                {
                    var filename = entitymetadata.GetNameTechnical(settings.FileName) + ".cs";
                    var entityfile = file.Replace("{entities}", entity);
                    WriteFile(Path.Combine(settings.OutputFolder, filename), entityfile);
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
                WriteFile(filename, file);
                message = $"Saved constants to\n  {filename}";
            }
            else
            {
                message = $"Saved files\n  {string.Join("\n  ", savefiles)}\nto folder\n  {settings.OutputFolder}";
            }
            MessageBox.Show(message, "Latebound Constant Generator", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private static void WriteFile(string filename, string content)
        {
            var lines = content.Split('\n').ToList();
            var fixedcontent = new StringBuilder();
            var lastline = string.Empty;
            foreach (var line in lines.Select(l => l.TrimEnd()))
            {
                if (!string.IsNullOrEmpty(line))
                {
                    if (lastline.Trim().Equals("}") && !line.Trim().Equals("}") && !line.Trim().StartsWith("public enum"))
                    {
                        fixedcontent.AppendLine();
                    }
                    fixedcontent.AppendLine(line);
                    lastline = line;
                }
            }
            content = copy
                .Replace("{timestamp}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .Replace("{location}", filename) + "\r\n\r\n" + fixedcontent.ToString();
            File.WriteAllText(filename, content);
        }

        private static string GetEntity(EntityMetadataProxy entitymetadata, Settings settings)
        {
            var name = entitymetadata.GetNameTechnical(settings.ConstantName);
            if (settings.ConstantName != NameType.DisplayName &&
                settings.DoStripPrefix && !string.IsNullOrEmpty(settings.StripPrefix) &&
                name.ToLowerInvariant().StartsWith(settings.StripPrefix))
            {
                name = name.Substring(settings.StripPrefix.Length);
            }
            return entitytemplate
                .Replace("{entity}", name)
                .Replace("{logicalname}", entitymetadata.LogicalName)
                .Replace("'", "\"")
                .Replace("{attributes}", GetAttributes(entitymetadata, settings))
                .Replace("{optionsets}", GetOptionSets(entitymetadata, settings));
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
            AlignSplitters(attributes, "=");
            AlignSplitters(attributes, "//");
            return string.Join("\r\n", attributes);
        }

        private static string GetOptionSets(EntityMetadataProxy entitymetadata, Settings settings)
        {
            var optionsets = new StringBuilder();
            if (settings.OptionSets && entitymetadata.Attributes != null)
            {
                foreach (var attributemetadata in entitymetadata.Attributes.Where(a => a.Selected && a.Metadata.AttributeType == AttributeTypeCode.Picklist))
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
                attributemetadata.GetNameTechnical(settings.ConstantName);
            if (settings.ConstantName != NameType.DisplayName &&
                settings.DoStripPrefix && !string.IsNullOrEmpty(settings.StripPrefix) &&
                name.ToLowerInvariant().StartsWith(settings.StripPrefix))
            {
                name = name.Substring(settings.StripPrefix.Length);
            }
            return attributetemplate
                .Replace("{attribute}", name)
                .Replace("{logicalname}", attributemetadata.LogicalName)
                .Replace("{type}", attributemetadata.Type.ToString())
                .Replace("'", "\"");
        }

        private static string GetOptionSet(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            var optionset = optionsettemplate.Replace("{name}", attributemetadata.GetNameTechnical(settings.ConstantName));
            var options = new List<string>();
            var optionsetmetadata = attributemetadata.Metadata as EnumAttributeMetadata;
            if (optionsetmetadata != null)
            {
                foreach (var optionmetadata in optionsetmetadata.OptionSet.Options)
                {
                    var label = MetadataProxy.StringToCSharpIdentifier(optionmetadata.Label.UserLocalizedLabel.Label);
                    if (int.TryParse(label, out int tmp))
                    {
                        label = "_" + label;
                    }
                    var option = optionsetvaluetemplate
                        .Replace("{name}", label)
                        .Replace("{value}", optionmetadata.Value.ToString());
                    options.Add(option);
                }
            }
            AlignSplitters(options, "=");
            optionset = optionset.Replace("{values}", string.Join(",\r\n", options));
            return optionset;
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