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
// *** Latebound Constant Generator for XrmToolBox produced this file.
// *** Author: Jonas Rapp http://twitter.com/rappen
// *** Repo: https://github.com/rappen/LateboundConstantGenerator
// *** Feel free to edit the file as you please,
// *** you can always regenerate it!
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
        private const string attributetemplate = @"        public const string {attribute} = '{logicalname}';";
        private const string optionsettemplate = @"        public enum V_{name}
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
                    var filename = (settings.UseCommonFileDisplay ? entitymetadata.CSharpName : entitymetadata.LogicalName) + ".cs";
                    var entityfile = file.Replace("{entities}", entity.TrimEnd());
                    File.WriteAllText(Path.Combine(settings.OutputFolder, filename), FileWithHeader(entityfile));
                    savefiles.Add(filename);
                }
                else
                {
                    entities.AppendLine(entity);
                }
            }
            file = file.Replace("{entities}", entities.ToString().TrimEnd());
            if (settings.UseCommonFile)
            {
                var filename = Path.Combine(settings.OutputFolder, settings.CommonFile + ".cs");
                File.WriteAllText(filename, FileWithHeader(file));
                MessageBox.Show($"Saved constants to\n  {filename}");
            }
            else
            {
                MessageBox.Show($"Saved files\n  {string.Join("\n  ", savefiles)}\nto folder\n  {settings.OutputFolder}");
            }
        }

        private static string FileWithHeader(string file)
        {
            return copy + "\r\n\r\n" + file;
        }

        private static string GetEntity(EntityMetadataProxy entitymetadata, Settings settings)
        {
            return entitytemplate
                .Replace("{entity}", settings.UseConstNameDisplay ? entitymetadata.CSharpName : entitymetadata.LogicalName)
                .Replace("{logicalname}", entitymetadata.LogicalName)
                .Replace("'", "\"")
                .Replace("{attributes}", GetAttributes(entitymetadata, settings))
                .Replace("{optionsets}", GetOptionSets(entitymetadata, settings))
                .Replace("\r\n\r\n", "\r\n");
        }

        private static string GetAttributes(EntityMetadataProxy entitymetadata, Settings settings)
        {
            var attributes = new StringBuilder();
            if (entitymetadata.Attributes != null)
            {
                if (entitymetadata.PrimaryKey?.IsSelected == true)
                {   // First Primary Key
                    attributes.AppendLine(GetAttribute(entitymetadata.PrimaryKey, settings));
                }
                if (entitymetadata.PrimaryName?.IsSelected == true)
                {   // Then Primary Name
                    attributes.AppendLine(GetAttribute(entitymetadata.PrimaryName, settings));
                }
                foreach (var attributemetadata in entitymetadata.Attributes
                    .Where(a => a.Selected && a.Metadata.IsPrimaryId != true && a.Metadata.IsPrimaryName != true))
                {   // Then all the rest
                    var attribute = GetAttribute(attributemetadata, settings);
                    attributes.AppendLine(attribute);
                }
            }
            return attributes.ToString().TrimEnd();
        }

        private static string GetOptionSets(EntityMetadataProxy entitymetadata, Settings settings)
        {
            var optionsets = new StringBuilder();
            if (settings.OptionSets)
            {
                foreach (var attributemetadata in entitymetadata.Attributes.Where(a => a.Selected && a.Metadata.AttributeType == AttributeTypeCode.Picklist))
                {
                    string optionset = GetOptionSet(attributemetadata, settings);
                    optionsets.AppendLine(optionset);
                }
            }
            return optionsets.ToString().TrimEnd();
        }

        private static string GetAttribute(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            var name = attributemetadata.Metadata.IsPrimaryId == true ? "PrimaryKey" :
                attributemetadata.Metadata.IsPrimaryName == true ? "PrimaryName" :
                "A_" + (settings.UseConstNameDisplay ? attributemetadata.CSharpName : attributemetadata.LogicalName);
            return attributetemplate
                .Replace("{attribute}", name)
                .Replace("{logicalname}", attributemetadata.LogicalName)
                .Replace("'", "\"");
        }

        private static string GetOptionSet(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            var optionset = optionsettemplate.Replace("{name}", settings.UseConstNameDisplay ? attributemetadata.CSharpName : attributemetadata.LogicalName);
            var options = new List<string>();
            var optionsetmetadata = attributemetadata.Metadata as EnumAttributeMetadata;
            if (optionsetmetadata != null)
            {
                foreach (var optionmetadata in optionsetmetadata.OptionSet.Options)
                {
                    var label = optionmetadata.Label.UserLocalizedLabel.Label;
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
            optionset = optionset.Replace("{values}", string.Join(",\r\n", options));
            return optionset;
        }
    }
}