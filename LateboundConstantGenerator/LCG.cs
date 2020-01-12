using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
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
    public partial class LCG : PluginControlBase, IGitHubPlugin, IPayPalPlugin, IAboutPlugin
    {
        #region Private Fields

        private const string aiEndpoint = "https://dc.services.visualstudio.com/v2/track";
        //private const string aiKey = "cc7cb081-b489-421d-bb61-2ee53495c336";    // jonas@rappen.net tenant, TestAI 
        private const string aiKey = "eed73022-2444-45fd-928b-5eebd8fa46a6";    // jonas@rappen.net tenant, XrmToolBox
        private AppInsights ai;

        private List<EntityMetadataProxy> entities;
        private CommonSettings commonsettings;
        private Settings settings;
        private Dictionary<string, int> groupBoxHeights;
        private bool restoringselection = false;
        private EntityMetadataProxy selectedEntity;
        private string settingsfile;
        private object checkedrow;
        private readonly string commonsettingsfile = "[Common]";
        internal readonly bool isUML = false;
        internal static string toolnameLCG = "Latebound Constants Generator";
        internal static string toolnameUDG = "UML Diagram Generator";
        internal readonly string toolname = toolnameLCG;

        #endregion Private Fields

        #region Interface implementations

        public string DonationDescription => "LCG and UDG Fan Club";
        public string EmailAccount => "jonas@rappen.net";
        public string RepositoryName => "LateboundConstantGenerator";
        public string UserName => "rappen";

        public void ShowAboutDialog()
        {
            tslAbout_Click(null, null);
        }

        #endregion Interface implementations

        #region Public Constructors

        public LCG(bool isuml)
        {
            isUML = isuml;
            toolname = isUML ? toolnameUDG : toolnameLCG;
            ai = new AppInsights(new AiConfig(aiEndpoint, aiKey) { PluginName = toolname });
            IEnumerable<Control> GetAll(Control control, Type type)
            {
                var controls = control.Controls.Cast<Control>().ToArray();
                return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                          .Concat(controls)
                                          .Where(c => c.GetType() == type);
            }

            InitializeComponent();
            groupBoxHeights = new Dictionary<string, int>();
            foreach (var gb in GetAll(this, typeof(GroupBox)))
            {
                groupBoxHeights.Add(gb.Name, gb.Height);
            }
            if (isUML)
            {
                FixFormForUML();
            }
        }

        #endregion Public Constructors

        #region Public Methods

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            SettingsManager.Instance.Save(GetType(), commonsettings, SettingsFileName(commonsettingsfile));
            SaveSettings(ConnectionDetail?.ConnectionName, null);
            LogUse("Close");
            base.ClosingPlugin(info);
        }

        #endregion Public Methods

        #region Private Event Handlers

        private void attributeFilter_Changed(object sender, EventArgs e)
        {
            DisplayFilteredAttributes();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            LogUse("Generate");
            settings = GetSettingsFromUI(false);
            if (!GetFileSettings())
            {
                return;
            }
            var filewriter = settings.GetWriter(ConnectionDetail.WebApplicationUrl);
            var message = CSharpUtils.GenerateClasses(entities, settings, filewriter);
            MessageBox.Show(message, toolname, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            var sfd = new OpenFileDialog
            {
                Title = "Load settings and selections",
                Filter = "XML file (*.xml)|*.xml",
                FileName = Path.GetDirectoryName(settingsfile)
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                settingsfile = sfd.FileName;
                if (File.Exists(settingsfile))
                {
                    var document = new XmlDocument();
                    document.Load(settingsfile);
                    settings = (Settings)XmlSerializerHelper.Deserialize(document.OuterXml, typeof(Settings));
                    ApplySettings();
                    RestoreSelectedEntities();
                }
            }
        }

        private void btnLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            settings = GetSettingsFromUI(false);
            var gensettings = isUML ?
                OptionsDialogUML.GetSettings(this, settings) :
                OptionsDialogLCG.GetSettings(this, settings);
            if (gensettings != null)
            {
                if (settings == null)
                {
                    settings = new Settings();
                }
                settings.GenerationSettings = gensettings;
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            settings = GetSettingsFromUI(false);
            var sfd = new SaveFileDialog
            {
                Title = "Save settings and selections",
                Filter = "XML file (*.xml)|*.xml",
                FileName = settingsfile
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                settingsfile = sfd.FileName;
                XmlSerializerHelper.SerializeToFile(settings, settingsfile);
                MessageBox.Show("Settings and selections saved.", "Save configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chkAllRows_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            var grid = chk == chkEntAll ? gridEntities : chk == chkAttAll ? gridAttributes : null;
            if (grid != null)
            {
                SelectAllRows(grid, chk.Checked);
            }
        }

        private void entityFilter_Changed(object sender, EventArgs e)
        {
            FilterEntities();
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
                }
            }
        }

        private void gridEntities_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0
                && sender is DataGridView dgv
                && dgv.Rows[e.RowIndex].DataBoundItem is EntityMetadataProxy data
                && !string.IsNullOrEmpty(data.Metadata.EntityColor))
            {
                e.CellStyle.BackColor = ColorTranslator.FromHtml(data.Metadata.EntityColor);
            }
        }

        private void gridEntities_SelectionChanged(object sender, EventArgs e)
        {
            if (restoringselection)
            {
                return;
            }
            var newselectedEntity = GetSelectedEntity();
            if (newselectedEntity != null && newselectedEntity != selectedEntity)
            {
                selectedEntity = newselectedEntity;
                DisplayAttributes();
            }
        }

        private void LCG_ConnectionUpdated(object sender, ConnectionUpdatedEventArgs e)
        {
            LogInfo("Connection has changed to: {0}", e.ConnectionDetail.WebApplicationUrl);
            chkEntAll.Visible = false;
            chkAttAll.Visible = false;
            btnLoadConfig.Enabled = false;
            btnSaveConfig.Enabled = false;
            entities = null;
            selectedEntity = null;
            gridAttributes.DataSource = null;
            gridEntities.DataSource = null;
            LoadSettings(e.ConnectionDetail?.ConnectionName);
            LoadSolutions();
            Enabled = true;
        }

        private void LCG_Load(object sender, EventArgs e)
        {
            if (commonsettings == null)
            {
                LoadCommonSettings();
            }
            LogUse("Load");
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
            FilterEntities();
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

        #endregion Private Event Handlers

        #region Private Methods

        private string SettingsFileName(string name)
        {
            return (isUML ? "UDG_" : "") + name;
        }

        private void FixFormForUML()
        {
            btnGenerate.Text = "Generate UML";
        }

        internal void LogUse(string action)
        {
            ai.WriteEvent(action);
        }

        private static void SelectAllRows(DataGridView grid, bool select)
        {
            foreach (var metadata in grid.Rows
                .Cast<DataGridViewRow>()
                .Select(r => r.DataBoundItem)
                .OfType<MetadataProxy>())
            {
                metadata.SetSelected(select);
            }
        }

        private void ApplySettings()
        {
            rbEntCustomAll.Checked = settings.EntityFilter?.CustomAll != false;
            rbEntCustomFalse.Checked = settings.EntityFilter?.CustomFalse == true;
            rbEntCustomTrue.Checked = settings.EntityFilter?.CustomTrue == true;
            rbEntMgdAll.Checked = settings.EntityFilter?.ManagedAll != false;
            rbEntMgdTrue.Checked = settings.EntityFilter?.ManagedTrue == true;
            rbEntMgdFalse.Checked = settings.EntityFilter?.ManagedFalse == true;
            chkEntIntersect.Checked = settings.EntityFilter?.Intersect == true;
            //chkEntSelected.Checked = settings.EntityFilter?.SelectedOnly == true;
            chkAttCheckAll.Checked = settings.AttributeFilter?.CheckAll != false;
            rbAttCustomAll.Checked = settings.AttributeFilter?.CustomAll != false;
            rbAttCustomFalse.Checked = settings.AttributeFilter?.CustomFalse == true;
            rbAttCustomTrue.Checked = settings.AttributeFilter?.CustomTrue == true;
            rbAttMgdAll.Checked = settings.AttributeFilter?.ManagedAll != false;
            rbAttMgdTrue.Checked = settings.AttributeFilter?.ManagedTrue == true;
            rbAttMgdFalse.Checked = settings.AttributeFilter?.ManagedFalse == true;
            chkAttPrimaryKey.Checked = settings.AttributeFilter?.PrimaryKey == true;
            chkAttPrimaryAttribute.Checked = settings.AttributeFilter?.PrimaryAttribute == true;
            chkAttLogical.Checked = settings.AttributeFilter?.Logical == true;
            GroupBoxSetState(llEntityExpander, settings.EntityFilterExpanded);
            GroupBoxSetState(llAttributeExpander, settings.AttributeFilterExpanded);
        }

        private void Attribute_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SetSelected"))
            {
                UpdateAttributesStatus();
            }
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
            if (selectedEntity?.Attributes != null && selectedEntity.Attributes.Count > 0)
            {
                var filteredAttributes = GetFilter();
                if (chkAttPrimaryAttribute.Checked)
                {
                    AddToFilteredAttributes(filteredAttributes, selectedEntity.Metadata.PrimaryNameAttribute);
                }
                if (chkAttPrimaryKey.Checked)
                {
                    AddToFilteredAttributes(filteredAttributes, selectedEntity.Metadata.PrimaryIdAttribute);
                }
                gridAttributes.DataSource = filteredAttributes;
                if (gridAttributes.Columns.Count > 0)
                {
                    gridAttributes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
                    gridAttributes.Columns[0].Width = 30;
                }
            }
            else
            {
                gridAttributes.DataSource = null;
            }
            UpdateAttributesStatus();
        }

        private void AddToFilteredAttributes(SortableBindingList<AttributeMetadataProxy> filteredAttributes, string attributeName)
        {
            var att = selectedEntity.Attributes.FirstOrDefault(a => a.LogicalName == attributeName);
            if (att != null && !filteredAttributes.Contains(att))
            {
                filteredAttributes.Insert(0, att);
            }
        }

        private SortableBindingList<AttributeMetadataProxy> GetFilter()
        {
            return new SortableBindingList<AttributeMetadataProxy>(
                selectedEntity.Attributes
                    .Where(
                        e => GetCustomFilter(e)
                           && GetManagedFilter(e)
                           && GetSearchFilter(e)
                           && GetLogicalFilter(e)));
        }

        private bool GetCustomFilter(AttributeMetadataProxy e)
        {
            return rbAttCustomAll.Checked ||
                   rbAttCustomTrue.Checked && e.Metadata.IsCustomAttribute.GetValueOrDefault() ||
                   rbAttCustomFalse.Checked && !e.Metadata.IsCustomAttribute.GetValueOrDefault();
        }

        private bool GetManagedFilter(AttributeMetadataProxy e)
        {
            return rbAttMgdAll.Checked ||
                   rbAttMgdTrue.Checked && e.Metadata.IsManaged.GetValueOrDefault() ||
                   rbAttMgdFalse.Checked && !e.Metadata.IsManaged.GetValueOrDefault();
        }

        private bool GetSearchFilter(AttributeMetadataProxy e)
        {
            return string.IsNullOrWhiteSpace(txtAttSearch.Text) ||
                   e.Metadata.LogicalName.ToLowerInvariant().Contains(txtAttSearch.Text) ||
                   e.Metadata.DisplayName?.UserLocalizedLabel?.Label?.ToLowerInvariant().Contains(txtAttSearch.Text) == true;
        }

        private bool GetLogicalFilter(AttributeMetadataProxy e)
        {
            return chkAttLogical.Checked ||
                   e.Metadata.IsLogical != true;
        }

        private void EnableControls(bool enabled)
        {
            UpdateUI(() =>
            {
                Enabled = enabled;
            });
        }

        private void Entity_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
            if (!restoringselection && chkAttCheckAll.Checked && entity?.Selected == true)
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
            checkedrow = null;
        }

        private void FilterEntities()
        {
            if (entities != null && entities.Count > 0)
            {
                var filteredentities = GetFilteredEntities();
                if (cmbSolution.SelectedItem is SolutionProxy solution)
                {
                    if (solution.Entities == null)
                    {
                        LoadSolutionEntities(solution, FilterEntities);
                        return;
                    }
                    filteredentities = filteredentities
                        .Where(e => solution.Entities.Contains(e.LogicalName));
                }

                gridEntities.DataSource = new SortableBindingList<EntityMetadataProxy>(filteredentities);
            }
            else
            {
                gridEntities.DataSource = null;
            }
            UpdateEntitiesStatus();
        }

        private IEnumerable<EntityMetadataProxy> GetFilteredEntities()
        {
            var filteredentities = entities.Where(
                e => IsNotPrivate(e)
                     && GetSelectedFilter(e)
                     && GetCustomFilter(e)
                     && GetManagedFilter(e)
                     && GetIntersectFilter(e)
                     && GetSearchFilter(e));
            return filteredentities;
        }

        private bool GetSearchFilter(EntityMetadataProxy e)
        {
            return string.IsNullOrWhiteSpace(txtEntSearch.Text) ||
                   e.Metadata.LogicalName.ToLowerInvariant().Contains(txtEntSearch.Text) ||
                   e.Metadata.DisplayName?.UserLocalizedLabel?.Label?.ToLowerInvariant().Contains(txtEntSearch.Text) == true;
        }

        private bool GetIntersectFilter(EntityMetadataProxy e) { return !e.Metadata.IsIntersect.GetValueOrDefault() || chkEntIntersect.Checked; }

        private static bool IsNotPrivate(EntityMetadataProxy e) { return !e.Metadata.IsPrivate.GetValueOrDefault(); }

        private bool GetSelectedFilter(EntityMetadataProxy e) { return !chkEntSelected.Checked || e.IsSelected; }

        private bool GetManagedFilter(EntityMetadataProxy e)
        {
            return rbEntMgdAll.Checked ||
                   rbEntMgdTrue.Checked && e.Metadata.IsManaged.GetValueOrDefault() ||
                   rbEntMgdFalse.Checked && !e.Metadata.IsManaged.GetValueOrDefault();
        }

        private bool GetCustomFilter(EntityMetadataProxy e)
        {
            return rbEntCustomAll.Checked ||
                   rbEntCustomTrue.Checked && e.Metadata.IsCustomEntity.GetValueOrDefault() ||
                   rbEntCustomFalse.Checked && !e.Metadata.IsCustomEntity.GetValueOrDefault();
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

        private Settings GetSettingsFromUI(bool noprompt)
        {
            if (settings == null)
            {
                settings = new Settings();
            }
            settings.commonsettings = commonsettings;
            settings.EntityFilterExpanded = gbEntities.Height > 20;
            settings.AttributeFilterExpanded = gbAttributes.Height > 20;
            settings.EntityFilter = new EntityFilter
            {
                CustomAll = rbEntCustomAll.Checked,
                CustomFalse = rbEntCustomFalse.Checked,
                CustomTrue = rbEntCustomTrue.Checked,
                ManagedAll = rbEntMgdAll.Checked,
                ManagedTrue = rbEntMgdTrue.Checked,
                ManagedFalse = rbEntMgdFalse.Checked,
                Intersect = chkEntIntersect.Checked,
                SelectedOnly = chkEntSelected.Checked
            };
            settings.AttributeFilter = new AttributeFilter
            {
                CheckAll = chkAttCheckAll.Checked,
                CustomAll = rbAttCustomAll.Checked,
                CustomFalse = rbAttCustomFalse.Checked,
                CustomTrue = rbAttCustomTrue.Checked,
                ManagedAll = rbAttMgdAll.Checked,
                ManagedTrue = rbAttMgdTrue.Checked,
                ManagedFalse = rbAttMgdFalse.Checked,
                PrimaryKey = chkAttPrimaryKey.Checked,
                PrimaryAttribute = chkAttPrimaryAttribute.Checked,
                Logical = chkAttLogical.Checked
            };
            if (entities != null)
            {
                settings.Selection = entities
                    .Where(e => e.IsSelected)
                    .Select(e => e.LogicalName + ":" + (e.Attributes != null ? string.Join(",", e.Attributes.Where(a => a.Selected).Select(a => a.LogicalName)) : string.Empty))
                    .ToList();
            }
            if (string.IsNullOrWhiteSpace(settings.OutputFolder) && !noprompt)
            {
                GetFileSettings();
            }
            return settings;
        }

        private bool GetFileSettings()
        {
            var filesettings = isUML ?
                FileDialogUML.GetSettings(this, settings) :
                FileDialogLCG.GetSettings(this, settings);
            if (filesettings != null)
            {
                settings.FileSettings = filesettings;
                return true;
            }
            return false;
        }

        private void GroupBoxCollapse(LinkLabel link)
        {
            link.Parent.Height = 18;
            link.Text = "Show";
        }

        private void GroupBoxExpand(LinkLabel link)
        {
            link.Parent.Height = groupBoxHeights[link.Parent.Name];
            link.Text = "Hide";
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
            if (link.Parent.Height > 20)
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
                        MessageBox.Show(completedArgs.Error.Message);
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
                                attribute.PropertyChanged += Attribute_PropertyChanged;
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

        private void LoadEntities()
        {
            entities = null;
            EnableControls(false);
            gridAttributes.DataSource = null;
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
                        MessageBox.Show(args.Error.Message);
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
                            entity.PropertyChanged += Entity_PropertyChanged;
                            entity.Relationships = new List<RelationshipMetadataProxy>(
                                entity.Metadata.ManyToOneRelationships.Select(m => new RelationshipMetadataProxy(entities, m)));
                            entity.Relationships.AddRange(
                                entity.Metadata.OneToManyRelationships
                                    .Where(r => !entity.Metadata.ManyToOneRelationships.Select(r1m => r1m.SchemaName).Contains(r.SchemaName))
                                    .Select(r => new RelationshipMetadataProxy(entities, r)));
                            entity.Relationships.AddRange(
                                entity.Metadata.ManyToManyRelationships.Select(m => new RelationshipMetadataProxy(entities, m)));
                        }
                    }
                    UpdateUI(() =>
                    {
                        RestoreSelectedEntities();
                        FilterEntities();
                        if (gridEntities.Columns.Count > 0)
                        {
                            gridEntities.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
                            gridEntities.Columns[0].Width = 30;
                        }
                        btnLoadConfig.Enabled = true;
                        btnSaveConfig.Enabled = true;
                        EnableControls(true);
                    });
                }
            });
        }

        private void LoadCommonSettings()
        {
            if (!SettingsManager.Instance.TryLoad(GetType(), out commonsettings, SettingsFileName(commonsettingsfile)))
            {
                commonsettings = new CommonSettings(isUML);
                LogWarning("Common Settings not found => created");
            }
            else
            {
                LogInfo("Common Settings found and loaded");
            }
            commonsettings.Template.SetFixedValues(isUML);
            if (commonsettings.Template.TemplateVersion != new Template(isUML).TemplateVersion)
            {
                MessageBox.Show("Template has been updated.\nAny customizations will need to be recreated.", "Template", MessageBoxButtons.OK, MessageBoxIcon.Information);
                commonsettings.Template = new Template(isUML);
            }
        }

        private void LoadSettings(string connectionname)
        {
            if (SettingsManager.Instance.TryLoad(GetType(), out settings, SettingsFileName(connectionname)))
            {
                ApplySettings();
            }
        }

        private void LoadSolutionEntities(SolutionProxy solution, Action callback)
        {
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
                        MessageBox.Show(args.Error.Message);
                    }
                    if (args.Result is EntityCollection solutionentities)
                    {
                        solution.Entities = entities
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
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        if (completedargs.Result is EntityCollection solutions)
                        {
                            var proxiedsolutions = solutions.Entities.Select(s => new SolutionProxy(s)).OrderBy(s => s.ToString());
                            cmbSolution.Items.Add("");
                            cmbSolution.Items.AddRange(proxiedsolutions.Cast<object>().ToArray());
                        }
                    }
                    EnableControls(true);
                }
            });
        }

        private void RestoreSelectedEntities()
        {
            if (entities == null)
            {
                return;
            }
            if (settings == null && !SettingsManager.Instance.TryLoad(GetType(), out settings, SettingsFileName(ConnectionDetail.ConnectionName)))
            {
                return;
            }

            restoringselection = true;
            foreach (var entitystring in settings.Selection)
            {
                var entityname = entitystring.Split(':')[0];
                var attributes = entitystring.Split(':')[1].Split(',').ToList();
                var entity = entities.FirstOrDefault(e => e.LogicalName == entityname);
                if (entity == null)
                {
                    continue;
                }
                if (!entity.Selected)
                {
                    entity.SetSelected(true);
                }

                foreach (var attributename in attributes)
                {
                    if (entity.Attributes == null)
                    {
                        LoadAttributes(entity, RestoreSelectedEntities);
                        return;
                    }
                    var attribute = entity.Attributes.FirstOrDefault(a => a.LogicalName == attributename);
                    if (attribute != null && !attribute.Selected)
                    {
                        attribute.SetSelected(true);
                    }
                }
            }
            restoringselection = false;
            gridEntities_SelectionChanged(null, null);
        }

        private void SaveSettings(string connectionname, Settings settings)
        {
            if (settings == null)
            {
                settings = GetSettingsFromUI(true);
            }
            SettingsManager.Instance.Save(GetType(), settings, SettingsFileName(connectionname));
        }

        private void SelectAllAttributes()
        {
            SelectAllRows(gridAttributes, true);
        }

        private void UpdateAttributesStatus()
        {
            chkAttAll.Visible = gridAttributes.Rows.Count > 0;
            if (gridAttributes.DataSource != null && selectedEntity != null && selectedEntity.Attributes != null)
            {
                statusAttributesShowing.Text = $"Showing {gridAttributes.Rows.Count} of {selectedEntity.Attributes.Count} attributes.";
                statusAttributesSelected.Text = $"{selectedEntity?.Attributes?.Count(att => att.Selected)} selected.";
            }
            else
            {
                statusAttributesShowing.Text = "No attributes available";
                statusAttributesSelected.Text = "";
            }
        }

        private void UpdateEntitiesStatus()
        {
            chkEntAll.Visible = gridEntities.Rows.Count > 0;
            btnGenerate.Enabled = entities != null && (bool)entities?.Any(e => e.IsSelected);
            if (gridEntities.DataSource != null && entities != null)
            {
                statusEntitiesShowing.Text = $"Showing {gridEntities.Rows.Count} of {entities.Count} entities.";
                statusEntitiesSelected.Text = $"{entities.Count(ent => ent.Selected)} selected.";
            }
            else
            {
                statusEntitiesShowing.Text = "No entities available";
                statusEntitiesSelected.Text = "";
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

        #endregion Private Methods
    }
}