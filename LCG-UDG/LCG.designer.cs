namespace Rappen.XTB.LCG
{
    partial class LCG
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LCG));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.btnLoadEntities = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuOpen = new System.Windows.Forms.ToolStripButton();
            this.btnGenerate = new System.Windows.Forms.ToolStripSplitButton();
            this.btnSaveCsAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveConfigAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOptions = new System.Windows.Forms.ToolStripButton();
            this.tslAbout = new System.Windows.Forms.ToolStripLabel();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.tsbSupporting = new System.Windows.Forms.ToolStripButton();
            this.splitEntityRest = new System.Windows.Forms.SplitContainer();
            this.pnEntityGrid = new System.Windows.Forms.Panel();
            this.chkEntAll = new System.Windows.Forms.CheckBox();
            this.gridEntities = new System.Windows.Forms.DataGridView();
            this.panEntityGroup = new System.Windows.Forms.Panel();
            this.posGroupUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnGroupDelete = new System.Windows.Forms.Button();
            this.btnGroupAdd = new System.Windows.Forms.Button();
            this.btnGroupColor = new System.Windows.Forms.Button();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tsEntities = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkEntAddAllShownColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.chkEntAddAllShownRelationships = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEntSelectAllVisible = new System.Windows.Forms.ToolStripButton();
            this.btnEntUnselectAll = new System.Windows.Forms.ToolStripButton();
            this.btnEntShowAll = new System.Windows.Forms.ToolStripButton();
            this.lblEntUnShown = new System.Windows.Forms.Label();
            this.statusEntities = new System.Windows.Forms.StatusStrip();
            this.statusEntitiesShowing = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusEntitiesSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEntNoMatch = new System.Windows.Forms.Label();
            this.gbEntities = new System.Windows.Forms.GroupBox();
            this.pnEntSolution = new System.Windows.Forms.Panel();
            this.cmbSolution = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnEntCustom = new System.Windows.Forms.Panel();
            this.rbEntUnsel = new System.Windows.Forms.RadioButton();
            this.rbEntSel = new System.Windows.Forms.RadioButton();
            this.rbEntAll = new System.Windows.Forms.RadioButton();
            this.chkEntShowUncountable = new System.Windows.Forms.CheckBox();
            this.chkEntExclMS = new System.Windows.Forms.CheckBox();
            this.chkEntExclIntersect = new System.Windows.Forms.CheckBox();
            this.llEntityExpander = new System.Windows.Forms.LinkLabel();
            this.pnEntSearch = new System.Windows.Forms.Panel();
            this.txtEntSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitAttRel = new System.Windows.Forms.SplitContainer();
            this.pnAttributeGrid = new System.Windows.Forms.Panel();
            this.chkAttAll = new System.Windows.Forms.CheckBox();
            this.gridAttributes = new System.Windows.Forms.DataGridView();
            this.tsAttributes = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkAttCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAttSelectAllVisible = new System.Windows.Forms.ToolStripButton();
            this.btnAttUnselectAll = new System.Windows.Forms.ToolStripButton();
            this.btnAttShowAll = new System.Windows.Forms.ToolStripButton();
            this.lblAttUnShown = new System.Windows.Forms.Label();
            this.statusAttributes = new System.Windows.Forms.StatusStrip();
            this.statusAttributesShowing = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusAttributesSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAttNoMatch = new System.Windows.Forms.Label();
            this.gbAttributes = new System.Windows.Forms.GroupBox();
            this.pnAttSearch = new System.Windows.Forms.Panel();
            this.txtAttSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.llAttributeExpander = new System.Windows.Forms.LinkLabel();
            this.pnAttCustom = new System.Windows.Forms.Panel();
            this.picAttReloadRecords = new System.Windows.Forms.PictureBox();
            this.chkAttUniques = new System.Windows.Forms.CheckBox();
            this.chkAttUsed = new System.Windows.Forms.CheckBox();
            this.chkAttExclCreMod = new System.Windows.Forms.CheckBox();
            this.chkAttExclOwners = new System.Windows.Forms.CheckBox();
            this.pnRelationshipGrid = new System.Windows.Forms.Panel();
            this.chkRelAll = new System.Windows.Forms.CheckBox();
            this.gridRelationships = new System.Windows.Forms.DataGridView();
            this.tsRelationships = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.chkRelCheckAll = new System.Windows.Forms.ToolStripMenuItem();
            this.chkRelRemoveWhenUncheckedEntity = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRelSelectAllVisible = new System.Windows.Forms.ToolStripButton();
            this.btnRelUnselectAll = new System.Windows.Forms.ToolStripButton();
            this.btnRelShowAll = new System.Windows.Forms.ToolStripButton();
            this.lblRelUnShown = new System.Windows.Forms.Label();
            this.statusRelationships = new System.Windows.Forms.StatusStrip();
            this.statusRelationshipsShowing = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusRelationshipsSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRelNoMatch = new System.Windows.Forms.Label();
            this.gbRelationships = new System.Windows.Forms.GroupBox();
            this.panRelSearch = new System.Windows.Forms.Panel();
            this.txtRelSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panRel2 = new System.Windows.Forms.Panel();
            this.chkRelReqLookups = new System.Windows.Forms.CheckBox();
            this.chkRelExclDupRecords = new System.Windows.Forms.CheckBox();
            this.chkRelNN = new System.Windows.Forms.CheckBox();
            this.chkRelExclCreMod = new System.Windows.Forms.CheckBox();
            this.chkRelExclRegarding = new System.Windows.Forms.CheckBox();
            this.chkRelExclOwners = new System.Windows.Forms.CheckBox();
            this.chkRelN1 = new System.Windows.Forms.CheckBox();
            this.chkRelExclOrphans = new System.Windows.Forms.CheckBox();
            this.chkRel1N = new System.Windows.Forms.CheckBox();
            this.llRelationshipExpander = new System.Windows.Forms.LinkLabel();
            this.tmEntSearch = new System.Windows.Forms.Timer(this.components);
            this.tmAttSearch = new System.Windows.Forms.Timer(this.components);
            this.pnWindowTopSpacer = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tmRelSearch = new System.Windows.Forms.Timer(this.components);
            this.tmHideNotification = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.chkRelIncludeColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.triEntManaged = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triEntCustom = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triEntRecords = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triAttRequired = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triAttManaged = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triAttLogical = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triAttInternal = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triAttCustom = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triAttPrimaryKeyName = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triRelManaged = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triRelCustom = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitEntityRest)).BeginInit();
            this.splitEntityRest.Panel1.SuspendLayout();
            this.splitEntityRest.Panel2.SuspendLayout();
            this.splitEntityRest.SuspendLayout();
            this.pnEntityGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntities)).BeginInit();
            this.panEntityGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posGroupUpDown)).BeginInit();
            this.tsEntities.SuspendLayout();
            this.statusEntities.SuspendLayout();
            this.gbEntities.SuspendLayout();
            this.pnEntSolution.SuspendLayout();
            this.pnEntCustom.SuspendLayout();
            this.pnEntSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitAttRel)).BeginInit();
            this.splitAttRel.Panel1.SuspendLayout();
            this.splitAttRel.Panel2.SuspendLayout();
            this.splitAttRel.SuspendLayout();
            this.pnAttributeGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttributes)).BeginInit();
            this.tsAttributes.SuspendLayout();
            this.statusAttributes.SuspendLayout();
            this.gbAttributes.SuspendLayout();
            this.pnAttSearch.SuspendLayout();
            this.pnAttCustom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAttReloadRecords)).BeginInit();
            this.pnRelationshipGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRelationships)).BeginInit();
            this.tsRelationships.SuspendLayout();
            this.statusRelationships.SuspendLayout();
            this.gbRelationships.SuspendLayout();
            this.panRelSearch.SuspendLayout();
            this.panRel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadEntities,
            this.toolStripSeparator1,
            this.menuOpen,
            this.btnGenerate,
            this.toolStripSeparator2,
            this.btnOptions,
            this.tslAbout,
            this.btnCancel,
            this.tsbSupporting});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1028, 39);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // btnLoadEntities
            // 
            this.btnLoadEntities.Image = global::Rappen.XTB.LCG.Properties.Resources.icons8_reset_32__2_;
            this.btnLoadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadEntities.Name = "btnLoadEntities";
            this.btnLoadEntities.Size = new System.Drawing.Size(132, 36);
            this.btnLoadEntities.Text = "Reload metadata";
            this.btnLoadEntities.Click += new System.EventHandler(this.btnLoadEntities_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // menuOpen
            // 
            this.menuOpen.Image = global::Rappen.XTB.LCG.Properties.Resources.icons8_open_32;
            this.menuOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(72, 36);
            this.menuOpen.Text = "Open";
            this.menuOpen.Click += new System.EventHandler(this.btnOpenGeneratedFile_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveCsAs,
            this.toolStripSeparator3,
            this.btnSaveConfig,
            this.btnSaveConfigAs});
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Image = global::Rappen.XTB.LCG.Properties.Resources.icons8_run_command_32;
            this.btnGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(102, 36);
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.ButtonClick += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnSaveCsAs
            // 
            this.btnSaveCsAs.Image = global::Rappen.XTB.LCG.Properties.Resources.csharp32;
            this.btnSaveCsAs.Name = "btnSaveCsAs";
            this.btnSaveCsAs.Size = new System.Drawing.Size(153, 22);
            this.btnSaveCsAs.Text = "C# file as...";
            this.btnSaveCsAs.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(150, 6);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Image = global::Rappen.XTB.LCG.Properties.Resources.project32;
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(153, 22);
            this.btnSaveConfig.Text = "Project file";
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfigAs_Click);
            // 
            // btnSaveConfigAs
            // 
            this.btnSaveConfigAs.Image = global::Rappen.XTB.LCG.Properties.Resources.projectnew32;
            this.btnSaveConfigAs.Name = "btnSaveConfigAs";
            this.btnSaveConfigAs.Size = new System.Drawing.Size(153, 22);
            this.btnSaveConfigAs.Text = "Project file as...";
            this.btnSaveConfigAs.Click += new System.EventHandler(this.btnSaveConfigAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnOptions
            // 
            this.btnOptions.Image = global::Rappen.XTB.LCG.Properties.Resources.icons8_options_32__3_;
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(85, 36);
            this.btnOptions.Text = "Options";
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // tslAbout
            // 
            this.tslAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tslAbout.Image = global::Rappen.XTB.LCG.Properties.Resources.LCG32;
            this.tslAbout.IsLink = true;
            this.tslAbout.Name = "tslAbout";
            this.tslAbout.Size = new System.Drawing.Size(114, 36);
            this.tslAbout.Text = "by Jonas Rapp";
            this.tslAbout.Click += new System.EventHandler(this.tslAbout_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Image = global::Rappen.XTB.LCG.Properties.Resources.icons8_stop_sign_32;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 36);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tsbSupporting
            // 
            this.tsbSupporting.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbSupporting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSupporting.Image = global::Rappen.XTB.LCG.Properties.Resources.Supporting_icon;
            this.tsbSupporting.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSupporting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSupporting.Name = "tsbSupporting";
            this.tsbSupporting.Size = new System.Drawing.Size(56, 36);
            this.tsbSupporting.ToolTipText = "We all support these free, open-source tools - either\r\nas a company, personally, " +
    "or by contribution.";
            this.tsbSupporting.Click += new System.EventHandler(this.tsbSupporting_Click);
            // 
            // splitEntityRest
            // 
            this.splitEntityRest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitEntityRest.Location = new System.Drawing.Point(0, 56);
            this.splitEntityRest.Name = "splitEntityRest";
            // 
            // splitEntityRest.Panel1
            // 
            this.splitEntityRest.Panel1.Controls.Add(this.pnEntityGrid);
            this.splitEntityRest.Panel1.Controls.Add(this.tsEntities);
            this.splitEntityRest.Panel1.Controls.Add(this.lblEntUnShown);
            this.splitEntityRest.Panel1.Controls.Add(this.statusEntities);
            this.splitEntityRest.Panel1.Controls.Add(this.lblEntNoMatch);
            this.splitEntityRest.Panel1.Controls.Add(this.gbEntities);
            // 
            // splitEntityRest.Panel2
            // 
            this.splitEntityRest.Panel2.Controls.Add(this.splitAttRel);
            this.splitEntityRest.Size = new System.Drawing.Size(1028, 783);
            this.splitEntityRest.SplitterDistance = 347;
            this.splitEntityRest.TabIndex = 2;
            // 
            // pnEntityGrid
            // 
            this.pnEntityGrid.Controls.Add(this.chkEntAll);
            this.pnEntityGrid.Controls.Add(this.gridEntities);
            this.pnEntityGrid.Controls.Add(this.panEntityGroup);
            this.pnEntityGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnEntityGrid.Location = new System.Drawing.Point(0, 265);
            this.pnEntityGrid.Name = "pnEntityGrid";
            this.pnEntityGrid.Size = new System.Drawing.Size(347, 470);
            this.pnEntityGrid.TabIndex = 3;
            this.pnEntityGrid.Visible = false;
            // 
            // chkEntAll
            // 
            this.chkEntAll.AutoSize = true;
            this.chkEntAll.Location = new System.Drawing.Point(10, 10);
            this.chkEntAll.Name = "chkEntAll";
            this.chkEntAll.Size = new System.Drawing.Size(15, 14);
            this.chkEntAll.TabIndex = 8;
            this.chkEntAll.UseVisualStyleBackColor = true;
            this.chkEntAll.Visible = false;
            this.chkEntAll.CheckedChanged += new System.EventHandler(this.chkAllRows_CheckedChanged);
            // 
            // gridEntities
            // 
            this.gridEntities.AllowUserToAddRows = false;
            this.gridEntities.AllowUserToDeleteRows = false;
            this.gridEntities.AllowUserToOrderColumns = true;
            this.gridEntities.AllowUserToResizeRows = false;
            this.gridEntities.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridEntities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEntities.EnableHeadersVisualStyles = false;
            this.gridEntities.Location = new System.Drawing.Point(0, 0);
            this.gridEntities.Name = "gridEntities";
            this.gridEntities.RowHeadersVisible = false;
            this.gridEntities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEntities.Size = new System.Drawing.Size(347, 440);
            this.gridEntities.TabIndex = 2;
            this.gridEntities.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            this.gridEntities.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gridEntities_CellFormatting);
            this.gridEntities.SelectionChanged += new System.EventHandler(this.gridEntities_SelectionChanged);
            // 
            // panEntityGroup
            // 
            this.panEntityGroup.Controls.Add(this.posGroupUpDown);
            this.panEntityGroup.Controls.Add(this.btnGroupDelete);
            this.panEntityGroup.Controls.Add(this.btnGroupAdd);
            this.panEntityGroup.Controls.Add(this.btnGroupColor);
            this.panEntityGroup.Controls.Add(this.cmbGroup);
            this.panEntityGroup.Controls.Add(this.label20);
            this.panEntityGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panEntityGroup.Location = new System.Drawing.Point(0, 440);
            this.panEntityGroup.Name = "panEntityGroup";
            this.panEntityGroup.Size = new System.Drawing.Size(347, 30);
            this.panEntityGroup.TabIndex = 9;
            // 
            // posGroupUpDown
            // 
            this.posGroupUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.posGroupUpDown.Enabled = false;
            this.posGroupUpDown.Location = new System.Drawing.Point(217, 5);
            this.posGroupUpDown.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.posGroupUpDown.Name = "posGroupUpDown";
            this.posGroupUpDown.Size = new System.Drawing.Size(18, 20);
            this.posGroupUpDown.TabIndex = 5;
            this.posGroupUpDown.ValueChanged += new System.EventHandler(this.posGroupUpDown_ValueChanged);
            // 
            // btnGroupDelete
            // 
            this.btnGroupDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupDelete.Location = new System.Drawing.Point(313, 4);
            this.btnGroupDelete.Name = "btnGroupDelete";
            this.btnGroupDelete.Size = new System.Drawing.Size(34, 23);
            this.btnGroupDelete.TabIndex = 4;
            this.btnGroupDelete.Text = "Del";
            this.btnGroupDelete.UseVisualStyleBackColor = true;
            this.btnGroupDelete.Click += new System.EventHandler(this.btnGroupDelete_Click);
            // 
            // btnGroupAdd
            // 
            this.btnGroupAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupAdd.Location = new System.Drawing.Point(277, 4);
            this.btnGroupAdd.Name = "btnGroupAdd";
            this.btnGroupAdd.Size = new System.Drawing.Size(34, 23);
            this.btnGroupAdd.TabIndex = 3;
            this.btnGroupAdd.Text = "Add";
            this.btnGroupAdd.UseVisualStyleBackColor = true;
            this.btnGroupAdd.Click += new System.EventHandler(this.btnGroupAdd_Click);
            // 
            // btnGroupColor
            // 
            this.btnGroupColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGroupColor.Location = new System.Drawing.Point(241, 4);
            this.btnGroupColor.Name = "btnGroupColor";
            this.btnGroupColor.Size = new System.Drawing.Size(34, 23);
            this.btnGroupColor.TabIndex = 2;
            this.btnGroupColor.UseVisualStyleBackColor = true;
            this.btnGroupColor.Click += new System.EventHandler(this.btnGroupColor_Click);
            // 
            // cmbGroup
            // 
            this.cmbGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroup.Enabled = false;
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(49, 5);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(168, 21);
            this.cmbGroup.TabIndex = 1;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(36, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Group";
            // 
            // tsEntities
            // 
            this.tsEntities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.btnEntSelectAllVisible,
            this.btnEntUnselectAll,
            this.btnEntShowAll});
            this.tsEntities.Location = new System.Drawing.Point(0, 240);
            this.tsEntities.Name = "tsEntities";
            this.tsEntities.Size = new System.Drawing.Size(347, 25);
            this.tsEntities.TabIndex = 5;
            this.tsEntities.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkEntAddAllShownColumns,
            this.chkEntAddAllShownRelationships});
            this.toolStripDropDownButton1.Image = global::Rappen.XTB.LCG.Properties.Resources.icons8_dots_32x20;
            this.toolStripDropDownButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(57, 22);
            this.toolStripDropDownButton1.Text = "More...";
            this.toolStripDropDownButton1.ToolTipText = "Advanced";
            this.toolStripDropDownButton1.Visible = false;
            // 
            // chkEntAddAllShownColumns
            // 
            this.chkEntAddAllShownColumns.Name = "chkEntAddAllShownColumns";
            this.chkEntAddAllShownColumns.Size = new System.Drawing.Size(181, 22);
            this.chkEntAddAllShownColumns.Text = "Add all columns";
            // 
            // chkEntAddAllShownRelationships
            // 
            this.chkEntAddAllShownRelationships.Name = "chkEntAddAllShownRelationships";
            this.chkEntAddAllShownRelationships.Size = new System.Drawing.Size(181, 22);
            this.chkEntAddAllShownRelationships.Text = "Add all relationships";
            // 
            // btnEntSelectAllVisible
            // 
            this.btnEntSelectAllVisible.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEntSelectAllVisible.Image = ((System.Drawing.Image)(resources.GetObject("btnEntSelectAllVisible.Image")));
            this.btnEntSelectAllVisible.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEntSelectAllVisible.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.btnEntSelectAllVisible.Name = "btnEntSelectAllVisible";
            this.btnEntSelectAllVisible.Size = new System.Drawing.Size(93, 22);
            this.btnEntSelectAllVisible.Text = "Select all visible";
            this.btnEntSelectAllVisible.Click += new System.EventHandler(this.btnSelectAllVisible_Click);
            // 
            // btnEntUnselectAll
            // 
            this.btnEntUnselectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEntUnselectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnEntUnselectAll.Image")));
            this.btnEntUnselectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEntUnselectAll.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.btnEntUnselectAll.Name = "btnEntUnselectAll";
            this.btnEntUnselectAll.Size = new System.Drawing.Size(71, 22);
            this.btnEntUnselectAll.Text = "Unselect all";
            this.btnEntUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnEntShowAll
            // 
            this.btnEntShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnEntShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnEntShowAll.Image")));
            this.btnEntShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEntShowAll.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.btnEntShowAll.Name = "btnEntShowAll";
            this.btnEntShowAll.Size = new System.Drawing.Size(55, 22);
            this.btnEntShowAll.Text = "Show all";
            this.btnEntShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblEntUnShown
            // 
            this.lblEntUnShown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEntUnShown.ForeColor = System.Drawing.Color.Red;
            this.lblEntUnShown.Location = new System.Drawing.Point(0, 735);
            this.lblEntUnShown.Name = "lblEntUnShown";
            this.lblEntUnShown.Size = new System.Drawing.Size(347, 26);
            this.lblEntUnShown.TabIndex = 9;
            this.lblEntUnShown.Text = "Selected but not shown";
            this.lblEntUnShown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEntUnShown.Visible = false;
            // 
            // statusEntities
            // 
            this.statusEntities.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusEntities.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusEntitiesShowing,
            this.statusEntitiesSelected});
            this.statusEntities.Location = new System.Drawing.Point(0, 761);
            this.statusEntities.Name = "statusEntities";
            this.statusEntities.Size = new System.Drawing.Size(347, 22);
            this.statusEntities.SizingGrip = false;
            this.statusEntities.TabIndex = 2;
            this.statusEntities.Text = "statusStrip1";
            // 
            // statusEntitiesShowing
            // 
            this.statusEntitiesShowing.Name = "statusEntitiesShowing";
            this.statusEntitiesShowing.Size = new System.Drawing.Size(77, 17);
            this.statusEntitiesShowing.Text = "Load entities!";
            // 
            // statusEntitiesSelected
            // 
            this.statusEntitiesSelected.Name = "statusEntitiesSelected";
            this.statusEntitiesSelected.Size = new System.Drawing.Size(0, 17);
            // 
            // lblEntNoMatch
            // 
            this.lblEntNoMatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEntNoMatch.Location = new System.Drawing.Point(0, 171);
            this.lblEntNoMatch.Name = "lblEntNoMatch";
            this.lblEntNoMatch.Size = new System.Drawing.Size(347, 69);
            this.lblEntNoMatch.TabIndex = 8;
            this.lblEntNoMatch.Text = "No entities match current filter";
            this.lblEntNoMatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEntNoMatch.Visible = false;
            // 
            // gbEntities
            // 
            this.gbEntities.Controls.Add(this.pnEntSolution);
            this.gbEntities.Controls.Add(this.pnEntCustom);
            this.gbEntities.Controls.Add(this.llEntityExpander);
            this.gbEntities.Controls.Add(this.pnEntSearch);
            this.gbEntities.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEntities.Location = new System.Drawing.Point(0, 0);
            this.gbEntities.Name = "gbEntities";
            this.gbEntities.Size = new System.Drawing.Size(347, 171);
            this.gbEntities.TabIndex = 2;
            this.gbEntities.TabStop = false;
            this.gbEntities.Text = "Entities";
            // 
            // pnEntSolution
            // 
            this.pnEntSolution.Controls.Add(this.cmbSolution);
            this.pnEntSolution.Controls.Add(this.label4);
            this.pnEntSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEntSolution.Location = new System.Drawing.Point(3, 113);
            this.pnEntSolution.Name = "pnEntSolution";
            this.pnEntSolution.Size = new System.Drawing.Size(341, 26);
            this.pnEntSolution.TabIndex = 3;
            // 
            // cmbSolution
            // 
            this.cmbSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSolution.FormattingEnabled = true;
            this.cmbSolution.Location = new System.Drawing.Point(99, 4);
            this.cmbSolution.Name = "cmbSolution";
            this.cmbSolution.Size = new System.Drawing.Size(237, 21);
            this.cmbSolution.TabIndex = 1;
            this.cmbSolution.DropDown += new System.EventHandler(this.cmbSolution_DropDown);
            this.cmbSolution.SelectedIndexChanged += new System.EventHandler(this.filter_entity_Changed);
            this.cmbSolution.DropDownClosed += new System.EventHandler(this.cmbSolution_DropDownClosed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Solution";
            // 
            // pnEntCustom
            // 
            this.pnEntCustom.Controls.Add(this.rbEntUnsel);
            this.pnEntCustom.Controls.Add(this.rbEntSel);
            this.pnEntCustom.Controls.Add(this.rbEntAll);
            this.pnEntCustom.Controls.Add(this.chkEntShowUncountable);
            this.pnEntCustom.Controls.Add(this.triEntManaged);
            this.pnEntCustom.Controls.Add(this.chkEntExclMS);
            this.pnEntCustom.Controls.Add(this.triEntCustom);
            this.pnEntCustom.Controls.Add(this.triEntRecords);
            this.pnEntCustom.Controls.Add(this.chkEntExclIntersect);
            this.pnEntCustom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEntCustom.Location = new System.Drawing.Point(3, 16);
            this.pnEntCustom.Name = "pnEntCustom";
            this.pnEntCustom.Size = new System.Drawing.Size(341, 97);
            this.pnEntCustom.TabIndex = 2;
            // 
            // rbEntUnsel
            // 
            this.rbEntUnsel.AutoSize = true;
            this.rbEntUnsel.Location = new System.Drawing.Point(162, 77);
            this.rbEntUnsel.Name = "rbEntUnsel";
            this.rbEntUnsel.Size = new System.Drawing.Size(79, 17);
            this.rbEntUnsel.TabIndex = 63;
            this.rbEntUnsel.Text = "Unselected";
            this.rbEntUnsel.UseVisualStyleBackColor = true;
            this.rbEntUnsel.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // rbEntSel
            // 
            this.rbEntSel.AutoSize = true;
            this.rbEntSel.Location = new System.Drawing.Point(71, 77);
            this.rbEntSel.Name = "rbEntSel";
            this.rbEntSel.Size = new System.Drawing.Size(67, 17);
            this.rbEntSel.TabIndex = 62;
            this.rbEntSel.Text = "Selected";
            this.rbEntSel.UseVisualStyleBackColor = true;
            this.rbEntSel.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // rbEntAll
            // 
            this.rbEntAll.AutoSize = true;
            this.rbEntAll.Checked = true;
            this.rbEntAll.Location = new System.Drawing.Point(12, 77);
            this.rbEntAll.Name = "rbEntAll";
            this.rbEntAll.Size = new System.Drawing.Size(36, 17);
            this.rbEntAll.TabIndex = 61;
            this.rbEntAll.TabStop = true;
            this.rbEntAll.Text = "All";
            this.rbEntAll.UseVisualStyleBackColor = true;
            this.rbEntAll.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // chkEntShowUncountable
            // 
            this.chkEntShowUncountable.AutoSize = true;
            this.chkEntShowUncountable.Location = new System.Drawing.Point(162, 60);
            this.chkEntShowUncountable.Name = "chkEntShowUncountable";
            this.chkEntShowUncountable.Size = new System.Drawing.Size(87, 17);
            this.chkEntShowUncountable.TabIndex = 60;
            this.chkEntShowUncountable.Text = "Uncountable";
            this.toolTip1.SetToolTip(this.chkEntShowUncountable, "Some entities are not able to count the records.\r\nShall those also be shown?");
            this.chkEntShowUncountable.UseVisualStyleBackColor = true;
            this.chkEntShowUncountable.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // chkEntExclMS
            // 
            this.chkEntExclMS.AutoSize = true;
            this.chkEntExclMS.Location = new System.Drawing.Point(162, 42);
            this.chkEntExclMS.Name = "chkEntExclMS";
            this.chkEntExclMS.Size = new System.Drawing.Size(133, 17);
            this.chkEntExclMS.TabIndex = 40;
            this.chkEntExclMS.Text = "No with MSFT prefixes";
            this.toolTip1.SetToolTip(this.chkEntExclMS, "Will not include with prefix...");
            this.chkEntExclMS.UseVisualStyleBackColor = true;
            this.chkEntExclMS.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // chkEntExclIntersect
            // 
            this.chkEntExclIntersect.AutoSize = true;
            this.chkEntExclIntersect.Checked = true;
            this.chkEntExclIntersect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEntExclIntersect.Location = new System.Drawing.Point(12, 42);
            this.chkEntExclIntersect.Name = "chkEntExclIntersect";
            this.chkEntExclIntersect.Size = new System.Drawing.Size(83, 17);
            this.chkEntExclIntersect.TabIndex = 30;
            this.chkEntExclIntersect.Text = "No intersect";
            this.toolTip1.SetToolTip(this.chkEntExclIntersect, "Show intersected tables for M:M relationships.");
            this.chkEntExclIntersect.UseVisualStyleBackColor = true;
            this.chkEntExclIntersect.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // llEntityExpander
            // 
            this.llEntityExpander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llEntityExpander.AutoSize = true;
            this.llEntityExpander.Location = new System.Drawing.Point(289, 0);
            this.llEntityExpander.Name = "llEntityExpander";
            this.llEntityExpander.Size = new System.Drawing.Size(51, 13);
            this.llEntityExpander.TabIndex = 900;
            this.llEntityExpander.TabStop = true;
            this.llEntityExpander.Text = "Hide filter";
            this.llEntityExpander.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGroupBoxExpander_LinkClicked);
            // 
            // pnEntSearch
            // 
            this.pnEntSearch.Controls.Add(this.txtEntSearch);
            this.pnEntSearch.Controls.Add(this.label1);
            this.pnEntSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnEntSearch.Location = new System.Drawing.Point(3, 142);
            this.pnEntSearch.Name = "pnEntSearch";
            this.pnEntSearch.Size = new System.Drawing.Size(341, 26);
            this.pnEntSearch.TabIndex = 4;
            // 
            // txtEntSearch
            // 
            this.txtEntSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEntSearch.Location = new System.Drawing.Point(99, 2);
            this.txtEntSearch.Name = "txtEntSearch";
            this.txtEntSearch.Size = new System.Drawing.Size(237, 20);
            this.txtEntSearch.TabIndex = 4;
            this.txtEntSearch.TextChanged += new System.EventHandler(this.txtEntSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search";
            // 
            // splitAttRel
            // 
            this.splitAttRel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitAttRel.Location = new System.Drawing.Point(0, 0);
            this.splitAttRel.Name = "splitAttRel";
            // 
            // splitAttRel.Panel1
            // 
            this.splitAttRel.Panel1.Controls.Add(this.pnAttributeGrid);
            this.splitAttRel.Panel1.Controls.Add(this.tsAttributes);
            this.splitAttRel.Panel1.Controls.Add(this.lblAttUnShown);
            this.splitAttRel.Panel1.Controls.Add(this.statusAttributes);
            this.splitAttRel.Panel1.Controls.Add(this.lblAttNoMatch);
            this.splitAttRel.Panel1.Controls.Add(this.gbAttributes);
            // 
            // splitAttRel.Panel2
            // 
            this.splitAttRel.Panel2.Controls.Add(this.pnRelationshipGrid);
            this.splitAttRel.Panel2.Controls.Add(this.tsRelationships);
            this.splitAttRel.Panel2.Controls.Add(this.lblRelUnShown);
            this.splitAttRel.Panel2.Controls.Add(this.statusRelationships);
            this.splitAttRel.Panel2.Controls.Add(this.lblRelNoMatch);
            this.splitAttRel.Panel2.Controls.Add(this.gbRelationships);
            this.splitAttRel.Size = new System.Drawing.Size(677, 783);
            this.splitAttRel.SplitterDistance = 332;
            this.splitAttRel.TabIndex = 4;
            // 
            // pnAttributeGrid
            // 
            this.pnAttributeGrid.Controls.Add(this.chkAttAll);
            this.pnAttributeGrid.Controls.Add(this.gridAttributes);
            this.pnAttributeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnAttributeGrid.Location = new System.Drawing.Point(0, 265);
            this.pnAttributeGrid.Name = "pnAttributeGrid";
            this.pnAttributeGrid.Size = new System.Drawing.Size(332, 470);
            this.pnAttributeGrid.TabIndex = 3;
            this.pnAttributeGrid.Visible = false;
            // 
            // chkAttAll
            // 
            this.chkAttAll.AutoSize = true;
            this.chkAttAll.Location = new System.Drawing.Point(10, 10);
            this.chkAttAll.Name = "chkAttAll";
            this.chkAttAll.Size = new System.Drawing.Size(15, 14);
            this.chkAttAll.TabIndex = 9;
            this.chkAttAll.UseVisualStyleBackColor = true;
            this.chkAttAll.Visible = false;
            this.chkAttAll.CheckedChanged += new System.EventHandler(this.chkAllRows_CheckedChanged);
            // 
            // gridAttributes
            // 
            this.gridAttributes.AllowUserToAddRows = false;
            this.gridAttributes.AllowUserToDeleteRows = false;
            this.gridAttributes.AllowUserToOrderColumns = true;
            this.gridAttributes.AllowUserToResizeRows = false;
            this.gridAttributes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAttributes.EnableHeadersVisualStyles = false;
            this.gridAttributes.Location = new System.Drawing.Point(0, 0);
            this.gridAttributes.Name = "gridAttributes";
            this.gridAttributes.RowHeadersVisible = false;
            this.gridAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAttributes.Size = new System.Drawing.Size(332, 470);
            this.gridAttributes.TabIndex = 2;
            this.gridAttributes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // tsAttributes
            // 
            this.tsAttributes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.btnAttSelectAllVisible,
            this.btnAttUnselectAll,
            this.btnAttShowAll});
            this.tsAttributes.Location = new System.Drawing.Point(0, 240);
            this.tsAttributes.Name = "tsAttributes";
            this.tsAttributes.Size = new System.Drawing.Size(332, 25);
            this.tsAttributes.TabIndex = 9;
            this.tsAttributes.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkAttCheckAll});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(57, 22);
            this.toolStripDropDownButton2.Text = "More...";
            // 
            // chkAttCheckAll
            // 
            this.chkAttCheckAll.CheckOnClick = true;
            this.chkAttCheckAll.Name = "chkAttCheckAll";
            this.chkAttCheckAll.Size = new System.Drawing.Size(293, 22);
            this.chkAttCheckAll.Text = "Add shown columns when adding a table";
            // 
            // btnAttSelectAllVisible
            // 
            this.btnAttSelectAllVisible.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAttSelectAllVisible.Image = ((System.Drawing.Image)(resources.GetObject("btnAttSelectAllVisible.Image")));
            this.btnAttSelectAllVisible.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAttSelectAllVisible.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.btnAttSelectAllVisible.Name = "btnAttSelectAllVisible";
            this.btnAttSelectAllVisible.Size = new System.Drawing.Size(93, 22);
            this.btnAttSelectAllVisible.Text = "Select all visible";
            this.btnAttSelectAllVisible.Click += new System.EventHandler(this.btnSelectAllVisible_Click);
            // 
            // btnAttUnselectAll
            // 
            this.btnAttUnselectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAttUnselectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnAttUnselectAll.Image")));
            this.btnAttUnselectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAttUnselectAll.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.btnAttUnselectAll.Name = "btnAttUnselectAll";
            this.btnAttUnselectAll.Size = new System.Drawing.Size(71, 22);
            this.btnAttUnselectAll.Text = "Unselect all";
            this.btnAttUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnAttShowAll
            // 
            this.btnAttShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAttShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnAttShowAll.Image")));
            this.btnAttShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAttShowAll.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.btnAttShowAll.Name = "btnAttShowAll";
            this.btnAttShowAll.Size = new System.Drawing.Size(55, 22);
            this.btnAttShowAll.Text = "Show all";
            this.btnAttShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblAttUnShown
            // 
            this.lblAttUnShown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAttUnShown.ForeColor = System.Drawing.Color.Red;
            this.lblAttUnShown.Location = new System.Drawing.Point(0, 735);
            this.lblAttUnShown.Name = "lblAttUnShown";
            this.lblAttUnShown.Size = new System.Drawing.Size(332, 26);
            this.lblAttUnShown.TabIndex = 8;
            this.lblAttUnShown.Text = "Selected but not shown";
            this.lblAttUnShown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAttUnShown.Visible = false;
            // 
            // statusAttributes
            // 
            this.statusAttributes.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusAttributes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusAttributesShowing,
            this.statusAttributesSelected});
            this.statusAttributes.Location = new System.Drawing.Point(0, 761);
            this.statusAttributes.Name = "statusAttributes";
            this.statusAttributes.Size = new System.Drawing.Size(332, 22);
            this.statusAttributes.SizingGrip = false;
            this.statusAttributes.TabIndex = 2;
            this.statusAttributes.Text = "statusStrip1";
            // 
            // statusAttributesShowing
            // 
            this.statusAttributesShowing.Name = "statusAttributesShowing";
            this.statusAttributesShowing.Size = new System.Drawing.Size(144, 17);
            this.statusAttributesShowing.Text = "Select an entity to the left!";
            // 
            // statusAttributesSelected
            // 
            this.statusAttributesSelected.Name = "statusAttributesSelected";
            this.statusAttributesSelected.Size = new System.Drawing.Size(0, 17);
            // 
            // lblAttNoMatch
            // 
            this.lblAttNoMatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAttNoMatch.Location = new System.Drawing.Point(0, 171);
            this.lblAttNoMatch.Name = "lblAttNoMatch";
            this.lblAttNoMatch.Size = new System.Drawing.Size(332, 69);
            this.lblAttNoMatch.TabIndex = 7;
            this.lblAttNoMatch.Text = "No attributes match current filter";
            this.lblAttNoMatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAttNoMatch.Visible = false;
            // 
            // gbAttributes
            // 
            this.gbAttributes.Controls.Add(this.pnAttSearch);
            this.gbAttributes.Controls.Add(this.llAttributeExpander);
            this.gbAttributes.Controls.Add(this.pnAttCustom);
            this.gbAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAttributes.Location = new System.Drawing.Point(0, 0);
            this.gbAttributes.Name = "gbAttributes";
            this.gbAttributes.Size = new System.Drawing.Size(332, 171);
            this.gbAttributes.TabIndex = 2;
            this.gbAttributes.TabStop = false;
            this.gbAttributes.Text = "Columns";
            // 
            // pnAttSearch
            // 
            this.pnAttSearch.Controls.Add(this.txtAttSearch);
            this.pnAttSearch.Controls.Add(this.label2);
            this.pnAttSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnAttSearch.Location = new System.Drawing.Point(3, 142);
            this.pnAttSearch.Name = "pnAttSearch";
            this.pnAttSearch.Size = new System.Drawing.Size(326, 26);
            this.pnAttSearch.TabIndex = 6;
            // 
            // txtAttSearch
            // 
            this.txtAttSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAttSearch.Location = new System.Drawing.Point(99, 2);
            this.txtAttSearch.Name = "txtAttSearch";
            this.txtAttSearch.Size = new System.Drawing.Size(220, 20);
            this.txtAttSearch.TabIndex = 4;
            this.txtAttSearch.TextChanged += new System.EventHandler(this.txtAttSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search";
            // 
            // llAttributeExpander
            // 
            this.llAttributeExpander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llAttributeExpander.AutoSize = true;
            this.llAttributeExpander.Location = new System.Drawing.Point(273, 0);
            this.llAttributeExpander.Name = "llAttributeExpander";
            this.llAttributeExpander.Size = new System.Drawing.Size(51, 13);
            this.llAttributeExpander.TabIndex = 4;
            this.llAttributeExpander.TabStop = true;
            this.llAttributeExpander.Text = "Hide filter";
            this.llAttributeExpander.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGroupBoxExpander_LinkClicked);
            // 
            // pnAttCustom
            // 
            this.pnAttCustom.Controls.Add(this.picAttReloadRecords);
            this.pnAttCustom.Controls.Add(this.triAttRequired);
            this.pnAttCustom.Controls.Add(this.triAttManaged);
            this.pnAttCustom.Controls.Add(this.chkAttUniques);
            this.pnAttCustom.Controls.Add(this.triAttLogical);
            this.pnAttCustom.Controls.Add(this.triAttInternal);
            this.pnAttCustom.Controls.Add(this.triAttCustom);
            this.pnAttCustom.Controls.Add(this.chkAttUsed);
            this.pnAttCustom.Controls.Add(this.triAttPrimaryKeyName);
            this.pnAttCustom.Controls.Add(this.chkAttExclCreMod);
            this.pnAttCustom.Controls.Add(this.chkAttExclOwners);
            this.pnAttCustom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnAttCustom.Location = new System.Drawing.Point(3, 16);
            this.pnAttCustom.Name = "pnAttCustom";
            this.pnAttCustom.Size = new System.Drawing.Size(326, 115);
            this.pnAttCustom.TabIndex = 2;
            // 
            // picAttReloadRecords
            // 
            this.picAttReloadRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAttReloadRecords.Image = global::Rappen.XTB.LCG.Properties.Resources.icons8_reset_32__2_1;
            this.picAttReloadRecords.Location = new System.Drawing.Point(237, 96);
            this.picAttReloadRecords.Margin = new System.Windows.Forms.Padding(2);
            this.picAttReloadRecords.Name = "picAttReloadRecords";
            this.picAttReloadRecords.Size = new System.Drawing.Size(16, 16);
            this.picAttReloadRecords.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAttReloadRecords.TabIndex = 9;
            this.picAttReloadRecords.TabStop = false;
            this.toolTip1.SetToolTip(this.picAttReloadRecords, "Reloading record datas");
            this.picAttReloadRecords.Click += new System.EventHandler(this.picAttReloadRecords_Click);
            // 
            // chkAttUniques
            // 
            this.chkAttUniques.AutoSize = true;
            this.chkAttUniques.Enabled = false;
            this.chkAttUniques.Location = new System.Drawing.Point(162, 96);
            this.chkAttUniques.Name = "chkAttUniques";
            this.chkAttUniques.Size = new System.Drawing.Size(78, 17);
            this.chkAttUniques.TabIndex = 120;
            this.chkAttUniques.Text = ">1 uniques";
            this.chkAttUniques.UseVisualStyleBackColor = true;
            this.chkAttUniques.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // chkAttUsed
            // 
            this.chkAttUsed.AutoSize = true;
            this.chkAttUsed.Location = new System.Drawing.Point(12, 96);
            this.chkAttUsed.Name = "chkAttUsed";
            this.chkAttUsed.Size = new System.Drawing.Size(105, 17);
            this.chkAttUsed.TabIndex = 110;
            this.chkAttUsed.Text = "Column has data";
            this.chkAttUsed.UseVisualStyleBackColor = true;
            this.chkAttUsed.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // chkAttExclCreMod
            // 
            this.chkAttExclCreMod.AutoSize = true;
            this.chkAttExclCreMod.Location = new System.Drawing.Point(162, 78);
            this.chkAttExclCreMod.Name = "chkAttExclCreMod";
            this.chkAttExclCreMod.Size = new System.Drawing.Size(102, 17);
            this.chkAttExclCreMod.TabIndex = 100;
            this.chkAttExclCreMod.Text = "No saving users";
            this.toolTip1.SetToolTip(this.chkAttExclCreMod, "Exclude all columns CreateBy/On and UpdatedNy/On.");
            this.chkAttExclCreMod.UseVisualStyleBackColor = true;
            this.chkAttExclCreMod.CheckStateChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // chkAttExclOwners
            // 
            this.chkAttExclOwners.AutoSize = true;
            this.chkAttExclOwners.Location = new System.Drawing.Point(12, 78);
            this.chkAttExclOwners.Name = "chkAttExclOwners";
            this.chkAttExclOwners.Size = new System.Drawing.Size(77, 17);
            this.chkAttExclOwners.TabIndex = 90;
            this.chkAttExclOwners.Text = "No owners";
            this.toolTip1.SetToolTip(this.chkAttExclOwners, "Relationships for Owner fields");
            this.chkAttExclOwners.UseVisualStyleBackColor = true;
            this.chkAttExclOwners.CheckStateChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // pnRelationshipGrid
            // 
            this.pnRelationshipGrid.Controls.Add(this.chkRelAll);
            this.pnRelationshipGrid.Controls.Add(this.gridRelationships);
            this.pnRelationshipGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRelationshipGrid.Location = new System.Drawing.Point(0, 265);
            this.pnRelationshipGrid.Name = "pnRelationshipGrid";
            this.pnRelationshipGrid.Size = new System.Drawing.Size(341, 470);
            this.pnRelationshipGrid.TabIndex = 4;
            this.pnRelationshipGrid.Visible = false;
            // 
            // chkRelAll
            // 
            this.chkRelAll.AutoSize = true;
            this.chkRelAll.Location = new System.Drawing.Point(10, 10);
            this.chkRelAll.Name = "chkRelAll";
            this.chkRelAll.Size = new System.Drawing.Size(15, 14);
            this.chkRelAll.TabIndex = 9;
            this.chkRelAll.UseVisualStyleBackColor = true;
            this.chkRelAll.Visible = false;
            this.chkRelAll.CheckedChanged += new System.EventHandler(this.chkAllRows_CheckedChanged);
            // 
            // gridRelationships
            // 
            this.gridRelationships.AllowUserToAddRows = false;
            this.gridRelationships.AllowUserToDeleteRows = false;
            this.gridRelationships.AllowUserToOrderColumns = true;
            this.gridRelationships.AllowUserToResizeRows = false;
            this.gridRelationships.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridRelationships.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRelationships.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRelationships.EnableHeadersVisualStyles = false;
            this.gridRelationships.Location = new System.Drawing.Point(0, 0);
            this.gridRelationships.Name = "gridRelationships";
            this.gridRelationships.RowHeadersVisible = false;
            this.gridRelationships.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRelationships.Size = new System.Drawing.Size(341, 470);
            this.gridRelationships.TabIndex = 2;
            this.gridRelationships.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // tsRelationships
            // 
            this.tsRelationships.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton3,
            this.btnRelSelectAllVisible,
            this.btnRelUnselectAll,
            this.btnRelShowAll});
            this.tsRelationships.Location = new System.Drawing.Point(0, 240);
            this.tsRelationships.Name = "tsRelationships";
            this.tsRelationships.Size = new System.Drawing.Size(341, 25);
            this.tsRelationships.TabIndex = 10;
            this.tsRelationships.Text = "toolStrip2";
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkRelCheckAll,
            this.chkRelRemoveWhenUncheckedEntity,
            this.toolStripMenuItem1,
            this.chkRelIncludeColumns});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(57, 22);
            this.toolStripDropDownButton3.Text = "More...";
            // 
            // chkRelCheckAll
            // 
            this.chkRelCheckAll.CheckOnClick = true;
            this.chkRelCheckAll.Name = "chkRelCheckAll";
            this.chkRelCheckAll.Size = new System.Drawing.Size(277, 22);
            this.chkRelCheckAll.Text = "Add shown when adding a table";
            this.chkRelCheckAll.ToolTipText = "Check this option to include all visible\r\nrelationships when the table is added/s" +
    "elected.";
            // 
            // chkRelRemoveWhenUncheckedEntity
            // 
            this.chkRelRemoveWhenUncheckedEntity.CheckOnClick = true;
            this.chkRelRemoveWhenUncheckedEntity.Name = "chkRelRemoveWhenUncheckedEntity";
            this.chkRelRemoveWhenUncheckedEntity.Size = new System.Drawing.Size(277, 22);
            this.chkRelRemoveWhenUncheckedEntity.Text = "Remove related unchecked tables";
            this.chkRelRemoveWhenUncheckedEntity.ToolTipText = "Remove/uncheck all relationships when the\r\ntable is removed/unchecked to make sur" +
    "e\r\nwe don\'t have any orphan relationships.";
            // 
            // btnRelSelectAllVisible
            // 
            this.btnRelSelectAllVisible.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRelSelectAllVisible.Image = ((System.Drawing.Image)(resources.GetObject("btnRelSelectAllVisible.Image")));
            this.btnRelSelectAllVisible.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRelSelectAllVisible.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.btnRelSelectAllVisible.Name = "btnRelSelectAllVisible";
            this.btnRelSelectAllVisible.Size = new System.Drawing.Size(93, 22);
            this.btnRelSelectAllVisible.Text = "Select all visible";
            this.btnRelSelectAllVisible.Click += new System.EventHandler(this.btnSelectAllVisible_Click);
            // 
            // btnRelUnselectAll
            // 
            this.btnRelUnselectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRelUnselectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnRelUnselectAll.Image")));
            this.btnRelUnselectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRelUnselectAll.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.btnRelUnselectAll.Name = "btnRelUnselectAll";
            this.btnRelUnselectAll.Size = new System.Drawing.Size(71, 22);
            this.btnRelUnselectAll.Text = "Unselect all";
            this.btnRelUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // btnRelShowAll
            // 
            this.btnRelShowAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRelShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnRelShowAll.Image")));
            this.btnRelShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRelShowAll.Margin = new System.Windows.Forms.Padding(0, 1, 4, 2);
            this.btnRelShowAll.Name = "btnRelShowAll";
            this.btnRelShowAll.Size = new System.Drawing.Size(55, 22);
            this.btnRelShowAll.Text = "Show all";
            this.btnRelShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // lblRelUnShown
            // 
            this.lblRelUnShown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRelUnShown.ForeColor = System.Drawing.Color.Red;
            this.lblRelUnShown.Location = new System.Drawing.Point(0, 735);
            this.lblRelUnShown.Name = "lblRelUnShown";
            this.lblRelUnShown.Size = new System.Drawing.Size(341, 26);
            this.lblRelUnShown.TabIndex = 7;
            this.lblRelUnShown.Text = "Selected but not shown";
            this.lblRelUnShown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRelUnShown.Visible = false;
            // 
            // statusRelationships
            // 
            this.statusRelationships.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.statusRelationships.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusRelationshipsShowing,
            this.statusRelationshipsSelected});
            this.statusRelationships.Location = new System.Drawing.Point(0, 761);
            this.statusRelationships.Name = "statusRelationships";
            this.statusRelationships.Size = new System.Drawing.Size(341, 22);
            this.statusRelationships.SizingGrip = false;
            this.statusRelationships.TabIndex = 5;
            this.statusRelationships.Text = "statusStrip1";
            // 
            // statusRelationshipsShowing
            // 
            this.statusRelationshipsShowing.Name = "statusRelationshipsShowing";
            this.statusRelationshipsShowing.Size = new System.Drawing.Size(144, 17);
            this.statusRelationshipsShowing.Text = "Select an entity to the left!";
            // 
            // statusRelationshipsSelected
            // 
            this.statusRelationshipsSelected.Name = "statusRelationshipsSelected";
            this.statusRelationshipsSelected.Size = new System.Drawing.Size(0, 17);
            // 
            // lblRelNoMatch
            // 
            this.lblRelNoMatch.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRelNoMatch.Location = new System.Drawing.Point(0, 171);
            this.lblRelNoMatch.Name = "lblRelNoMatch";
            this.lblRelNoMatch.Size = new System.Drawing.Size(341, 69);
            this.lblRelNoMatch.TabIndex = 6;
            this.lblRelNoMatch.Text = "No relationships match current filter";
            this.lblRelNoMatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRelNoMatch.Visible = false;
            // 
            // gbRelationships
            // 
            this.gbRelationships.Controls.Add(this.panRelSearch);
            this.gbRelationships.Controls.Add(this.panRel2);
            this.gbRelationships.Controls.Add(this.llRelationshipExpander);
            this.gbRelationships.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRelationships.Location = new System.Drawing.Point(0, 0);
            this.gbRelationships.Name = "gbRelationships";
            this.gbRelationships.Size = new System.Drawing.Size(341, 171);
            this.gbRelationships.TabIndex = 3;
            this.gbRelationships.TabStop = false;
            this.gbRelationships.Text = "Relationships";
            // 
            // panRelSearch
            // 
            this.panRelSearch.Controls.Add(this.txtRelSearch);
            this.panRelSearch.Controls.Add(this.label3);
            this.panRelSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panRelSearch.Location = new System.Drawing.Point(3, 142);
            this.panRelSearch.Name = "panRelSearch";
            this.panRelSearch.Size = new System.Drawing.Size(335, 26);
            this.panRelSearch.TabIndex = 10;
            // 
            // txtRelSearch
            // 
            this.txtRelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRelSearch.Location = new System.Drawing.Point(99, 2);
            this.txtRelSearch.Name = "txtRelSearch";
            this.txtRelSearch.Size = new System.Drawing.Size(229, 20);
            this.txtRelSearch.TabIndex = 4;
            this.txtRelSearch.TextChanged += new System.EventHandler(this.txtRelSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Search";
            // 
            // panRel2
            // 
            this.panRel2.Controls.Add(this.chkRelReqLookups);
            this.panRel2.Controls.Add(this.chkRelExclDupRecords);
            this.panRel2.Controls.Add(this.chkRelNN);
            this.panRel2.Controls.Add(this.chkRelExclCreMod);
            this.panRel2.Controls.Add(this.triRelManaged);
            this.panRel2.Controls.Add(this.chkRelExclRegarding);
            this.panRel2.Controls.Add(this.chkRelExclOwners);
            this.panRel2.Controls.Add(this.chkRelN1);
            this.panRel2.Controls.Add(this.chkRelExclOrphans);
            this.panRel2.Controls.Add(this.triRelCustom);
            this.panRel2.Controls.Add(this.chkRel1N);
            this.panRel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panRel2.Location = new System.Drawing.Point(3, 16);
            this.panRel2.Name = "panRel2";
            this.panRel2.Size = new System.Drawing.Size(335, 115);
            this.panRel2.TabIndex = 7;
            // 
            // chkRelReqLookups
            // 
            this.chkRelReqLookups.AutoSize = true;
            this.chkRelReqLookups.Location = new System.Drawing.Point(144, 96);
            this.chkRelReqLookups.Name = "chkRelReqLookups";
            this.chkRelReqLookups.Size = new System.Drawing.Size(109, 17);
            this.chkRelReqLookups.TabIndex = 101;
            this.chkRelReqLookups.Text = "Required lookups";
            this.chkRelReqLookups.UseVisualStyleBackColor = true;
            this.chkRelReqLookups.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRelExclDupRecords
            // 
            this.chkRelExclDupRecords.AutoSize = true;
            this.chkRelExclDupRecords.Location = new System.Drawing.Point(144, 78);
            this.chkRelExclDupRecords.Name = "chkRelExclDupRecords";
            this.chkRelExclDupRecords.Size = new System.Drawing.Size(99, 17);
            this.chkRelExclDupRecords.TabIndex = 90;
            this.chkRelExclDupRecords.Text = "No duplications";
            this.chkRelExclDupRecords.UseVisualStyleBackColor = true;
            this.chkRelExclDupRecords.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRelNN
            // 
            this.chkRelNN.AutoSize = true;
            this.chkRelNN.Location = new System.Drawing.Point(144, 42);
            this.chkRelNN.Name = "chkRelNN";
            this.chkRelNN.Size = new System.Drawing.Size(47, 17);
            this.chkRelNN.TabIndex = 50;
            this.chkRelNN.Text = "M:M";
            this.chkRelNN.UseVisualStyleBackColor = true;
            this.chkRelNN.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRelExclCreMod
            // 
            this.chkRelExclCreMod.AutoSize = true;
            this.chkRelExclCreMod.Location = new System.Drawing.Point(12, 60);
            this.chkRelExclCreMod.Name = "chkRelExclCreMod";
            this.chkRelExclCreMod.Size = new System.Drawing.Size(102, 17);
            this.chkRelExclCreMod.TabIndex = 60;
            this.chkRelExclCreMod.Text = "No saving users";
            this.chkRelExclCreMod.UseVisualStyleBackColor = true;
            this.chkRelExclCreMod.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRelExclRegarding
            // 
            this.chkRelExclRegarding.AutoSize = true;
            this.chkRelExclRegarding.Location = new System.Drawing.Point(12, 78);
            this.chkRelExclRegarding.Name = "chkRelExclRegarding";
            this.chkRelExclRegarding.Size = new System.Drawing.Size(92, 17);
            this.chkRelExclRegarding.TabIndex = 80;
            this.chkRelExclRegarding.Text = "No regardings";
            this.toolTip1.SetToolTip(this.chkRelExclRegarding, "Relationships for Regarding fields");
            this.chkRelExclRegarding.UseVisualStyleBackColor = true;
            this.chkRelExclRegarding.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRelExclOwners
            // 
            this.chkRelExclOwners.AutoSize = true;
            this.chkRelExclOwners.Location = new System.Drawing.Point(144, 60);
            this.chkRelExclOwners.Name = "chkRelExclOwners";
            this.chkRelExclOwners.Size = new System.Drawing.Size(77, 17);
            this.chkRelExclOwners.TabIndex = 70;
            this.chkRelExclOwners.Text = "No owners";
            this.toolTip1.SetToolTip(this.chkRelExclOwners, "Relationships for Owner fields");
            this.chkRelExclOwners.UseVisualStyleBackColor = true;
            this.chkRelExclOwners.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRelN1
            // 
            this.chkRelN1.AutoSize = true;
            this.chkRelN1.Location = new System.Drawing.Point(75, 42);
            this.chkRelN1.Name = "chkRelN1";
            this.chkRelN1.Size = new System.Drawing.Size(44, 17);
            this.chkRelN1.TabIndex = 40;
            this.chkRelN1.Text = "M:1";
            this.chkRelN1.UseVisualStyleBackColor = true;
            this.chkRelN1.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRelExclOrphans
            // 
            this.chkRelExclOrphans.AutoSize = true;
            this.chkRelExclOrphans.Location = new System.Drawing.Point(12, 96);
            this.chkRelExclOrphans.Name = "chkRelExclOrphans";
            this.chkRelExclOrphans.Size = new System.Drawing.Size(81, 17);
            this.chkRelExclOrphans.TabIndex = 100;
            this.chkRelExclOrphans.Text = "No orphans";
            this.toolTip1.SetToolTip(this.chkRelExclOrphans, "Relationships where the \"other\" entity is not selected");
            this.chkRelExclOrphans.UseVisualStyleBackColor = true;
            this.chkRelExclOrphans.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRel1N
            // 
            this.chkRel1N.AutoSize = true;
            this.chkRel1N.Location = new System.Drawing.Point(12, 42);
            this.chkRel1N.Name = "chkRel1N";
            this.chkRel1N.Size = new System.Drawing.Size(44, 17);
            this.chkRel1N.TabIndex = 30;
            this.chkRel1N.Text = "1:M";
            this.toolTip1.SetToolTip(this.chkRel1N, "Relationships where the \"other\" entity is not selected");
            this.chkRel1N.UseVisualStyleBackColor = true;
            this.chkRel1N.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // llRelationshipExpander
            // 
            this.llRelationshipExpander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llRelationshipExpander.AutoSize = true;
            this.llRelationshipExpander.Location = new System.Drawing.Point(282, 0);
            this.llRelationshipExpander.Name = "llRelationshipExpander";
            this.llRelationshipExpander.Size = new System.Drawing.Size(51, 13);
            this.llRelationshipExpander.TabIndex = 4;
            this.llRelationshipExpander.TabStop = true;
            this.llRelationshipExpander.Text = "Hide filter";
            this.llRelationshipExpander.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGroupBoxExpander_LinkClicked);
            // 
            // tmEntSearch
            // 
            this.tmEntSearch.Interval = 500;
            this.tmEntSearch.Tick += new System.EventHandler(this.tmEntSearch_Tick);
            // 
            // tmAttSearch
            // 
            this.tmAttSearch.Interval = 500;
            this.tmAttSearch.Tick += new System.EventHandler(this.tmAttSearch_Tick);
            // 
            // pnWindowTopSpacer
            // 
            this.pnWindowTopSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnWindowTopSpacer.Location = new System.Drawing.Point(0, 39);
            this.pnWindowTopSpacer.Name = "pnWindowTopSpacer";
            this.pnWindowTopSpacer.Size = new System.Drawing.Size(1028, 17);
            this.pnWindowTopSpacer.TabIndex = 11;
            // 
            // tmRelSearch
            // 
            this.tmRelSearch.Interval = 500;
            this.tmRelSearch.Tick += new System.EventHandler(this.tmRelSearch_Tick);
            // 
            // tmHideNotification
            // 
            this.tmHideNotification.Interval = 5000;
            this.tmHideNotification.Tick += new System.EventHandler(this.tmHideNotification_Tick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(274, 6);
            // 
            // chkRelIncludeColumns
            // 
            this.chkRelIncludeColumns.CheckOnClick = true;
            this.chkRelIncludeColumns.Name = "chkRelIncludeColumns";
            this.chkRelIncludeColumns.Size = new System.Drawing.Size(277, 22);
            this.chkRelIncludeColumns.Text = "Include primary id and lookup column";
            this.chkRelIncludeColumns.ToolTipText = "If this option is checked, it will make sure\r\nthat the two columns in this relati" +
    "onship are\r\nincluded/checked.";
            // 
            // triEntManaged
            // 
            this.triEntManaged.AutoSize = true;
            this.triEntManaged.Checked = true;
            this.triEntManaged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.triEntManaged.Location = new System.Drawing.Point(12, 24);
            this.triEntManaged.Name = "triEntManaged";
            this.triEntManaged.Size = new System.Drawing.Size(204, 17);
            this.triEntManaged.TabIndex = 20;
            this.triEntManaged.Text = "Show both managed and unmanaged";
            this.triEntManaged.TextChecked = "Show both managed and unmanaged";
            this.triEntManaged.TextIndeterminate = "Only unmanaged tables";
            this.triEntManaged.TextUnchecked = "Only managed tables";
            this.toolTip1.SetToolTip(this.triEntManaged, "Click to flip beween all option, only unmanaged entities, only managed entities.\r" +
        "\nFiltered by metadata property: IsManaged");
            this.triEntManaged.UseVisualStyleBackColor = true;
            this.triEntManaged.CheckStateChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // triEntCustom
            // 
            this.triEntCustom.AutoSize = true;
            this.triEntCustom.Checked = true;
            this.triEntCustom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.triEntCustom.Location = new System.Drawing.Point(12, 6);
            this.triEntCustom.Name = "triEntCustom";
            this.triEntCustom.Size = new System.Drawing.Size(198, 17);
            this.triEntCustom.TabIndex = 10;
            this.triEntCustom.Text = "Show both customized and standard";
            this.triEntCustom.TextChecked = "Show both customized and standard";
            this.triEntCustom.TextIndeterminate = "Only custom tables";
            this.triEntCustom.TextUnchecked = "Only core tables";
            this.toolTip1.SetToolTip(this.triEntCustom, "Click to flip beween all option, only system entities, only customized entities.\r" +
        "\nFiltered by metadata property: IsCustomEntity");
            this.triEntCustom.UseVisualStyleBackColor = true;
            this.triEntCustom.CheckStateChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // triEntRecords
            // 
            this.triEntRecords.AutoSize = true;
            this.triEntRecords.Checked = true;
            this.triEntRecords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.triEntRecords.Location = new System.Drawing.Point(12, 60);
            this.triEntRecords.Name = "triEntRecords";
            this.triEntRecords.Size = new System.Drawing.Size(152, 17);
            this.triEntRecords.TabIndex = 50;
            this.triEntRecords.Text = "Ignoring number of records";
            this.triEntRecords.TextChecked = "Ignoring number of records";
            this.triEntRecords.TextIndeterminate = "Only tables with records";
            this.triEntRecords.TextUnchecked = "Only empty tables";
            this.triEntRecords.UseVisualStyleBackColor = true;
            this.triEntRecords.CheckStateChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // triAttRequired
            // 
            this.triAttRequired.AutoSize = true;
            this.triAttRequired.Checked = true;
            this.triAttRequired.CheckState = System.Windows.Forms.CheckState.Checked;
            this.triAttRequired.Location = new System.Drawing.Point(162, 42);
            this.triAttRequired.Name = "triAttRequired";
            this.triAttRequired.Size = new System.Drawing.Size(147, 17);
            this.triAttRequired.TabIndex = 50;
            this.triAttRequired.Text = "Ignoring requirement level";
            this.triAttRequired.TextChecked = "Ignoring requirement level";
            this.triAttRequired.TextIndeterminate = "Only required";
            this.triAttRequired.TextUnchecked = "Only not required";
            this.toolTip1.SetToolTip(this.triAttRequired, "Show columns based on Requirement level.");
            this.triAttRequired.UseVisualStyleBackColor = true;
            this.triAttRequired.CheckStateChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // triAttManaged
            // 
            this.triAttManaged.AutoSize = true;
            this.triAttManaged.Checked = true;
            this.triAttManaged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.triAttManaged.Location = new System.Drawing.Point(12, 24);
            this.triAttManaged.Name = "triAttManaged";
            this.triAttManaged.Size = new System.Drawing.Size(204, 17);
            this.triAttManaged.TabIndex = 20;
            this.triAttManaged.Text = "Show both managed and unmanaged";
            this.triAttManaged.TextChecked = "Show both managed and unmanaged";
            this.triAttManaged.TextIndeterminate = "Only unmanaged columns";
            this.triAttManaged.TextUnchecked = "Only managed columns";
            this.toolTip1.SetToolTip(this.triAttManaged, "Click to flip beween all option, only unmanaged attributes, only managed attribut" +
        "es.\r\nFiltered by metadata property: IsManaged");
            this.triAttManaged.UseVisualStyleBackColor = true;
            this.triAttManaged.CheckStateChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // triAttLogical
            // 
            this.triAttLogical.AutoSize = true;
            this.triAttLogical.Location = new System.Drawing.Point(12, 60);
            this.triAttLogical.Name = "triAttLogical";
            this.triAttLogical.Size = new System.Drawing.Size(76, 17);
            this.triAttLogical.TabIndex = 60;
            this.triAttLogical.Text = "Not logical";
            this.triAttLogical.TextChecked = "Ignoring logical flag";
            this.triAttLogical.TextIndeterminate = "Only logical";
            this.triAttLogical.TextUnchecked = "Not logical";
            this.toolTip1.SetToolTip(this.triAttLogical, "Show regarding on IsLogical metadata.");
            this.triAttLogical.UseVisualStyleBackColor = true;
            this.triAttLogical.CheckStateChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // triAttInternal
            // 
            this.triAttInternal.AutoSize = true;
            this.triAttInternal.Location = new System.Drawing.Point(162, 60);
            this.triAttInternal.Name = "triAttInternal";
            this.triAttInternal.Size = new System.Drawing.Size(80, 17);
            this.triAttInternal.TabIndex = 70;
            this.triAttInternal.Text = "Not internal";
            this.triAttInternal.TextChecked = "Ignoring internal flag";
            this.triAttInternal.TextIndeterminate = "Only internal";
            this.triAttInternal.TextUnchecked = "Not internal";
            this.toolTip1.SetToolTip(this.triAttInternal, "Show regarding on Jonas\' thoughts on what are only internal attributes.\r\n");
            this.triAttInternal.UseVisualStyleBackColor = true;
            this.triAttInternal.CheckStateChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // triAttCustom
            // 
            this.triAttCustom.AutoSize = true;
            this.triAttCustom.Checked = true;
            this.triAttCustom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.triAttCustom.Location = new System.Drawing.Point(12, 6);
            this.triAttCustom.Name = "triAttCustom";
            this.triAttCustom.Size = new System.Drawing.Size(198, 17);
            this.triAttCustom.TabIndex = 10;
            this.triAttCustom.Text = "Show both customized and standard";
            this.triAttCustom.TextChecked = "Show both customized and standard";
            this.triAttCustom.TextIndeterminate = "Only custom columns";
            this.triAttCustom.TextUnchecked = "Only core columns";
            this.toolTip1.SetToolTip(this.triAttCustom, "Click to flip beween all option, only system attributes, only customized attribut" +
        "es.\r\nFiltering by metadata property: IsCustomAttribute");
            this.triAttCustom.UseVisualStyleBackColor = true;
            this.triAttCustom.CheckStateChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // triAttPrimaryKeyName
            // 
            this.triAttPrimaryKeyName.AutoSize = true;
            this.triAttPrimaryKeyName.Checked = true;
            this.triAttPrimaryKeyName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.triAttPrimaryKeyName.Location = new System.Drawing.Point(12, 42);
            this.triAttPrimaryKeyName.Name = "triAttPrimaryKeyName";
            this.triAttPrimaryKeyName.Size = new System.Drawing.Size(106, 17);
            this.triAttPrimaryKeyName.TabIndex = 30;
            this.triAttPrimaryKeyName.Text = "Include Id/Name";
            this.triAttPrimaryKeyName.TextChecked = "Include Id/Name";
            this.triAttPrimaryKeyName.TextIndeterminate = "Only Id/Name";
            this.triAttPrimaryKeyName.TextUnchecked = "No Id/Name";
            this.toolTip1.SetToolTip(this.triAttPrimaryKeyName, "Show or not PrimaryKey and PrimaryName.");
            this.triAttPrimaryKeyName.UseVisualStyleBackColor = true;
            this.triAttPrimaryKeyName.CheckStateChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // triRelManaged
            // 
            this.triRelManaged.AutoSize = true;
            this.triRelManaged.Checked = true;
            this.triRelManaged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.triRelManaged.Location = new System.Drawing.Point(12, 24);
            this.triRelManaged.Name = "triRelManaged";
            this.triRelManaged.Size = new System.Drawing.Size(204, 17);
            this.triRelManaged.TabIndex = 20;
            this.triRelManaged.Text = "Show both managed and unmanaged";
            this.triRelManaged.TextChecked = "Show both managed and unmanaged";
            this.triRelManaged.TextIndeterminate = "Only unmanaged relationships";
            this.triRelManaged.TextUnchecked = "Only managed relationships";
            this.toolTip1.SetToolTip(this.triRelManaged, "Click to flip beween all option, only unmanaged relationships, only managed relat" +
        "ionships.\r\nFiltered by metadata property: IsManaged");
            this.triRelManaged.UseVisualStyleBackColor = true;
            this.triRelManaged.CheckStateChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // triRelCustom
            // 
            this.triRelCustom.AutoSize = true;
            this.triRelCustom.Checked = true;
            this.triRelCustom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.triRelCustom.Location = new System.Drawing.Point(12, 6);
            this.triRelCustom.Name = "triRelCustom";
            this.triRelCustom.Size = new System.Drawing.Size(198, 17);
            this.triRelCustom.TabIndex = 10;
            this.triRelCustom.Text = "Show both customized and standard";
            this.triRelCustom.TextChecked = "Show both customized and standard";
            this.triRelCustom.TextIndeterminate = "Only custom relationships";
            this.triRelCustom.TextUnchecked = "Only core relationships";
            this.toolTip1.SetToolTip(this.triRelCustom, "Click to flip beween all option, only system relationships, only customized relat" +
        "ionships.\r\nFiltering by metadata property: IsCustomAttribute");
            this.triRelCustom.UseVisualStyleBackColor = true;
            this.triRelCustom.CheckStateChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // LCG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.splitEntityRest);
            this.Controls.Add(this.pnWindowTopSpacer);
            this.Controls.Add(this.toolStripMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LCG";
            this.PluginIcon = ((System.Drawing.Icon)(resources.GetObject("$this.PluginIcon")));
            this.Size = new System.Drawing.Size(1028, 839);
            this.TabIcon = ((System.Drawing.Image)(resources.GetObject("$this.TabIcon")));
            this.ConnectionUpdated += new XrmToolBox.Extensibility.PluginControlBase.ConnectionUpdatedHandler(this.LCG_ConnectionUpdated);
            this.Load += new System.EventHandler(this.LCG_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.splitEntityRest.Panel1.ResumeLayout(false);
            this.splitEntityRest.Panel1.PerformLayout();
            this.splitEntityRest.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitEntityRest)).EndInit();
            this.splitEntityRest.ResumeLayout(false);
            this.pnEntityGrid.ResumeLayout(false);
            this.pnEntityGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntities)).EndInit();
            this.panEntityGroup.ResumeLayout(false);
            this.panEntityGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posGroupUpDown)).EndInit();
            this.tsEntities.ResumeLayout(false);
            this.tsEntities.PerformLayout();
            this.statusEntities.ResumeLayout(false);
            this.statusEntities.PerformLayout();
            this.gbEntities.ResumeLayout(false);
            this.gbEntities.PerformLayout();
            this.pnEntSolution.ResumeLayout(false);
            this.pnEntSolution.PerformLayout();
            this.pnEntCustom.ResumeLayout(false);
            this.pnEntCustom.PerformLayout();
            this.pnEntSearch.ResumeLayout(false);
            this.pnEntSearch.PerformLayout();
            this.splitAttRel.Panel1.ResumeLayout(false);
            this.splitAttRel.Panel1.PerformLayout();
            this.splitAttRel.Panel2.ResumeLayout(false);
            this.splitAttRel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitAttRel)).EndInit();
            this.splitAttRel.ResumeLayout(false);
            this.pnAttributeGrid.ResumeLayout(false);
            this.pnAttributeGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttributes)).EndInit();
            this.tsAttributes.ResumeLayout(false);
            this.tsAttributes.PerformLayout();
            this.statusAttributes.ResumeLayout(false);
            this.statusAttributes.PerformLayout();
            this.gbAttributes.ResumeLayout(false);
            this.gbAttributes.PerformLayout();
            this.pnAttSearch.ResumeLayout(false);
            this.pnAttSearch.PerformLayout();
            this.pnAttCustom.ResumeLayout(false);
            this.pnAttCustom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAttReloadRecords)).EndInit();
            this.pnRelationshipGrid.ResumeLayout(false);
            this.pnRelationshipGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRelationships)).EndInit();
            this.tsRelationships.ResumeLayout(false);
            this.tsRelationships.PerformLayout();
            this.statusRelationships.ResumeLayout(false);
            this.statusRelationships.PerformLayout();
            this.gbRelationships.ResumeLayout(false);
            this.gbRelationships.PerformLayout();
            this.panRelSearch.ResumeLayout(false);
            this.panRelSearch.PerformLayout();
            this.panRel2.ResumeLayout(false);
            this.panRel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton btnLoadEntities;
        private System.Windows.Forms.SplitContainer splitEntityRest;
        private System.Windows.Forms.GroupBox gbEntities;
        private System.Windows.Forms.DataGridView gridEntities;
        private System.Windows.Forms.StatusStrip statusEntities;
        private System.Windows.Forms.ToolStripStatusLabel statusEntitiesShowing;
        private System.Windows.Forms.ToolStripStatusLabel statusEntitiesSelected;
        private System.Windows.Forms.GroupBox gbAttributes;
        private System.Windows.Forms.StatusStrip statusAttributes;
        private System.Windows.Forms.DataGridView gridAttributes;
        private System.Windows.Forms.Panel pnAttSearch;
        private System.Windows.Forms.Panel pnAttCustom;
        private System.Windows.Forms.TextBox txtAttSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkEntAll;
        private System.Windows.Forms.CheckBox chkAttAll;
        private System.Windows.Forms.ToolStripStatusLabel statusAttributesShowing;
        private System.Windows.Forms.ToolStripStatusLabel statusAttributesSelected;
        private System.Windows.Forms.LinkLabel llEntityExpander;
        private System.Windows.Forms.LinkLabel llAttributeExpander;
        private System.Windows.Forms.Panel pnEntSearch;
        private System.Windows.Forms.TextBox txtEntSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnEntSolution;
        private System.Windows.Forms.ComboBox cmbSolution;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkEntExclIntersect;
        private System.Windows.Forms.Panel pnEntCustom;
        private System.Windows.Forms.Timer tmEntSearch;
        private System.Windows.Forms.Timer tmAttSearch;
        private Rappen.XTB.Helpers.Controls.TriCheckBox triAttPrimaryKeyName;
        private System.Windows.Forms.Panel pnAttributeGrid;
        private System.Windows.Forms.Panel pnEntityGrid;
        private System.Windows.Forms.Panel pnWindowTopSpacer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripLabel tslAbout;
        private System.Windows.Forms.ToolStripButton btnOptions;
        private System.Windows.Forms.ToolStripMenuItem btnSaveConfigAs;
        private System.Windows.Forms.SplitContainer splitAttRel;
        private System.Windows.Forms.GroupBox gbRelationships;
        private System.Windows.Forms.LinkLabel llRelationshipExpander;
        private System.Windows.Forms.Panel pnRelationshipGrid;
        private System.Windows.Forms.CheckBox chkRelAll;
        private System.Windows.Forms.DataGridView gridRelationships;
        private System.Windows.Forms.Panel panRelSearch;
        private System.Windows.Forms.TextBox txtRelSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkRelExclRegarding;
        private System.Windows.Forms.CheckBox chkRelExclOwners;
        private System.Windows.Forms.CheckBox chkRelExclOrphans;
        private System.Windows.Forms.Panel panRel2;
        private System.Windows.Forms.StatusStrip statusRelationships;
        private System.Windows.Forms.ToolStripStatusLabel statusRelationshipsShowing;
        private System.Windows.Forms.ToolStripStatusLabel statusRelationshipsSelected;
        private System.Windows.Forms.Timer tmRelSearch;
        private System.Windows.Forms.CheckBox chkRelNN;
        private System.Windows.Forms.CheckBox chkRelN1;
        private System.Windows.Forms.CheckBox chkRel1N;
        private System.Windows.Forms.Label lblEntNoMatch;
        private System.Windows.Forms.Label lblAttNoMatch;
        private System.Windows.Forms.Label lblRelNoMatch;
        private System.Windows.Forms.ToolStripMenuItem btnSaveConfig;
        private System.Windows.Forms.Timer tmHideNotification;
        private System.Windows.Forms.ToolStripSplitButton btnGenerate;
        private System.Windows.Forms.ToolStripMenuItem btnSaveCsAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.CheckBox chkRelExclCreMod;
        private System.Windows.Forms.CheckBox chkRelExclDupRecords;
        private System.Windows.Forms.CheckBox chkAttExclOwners;
        private System.Windows.Forms.CheckBox chkAttExclCreMod;
        private Rappen.XTB.Helpers.Controls.TriCheckBox triAttInternal;
        private Rappen.XTB.Helpers.Controls.TriCheckBox triEntRecords;
        private System.Windows.Forms.CheckBox chkAttUsed;
        private System.Windows.Forms.PictureBox picAttReloadRecords;
        private System.Windows.Forms.CheckBox chkAttUniques;
        private Rappen.XTB.Helpers.Controls.TriCheckBox triAttRequired;
        private System.Windows.Forms.Label lblRelUnShown;
        private System.Windows.Forms.Label lblEntUnShown;
        private System.Windows.Forms.Label lblAttUnShown;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.CheckBox chkEntExclMS;
        private System.Windows.Forms.ToolStripButton tsbSupporting;
        private System.Windows.Forms.Panel panEntityGroup;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnGroupDelete;
        private System.Windows.Forms.Button btnGroupAdd;
        private System.Windows.Forms.Button btnGroupColor;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown posGroupUpDown;
        private Helpers.Controls.TriCheckBox triAttCustom;
        private Helpers.Controls.TriCheckBox triEntCustom;
        private Helpers.Controls.TriCheckBox triEntManaged;
        private Helpers.Controls.TriCheckBox triAttManaged;
        private Helpers.Controls.TriCheckBox triRelManaged;
        private Helpers.Controls.TriCheckBox triRelCustom;
        private System.Windows.Forms.CheckBox chkEntShowUncountable;
        private Helpers.Controls.TriCheckBox triAttLogical;
        private System.Windows.Forms.CheckBox chkRelReqLookups;
        private System.Windows.Forms.ToolStrip tsEntities;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem chkEntAddAllShownRelationships;
        private System.Windows.Forms.ToolStripMenuItem chkEntAddAllShownColumns;
        private System.Windows.Forms.ToolStripButton btnEntSelectAllVisible;
        private System.Windows.Forms.ToolStripButton btnEntUnselectAll;
        private System.Windows.Forms.ToolStripButton btnEntShowAll;
        private System.Windows.Forms.ToolStrip tsAttributes;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripButton btnAttSelectAllVisible;
        private System.Windows.Forms.ToolStripButton btnAttUnselectAll;
        private System.Windows.Forms.ToolStripButton btnAttShowAll;
        private System.Windows.Forms.ToolStrip tsRelationships;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripButton btnRelSelectAllVisible;
        private System.Windows.Forms.ToolStripButton btnRelUnselectAll;
        private System.Windows.Forms.ToolStripButton btnRelShowAll;
        private System.Windows.Forms.ToolStripMenuItem chkAttCheckAll;
        private System.Windows.Forms.ToolStripMenuItem chkRelCheckAll;
        private System.Windows.Forms.ToolStripMenuItem chkRelRemoveWhenUncheckedEntity;
        private System.Windows.Forms.ToolStripButton menuOpen;
        private System.Windows.Forms.RadioButton rbEntUnsel;
        private System.Windows.Forms.RadioButton rbEntSel;
        private System.Windows.Forms.RadioButton rbEntAll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chkRelIncludeColumns;
    }
}
