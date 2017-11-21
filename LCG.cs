using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Rappen.XTB.LCG
{
    public partial class LCG : PluginControlBase
    {
        #region Private Fields

        private List<EntityMetadataProxy> entities;
        private EntityMetadataProxy selectedEntity;

        #endregion Private Fields

        #region Public Constructors

        public LCG()
        {
            InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Methods

        public override void ClosingPlugin(PluginCloseInfo info)
        {
            SettingsSave(ConnectionDetail?.ConnectionName);
            base.ClosingPlugin(info);
        }

        #endregion Public Methods

        #region Private Event Handlers

        private void attributeFilter_Changed(object sender, EventArgs e)
        {
            FilterAttributes(selectedEntity);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateClasses();
        }

        private void btnLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            var fldr = new FolderBrowserDialog
            {
                Description = "Select folder where generated constant files will be generated.",
                SelectedPath = txtOutputFolder.Text,
                ShowNewFolderButton = true
            };
            if (fldr.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolder.Text = fldr.SelectedPath;
            }
        }

        private void chkAllRows_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            var grid = chk == chkEntAll ? gridEntities : chk == chkAttAll ? gridAttributes : null;
            if (grid != null)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    var metadata = row.DataBoundItem as MetadataProxy;
                    if (metadata != null)
                    {
                        metadata.SetSelected(chk.Checked);
                    }
                }
                grid.Refresh();
            }
        }

        private void entityFilter_Changed(object sender, EventArgs e)
        {
            FilterEntities();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid != null && e.ColumnIndex == 0)
            {
                var row = grid.Rows[e.RowIndex];
                var metadata = row.DataBoundItem as MetadataProxy;
                if (metadata != null)
                {
                    metadata.SetSelected(!metadata.IsSelected);
                }
            }
        }

        private void gridEntities_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridView dgv = sender as DataGridView;
                var data = dgv.Rows[e.RowIndex].DataBoundItem as EntityMetadataProxy;
                if (!string.IsNullOrEmpty(data.Metadata.EntityColor))
                {
                    e.CellStyle.BackColor = ColorTranslator.FromHtml(data.Metadata.EntityColor);
                }
            }
        }

        private void gridEntities_SelectionChanged(object sender, EventArgs e)
        {
            var newselectedEntity = GetSelectedEntity();
            if (newselectedEntity != null && newselectedEntity != selectedEntity)
            {
                selectedEntity = newselectedEntity;
                DisplayAttributes(selectedEntity);
            }
        }

        private void LCG_ConnectionUpdated(object sender, ConnectionUpdatedEventArgs e)
        {
            LogInfo("Connection has changed to: {0}", e.ConnectionDetail.WebApplicationUrl);
            SettingsLoad(e.ConnectionDetail?.ConnectionName);
            Enabled = true;
        }

        private void llOptionsExpander_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OptionsToggle();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        #endregion Private Event Handlers

        #region Private Methods

        private void DisplayAttributes(EntityMetadataProxy entity)
        {
            if (entity != null && entity.Attributes == null)
            {
                LoadAttributes(entity);
            }
            FilterAttributes(entity);
        }

        private void EnableControls(bool enabled)
        {
            UpdateUI(() =>
            {
                Enabled = enabled;
            });
        }

        private void FilterAttributes(EntityMetadataProxy entity)
        {
            if (entity != null && entity.Attributes != null && entity.Attributes.Count > 0)
            {
                gridAttributes.DataSource = new SortableBindingList<AttributeMetadataProxy>(
                    entity.Attributes
                    .Where(e => (rbAttCustomAll.Checked ||
                         (rbAttCustomTrue.Checked && e.Metadata.IsCustomAttribute.Value) ||
                         (rbAttCustomFalse.Checked && !e.Metadata.IsCustomAttribute.Value)))
                    .Where(e => (rbAttMgdAll.Checked ||
                         (rbAttMgdTrue.Checked && e.Metadata.IsManaged.Value) ||
                         (rbAttMgdFalse.Checked && !e.Metadata.IsManaged.Value)))
                    .Where(e => string.IsNullOrWhiteSpace(txtAttFilter.Text) ||
                        e.Metadata.LogicalName.ToLowerInvariant().Contains(txtAttFilter.Text) ||
                        e.Metadata.DisplayName?.UserLocalizedLabel?.Label?.ToLowerInvariant().Contains(txtAttFilter.Text) == true));
            }
            else
            {
                gridAttributes.DataSource = null;
            }
            UpdateAttributesStatus();
        }

        private void FilterEntities()
        {
            if (entities != null && entities.Count > 0)
            {
                gridEntities.DataSource = new SortableBindingList<EntityMetadataProxy>(
                    entities
                    .Where(e => !e.Metadata.IsPrivate.Value)
                    .Where(e => !chkEntSelected.Checked || e.IsSelected)
                    .Where(e => (rbEntCustomAll.Checked ||
                         (rbEntCustomTrue.Checked && e.Metadata.IsCustomEntity.Value) ||
                         (rbEntCustomFalse.Checked && !e.Metadata.IsCustomEntity.Value)))
                    .Where(e => (rbEntMgdAll.Checked ||
                         (rbEntMgdTrue.Checked && e.Metadata.IsManaged.Value) ||
                         (rbEntMgdFalse.Checked && !e.Metadata.IsManaged.Value)))
                    .Where(e => !e.Metadata.IsIntersect.Value || chkEntIntersect.Checked)
                    .Where(e => string.IsNullOrWhiteSpace(txtEntFilter.Text) ||
                        e.Metadata.LogicalName.ToLowerInvariant().Contains(txtEntFilter.Text) ||
                        e.Metadata.DisplayName?.UserLocalizedLabel?.Label?.ToLowerInvariant().Contains(txtEntFilter.Text) == true));
            }
            else
            {
                gridEntities.DataSource = null;
            }
            UpdateEntitiesStatus();
        }

        private void GenerateClasses()
        {
            var ent = string.Join("\n", entities
                .Where(e => e.IsSelected)
                .Select(e => e.ToString() + "\n" +
                    string.Join("\n", e.Attributes
                        .Where(a => a.IsSelected)
                        .Select(a => "  " + a.ToString()))));
            MessageBox.Show(ent);
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

        private void LoadAttributes(EntityMetadataProxy entity)
        {
            entity.Attributes = null;
            EnableControls(false);
            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Loading attributes for {entity}...",
                Work = (worker, args) =>
                {
                    args.Result = MetadataHelper.LoadEntityDetails(Service, entity.LogicalName);
                },
                PostWorkCallBack = (completedargs) =>
                {
                    if (completedargs.Error != null)
                    {
                        MessageBox.Show(completedargs.Error.Message);
                    }
                    else
                    {
                        if (completedargs.Result is RetrieveMetadataChangesResponse)
                        {
                            var metaresponse = ((RetrieveMetadataChangesResponse)completedargs.Result).EntityMetadata;
                            if (metaresponse.Count == 1)
                            {
                                entity.Attributes = new List<AttributeMetadataProxy>(
                                    metaresponse[0].Attributes
                                    .Select(m => new AttributeMetadataProxy(entity, m))
                                    .OrderBy(a => a.ToString()));
                                foreach (var attribute in entity.Attributes)
                                {
                                    attribute.PropertyChanged += Attribute_PropertyChanged;
                                }
                            }
                        }
                    }
                    UpdateUI(() =>
                    {
                        FilterAttributes(entity);
                        if (gridAttributes.Columns.Count > 0)
                        {
                            gridAttributes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
                            gridAttributes.Columns[0].Width = 30;
                        }
                        EnableControls(true);
                    });
                }
            });
        }

        private void Attribute_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateAttributesStatus();
        }

        private void UpdateAttributesStatus()
        {
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

        private void LoadEntities()
        {
            entities = null;
            EnableControls(false);
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading entities...",
                Work = (worker, args) =>
                {
                    args.Result = MetadataHelper.LoadEntities(Service);
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.Message);
                    }
                    else
                    {
                        if (args.Result is RetrieveMetadataChangesResponse)
                        {
                            var metaresponse = ((RetrieveMetadataChangesResponse)args.Result).EntityMetadata;
                            entities = new List<EntityMetadataProxy>(
                                metaresponse
                                .Select(m => new EntityMetadataProxy(m))
                                .OrderBy(e => e.ToString()));
                            foreach (var entity in entities)
                            {
                                entity.PropertyChanged += Entity_PropertyChanged;
                            }
                        }
                    }
                    UpdateUI(() =>
                    {
                        FilterEntities();
                        if (gridEntities.Columns.Count > 0)
                        {
                            gridEntities.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader);
                            gridEntities.Columns[0].Width = 30;
                        }
                        EnableControls(true);
                    });
                }
            });
        }

        private void Entity_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateEntitiesStatus();
        }

        private void UpdateEntitiesStatus()
        {
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

        private void OptionsCollapse()
        {
            gbOptions.Height = 18;
            llOptionsExpander.Text = "Expand";
        }

        private void OptionsExpand()
        {
            gbOptions.Height = 130;
            llOptionsExpander.Text = "Collapse";
        }

        private void OptionsToggle()
        {
            if (gbOptions.Height > 20)
            {
                OptionsCollapse();
            }
            else
            {
                OptionsExpand();
            }
        }

        private void SettingsLoad(string connectionname)
        {
            if (SettingsManager.Instance.TryLoad(GetType(), out Settings settings, connectionname))
            {
                rbEntCustomAll.Checked = settings.EntitiesCustomAll;
                rbEntCustomFalse.Checked = settings.EntitiesCustomFalse;
                rbEntCustomTrue.Checked = settings.EntitiesCustomTrue;
                rbEntMgdAll.Checked = settings.EntitiesManagedAll;
                rbEntMgdTrue.Checked = settings.EntitiesManagedTrue;
                rbEntMgdFalse.Checked = settings.EntitiesManagedFalse;
                chkEntIntersect.Checked = settings.EntitiesIntersect;
                rbAttCustomAll.Checked = settings.AttributesCustomAll;
                rbAttCustomFalse.Checked = settings.AttributesCustomFalse;
                rbAttCustomTrue.Checked = settings.AttributesCustomTrue;
                rbAttMgdAll.Checked = settings.AttributesManagedAll;
                rbAttMgdTrue.Checked = settings.AttributesManagedTrue;
                rbAttMgdFalse.Checked = settings.AttributesManagedFalse;
                if (string.IsNullOrEmpty(txtOutputFolder.Text))
                {
                    txtOutputFolder.Text = settings.OutputFolder;
                }
                if (settings.OptionsExpanded)
                {
                    OptionsExpand();
                }
                else
                {
                    OptionsCollapse();
                }
            }
        }

        private void SettingsSave(string connectionname)
        {
            SettingsManager.Instance.Save(GetType(), new Settings
            {
                EntitiesCustomAll = rbEntCustomAll.Checked,
                EntitiesCustomFalse = rbEntCustomFalse.Checked,
                EntitiesCustomTrue = rbEntCustomTrue.Checked,
                EntitiesManagedAll = rbEntMgdAll.Checked,
                EntitiesManagedTrue = rbEntMgdTrue.Checked,
                EntitiesManagedFalse = rbEntMgdFalse.Checked,
                EntitiesIntersect = chkEntIntersect.Checked,
                AttributesCustomAll = rbAttCustomAll.Checked,
                AttributesCustomFalse = rbAttCustomFalse.Checked,
                AttributesCustomTrue = rbAttCustomTrue.Checked,
                AttributesManagedAll = rbAttMgdAll.Checked,
                AttributesManagedTrue = rbAttMgdTrue.Checked,
                AttributesManagedFalse = rbAttMgdFalse.Checked,
                OutputFolder = txtOutputFolder.Text,
                OptionsExpanded = gbOptions.Height > 20
            }, connectionname);
        }

        private void UpdateUI(Action action)
        {
            MethodInvoker mi = delegate
            {
                action();
            };
            if (InvokeRequired)
            {
                //                if (!Disposing)
                {
                    Invoke(mi);
                }
            }
            else
            {
                mi();
            }
        }

        #endregion Private Methods
    }
}