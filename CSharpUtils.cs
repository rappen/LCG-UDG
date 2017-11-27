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
        private const string copy = @"// *************************************************
// *** Latebound Constant Generator for XrmToolBox
// *** by Jonas Rapp http://twitter.com/rappen
// *** produced this file.
// *** Feel free to edit the file as you please,
// *** you can always regenerate it!
// *************************************************";

        private const string namespacetemplate = @"namespace {namespace}
{
{entities}
}";
        private const string entitytemplate = @"    public static class {entity}
    {
        public const string E_{entity} = '{logicalname}';
{attributes}
    }";
        private const string attributetemplate = @"        public const string A_{attribute} = '{logicalname}';";

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
                    var filename = (settings.UseCommonFileDisplay ? CodifyDisplayName(entitymetadata.DisplayName) : entitymetadata.LogicalName) + ".cs";
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
            var entity = entitytemplate
                .Replace("{entity}", settings.UseConstNameDisplay ? CodifyDisplayName(entitymetadata.DisplayName) : entitymetadata.LogicalName)
                .Replace("{logicalname}", entitymetadata.LogicalName)
                .Replace("'", "\"");
            var attributes = new StringBuilder();
            if (entitymetadata.Attributes != null)
            {
                foreach (var attributemetadata in entitymetadata.Attributes.Where(a => a.Selected))
                {
                    string attribute = GetAttribute(attributemetadata, settings);
                    attributes.AppendLine(attribute);
                }
            }
            entity = entity.Replace("{attributes}", attributes.ToString().TrimEnd());
            return entity;
        }

        private static string GetAttribute(AttributeMetadataProxy attributemetadata, Settings settings)
        {
            return attributetemplate
                .Replace("{attribute}", settings.UseConstNameDisplay ? CodifyDisplayName(attributemetadata.DisplayName) : attributemetadata.LogicalName)
                .Replace("{logicalname}", attributemetadata.LogicalName)
                .Replace("'", "\"");
        }

        private static string CodifyDisplayName(string name)
        {
            return System.Text.Encoding.UTF8.GetString(System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(name))
                .Replace(" ", "").Replace("(", "").Replace(")", "");
        }
    }

    namespace Cinteros.MMS.MUA.Core.Const
    {
        public static class Assignment
        {
            public const string A_AccountId = "cint_mms_mua_account_id";
            public const string A_AssignmentParty = "cint_assignment_party";
            public const string A_AssignmentPartyType = "cint_assignment_party_type";
            public const string A_AssignmentTypeId = "cint_assignment_type_id";
            public const string A_ContactId = "cint_mms_mua_contact_id";
            public const string A_Description = "cint_description";
            public const string A_IncidentCreated = "cint_incident_created";
            public const string A_LocalUnionId = "cint_local_union_id";
            public const string A_OrganizationId = "cint_mms_mua_organization_id";
            public const string A_RegionId = "cint_mms_mua_region_id";
            public const string A_SectionId = "cint_mms_mua_union_sub_section_id";
            public const string A_SiteId = "cint_site_id";
            public const string A_UnionId = "cint_union_id";
            public const string A_UnionSectionId = "cint_union_section_id";

            public const string CFG_AssignmentsWithoutMembership = "MMS_MUA_AssignmentsWithoutMembership";
            public const string CFG_AssignmentVerifyLocalUnionfetch = "MMS_MUA_Assignment_Verify_LocalUnion_Fetch";
            public const string CFG_AutoCloseFlag = "MMS_MUA_AssignmentAutoClose";
            public const string CFG_AutoCloseIncidentTemplate = "MMS_MUA_IncidentAssignmentTemplate";
            public const string CFG_AutoCloseIncidentTypeCode = "MMS_MUA_IncidentTypeAutoCloseAssignment";

            public const string E_Assignment = "cint_mms_mua_assignment";

            public const string MSG_AssigmentBlockedByPartyType = "MMS_MUA_AssigmentBlockedByPartyType";
            public const string MSG_AssignmentBlockedByMembershipType = "MMS_MUA_AssigmentBlockedByMembershipType";
            public const string MSG_AssignmentBlockedByMembershipTypeAll = "MMS_MUA_AssigmentBlockedByMembershipTypeAll";
            public const string MSG_AssignmentMembershipTypeConflict = "MMS_MUA_AssigmentMembershipTypeConflict";
            public const string MSG_AssignmentMembershipTypeDiff = "MMS_MUA_AssigmentMembershipTypeDiff";
            public const string MSG_AssignmentNoActiveMemberships = "MMS_MUA_AssignmentNoActiveMemberships";
            public const string MSG_AssignmentTooManyOfSameType = "MMS_MUA_AssignmentTooManyOfSameType";
            public const string MSG_AssignmentTooManyParties = "MMS_MUA_AssignmentTooManyParties";
            public const string MSG_AssignmentTypeIncompatibleExists = "MMS_MUA_AssignmentTypeIncompatibleExists";

            public enum V_BlockLevel
            {
                /// <summary>
                /// Förbund
                /// </summary>
                Union = 1,

                /// <summary>
                /// Avdelning
                /// </summary>
                UnionSection = 2,

                /// <summary>
                /// Region
                /// </summary>
                Region = 3,

                /// <summary>
                /// Klubb
                /// </summary>
                LocalUnion = 4
            }

            public enum OptionSet_AssignmentParty
            {
                Union = 478880000,
                UnionSection = 478880001,
                Region = 478880002,
                LocalUnion = 478880003,
                Organization = 478880004,
                Site = 478880005,
                Account = 478880006,
                Extern = 478880007,
                Section = 478880008
            }

            public enum Status
            {
                Active = 1,
                Inactive = 478880000,
                Finished = 478880001
            }
        }
    }
}