using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Rappen.XTB.Helper;
using Rappen.XTB.Helpers;
using Rappen.XTB.LCG.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace Rappen.XTB.LCG
{
    public partial class LCG : PluginControlBase, IGitHubPlugin, IPayPalPlugin, IAboutPlugin, IHelpPlugin, IMessageBusHost
    {
        #region Private Fields

        internal static string toolnameLCG = "Latebound Constants Generator";
        internal static string toolnameUDG = "UML Diagram Generator";
        internal bool isUML => toolname == toolnameUDG;
        internal readonly TemplateFormat templFormat = TemplateFormat.Constants;
        internal readonly string toolname = toolnameLCG;

        private const string aiEndpoint = "https://dc.services.visualstudio.com/v2/track";
        private const string aiKey1 = "eed73022-2444-45fd-928b-5eebd8fa46a6";    // jonas@rappen.net tenant, XrmToolBox
        private const string aiKey2 = "d46e9c12-ee8b-4b28-9643-dae62ae7d3d4";    // jonas@jonasr.app, XrmToolBoxTools
        private readonly AppInsights ai1;
        private readonly AppInsights ai2;

        private readonly string commonsettingsfile = "[Common]";
        private readonly string globalsettingsfile = "[Global]";
        private object checkedrow;
        private List<EntityMetadataProxy> entities;
        private Dictionary<string, int> groupBoxHeights;
        private string lasttriedattributeload;
        private bool restoringselection = false;
        private EntityMetadataProxy selectedEntity;
        private Settings settings;
        private string settingsfile;
        private bool generatedfileprompted = false;

        #endregion Private Fields

        #region Interface implementations

        public string DonationDescription => $"{toolname} Fan Club";
        public string EmailAccount => "jonas@rappen.net";
        public string RepositoryName => "LCG-UDG";
        public string UserName => "rappen";

        public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string HelpUrl => isUML ? "https://jonasr.app/UML" : "https://jonasr.app/LCG";

        public event EventHandler<MessageBusEventArgs> OnOutgoingMessage;

        public void ShowAboutDialog()
        {
            tslAbout_Click(null, null);
        }

        public void OnIncomingMessage(MessageBusEventArgs message)
        {
            MessageBox.Show("Sorry, we can't handle incoming from other tools.\n\nWhat features would you like to see?\nClick on the Help button to add your requests there!", "Incoming", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0, "https://github.com/rappen/LCG-UDG/issues/new");
        }

        #endregion Interface implementations

        #region Public Constructors

        public LCG(bool isuml)
        {
            toolname = isuml ? toolnameUDG : toolnameLCG;
            UrlUtils.TOOL_NAME = toolname.Replace(" ", "");

            ai1 = new AppInsights(aiEndpoint, aiKey1, Assembly.GetExecutingAssembly(), toolname);
            ai2 = new AppInsights(aiEndpoint, aiKey2, Assembly.GetExecutingAssembly(), toolname);

            IEnumerable<Control> GetAll(Control control, Type type)
            {
                var controls = control.Controls.Cast<Control>().ToArray();
                return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                          .Concat(controls)
                                          .Where(c => c.GetType() == type);
            }

            InitializeComponent();
            tslAbout.ToolTipText = $"Version: {Assembly.GetExecutingAssembly().GetName().Version}";
            groupBoxHeights = new Dictionary<string, int>();
            foreach (var gb in GetAll(this, typeof(GroupBox)))
            {
                groupBoxHeights.Add(gb.Name, gb.Height);
            }
            FixFormForSettings();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            if (settings.TemplateSettings != null)
            {
                SettingsManager.Instance.Save(GetType(), settings.TemplateSettings, SettingsFileName(isUML, commonsettingsfile));
            }
            SaveSettings(ConnectionDetail?.ConnectionName);
            LogUse("Close");
            base.ClosingPlugin(info);
        }

        #endregion Public Methods

        #region Private Event Handlers

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LogUse($"Generate {settings.UseCommonFile}");
            if (!GetFileSettings(sender == btnSaveCsAs))
            {
                return;
            }
            GetSettingsFromUI();
            GetSelectionFromUI();
            var filewriter = settings.GetWriter(ConnectionDetail.WebApplicationUrl);
            if (GenerationUtils.GenerateFiles(entities.Where(ent => ent.Selected).ToList(), settings, filewriter))
            {
                var message = filewriter.GetResult(settings);
                if (isUML)
                {
                    ShowInfoNotification(message + "\nClick \"learn more\" to the right to open file 👉", new Uri("file://" + settings.CommonFilePath));
                }
                else
                {
                    ShowInfoNotification(message, null);
                }
                tmHideNotification.Start();
            }
        }

        private void btnLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadSolutions);
        }

        private void btnOpenGeneratedFile_Click(object sender, EventArgs e)
        {
            var filters = Settings.FileFilter(settings.TemplateFormat);
            Enum.GetValues(typeof(TemplateFormat))
               .Cast<TemplateFormat>()
               .Where(f => f != settings.TemplateFormat)
               .ToList()
               .ForEach(format => filters += $"|{Settings.FileFilter(format)}");
            filters += "|Project XML file (*.xml)|*.xml";
            filters += "|All files (*.*)|*.*";
            var ofd = new OpenFileDialog
            {
                Title = $"Load generated {Settings.FileType(settings.TemplateFormat)} file with configuration",
                Filter = filters,
                InitialDirectory = settings.OutputFolder,
                FileName = settings.CommonFile
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                settings.OutputFolder = Path.GetDirectoryName(ofd.FileName);
                settings.CommonFile = Path.GetFileNameWithoutExtension(ofd.FileName);
                if (File.Exists(ofd.FileName))
                {
                    ApplyEmbeddedConfiguration(ofd.FileName);
                }
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            GetSettingsFromUI();
            if (isUML)
            {
                FormatDialogUML.GetSettings(this, settings);
            }
            else
            {
                FormatDialogLCG.GetSettings(this, settings);
            }
            FixFormForSettings();
        }

        private void btnSaveConfigAs_Click(object sender, EventArgs e)
        {
            if (sender == btnSaveConfigAs || string.IsNullOrWhiteSpace(settingsfile))
            {
                var sfd = new SaveFileDialog
                {
                    Title = "Save settings and selections",
                    Filter = "XML file (*.xml)|*.xml",
                    FileName = settingsfile
                };
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                settingsfile = sfd.FileName;
            }
            GetSettingsFromUI();
            GetSelectionFromUI();
            settings.Version = Version;
            XmlSerializerHelper.SerializeToFile(settings, settingsfile);
            ShowInfoNotification($"Saved project as: {settingsfile}", null);
            tmHideNotification.Start();
        }

        private void chkAllRows_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            var grid = chk == chkEntAll ? gridEntities : chk == chkAttAll ? gridAttributes : chk == chkRelAll ? gridRelationships : null;
            if (grid != null)
            {
                SelectAllRows(grid, chk.Checked);
            }
        }

        private void cmbSolution_DropDown(object sender, EventArgs e)
        {
            if (cmbSolution.Width < 400)
            {
                cmbSolution.Tag = cmbSolution.Width;
                cmbSolution.Width = 500;
            }
            else
            {
                cmbSolution.Tag = null;
            }
        }

        private void cmbSolution_DropDownClosed(object sender, EventArgs e)
        {
            if (cmbSolution.Tag is int width)
            {
                cmbSolution.Width = width;
            }
            cmbSolution.Tag = null;
        }

        private void filter_attribute_Changed(object sender, EventArgs e)
        {
            DisplayFilteredAttributes();
        }

        private void filter_entity_Changed(object sender, EventArgs e)
        {
            DisplayFilteredEntities();
        }

        private void filter_relationship_Changed(object sender, EventArgs e)
        {
            DisplayFilteredRelationships();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView grid && e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                var row = grid.Rows[e.RowIndex];
                if (row.DataBoundItem is MetadataProxy metadata)
                {
                    checkedrow = metadata;
                    metadata.SetSelected(!metadata.IsSelected);
                    checkedrow = null;

                    if (metadata is EntityMetadataProxy entitymeta && !metadata.IsSelected && chkRelRemoveWhenUncheckedEntity.Checked)
                    {
                        var rels = entities
                           .Where(ent => ent.Relationships != null)
                           .SelectMany(ent => ent.Relationships)
                           .Where(rel => rel.OtherEntity == entitymeta)
                           .ToList();
                        rels.ForEach(rel => rel.SetSelected(false));
                    }
                }
            }
        }

        private void gridEntities_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (sender is DataGridView dgv &&
                dgv.Rows[e.RowIndex].DataBoundItem is EntityMetadataProxy data)
            {
                if (e.ColumnIndex == 0 &&
                    !string.IsNullOrEmpty(data.Metadata.EntityColor))
                {
                    e.CellStyle.BackColor = ColorTranslator.FromHtml(data.Metadata.EntityColor);
                }
                if (e.ColumnIndex == 3 &&
                    data.Group is EntityGroup group &&
                    group.Color != null)
                {
                    e.CellStyle.BackColor = group.Color;
                }
            }
        }

        private void gridEntities_SelectionChanged(object sender, EventArgs e)
        {
            EntitySelected(false);
        }

        private void LCG_ConnectionUpdated(object sender, ConnectionUpdatedEventArgs e)
        {
            LogInfo("Connection has changed to: {0}", e.ConnectionDetail.WebApplicationUrl);
            lasttriedattributeload = string.Empty;
            chkEntAll.Visible = false;
            chkAttAll.Visible = false;
            menuOpen.Enabled = false;
            entities = null;
            selectedEntity = null;
            gridRelationships.DataSource = null;
            gridAttributes.DataSource = null;
            gridEntities.DataSource = null;
            LoadSettings(e.ConnectionDetail?.ConnectionName);
            LoadSolutions();
            Enabled = true;
        }

        private void LCG_Load(object sender, EventArgs e)
        {
            LoadGlobalSetting();
            if (settings != null && settings.TemplateSettings == null)
            {
                LoadCommonSettings();
            }
            LogUse("Load", ai2: true);
            Supporting.ShowIf(this, false, true, ai2);
            if (Supporting.IsEnabled(this))
            {
                tsbSupporting.Visible = true;
                var supptype = Supporting.IsSupporting(this);
                switch (supptype)
                {
                    case SupportType.Company:
                        tsbSupporting.Image = Resources.We_Support_icon;
                        break;

                    case SupportType.Personal:
                        tsbSupporting.Image = Resources.I_Support_icon;
                        break;

                    case SupportType.Contribute:
                        tsbSupporting.Image = Resources.I_Contribute_icon;
                        break;
                }
            }
            else
            {
                tsbSupporting.Visible = false;
            }
        }

        private void llGroupBoxExpander_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GroupBoxToggle(sender as LinkLabel);
        }

        private void tmAttSearch_Tick(object sender, EventArgs e)
        {
            tmAttSearch.Stop();
            DisplayFilteredAttributes();
        }

        private void tmEntSearch_Tick(object sender, EventArgs e)
        {
            tmEntSearch.Stop();
            DisplayFilteredEntities();
        }

        private void tmRelSearch_Tick(object sender, EventArgs e)
        {
            tmRelSearch.Stop();
            DisplayFilteredRelationships();
        }

        private void tslAbout_Click(object sender, EventArgs e)
        {
            LogUse("OpenAbout");
            var about = new About(this)
            {
                StartPosition = FormStartPosition.CenterParent,
                lblVersion = { Text = Assembly.GetExecutingAssembly().GetName().Version.ToString() }
            };
            about.ShowDialog();
        }

        private void txtAttSearch_TextChanged(object sender, EventArgs e)
        {
            tmAttSearch.Stop();
            tmAttSearch.Start();
        }

        private void txtEntSearch_TextChanged(object sender, EventArgs e)
        {
            tmEntSearch.Stop();
            tmEntSearch.Start();
        }

        private void txtRelSearch_TextChanged(object sender, EventArgs e)
        {
            tmRelSearch.Stop();
            tmRelSearch.Start();
        }

        private void tmHideNotification_Tick(object sender, EventArgs e)
        {
            tmHideNotification.Stop();
            HideNotification();
        }

        private void picAttReloadRecords_Click(object sender, EventArgs e)
        {
            if (selectedEntity == null)
            {
                return;
            }
            var withvalue = chkAttUsed.Checked;
            var uniques = chkAttUniques.Checked;
            selectedEntity.CountedAttributes = false;
            selectedEntity.Attributes.ForEach(a => a.WithValues = null);
            selectedEntity.Attributes.ForEach(a => a.UniqueValues = null);
            chkAttUsed.Checked = withvalue;
            chkAttUniques.Checked = uniques;
            DisplayFilteredAttributes();
        }

        private void ctxRelAddRemAccount_Click(object sender, EventArgs e)
        {
            if (entities.FirstOrDefault(ent => ent.LogicalName == "account") is EntityMetadataProxy entity)
            {
                entity.SetSelected(!entity.Selected);
            }
        }

        private void btnSelectAllVisible_Click(object sender, EventArgs e)
        {
            SelectAllRows(sender == btnEntSelectAllVisible ? gridEntities :
                          sender == btnAttSelectAllVisible ? gridAttributes :
                          sender == btnRelSelectAllVisible ? gridRelationships : null, true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm removing all selected items!", "Unselect all", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
            {
                return;
            }
            UnselectAll(sender == btnEntUnselectAll ? entities?.Select(m => (MetadataProxy)m) :
                        sender == btnAttUnselectAll ? selectedEntity?.Attributes?.Select(m => (MetadataProxy)m) :
                        sender == btnRelUnselectAll ? selectedEntity?.Relationships?.Select(m => (MetadataProxy)m) : null);
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (sender == btnEntShowAll)
            {
                cmbSolution.SelectedIndex = -1;
                cmbSolution.SelectedItem = null;
                triEntCustom.CheckState = CheckState.Checked;
                triEntManaged.CheckState = CheckState.Checked;
                chkEntExclIntersect.Checked = false;
                chkEntExclMS.Checked = false;
                triEntSelected.CheckState = CheckState.Checked;
                triEntRecords.CheckState = CheckState.Checked;
                txtEntSearch.Text = "";
            }
            else if (sender == btnAttShowAll)
            {
                triAttCustom.CheckState = CheckState.Checked;
                triAttManaged.CheckState = CheckState.Checked;
                triAttPrimaryKeyName.CheckState = CheckState.Checked;
                triAttRequired.CheckState = CheckState.Checked;
                triAttLogical.CheckState = CheckState.Unchecked;
                triAttInternal.CheckState = CheckState.Unchecked;
                chkAttExclOwners.Checked = false;
                chkAttExclCreMod.Checked = false;
                chkAttUsed.Checked = false;
                chkAttUniques.Checked = false;
                txtAttSearch.Text = "";
            }
            else if (sender == btnRelShowAll)
            {
                triRelCustom.CheckState = CheckState.Checked;
                triRelManaged.CheckState = CheckState.Checked;
                chkRel1N.Checked = true;
                chkRelN1.Checked = true;
                chkRelNN.Checked = true;
                chkRelExclOrphans.Checked = false;
                chkRelExclOwners.Checked = false;
                chkRelExclRegarding.Checked = false;
                chkRelExclCreMod.Checked = false;
                chkRelExclDupRecords.Checked = false;
                txtRelSearch.Text = "";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            btnCancel.Enabled = false;
            CancelWorker();
        }

        private void tsbSupporting_Click(object sender, EventArgs e)
        {
            Supporting.ShowIf(this, true, false, ai2);
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var group = cmbGroup.SelectedItem as EntityGroup;
            if (selectedEntity != null)
            {
                selectedEntity.Group = group;
                gridEntities.Refresh();
            }
            SelectGroup(group);
        }

        private void posGroupUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!(cmbGroup.SelectedItem is EntityGroup group))
            {
                return;
            }
            var pos = settings.Groups.IndexOf(group) + 1;
            if (pos == posGroupUpDown.Value)
            {
                return;
            }
            settings.Groups.Move(group, pos > (int)posGroupUpDown.Value);
            FillGroups(group);
            cmbGroup.DroppedDown = true;
        }

        private void btnGroupColor_Click(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedItem is EntityGroup group)
            {
                colorDialog1.Color = group.Color;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    group.Color = colorDialog1.Color;
                    SelectGroup(group);
                }
            }
        }

        private void btnGroupAdd_Click(object sender, EventArgs e)
        {
            var groupname = Extensions.ShowPrompt("Enter name of the new group.", "New Group");
            if (!string.IsNullOrEmpty(groupname))
            {
                SelectGroup(new EntityGroup { Name = groupname });
                gridEntities.Refresh();
            }
        }

        private void btnGroupDelete_Click(object sender, EventArgs e)
        {
            if (!(cmbGroup.SelectedItem is EntityGroup group))
            {
                return;
            }
            var grpents = entities.Where(ent => ent.Group == group).ToList();
            if (MessageBoxEx.Show(this, $"Deleting Group '{group}', used by {grpents.Count} entities.\n\nPlease confirm.", "Delete Group", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                grpents.ForEach(ent => ent.Group = null);
                gridEntities.Refresh();
                settings.Groups.Remove(group);
                cmbGroup.Items.Remove(group);
                SelectGroup(null);
            }
        }

        #endregion Private Event Handlers

        #region Private Methods

        internal void LogUse(string action, bool ai1 = true, bool ai2 = false)
        {
            if (ai1) this.ai1.WriteEvent(action);
            if (ai2) this.ai2.WriteEvent(action);
        }

        private static void SelectAllRows(DataGridView grid, bool select)
        {
            if (grid == null) return;
            grid.Rows
                .Cast<DataGridViewRow>()
                .Select(r => r.DataBoundItem)
                .OfType<MetadataProxy>()
                .ToList()
                .ForEach(m => m.SetSelected(select));
        }

        private static void UnselectAll(IEnumerable<MetadataProxy> metadatas)
        {
            metadatas?.ToList().ForEach(m => m.SetSelected(false));
        }

        private void AddToFilteredAttributes(IEnumerable<AttributeMetadataProxy> filteredAttributes, string attributeName)
        {
            if (selectedEntity.Attributes.FirstOrDefault(a => a.LogicalName == attributeName) is AttributeMetadataProxy att)
            {
                var result = filteredAttributes.ToList();
                if (result.Contains(att))
                {
                    result.Remove(att);
                }
                result.Insert(0, att);
                filteredAttributes = result;
            }
        }

        private void ApplyEmbeddedConfiguration(string filename)
        {
            Settings inlineconfig = null;
            try
            {
                inlineconfig = ConfigurationUtils.GetEmbeddedConfiguration<Settings>(filename, settings.TemplateSettings.InlineConfigBegin, settings.TemplateSettings.InlineConfigEnd);
                ShowInfoNotification("Loaded project embedded in file.", null);
            }
            catch (FileLoadException ex1)
            {
                if (filename.ToLowerInvariant().EndsWith(".xml"))
                {
                    try
                    {
                        var document = new XmlDocument();
                        document.Load(filename);
                        inlineconfig = (Settings)XmlSerializerHelper.Deserialize(document.OuterXml, typeof(Settings));
                        ShowInfoNotification("Loaded project file.", null);
                    }
                    catch (Exception ex2)
                    {
                        ShowErrorDialog(ex2, $"Open {filename}");
                        return;
                    }
                }
                else
                {
                    ShowErrorDialog(ex1, $"Open {filename}");
                    return;
                }
            }
            catch (Exception ex)
            {
                ShowErrorDialog(ex, $"Open {filename}");
                return;
            }
            if (inlineconfig == null)
            {
                return;
            }
            tmHideNotification.Start();
            settings.CopyInlineConfiguration(inlineconfig);
            ApplySettings();
            RestoreSelectedEntities();
        }

        private void ApplySettings()
        {
            restoringselection = true;
            triEntCustom.CheckState = settings.EntityFilter?.Custom ?? CheckState.Indeterminate;
            triEntManaged.CheckState = settings.EntityFilter?.Managed ?? CheckState.Indeterminate;
            chkEntExclIntersect.Checked = settings.EntityFilter?.ExcludeIntersect ?? false;
            triEntRecords.CheckState = settings.EntityFilter?.Records ?? CheckState.Indeterminate;
            chkEntShowUncountable.Checked = triEntRecords.CheckState != CheckState.Indeterminate && (settings.EntityFilter?.Uncountable ?? false);
            //chkEntSelected.Checked = settings.EntityFilter?.SelectedOnly ?? false;
            chkAttCheckAll.Checked = settings.AttributeFilter?.CheckAll ?? false;
            triAttCustom.CheckState = settings.AttributeFilter?.Custom ?? CheckState.Indeterminate;
            triAttManaged.CheckState = settings.AttributeFilter?.Managed ?? CheckState.Indeterminate;
            triAttPrimaryKeyName.CheckState = settings.AttributeFilter?.PrimaryKeyName ?? CheckState.Indeterminate;
            triAttRequired.CheckState = settings.AttributeFilter?.Required ?? CheckState.Indeterminate;
            triAttLogical.CheckState = settings.AttributeFilter?.Logical ?? CheckState.Unchecked;
            triAttInternal.CheckState = settings.AttributeFilter?.Internal ?? CheckState.Unchecked;
            chkAttExclCreMod.Checked = settings.AttributeFilter?.ExcludeCreMod ?? false;
            chkAttExclOwners.Checked = settings.AttributeFilter?.ExcludeOwner ?? false;
            //chkAttUsed.Checked = settings.AttributeFilter?.AreUsed ?? false;
            //chkAttUniques.Checked = settings.AttributeFilter?.UniqueValues ?? false;
            chkRelCheckAll.Checked = settings.RelationshipFilter?.CheckAll ?? false;
            triRelCustom.CheckState = settings.RelationshipFilter?.Custom ?? CheckState.Indeterminate;
            triRelManaged.CheckState = settings.RelationshipFilter?.Managed ?? CheckState.Indeterminate;
            chkRel1N.Checked = settings.RelationshipFilter?.Type1N ?? true;
            chkRelN1.Checked = settings.RelationshipFilter?.TypeN1 ?? true;
            chkRelNN.Checked = settings.RelationshipFilter?.TypeNN ?? true;
            chkRelExclOrphans.Checked = settings.RelationshipFilter?.ExcludeOrphans ?? false;
            chkRelExclOwners.Checked = settings.RelationshipFilter?.ExcludeOwner ?? false;
            chkRelExclRegarding.Checked = settings.RelationshipFilter?.ExcludeRegarding ?? false;
            chkRelExclCreMod.Checked = settings.RelationshipFilter?.ExcludeCreMod ?? false;
            chkRelExclDupRecords.Checked = settings.RelationshipFilter?.ExcludeDupRecords ?? false;
            chkRelReqLookups.Checked = settings.RelationshipFilter?.RequireLookups ?? false;
            GroupBoxSetState(llEntityExpander, settings.EntityFilter?.Expanded ?? true);
            GroupBoxSetState(llAttributeExpander, settings.AttributeFilter?.Expanded ?? true);
            GroupBoxSetState(llRelationshipExpander, settings.RelationshipFilter?.Expanded ?? true);
            FillGroups();
            toolTip1.SetToolTip(chkEntExclMS, $"Will not include with prefix:\r\n  {string.Join($"\r\n  ", OnlineSettings.Instance.MicrosoftPrefixes)}");
            FixFormForSettings();
            restoringselection = false;
        }

        private void DisplayAttributes()
        {
            if (selectedEntity != null && selectedEntity.Attributes == null)
            {
                LoadAttributes(selectedEntity, DisplayFilteredAttributes);
                return;
            }
            DisplayFilteredAttributes();
        }

        private void DisplayFilteredAttributes()
        {
            if (restoringselection)
            {
                return;
            }
            if (selectedEntity?.Attributes != null && selectedEntity.Attributes.Count > 0)
            {
                chkAttUniques.Enabled = chkAttUsed.Checked;
                picAttReloadRecords.Visible = chkAttUsed.Checked;
                if (!chkAttUsed.Checked && chkAttUniques.Checked)
                {
                    chkAttUniques.Checked = false;
                }
                GetSettingsFromUI();
                var filteredAttributes = GetFilteredAttributes(selectedEntity)?.ToList() ?? new List<AttributeMetadataProxy>();
                gridAttributes.DataSource = new SortableBindingList<AttributeMetadataProxy>(filteredAttributes);
                if (gridAttributes.Columns.Count > 0)
                {
                    gridAttributes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                    gridAttributes.Columns[0].Width = 30;
                    gridAttributes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    gridAttributes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            else
            {
                gridAttributes.DataSource = null;
            }
            UpdateAttributesStatus();
        }

        private void DisplayFilteredEntities()
        {
            chkEntShowUncountable.Enabled = triEntRecords.CheckState != CheckState.Indeterminate;
            if (entities != null && entities.Count > 0)
            {
                var filteredentities = GetFilteredEntities();
                if (cmbSolution.SelectedItem is SolutionProxy solution)
                {
                    if (solution.Entities == null)
                    {
                        LoadSolutionEntities(solution, DisplayFilteredEntities);
                        return;
                    }
                    filteredentities = filteredentities.Where(e => solution.Entities.Contains(e.LogicalName));
                }
                gridEntities.DataSource = new SortableBindingList<EntityMetadataProxy>(filteredentities);
                FixingEntityColumnWidths();
            }
            else
            {
                gridEntities.DataSource = null;
            }
            UpdateEntitiesStatus();
        }

        private void DisplayFilteredRelationships()
        {
            if (restoringselection)
            {
                return;
            }
            if (selectedEntity?.Relationships != null && selectedEntity.Relationships.Count > 0)
            {
                GetSettingsFromUI();
                var filteredRelationships = GetFilteredRelationships(selectedEntity, txtRelSearch.Text)
                    .OrderBy(r => r.LookupName)
                    .OrderBy(r => r.OtherEntity?.DisplayName)
                    .OrderBy(r => r.Type);
                gridRelationships.DataSource = new SortableBindingList<RelationshipMetadataProxy>(filteredRelationships);
                if (gridRelationships.Columns.Count > 0)
                {
                    gridRelationships.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
                    gridRelationships.Columns[0].Width = 30;
                }
            }
            else
            {
                gridRelationships.DataSource = null;
            }
            UpdateRelationshipssStatus();
        }

        private void EnableControls(bool enabled)
        {
            UpdateUI(() =>
            {
                Enabled = enabled;
            });
        }

        private void EntitySelected(bool force)
        {
            if (restoringselection)
            {
                return;
            }
            var entity = GetSelectedEntity();
            if (entity != null && (force || entity != selectedEntity))
            {
                selectedEntity = entity;
                SelectGroup(entity.Group);
                DisplayAttributes();
                DisplayFilteredRelationships();
            }
        }

        private void FixFormForSettings()
        {
            TabIcon = isUML ? Resources.UDG32 : Resources.LCG32;
            PluginIcon = isUML ? Resources.UDG16ico : Resources.LCG16ico;
            tslAbout.Image = isUML ? Resources.UDG32 : Resources.LCG32;
            btnGenerate.Text = $"Generate {settings?.TemplateFormat}";
            btnGenerate.Image =
                settings?.TemplateFormat == TemplateFormat.PlantUML ? Resources.plantuml32 :
                settings?.TemplateFormat == TemplateFormat.DBML ? Resources.dbml32 :
                Resources.csharp32;
            btnSaveCsAs.Text = $"{settings?.TemplateFormat} file as...";
            btnSaveCsAs.Image =
                settings?.TemplateFormat == TemplateFormat.PlantUML ? Resources.plantuml32 :
                settings?.TemplateFormat == TemplateFormat.DBML ? Resources.dbml32 :
                Resources.csharp32;
        }

        private bool GetFileSettings(bool forceprompt)
        {
            var result = true;
            if (forceprompt || !generatedfileprompted)
            {
                if (settings.UseCommonFile)
                {
                    using (var filedlg = new SaveFileDialog
                    {
                        Title = $"Save generated {Settings.FileType(settings.TemplateFormat)} file",
                        InitialDirectory = settings.OutputFolder,
                        FileName = settings.CommonFile,
                        DefaultExt = Settings.FileSuffix(settings.TemplateFormat),
                        Filter = Settings.FileFilter(settings.TemplateFormat)
                    })
                    {
                        result = filedlg.ShowDialog(this) == DialogResult.OK;
                        if (result)
                        {
                            settings.OutputFolder = Path.GetDirectoryName(filedlg.FileName);
                            settings.CommonFile = Path.GetFileNameWithoutExtension(filedlg.FileName);
                            result = true;
                        }
                    }
                }
                else
                {
                    using (var fldr = new FolderBrowserDialog
                    {
                        Description = "Select folder where files will be generated.",
                        SelectedPath = string.IsNullOrWhiteSpace(settings.OutputFolder) ? Path.GetDirectoryName(settingsfile) : settings.OutputFolder,
                        ShowNewFolderButton = true
                    })
                    {
                        result = fldr.ShowDialog(this) == DialogResult.OK;
                        if (result)
                        {
                            settings.OutputFolder = fldr.SelectedPath;
                            result = true;
                        }
                    }
                }
            }
            if (result)
            {
                generatedfileprompted = true;
            }
            return result;
        }

        private IEnumerable<AttributeMetadataProxy> GetFilteredAttributes(EntityMetadataProxy entity)
        {
            bool GetCustomFilter(AttributeMetadataProxy a) =>
                triAttCustom.CheckState == CheckState.Checked ||
                (triAttCustom.CheckState == CheckState.Indeterminate && a.Metadata.IsCustomAttribute.GetValueOrDefault()) ||
                (triAttCustom.CheckState == CheckState.Unchecked && !a.Metadata.IsCustomAttribute.GetValueOrDefault());

            bool GetManagedFilter(AttributeMetadataProxy a) =>
                triAttManaged.CheckState == CheckState.Checked ||
                (triAttManaged.CheckState == CheckState.Unchecked && a.Metadata.IsManaged.GetValueOrDefault()) ||
                (triAttManaged.CheckState == CheckState.Indeterminate && !a.Metadata.IsManaged.GetValueOrDefault());

            bool GetSearchFilter(AttributeMetadataProxy a) =>
                string.IsNullOrWhiteSpace(txtAttSearch.Text) ||
                a.Metadata.LogicalName.ToLowerInvariant().Contains(txtAttSearch.Text) ||
                a.Metadata.DisplayName?.UserLocalizedLabel?.Label?.ToLowerInvariant().Contains(txtAttSearch.Text) == true;

            bool GetLogicalFilter(AttributeMetadataProxy a, List<AttributeMetadataProxy> attributes) =>
                triAttLogical.CheckState == CheckState.Checked ||
                (triAttLogical.CheckState == CheckState.Unchecked && a.Metadata.IsLogical != true && !IsMoneyBase(a) && !IsCustomerLogical(a, attributes)) ||
                (triAttLogical.CheckState == CheckState.Indeterminate && a.Metadata.IsLogical == true);

            bool GetInternalFilter(AttributeMetadataProxy a) =>
                triAttInternal.CheckState == CheckState.Checked ||
                (triAttInternal.CheckState == CheckState.Unchecked && !OnlineSettings.Instance.InternalAttributes.Contains(a.LogicalName)) ||
                (triAttInternal.CheckState == CheckState.Indeterminate && OnlineSettings.Instance.InternalAttributes.Contains(a.LogicalName));

            bool GetRequiredFilter(AttributeMetadataProxy a) =>
                triAttRequired.CheckState == CheckState.Checked ||
                (a.Required == (triAttRequired.CheckState == CheckState.Indeterminate));

            bool GetCreModFilter(AttributeMetadataProxy a) =>
                !chkAttExclCreMod.Checked ||
                (!a.LogicalName.StartsWith("created") && !a.LogicalName.StartsWith("modified"));

            bool GetOwnersFilter(AttributeMetadataProxy a) =>
                !chkAttExclOwners.Checked ||
                (!a.LogicalName.StartsWith("owner") && !a.LogicalName.StartsWith("owning"));

            bool IsMoneyBase(AttributeMetadataProxy a) =>
                a.Metadata is MoneyAttributeMetadata && a.LogicalName.EndsWith("_base");

            bool IsCustomerLogical(AttributeMetadataProxy a, List<AttributeMetadataProxy> attributes) =>
                !string.IsNullOrEmpty(a.Metadata.AttributeOf) &&
                attributes.FirstOrDefault(a2 => a2.LogicalName == a.Metadata.AttributeOf) is AttributeMetadataProxy parentattr &&
                parentattr.Type == AttributeTypeCode.Customer;

            bool AreUsed(AttributeMetadataProxy a) =>
                !chkAttUsed.Checked ||
                a.WithValues == null ||
                a.WithValues > 0;

            bool AreUniques(AttributeMetadataProxy a) =>
                !chkAttUniques.Checked ||
                a.UniqueValues > 1;

            bool AddPrimaryIdNames(AttributeMetadataProxy a) =>
                triAttPrimaryKeyName.CheckState != CheckState.Unchecked &&
                IsPriAttr(a);

            bool FilterPrimaryIdNames(AttributeMetadataProxy a) =>
                triAttPrimaryKeyName.CheckState == CheckState.Checked ||
                (triAttPrimaryKeyName.CheckState == CheckState.Indeterminate && IsPriAttr(a)) ||
                (triAttPrimaryKeyName.CheckState == CheckState.Unchecked && !IsPriAttr(a));

            bool AddRequired(AttributeMetadataProxy a) =>
                triAttRequired.CheckState != CheckState.Unchecked &&
                a.Required;

            bool FilterRequired(AttributeMetadataProxy a) =>
                triAttRequired.CheckState == CheckState.Checked ||
                (triAttRequired.CheckState == CheckState.Indeterminate && a.Required) ||
                (triAttRequired.CheckState == CheckState.Unchecked && !a.Required);

            bool IsPriAttr(AttributeMetadataProxy a) =>
                (a.Metadata?.IsPrimaryId.Value == true ||
                 a.Metadata?.IsPrimaryName.Value == true) &&
                a.Metadata?.IsLogical.Value == false;

            if (chkAttUsed.Checked && !entity.CountedAttributes && LoadCountingDatas(entity))
            {
                return null;
            }
            splitEntityRest.Enabled = true;

            var result = entity.Attributes
                .Where(a => AddPrimaryIdNames(a))
                .Union(entity.Attributes.Where(a => AddRequired(a)))
                .Union(entity.Attributes.Where(a =>
                    GetCustomFilter(a) &&
                    GetManagedFilter(a) &&
                    GetLogicalFilter(a, entity.Attributes) &&
                    GetInternalFilter(a) &&
                    //     GetRequiredFilter(a) &&
                    GetCreModFilter(a) &&
                    GetOwnersFilter(a) &&
                    AreUsed(a) &&
                    AreUniques(a)))
                .Where(a =>
                    GetSearchFilter(a) &&
                    FilterPrimaryIdNames(a) &&
                    FilterRequired(a))
                .Distinct()
                .OrderBy(a => a)
                .ToList();
            return result;
        }

        private bool LoadCountingDatas(EntityMetadataProxy entity)
        {
            if (entity.RecordCount == 0)
            {
                entity.CountedAttributes = true;
                entity.Attributes.ForEach(attr => attr.WithValues = 0);
                entity.Attributes.ForEach(attr => attr.UnDefaultValues = 0);
                entity.Attributes.ForEach(attr => attr.UniqueValues = 0);
                return false;
            }
            if (selectedEntity?.RecordCount > 5000 &&
                MessageBox.Show($"This might take more than a few seconds...\nCounting values on attributes for {selectedEntity.RecordCount} records.\n\nIf it takes too long, you can cancel it with the button in the menu.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
            {
                chkAttUsed.Checked = false;
                return false;
            }
            splitEntityRest.Enabled = false;
            btnCancel.Visible = true;
            btnCancel.Enabled = true;
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Counting attributes for {entity.DisplayName}{Environment.NewLine}...",
                IsCancelable = true,
                Work = (w, arg) =>
                {
                    var q = new QueryExpression(entity.LogicalName);
                    q.ColumnSet = new ColumnSet(true);
                    arg.Result = Service.RetrieveMultipleAll(q, w, arg, $"Counting attributes for {entity.DisplayName}{Environment.NewLine}{{0}} / {entity.RecordCount}");
                },
                ProgressChanged = (c) =>
                {
                    SetWorkingMessage(c.UserState.ToString());
                },
                PostWorkCallBack = (arg) =>
                {
                    entity.CountedAttributes = true;
                    btnCancel.Visible = false;
                    if (arg.Error != null)
                    {
                        ShowErrorDialog(arg.Error);
                    }
                    else if (arg.Cancelled)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("Cancelling load of all data.", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        chkAttUsed.Checked = false;
                        entity.CountedAttributes = false;
                    }
                    else if (arg.Result is EntityCollection records)
                    {
                        entity.Attributes
                            .ForEach(attr => attr.WithValues = records.Entities.Count(r => r.Contains(attr.LogicalName)));
                        entity.Attributes
                            .ForEach(attr => attr.UnDefaultValues = records.Entities.Count(r => !IsDefaultValue(r, attr)));
                        entity.Attributes
                            .ForEach(attr => attr.UniqueValues = records.Entities
                                .Select(e => e.Contains(attr.LogicalName) ? AttributeToBaseType(e[attr.LogicalName]) : null)
                                .Where(v => v != null)
                                .Distinct()
                                .Count());
                    }
                    DisplayFilteredAttributes();
                }
            });
            return true;
        }

        public static object AttributeToBaseType(object attribute)
        {
            if (attribute is AliasedValue aliasedvalue)
            {
                return AttributeToBaseType(aliasedvalue.Value);
            }
            else if (attribute is EntityReference entref)
            {
                if (!string.IsNullOrEmpty(entref.LogicalName) && !entref.Id.Equals(Guid.Empty))
                {
                    return entref.Id;
                }
                return null;
            }
            else if (attribute is OptionSetValue osv)
            {
                return osv.Value;
            }
            else if (attribute is OptionSetValueCollection copt)
            {
                return copt.Select(c => c.Value);
            }
            else if (attribute is Money money)
            {
                return money.Value;
            }
            else
            {
                return attribute;
            }
        }

        private static bool IsDefaultValue(Entity record, AttributeMetadataProxy attribute)
        {
            if (!record.Contains(attribute.LogicalName))
            {
                return true;
            }
            var value = record[attribute.LogicalName];
            if (attribute.Metadata is BooleanAttributeMetadata atbool)
            {
                return value is bool vabool ? vabool == atbool.DefaultValue : true;
            }
            else if (attribute.Metadata is PicklistAttributeMetadata atpick)
            {
                return value is OptionSetValue vaopt ? vaopt.Value == atpick.DefaultFormValue : true;
            }
            else if (attribute.Metadata is StringAttributeMetadata)
            {
                return value is string vastr ? string.IsNullOrWhiteSpace(vastr) : true;
            }
            return false;
        }

        private IEnumerable<EntityMetadataProxy> GetFilteredEntities()
        {
            bool GetSearchFilter(EntityMetadataProxy e) =>
                string.IsNullOrWhiteSpace(txtEntSearch.Text) ||
                e.Metadata.LogicalName.ToLowerInvariant().Contains(txtEntSearch.Text) ||
                e.Metadata.DisplayName?.UserLocalizedLabel?.Label?.ToLowerInvariant().Contains(txtEntSearch.Text) == true;

            bool GetIntersectFilter(EntityMetadataProxy e) =>
                !e.Metadata.IsIntersect.GetValueOrDefault() ||
                !chkEntExclIntersect.Checked;

            bool IsNotPrivate(EntityMetadataProxy e) =>
                !e.Metadata.IsPrivate.GetValueOrDefault();

            bool GetSelectedFilter(EntityMetadataProxy e) =>
                triEntSelected.CheckState == CheckState.Checked ||
                (triEntSelected.CheckState == CheckState.Indeterminate && e.IsSelected) ||
                (triEntSelected.CheckState == CheckState.Unchecked && !e.IsSelected);

            bool GetManagedFilter(EntityMetadataProxy e) =>
                triEntManaged.CheckState == CheckState.Checked ||
                (triEntManaged.CheckState == CheckState.Unchecked && e.Metadata.IsManaged.GetValueOrDefault()) ||
                (triEntManaged.CheckState == CheckState.Indeterminate && !e.Metadata.IsManaged.GetValueOrDefault());

            bool GetCustomFilter(EntityMetadataProxy e) =>
                triEntCustom.CheckState == CheckState.Checked ||
                (triEntCustom.CheckState == CheckState.Indeterminate && e.Metadata.IsCustomEntity.GetValueOrDefault()) ||
                (triEntCustom.CheckState == CheckState.Unchecked && !e.Metadata.IsCustomEntity.GetValueOrDefault());

            bool GetNoDataFilter(EntityMetadataProxy e) =>
                triEntRecords.CheckState == CheckState.Checked ||
                (triEntRecords.CheckState == CheckState.Indeterminate && e.Records > 0) ||
                (triEntRecords.CheckState == CheckState.Unchecked && e.Records == 0) ||
                (chkEntShowUncountable.Checked && e.Records == null);

            bool GetNoMSFT(EntityMetadataProxy e) =>
                !chkEntExclMS.Checked ||
                !e.LogicalName.Contains("_") ||
                !(OnlineSettings.Instance.MicrosoftPrefixes.Contains(e.LogicalName.Split('_')[0] + "_"));

            if (ConnectionDetail?.OrganizationMajorVersion < 9 && triEntRecords.CheckState != CheckState.Checked)
            {
                MessageBox.Show("Sorry, currently not possible to count records with Dynamics 365 before version 9.*.\n\nClick 'Help' for more info!",
                    "Count Records", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, 0,
                    "https://learn.microsoft.com/dotnet/api/microsoft.crm.sdk.messages.retrievetotalrecordcountrequest?WT.mc_id=DX-MVP-5002475");
                triEntRecords.CheckState = CheckState.Checked;
            }
            var filteredentities = entities.Where(
                e => IsNotPrivate(e)
                     && GetSelectedFilter(e)
                     && GetCustomFilter(e)
                     && GetManagedFilter(e)
                     && GetIntersectFilter(e)
                     && GetSearchFilter(e)
                     && GetNoDataFilter(e)
                     && GetNoMSFT(e));
            return filteredentities;
        }

        private IEnumerable<RelationshipMetadataProxy> GetFilteredRelationships(EntityMetadataProxy entity, string search)
        {
            bool GetTypeFilter(RelationshipMetadataProxy r)
            {   // Exclude relationships where selected entity is just child of the relationship
                if (settings.RelationshipFilter.Type1N &&
                    r.OneToManyRelationshipMetadata?.ReferencedEntity == entity?.LogicalName)
                {
                    return true;
                }
                if (settings.RelationshipFilter.TypeN1 &&
                    r.OneToManyRelationshipMetadata?.ReferencingEntity == entity?.LogicalName &&
                    r.OneToManyRelationshipMetadata?.ReferencedEntity != entity?.LogicalName)   // Exclude self-referencing relationships, they are included as 1:N
                {
                    return true;
                }
                if (settings.RelationshipFilter.TypeNN &&
                    r.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    return true;
                }
                return false;
            }
            bool GetCustomFilter(RelationshipMetadataProxy r)
            {
                return settings.RelationshipFilter.Custom == CheckState.Checked ||
                       (settings.RelationshipFilter.Custom == CheckState.Unchecked && r.Metadata.IsCustomRelationship.GetValueOrDefault()) ||
                       (settings.RelationshipFilter.Custom == CheckState.Indeterminate && !r.Metadata.IsCustomRelationship.GetValueOrDefault());
            }
            bool GetManagedFilter(RelationshipMetadataProxy r)
            {
                return settings.RelationshipFilter.Managed == CheckState.Checked ||
                       (settings.RelationshipFilter.Managed == CheckState.Unchecked && r.Metadata.IsManaged.GetValueOrDefault()) ||
                       (settings.RelationshipFilter.Managed == CheckState.Indeterminate && !r.Metadata.IsManaged.GetValueOrDefault());
            }
            bool GetSearchFilter(RelationshipMetadataProxy r)
            {
                return string.IsNullOrWhiteSpace(search) ||
                       r.Metadata.SchemaName.ToLowerInvariant().Contains(search) ||
                       r.Parent?.DisplayName?.ToLowerInvariant().Contains(search) == true;
            }
            bool GetOrphansFilter(RelationshipMetadataProxy r)
            {
                if (!settings.RelationshipFilter.ExcludeOrphans)
                {
                    return true;
                }
                var selectedentities = entities.Where(e => e.Selected).Select(e => e.LogicalName).Union(new string[] { entity.LogicalName }).Distinct();
                if (r.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    return selectedentities.Contains(r.ManyToManyRelationshipMetadata.Entity1LogicalName)
                        && selectedentities.Contains(r.ManyToManyRelationshipMetadata.Entity2LogicalName);
                }
                return selectedentities.Contains(r.OneToManyRelationshipMetadata.ReferencedEntity)
                    && selectedentities.Contains(r.OneToManyRelationshipMetadata.ReferencingEntity);
            }
            bool GetOwnersFilter(RelationshipMetadataProxy r)
            {
                if (!settings.RelationshipFilter.ExcludeOwner || r.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    return true;
                }
                return
                    !(r.OneToManyRelationshipMetadata.ReferencingAttribute.StartsWith("owner") ||
                      r.OneToManyRelationshipMetadata.ReferencingAttribute.StartsWith("owning")) &&
                    !(r.OneToManyRelationshipMetadata.ReferencedAttribute.StartsWith("owner") ||
                      r.OneToManyRelationshipMetadata.ReferencedAttribute.StartsWith("owning"));
            }
            bool GetRegardingFilter(RelationshipMetadataProxy r)
            {
                if (!settings.RelationshipFilter.ExcludeRegarding || r.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    return true;
                }
                return r.OneToManyRelationshipMetadata.ReferencingAttribute != "regardingobjectid";
            }
            bool GetCreModFilter(RelationshipMetadataProxy r)
            {
                if (!settings.RelationshipFilter.ExcludeCreMod || r.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    return true;
                }
                return
                    !(r.OneToManyRelationshipMetadata.ReferencingAttribute.StartsWith("created") ||
                      r.OneToManyRelationshipMetadata.ReferencingAttribute.StartsWith("modified"));
            }
            bool GetDupRecordsFilter(RelationshipMetadataProxy r)
            {
                if (!settings.RelationshipFilter.ExcludeDupRecords || r.Metadata.RelationshipType == RelationshipType.ManyToManyRelationship)
                {
                    return true;
                }
                return r.OneToManyRelationshipMetadata.ReferencingEntity != "duplicaterecord";
            }
            bool GetRequredFilters(RelationshipMetadataProxy r) =>
                !settings.RelationshipFilter.RequireLookups ||
                (r.LookupAttribute?.Required ?? false);

            return entity.Relationships
                    .Where(
                        r => GetTypeFilter(r) &&
                             GetCustomFilter(r) &&
                             GetManagedFilter(r) &&
                             GetSearchFilter(r) &&
                             GetOrphansFilter(r) &&
                             GetOwnersFilter(r) &&
                             GetRegardingFilter(r) &&
                             GetCreModFilter(r) &&
                             GetDupRecordsFilter(r) &&
                             GetRequredFilters(r));
        }

        private EntityMetadataProxy GetSelectedEntity()
        {
            if (gridEntities.SelectedRows.Count == 1)
            {
                var row = gridEntities.SelectedRows[0];
                return row.DataBoundItem as EntityMetadataProxy;
            }
            return null;
        }

        private void GetSelectionFromUI()
        {
            if (entities != null)
            {
                settings.Selection = null;
                settings.SelectedEntities = entities
                    .Where(e => e.IsSelected)
                    .Select(e => new SelectedEntity
                    {
                        Name = e.LogicalName,
                        Group = e.Group?.Name,
                        Attributes = e.Attributes != null ?
                            e.Attributes
                                .Where(a => a.IsSelected)
                                .Select(a => a.LogicalName)
                                .ToList() : new List<string>(),
                        Relationships = e.Relationships != null ?
                            e.Relationships
                                .Where(r => r.IsSelected)
                                .Select(r => r.Metadata.SchemaName)
                                .ToList() : new List<string>()
                    }).ToList();
            }
        }

        private void GetSettingsFromUI()
        {
            if (settings == null)
            {
                settings = new Settings(isUML);
            }
            settings.Version = Version;
            if (settings.EntityFilter == null)
            {
                settings.EntityFilter = new EntityFilter();
            }
            settings.EntityFilter.Expanded = gbEntities.Height > Settings.FilterCollapseHeight;
            settings.EntityFilter.Custom = triEntCustom.CheckState;
            settings.EntityFilter.Managed = triEntManaged.CheckState;
            settings.EntityFilter.ExcludeIntersect = chkEntExclIntersect.Checked;
            settings.EntityFilter.Selected = triEntSelected.CheckState;
            settings.EntityFilter.Records = triEntRecords.CheckState;
            settings.EntityFilter.Uncountable = settings.EntityFilter.Records != CheckState.Indeterminate && chkEntShowUncountable.Checked;
            if (settings.AttributeFilter == null)
            {
                settings.AttributeFilter = new AttributeFilter();
            }
            settings.AttributeFilter.Expanded = gbAttributes.Height > Settings.FilterCollapseHeight;
            settings.AttributeFilter.CheckAll = chkAttCheckAll.Checked;
            settings.AttributeFilter.Custom = triAttCustom.CheckState;
            settings.AttributeFilter.Managed = triAttManaged.CheckState;
            settings.AttributeFilter.PrimaryKeyName = triAttPrimaryKeyName.CheckState;
            settings.AttributeFilter.Logical = triAttLogical.CheckState;
            settings.AttributeFilter.Internal = triAttInternal.CheckState;
            settings.AttributeFilter.Required = triAttRequired.CheckState;
            settings.AttributeFilter.ExcludeCreMod = chkAttExclCreMod.Checked;
            settings.AttributeFilter.ExcludeOwner = chkAttExclOwners.Checked;
            settings.AttributeFilter.AreUsed = chkAttUsed.Checked;
            settings.AttributeFilter.UniqueValues = chkAttUsed.Checked && chkAttUniques.Checked;
            if (settings.RelationshipFilter == null)
            {
                settings.RelationshipFilter = new RelationshipFilter();
            }
            settings.RelationshipFilter.Expanded = gbRelationships.Height > Settings.FilterCollapseHeight;
            settings.RelationshipFilter.CheckAll = chkRelCheckAll.Checked;
            settings.RelationshipFilter.Custom = triRelCustom.CheckState;
            settings.RelationshipFilter.Managed = triRelManaged.CheckState;
            settings.RelationshipFilter.Type1N = chkRel1N.Checked;
            settings.RelationshipFilter.TypeN1 = chkRelN1.Checked;
            settings.RelationshipFilter.TypeNN = chkRelNN.Checked;
            settings.RelationshipFilter.ExcludeOrphans = chkRelExclOrphans.Checked;
            settings.RelationshipFilter.ExcludeOwner = chkRelExclOwners.Checked;
            settings.RelationshipFilter.ExcludeRegarding = chkRelExclRegarding.Checked;
            settings.RelationshipFilter.ExcludeCreMod = chkRelExclCreMod.Checked;
            settings.RelationshipFilter.ExcludeDupRecords = chkRelExclDupRecords.Checked;
            settings.RelationshipFilter.RequireLookups = chkRelReqLookups.Checked;
        }

        private void GroupBoxCollapse(LinkLabel link)
        {
            link.Parent.Height = Settings.FilterCollapseHeight;
            link.Parent.Controls.OfType<Control>().Where(c => c != link).ToList().ForEach(c => c.Visible = false);
            link.Text = "Show filter";
        }

        private void GroupBoxExpand(LinkLabel link)
        {
            link.Parent.Height = groupBoxHeights[link.Parent.Name];
            link.Parent.Controls.OfType<Control>().Where(c => c != link).ToList().ForEach(c => c.Visible = true);
            link.Text = "Hide filter";
        }

        private void GroupBoxSetState(LinkLabel link, bool expanded)
        {
            if (expanded)
            {
                GroupBoxExpand(link);
            }
            else
            {
                GroupBoxCollapse(link);
            }
        }

        private void GroupBoxToggle(LinkLabel link)
        {
            if (link.Parent.Height > Settings.FilterCollapseHeight)
            {
                GroupBoxCollapse(link);
            }
            else
            {
                GroupBoxExpand(link);
            }
        }

        private void LoadAttributes(EntityMetadataProxy entity, Action callback)
        {
            entity.Attributes = null;
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Loading attributes for {entity}...",
                Work = (worker, args) =>
                {
                    args.Result = MetadataHelper.LoadEntityDetails(Service, entity.LogicalName);
                },
                PostWorkCallBack = (completedArgs) =>
                {
                    if (completedArgs.Error != null)
                    {
                        ShowErrorDialog(completedArgs.Error);
                    }
                    else if (completedArgs.Result is RetrieveMetadataChangesResponse response)
                    {
                        var metaresponse = response.EntityMetadata;
                        if (metaresponse.Count == 1)
                        {
                            entity.Attributes = new List<AttributeMetadataProxy>(
                                metaresponse[0]
                                    .Attributes
                                    .Select(m => new AttributeMetadataProxy(entity, m))
                                    .OrderBy(a => a.ToString()));
                            foreach (var attribute in entity.Attributes)
                            {
                                attribute.PropertyChanged += PropertyChanged_Attribute;
                            }
                        }
                    }

                    UpdateUI(() =>
                    {
                        callback?.Invoke();
                    });
                }
            });
        }

        private void LoadCommonSettings()
        {
            if (!SettingsManager.Instance.TryLoad(GetType(), out settings.TemplateSettings, SettingsFileName(isUML, commonsettingsfile)))
            {
                settings.TemplateSettings = new TemplateSettings(isUML);
                LogWarning("Common Settings not found => created");
            }
            else
            {
                LogInfo("Common Settings found and loaded");
            }
            settings.TemplateSettings.TemplateFormat = settings.TemplateFormat;
        }

        private void LoadEntities()
        {
            entities = null;
            EnableControls(false);
            gridAttributes.DataSource = null;
            gridRelationships.DataSource = null;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading entities...",
                Work = (worker, args) =>
                {
                    args.Result = MetadataHelper.LoadEntities(Service, ConnectionDetail.OrganizationMajorVersion);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }
                    else if (args.Result is RetrieveMetadataChangesResponse response)
                    {
                        var metaresponse = response.EntityMetadata;
                        entities = new List<EntityMetadataProxy>(
                            metaresponse
                                .Select(m => new EntityMetadataProxy(m))
                                .OrderBy(e => e.ToString()));
                        foreach (var entity in entities)
                        {
                            entity.PropertyChanged += PropertyChanged_Entity;
                            entity.Relationships = new List<RelationshipMetadataProxy>(
                                entity.Metadata.ManyToOneRelationships.Select(m => new RelationshipMetadataProxy(entities, entity, m)));
                            entity.Relationships.AddRange(
                                entity.Metadata.OneToManyRelationships
                                    .Where(r => !entity.Metadata.ManyToOneRelationships.Select(r1m => r1m.SchemaName).Contains(r.SchemaName))
                                    .Select(r => new RelationshipMetadataProxy(entities, entity, r)));
                            entity.Relationships.AddRange(
                                entity.Metadata.ManyToManyRelationships.Select(m => new RelationshipMetadataProxy(entities, entity, m)));
                            foreach (var relationship in entity.Relationships)
                            {
                                relationship.PropertyChanged += PropertyChanged_Relationship;
                            }
                        }
                        if (ConnectionDetail.OrganizationMajorVersion >= 9)
                        {
                            this.CountRecords(entities.Select(e => e.Metadata).ToList(), SetEntityRecords, CountingCompleted);
                        }
                        LoadSolutionEntities(cmbSolution.SelectedItem as SolutionProxy, null);
                    }
                }
            });
        }

        private void LoadGlobalSetting()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (!SettingsManager.Instance.TryLoad(GetType(), out GlobalSettings globalsettings, SettingsFileName(isUML, globalsettingsfile)))
            {
                globalsettings = new GlobalSettings();
            }
            if (!version.Equals(globalsettings.CurrentVersion))
            {
                // Reset some settings when new version is deployed
                globalsettings.CurrentVersion = version;
                SettingsManager.Instance.Save(GetType(), globalsettings, SettingsFileName(isUML, globalsettingsfile));
                UrlUtils.OpenUrl($"{HelpUrl}/releases/#{version}");
            }
        }

        private void CountingCompleted()
        {
            UpdateUI(() =>
            {
                RestoreSelectedEntities();
                DisplayFilteredEntities();
                FixingEntityColumnWidths();
                menuOpen.Enabled = true;
                EnableControls(true);
            });
        }

        private void FixingEntityColumnWidths()
        {
            if (gridEntities.Columns.Count < 5)
            {
                return;
            }
            gridEntities.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            gridEntities.Columns[0].Width = 30;
            var totalwidthavailable = gridEntities.Width - 20;
            var widthavailable = totalwidthavailable - gridEntities.Columns[0].Width;
            if (gridEntities.Columns.Cast<DataGridViewColumn>().Sum(c => c.Width) > totalwidthavailable)
            {
                gridEntities.Columns[1].Width = widthavailable / 3;
            }
            if (gridEntities.Columns.Cast<DataGridViewColumn>().Sum(c => c.Width) > totalwidthavailable && gridEntities.Columns[2].Width > widthavailable / 3)
            {
                gridEntities.Columns[2].Width = widthavailable / 3;
            }
            if (gridEntities.Columns.Cast<DataGridViewColumn>().Sum(c => c.Width) > totalwidthavailable && gridEntities.Columns[3].Width > widthavailable / 6)
            {
                gridEntities.Columns[3].Width = widthavailable / 6;
            }
            if (gridEntities.Columns.Cast<DataGridViewColumn>().Sum(c => c.Width) > totalwidthavailable)
            {
                gridEntities.Columns[4].Width = widthavailable / 6;
            }
            gridEntities.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void SetEntityRecords(string entityname, int count, string error)
        {
            if (entities.FirstOrDefault(e => e.LogicalName == entityname) is EntityMetadataProxy entity)
            {
                if (string.IsNullOrEmpty(error))
                {
                    entity.Records = count;
                }
                else
                {
                    entity.Records = null;
                }
            }
        }

        private void LoadSettings(string connectionname)
        {
            SettingsManager.Instance.TryLoad(GetType(), out settings, SettingsFileName(isUML, connectionname));
            if (settings == null)
            {
                settings = new Settings(isUML);
            }
            ApplySettings();
        }

        private void LoadSolutionEntities(SolutionProxy solution, Action callback)
        {
            if (solution == null)
            {
                callback?.Invoke();
                return;
            }
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solution entities...",
                Work = (worker, args) =>
                {
                    var qx = new QueryExpression("solutioncomponent");
                    qx.ColumnSet.AddColumns("objectid");
                    qx.Criteria.AddCondition("componenttype", ConditionOperator.Equal, 1);
                    qx.Criteria.AddCondition("solutionid", ConditionOperator.Equal, solution.Solution.Id);
                    args.Result = Service.RetrieveMultiple(qx);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        ShowErrorDialog(args.Error);
                    }
                    if (args.Result is EntityCollection solutionentities)
                    {
                        solution.Entities = entities?
                            .Where(e => solutionentities.Entities
                                .Select(i => i["objectid"]).Contains(e.Metadata.MetadataId))
                            .Select(e => e.LogicalName)
                            .ToList();
                        callback?.Invoke();
                    }
                }
            });
        }

        private void LoadSolutions()
        {
            EnableControls(false);
            var lastsolution = cmbSolution.SelectedItem is SolutionProxy lastselectedsolution ? lastselectedsolution.UniqueName : null;
            cmbSolution.Items.Clear();
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solutions...",
                Work = (worker, args) =>
                  {
                      var qx = new QueryExpression("solution");
                      qx.ColumnSet.AddColumns("friendlyname", "uniquename");
                      //qx.Criteria.AddCondition("ismanaged", ConditionOperator.Equal, false);
                      qx.Criteria.AddCondition("isvisible", ConditionOperator.Equal, true);
                      var lePub = qx.AddLink("publisher", "publisherid", "publisherid");
                      lePub.EntityAlias = "P";
                      lePub.Columns.AddColumns("customizationprefix");
                      args.Result = Service.RetrieveMultiple(qx);
                  },
                PostWorkCallBack = (completedargs) =>
                {
                    if (completedargs.Error != null)
                    {
                        ShowErrorDialog(completedargs.Error);
                    }
                    else
                    {
                        if (completedargs.Result is EntityCollection solutions)
                        {
                            var proxiedsolutions = solutions.Entities.Select(s => new SolutionProxy(s)).OrderBy(s => s.ToString());
                            cmbSolution.Items.Add("");
                            cmbSolution.Items.AddRange(proxiedsolutions.Cast<object>().ToArray());
                            if (!string.IsNullOrEmpty(lastsolution))
                            {
                                cmbSolution.SelectedItem = cmbSolution.Items
                                    .OfType<SolutionProxy>()
                                    .FirstOrDefault(s => s.UniqueName == lastsolution) ?? null;
                            }
                        }
                    }
                    EnableControls(true);
                    LoadEntities();
                }
            });
        }

        private void MigrateFromPre2020Settings()
        {
            SelectedEntity ConvertSelectionFromPre2020(string entitystring)
            {
                return new SelectedEntity
                {
                    Name = entitystring.Split(':')[0],
                    Attributes = entitystring.Split(':')[1].Split(',').ToList()
                };
            }

            // Settings loaded from pre 2020, so need to reset RelationshipFilter and reflect that on the form and make sure all filters are shown
            if (settings.SelectedEntities?.Count == 0 && settings.Selection?.Count > 0)
            {
                settings.SelectedEntities = settings.Selection.Select(e => ConvertSelectionFromPre2020(e)).ToList();
            }
            settings.Version = Version;
            settings.EntityFilter.Expanded = true;
            settings.AttributeFilter.Expanded = true;
            settings.RelationshipFilter = new RelationshipFilter { Expanded = true };
            ApplySettings();
        }

        private void PropertyChanged_Attribute(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SetSelected"))
            {
                UpdateAttributesStatus();
            }
        }

        private void PropertyChanged_Entity(object sender, PropertyChangedEventArgs e)
        {
            if (!e.PropertyName.Equals("SetSelected"))
            {
                return;
            }

            UpdateEntitiesStatus();
            if (checkedrow != null && checkedrow != sender)
            {
                return;
            }
            checkedrow = sender;
            var entity = sender as EntityMetadataProxy;
            if (!restoringselection && entity?.Selected == true)
            {
                if (chkAttCheckAll.Checked)
                {
                    if (entity.Attributes == null)
                    {
                        LoadAttributes(entity, SelectAllAttributes);
                    }
                    else
                    {
                        SelectAllAttributes();
                    }
                }
                if (chkRelCheckAll.Checked)
                {
                    SelectAllRelationships();
                }
            }
            checkedrow = null;
        }

        private void PropertyChanged_Relationship(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SetSelected"))
            {
                UpdateRelationshipssStatus();
            }
        }

        private void RestoreSelectedEntities()
        {
            if (entities == null)
            {
                return;
            }
            if (settings == null && !SettingsManager.Instance.TryLoad(GetType(), out settings, SettingsFileName(isUML, ConnectionDetail.ConnectionName)))
            {
                return;
            }

            restoringselection = true;
            var version = System.Version.TryParse(settings.Version, out Version v) ? v : new Version();
            if (version < new Version(1, 2020))
            {   // Loading old style selection configuration
                MigrateFromPre2020Settings();
            }
            if (version.Major > 0 && version < new Version(1, 2021))
            {
                MessageBox.Show($@"Welcome to the new version!

By default the project configuration will now be embedded in a comment block at the end of the generated {Settings.FileType(settings.TemplateFormat)} file.
Using this feature will make the separate project xml files obsolete.
This behavior can be prevented by unchecking the box 'Include configuration' in the Options dialog", "New version", MessageBoxButtons.OK, MessageBoxIcon.Information);
                settings.Version = Version;
            }

            if (settings.SelectedEntities == null)
            {
                settings.SelectedEntities = new List<SelectedEntity>();
            }

            if (!settings.UseCommonFile && settings.SaveConfigurationInCommonFile)
            {
                settings.SaveConfigurationInCommonFile = false;
            }

            var selectedentitywithoutattributes = entities.FirstOrDefault(e => e.Attributes == null && settings.SelectedEntities.Select(se => se.Name).Contains(e.LogicalName));
            if (selectedentitywithoutattributes != null && selectedentitywithoutattributes.Attributes == null)
            {
                if (lasttriedattributeload == selectedentitywithoutattributes.LogicalName)
                {   // Already tried this entity, obviously failed, don't try again
                    selectedentitywithoutattributes.Attributes = new List<AttributeMetadataProxy>();
                }
                else
                {
                    LoadAttributes(selectedentitywithoutattributes, RestoreSelectedEntities);
                }
                lasttriedattributeload = selectedentitywithoutattributes.LogicalName;
                return;
            }

            entities.ForEach(e => e.SetSelected(false));
            entities.ForEach(e => e.Group = null);
            entities.Where(e => settings.SelectedEntities.Select(se => se.Name).Contains(e.LogicalName)).ToList().ForEach(e => e.SetSelected(true));
            var missingentities = new List<string>();
            foreach (var selectedentity in settings.SelectedEntities)
            {
                var entity = entities.FirstOrDefault(e => e.LogicalName.Equals(selectedentity.Name));
                if (entity == null)
                {
                    missingentities.Add(selectedentity.Name);
                    continue;
                }
                if (selectedentity.Relationships == null)
                {   // Needs to be defaulted since it was not stored in config
                    selectedentity.Relationships = GetDefaultRelationships(entity);
                }
                if (!entity.Selected)
                {
                    entity.SetSelected(true);
                }
                if (!string.IsNullOrEmpty(selectedentity.Group))
                {  // Set group if it was stored in config
                    entity.Group = settings.Groups.FirstOrDefault(g => g.Name == selectedentity.Group);
                }
                entity.Attributes.ForEach(a => a.SetSelected(false));
                entity.Relationships.ForEach(r => r.SetSelected(false, false));
                foreach (var attributename in selectedentity.Attributes)
                {
                    var attribute = entity.Attributes.FirstOrDefault(a => a.LogicalName == attributename);
                    if (attribute != null && !attribute.Selected)
                    {
                        attribute.SetSelected(true);
                    }
                }
                foreach (var relationshipname in selectedentity.Relationships)
                {
                    var relatioship = entity.Relationships.FirstOrDefault(r => r.LogicalName == relationshipname);
                    if (relatioship != null && !relatioship.Selected)
                    {
                        relatioship.SetSelected(true);
                    }
                }
            }
            if (missingentities?.Count > 0)
            {
                UpdateUI(() =>
                {
                    MessageBox.Show($"Failed to restore the following entities as they were not available in connected environment:\n\n{string.Join("\n", missingentities)}", "Restoring entities", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
            }
            restoringselection = false;
            EntitySelected(true);
        }

        private void SaveSettings(string connectionname)
        {
            GetSettingsFromUI();
            GetSelectionFromUI();
            settings.Version = Version;
            SettingsManager.Instance.Save(GetType(), settings, SettingsFileName(isUML, connectionname));
        }

        private void SelectAllAttributes()
        {
            SelectAllRows(gridAttributes, true);
        }

        private void SelectAllRelationships()
        {
            SelectAllRows(gridRelationships, true);
        }

        private List<string> GetDefaultRelationships(EntityMetadataProxy entity)
        {
            var selectedrelationships = GetFilteredRelationships(entity, string.Empty);
            return selectedrelationships.Select(r => r.LogicalName).ToList();
        }

        internal static string SettingsFileName(bool isUML, string name)
        {
            return (isUML ? "UDG_" : "LCG_") + name;
        }

        private void UpdateAttributesStatus()
        {
            pnAttributeGrid.Visible = gridAttributes.RowCount > 0;
            lblAttNoMatch.Visible = gridAttributes.DataSource != null && gridAttributes.RowCount == 0;
            chkAttAll.Visible = gridAttributes.Rows.Count > 0;
            if (gridAttributes.DataSource != null && selectedEntity != null && selectedEntity.Attributes != null)
            {
                var unshownselects = selectedEntity?.Attributes?.Count(e => e.IsSelected) -
                    gridAttributes.Rows.Cast<DataGridViewRow>().Count(r => r.DataBoundItem is MetadataProxy meta ? meta.IsSelected : false);
                lblAttUnShown.Text = $"{unshownselects} selected not shown with current filter.";
                lblAttUnShown.Visible = unshownselects > 0;
                statusAttributesShowing.Text = $"Showing {gridAttributes.Rows.Count} of {selectedEntity.Attributes?.Count} attributes.";
                statusAttributesSelected.Text = $"{selectedEntity?.Attributes?.Count(att => att.Selected)} selected.";
            }
            else
            {
                lblAttUnShown.Visible = false;
                statusAttributesShowing.Text = "No attributes available";
                statusAttributesSelected.Text = "";
            }
        }

        private void UpdateEntitiesStatus()
        {
            pnEntityGrid.Visible = gridEntities.RowCount > 0;
            lblEntNoMatch.Visible = gridEntities.DataSource != null && gridEntities.RowCount == 0;
            chkEntAll.Visible = gridEntities.Rows.Count > 0;
            btnGenerate.Enabled = entities != null && (bool)entities?.Any(e => e.IsSelected);
            if (gridEntities.DataSource != null && entities != null)
            {
                var unshownselects = entities.Count(e => e.IsSelected) -
                    gridEntities.Rows.Cast<DataGridViewRow>().Count(r => r.DataBoundItem is MetadataProxy meta ? meta.IsSelected : false);
                lblEntUnShown.Text = $"{unshownselects} selected not shown with current filter.";
                lblEntUnShown.Visible = unshownselects > 0;
                statusEntitiesShowing.Text = $"Showing {gridEntities.Rows.Count} of {entities.Count} entities.";
                statusEntitiesSelected.Text = $"{entities.Count(ent => ent.Selected)} selected.";
            }
            else
            {
                lblEntUnShown.Visible = false;
                statusEntitiesShowing.Text = "No entities available";
                statusEntitiesSelected.Text = "";
            }
        }

        private void UpdateRelationshipssStatus()
        {
            pnRelationshipGrid.Visible = gridRelationships.RowCount > 0;
            lblRelNoMatch.Visible = gridRelationships.DataSource != null && gridRelationships.RowCount == 0;
            chkRelAll.Visible = gridRelationships.Rows.Count > 0;
            if (gridRelationships.DataSource != null && selectedEntity != null && selectedEntity.Relationships != null)
            {
                var unshownselects = selectedEntity?.Relationships?.Count(r => r.IsSelected) -
                    gridRelationships.Rows.Cast<DataGridViewRow>().Count(r => r.DataBoundItem is MetadataProxy meta ? meta.IsSelected : false);
                lblRelUnShown.Text = $"{unshownselects} selected not shown with current filter.";
                lblRelUnShown.Visible = unshownselects > 0;
                statusRelationshipsShowing.Text = $"Showing {gridRelationships.Rows.Count} of {selectedEntity.Relationships?.Count} relationships.";
                statusRelationshipsSelected.Text = $"{selectedEntity?.Relationships?.Count(r => r.IsSelected)} selected.";
            }
            else
            {
                lblEntUnShown.Visible = false;
                statusRelationshipsShowing.Text = "No relationships available";
                statusRelationshipsSelected.Text = "";
            }
        }

        private void UpdateUI(Action action)
        {
            void Mi() { action(); }

            if (InvokeRequired)
            {
                Invoke((MethodInvoker)Mi);
            }
            else
            {
                Mi();
            }
        }

        private void FillGroups(EntityGroup selected = null)
        {
            cmbGroup.Items.Clear();
            cmbGroup.Items.Add("");
            cmbGroup.Items.AddRange(settings.Groups.ToArray());
            SelectGroup(selected);
        }

        private void SelectGroup(EntityGroup group)
        {
            posGroupUpDown.Minimum = 0;
            posGroupUpDown.Maximum = settings.Groups.Count;
            if (group != null)
            {
                if (!settings.Groups.Contains(group))
                {
                    settings.Groups.Add(group);
                }
                if (cmbGroup.Items.IndexOf(group) < 0)
                {
                    cmbGroup.Items.Add(group);
                }
                posGroupUpDown.Value = Math.Max(posGroupUpDown.Minimum, cmbGroup.SelectedIndex);
            }
            if (cmbGroup.SelectedItem != group)
            {
                if (group != null)
                {
                    cmbGroup.SelectedItem = group;
                }
                else
                {
                    cmbGroup.SelectedIndex = 0;
                }
            }
            cmbGroup.Enabled = settings.Groups.Count > 0;
            posGroupUpDown.Enabled = group != null && settings.Groups.Count >= 2;
            btnGroupColor.Enabled = group != null;
            btnGroupDelete.Enabled = group != null;
            btnGroupColor.BackColor = group?.Color ?? Color.White;
        }

        #endregion Private Methods
    }
}