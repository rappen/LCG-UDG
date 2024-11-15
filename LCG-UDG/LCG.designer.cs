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
            this.menuOpen = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnOpenGeneratedFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnOpenConfig = new System.Windows.Forms.ToolStripMenuItem();
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
            this.lblEntUnShown = new System.Windows.Forms.Label();
            this.statusEntities = new System.Windows.Forms.StatusStrip();
            this.statusEntitiesShowing = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusEntitiesSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblEntNoMatch = new System.Windows.Forms.Label();
            this.gbEntities = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnEntSearch = new System.Windows.Forms.Panel();
            this.txtEntSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.llEntityExpander = new System.Windows.Forms.LinkLabel();
            this.pnEntIntersect = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.chkEntExclMS = new System.Windows.Forms.CheckBox();
            this.chkEntExclNoRecords = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkEntExclUnselected = new System.Windows.Forms.CheckBox();
            this.chkEntExclIntersect = new System.Windows.Forms.CheckBox();
            this.pnEntManaged = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pnEntCustom = new System.Windows.Forms.Panel();
            this.triEntCustom = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnEntSolution = new System.Windows.Forms.Panel();
            this.cmbSolution = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEntSelectAllVisible = new System.Windows.Forms.Button();
            this.btnEntUnselectAll = new System.Windows.Forms.Button();
            this.btnEntShowAll = new System.Windows.Forms.Button();
            this.splitAttRel = new System.Windows.Forms.SplitContainer();
            this.pnAttributeGrid = new System.Windows.Forms.Panel();
            this.chkAttAll = new System.Windows.Forms.CheckBox();
            this.gridAttributes = new System.Windows.Forms.DataGridView();
            this.lblAttUnShown = new System.Windows.Forms.Label();
            this.statusAttributes = new System.Windows.Forms.StatusStrip();
            this.statusAttributesShowing = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusAttributesSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblAttNoMatch = new System.Windows.Forms.Label();
            this.gbAttributes = new System.Windows.Forms.GroupBox();
            this.pnAttExclude = new System.Windows.Forms.Panel();
            this.chkAttExclUnRequired = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.chkAttUniques = new System.Windows.Forms.CheckBox();
            this.chkAttExclLogical = new System.Windows.Forms.CheckBox();
            this.picAttReloadRecords = new System.Windows.Forms.PictureBox();
            this.chkAttExclInternal = new System.Windows.Forms.CheckBox();
            this.chkAttUsed = new System.Windows.Forms.CheckBox();
            this.chkAttExclCreMod = new System.Windows.Forms.CheckBox();
            this.chkAttExclOwners = new System.Windows.Forms.CheckBox();
            this.pnAttSearch = new System.Windows.Forms.Panel();
            this.txtAttSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.llAttributeExpander = new System.Windows.Forms.LinkLabel();
            this.pnAttInclude = new System.Windows.Forms.Panel();
            this.chkAttRequired = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkAttPrimaryAttribute = new System.Windows.Forms.CheckBox();
            this.chkAttPrimaryKey = new System.Windows.Forms.CheckBox();
            this.pnAttManaged = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.pnAttCustom = new System.Windows.Forms.Panel();
            this.triAttCustom = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.pnAttBehavior = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.chkAttCheckAll = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAttShowAll = new System.Windows.Forms.Button();
            this.btnAttSelectAllVisible = new System.Windows.Forms.Button();
            this.btnAttUnselectAll = new System.Windows.Forms.Button();
            this.pnRelationshipGrid = new System.Windows.Forms.Panel();
            this.chkRelAll = new System.Windows.Forms.CheckBox();
            this.gridRelationships = new System.Windows.Forms.DataGridView();
            this.ctxRelationshipMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxRelAddRemAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRelUnShown = new System.Windows.Forms.Label();
            this.statusRelationships = new System.Windows.Forms.StatusStrip();
            this.statusRelationshipsShowing = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusRelationshipsSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRelNoMatch = new System.Windows.Forms.Label();
            this.gbRelationships = new System.Windows.Forms.GroupBox();
            this.panRelSearch = new System.Windows.Forms.Panel();
            this.txtRelSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panRel4 = new System.Windows.Forms.Panel();
            this.chkRelExclDupRecords = new System.Windows.Forms.CheckBox();
            this.chkRelExclCreMod = new System.Windows.Forms.CheckBox();
            this.chkRelExclRegarding = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkRelExclOwners = new System.Windows.Forms.CheckBox();
            this.chkRelExclOrphans = new System.Windows.Forms.CheckBox();
            this.panRelType = new System.Windows.Forms.Panel();
            this.chkRelNN = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkRelN1 = new System.Windows.Forms.CheckBox();
            this.chkRel1N = new System.Windows.Forms.CheckBox();
            this.panRel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panRel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panRel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.chkRelCheckAll = new System.Windows.Forms.CheckBox();
            this.llRelationshipExpander = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRelShowAll = new System.Windows.Forms.Button();
            this.btnRelSelectAllVisible = new System.Windows.Forms.Button();
            this.btnRelUnselectAll = new System.Windows.Forms.Button();
            this.tmEntSearch = new System.Windows.Forms.Timer(this.components);
            this.tmAttSearch = new System.Windows.Forms.Timer(this.components);
            this.pnWindowTopSpacer = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tmRelSearch = new System.Windows.Forms.Timer(this.components);
            this.tmHideNotification = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.triEntManaged = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triAttManaged = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triRelManaged = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.triRelCustom = new Rappen.XTB.Helpers.Controls.TriCheckBox();
            this.chkEntShowUncountable = new System.Windows.Forms.CheckBox();
            this.toolStripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitEntityRest)).BeginInit();
            this.splitEntityRest.Panel1.SuspendLayout();
            this.splitEntityRest.Panel2.SuspendLayout();
            this.splitEntityRest.SuspendLayout();
            this.pnEntityGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEntities)).BeginInit();
            this.panEntityGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.posGroupUpDown)).BeginInit();
            this.statusEntities.SuspendLayout();
            this.gbEntities.SuspendLayout();
            this.pnEntSearch.SuspendLayout();
            this.pnEntIntersect.SuspendLayout();
            this.pnEntManaged.SuspendLayout();
            this.pnEntCustom.SuspendLayout();
            this.pnEntSolution.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitAttRel)).BeginInit();
            this.splitAttRel.Panel1.SuspendLayout();
            this.splitAttRel.Panel2.SuspendLayout();
            this.splitAttRel.SuspendLayout();
            this.pnAttributeGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttributes)).BeginInit();
            this.statusAttributes.SuspendLayout();
            this.gbAttributes.SuspendLayout();
            this.pnAttExclude.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAttReloadRecords)).BeginInit();
            this.pnAttSearch.SuspendLayout();
            this.pnAttInclude.SuspendLayout();
            this.pnAttManaged.SuspendLayout();
            this.pnAttCustom.SuspendLayout();
            this.pnAttBehavior.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnRelationshipGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRelationships)).BeginInit();
            this.ctxRelationshipMenu.SuspendLayout();
            this.statusRelationships.SuspendLayout();
            this.gbRelationships.SuspendLayout();
            this.panRelSearch.SuspendLayout();
            this.panRel4.SuspendLayout();
            this.panRelType.SuspendLayout();
            this.panRel3.SuspendLayout();
            this.panRel2.SuspendLayout();
            this.panRel1.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.menuOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenGeneratedFile,
            this.toolStripSeparator4,
            this.btnOpenConfig});
            this.menuOpen.Image = global::Rappen.XTB.LCG.Properties.Resources.icons8_open_32;
            this.menuOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(81, 36);
            this.menuOpen.Text = "Open";
            // 
            // btnOpenGeneratedFile
            // 
            this.btnOpenGeneratedFile.Image = global::Rappen.XTB.LCG.Properties.Resources.csharp32;
            this.btnOpenGeneratedFile.Name = "btnOpenGeneratedFile";
            this.btnOpenGeneratedFile.Size = new System.Drawing.Size(174, 22);
            this.btnOpenGeneratedFile.Text = "Generated C# file...";
            this.btnOpenGeneratedFile.Click += new System.EventHandler(this.btnOpenGeneratedFile_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(171, 6);
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.Image = global::Rappen.XTB.LCG.Properties.Resources.project32;
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(174, 22);
            this.btnOpenConfig.Text = "Project file...";
            this.btnOpenConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
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
            this.splitEntityRest.Panel1.Controls.Add(this.lblEntUnShown);
            this.splitEntityRest.Panel1.Controls.Add(this.statusEntities);
            this.splitEntityRest.Panel1.Controls.Add(this.lblEntNoMatch);
            this.splitEntityRest.Panel1.Controls.Add(this.gbEntities);
            // 
            // splitEntityRest.Panel2
            // 
            this.splitEntityRest.Panel2.Controls.Add(this.splitAttRel);
            this.splitEntityRest.Size = new System.Drawing.Size(1028, 538);
            this.splitEntityRest.SplitterDistance = 347;
            this.splitEntityRest.TabIndex = 2;
            // 
            // pnEntityGrid
            // 
            this.pnEntityGrid.Controls.Add(this.chkEntAll);
            this.pnEntityGrid.Controls.Add(this.gridEntities);
            this.pnEntityGrid.Controls.Add(this.panEntityGroup);
            this.pnEntityGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnEntityGrid.Location = new System.Drawing.Point(0, 316);
            this.pnEntityGrid.Name = "pnEntityGrid";
            this.pnEntityGrid.Size = new System.Drawing.Size(347, 174);
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
            this.gridEntities.Size = new System.Drawing.Size(347, 144);
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
            this.panEntityGroup.Location = new System.Drawing.Point(0, 144);
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
            // lblEntUnShown
            // 
            this.lblEntUnShown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEntUnShown.ForeColor = System.Drawing.Color.Red;
            this.lblEntUnShown.Location = new System.Drawing.Point(0, 490);
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
            this.statusEntities.Location = new System.Drawing.Point(0, 516);
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
            this.lblEntNoMatch.Location = new System.Drawing.Point(0, 247);
            this.lblEntNoMatch.Name = "lblEntNoMatch";
            this.lblEntNoMatch.Size = new System.Drawing.Size(347, 69);
            this.lblEntNoMatch.TabIndex = 8;
            this.lblEntNoMatch.Text = "No entities match current filter";
            this.lblEntNoMatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEntNoMatch.Visible = false;
            // 
            // gbEntities
            // 
            this.gbEntities.Controls.Add(this.panel4);
            this.gbEntities.Controls.Add(this.pnEntSearch);
            this.gbEntities.Controls.Add(this.llEntityExpander);
            this.gbEntities.Controls.Add(this.pnEntIntersect);
            this.gbEntities.Controls.Add(this.pnEntManaged);
            this.gbEntities.Controls.Add(this.pnEntCustom);
            this.gbEntities.Controls.Add(this.pnEntSolution);
            this.gbEntities.Controls.Add(this.panel1);
            this.gbEntities.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEntities.Location = new System.Drawing.Point(0, 0);
            this.gbEntities.Name = "gbEntities";
            this.gbEntities.Size = new System.Drawing.Size(347, 247);
            this.gbEntities.TabIndex = 2;
            this.gbEntities.TabStop = false;
            this.gbEntities.Text = "Entities";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 158);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(341, 23);
            this.panel4.TabIndex = 7;
            // 
            // pnEntSearch
            // 
            this.pnEntSearch.Controls.Add(this.txtEntSearch);
            this.pnEntSearch.Controls.Add(this.label1);
            this.pnEntSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnEntSearch.Location = new System.Drawing.Point(3, 181);
            this.pnEntSearch.Name = "pnEntSearch";
            this.pnEntSearch.Size = new System.Drawing.Size(341, 26);
            this.pnEntSearch.TabIndex = 5;
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
            // llEntityExpander
            // 
            this.llEntityExpander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llEntityExpander.AutoSize = true;
            this.llEntityExpander.Location = new System.Drawing.Point(291, 0);
            this.llEntityExpander.Name = "llEntityExpander";
            this.llEntityExpander.Size = new System.Drawing.Size(51, 13);
            this.llEntityExpander.TabIndex = 3;
            this.llEntityExpander.TabStop = true;
            this.llEntityExpander.Text = "Hide filter";
            this.llEntityExpander.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGroupBoxExpander_LinkClicked);
            // 
            // pnEntIntersect
            // 
            this.pnEntIntersect.Controls.Add(this.chkEntShowUncountable);
            this.pnEntIntersect.Controls.Add(this.label18);
            this.pnEntIntersect.Controls.Add(this.chkEntExclMS);
            this.pnEntIntersect.Controls.Add(this.chkEntExclNoRecords);
            this.pnEntIntersect.Controls.Add(this.label10);
            this.pnEntIntersect.Controls.Add(this.chkEntExclUnselected);
            this.pnEntIntersect.Controls.Add(this.chkEntExclIntersect);
            this.pnEntIntersect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEntIntersect.Location = new System.Drawing.Point(3, 94);
            this.pnEntIntersect.Name = "pnEntIntersect";
            this.pnEntIntersect.Size = new System.Drawing.Size(341, 63);
            this.pnEntIntersect.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Data";
            // 
            // chkEntExclMS
            // 
            this.chkEntExclMS.AutoSize = true;
            this.chkEntExclMS.Location = new System.Drawing.Point(99, 23);
            this.chkEntExclMS.Name = "chkEntExclMS";
            this.chkEntExclMS.Size = new System.Drawing.Size(94, 17);
            this.chkEntExclMS.TabIndex = 2;
            this.chkEntExclMS.Text = "MSFT prefixes";
            this.toolTip1.SetToolTip(this.chkEntExclMS, "Will not include with prefix...");
            this.chkEntExclMS.UseVisualStyleBackColor = true;
            this.chkEntExclMS.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // chkEntExclNoRecords
            // 
            this.chkEntExclNoRecords.AutoSize = true;
            this.chkEntExclNoRecords.Location = new System.Drawing.Point(99, 41);
            this.chkEntExclNoRecords.Name = "chkEntExclNoRecords";
            this.chkEntExclNoRecords.Size = new System.Drawing.Size(83, 17);
            this.chkEntExclNoRecords.TabIndex = 3;
            this.chkEntExclNoRecords.Text = "Has records";
            this.chkEntExclNoRecords.UseVisualStyleBackColor = true;
            this.chkEntExclNoRecords.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Exclude";
            // 
            // chkEntExclUnselected
            // 
            this.chkEntExclUnselected.AutoSize = true;
            this.chkEntExclUnselected.Location = new System.Drawing.Point(218, 5);
            this.chkEntExclUnselected.Name = "chkEntExclUnselected";
            this.chkEntExclUnselected.Size = new System.Drawing.Size(80, 17);
            this.chkEntExclUnselected.TabIndex = 1;
            this.chkEntExclUnselected.Text = "Unselected";
            this.chkEntExclUnselected.UseVisualStyleBackColor = true;
            this.chkEntExclUnselected.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // chkEntExclIntersect
            // 
            this.chkEntExclIntersect.AutoSize = true;
            this.chkEntExclIntersect.Checked = true;
            this.chkEntExclIntersect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEntExclIntersect.Location = new System.Drawing.Point(99, 5);
            this.chkEntExclIntersect.Name = "chkEntExclIntersect";
            this.chkEntExclIntersect.Size = new System.Drawing.Size(67, 17);
            this.chkEntExclIntersect.TabIndex = 0;
            this.chkEntExclIntersect.Text = "Intersect";
            this.chkEntExclIntersect.UseVisualStyleBackColor = true;
            this.chkEntExclIntersect.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // pnEntManaged
            // 
            this.pnEntManaged.Controls.Add(this.triEntManaged);
            this.pnEntManaged.Controls.Add(this.label12);
            this.pnEntManaged.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEntManaged.Location = new System.Drawing.Point(3, 68);
            this.pnEntManaged.Name = "pnEntManaged";
            this.pnEntManaged.Size = new System.Drawing.Size(341, 26);
            this.pnEntManaged.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Managed";
            // 
            // pnEntCustom
            // 
            this.pnEntCustom.Controls.Add(this.triEntCustom);
            this.pnEntCustom.Controls.Add(this.label11);
            this.pnEntCustom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEntCustom.Location = new System.Drawing.Point(3, 42);
            this.pnEntCustom.Name = "pnEntCustom";
            this.pnEntCustom.Size = new System.Drawing.Size(341, 26);
            this.pnEntCustom.TabIndex = 2;
            // 
            // triEntCustom
            // 
            this.triEntCustom.AutoSize = true;
            this.triEntCustom.Checked = true;
            this.triEntCustom.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.triEntCustom.Location = new System.Drawing.Point(99, 5);
            this.triEntCustom.Name = "triEntCustom";
            this.triEntCustom.Size = new System.Drawing.Size(119, 17);
            this.triEntCustom.TabIndex = 6;
            this.triEntCustom.Text = "System and Custom";
            this.triEntCustom.TextChecked = "Custom";
            this.triEntCustom.TextIndeterminate = "System and Custom";
            this.triEntCustom.TextUnchecked = "System";
            this.toolTip1.SetToolTip(this.triEntCustom, "Click to flip beween all option, only system entities, only customized entities.\r" +
        "\nFiltered by metadata property: IsCustomEntity");
            this.triEntCustom.UseVisualStyleBackColor = true;
            this.triEntCustom.CheckStateChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Customized";
            // 
            // pnEntSolution
            // 
            this.pnEntSolution.Controls.Add(this.cmbSolution);
            this.pnEntSolution.Controls.Add(this.label4);
            this.pnEntSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEntSolution.Location = new System.Drawing.Point(3, 16);
            this.pnEntSolution.Name = "pnEntSolution";
            this.pnEntSolution.Size = new System.Drawing.Size(341, 26);
            this.pnEntSolution.TabIndex = 1;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEntSelectAllVisible);
            this.panel1.Controls.Add(this.btnEntUnselectAll);
            this.panel1.Controls.Add(this.btnEntShowAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 37);
            this.panel1.TabIndex = 6;
            // 
            // btnEntSelectAllVisible
            // 
            this.btnEntSelectAllVisible.Location = new System.Drawing.Point(7, 6);
            this.btnEntSelectAllVisible.Name = "btnEntSelectAllVisible";
            this.btnEntSelectAllVisible.Size = new System.Drawing.Size(93, 23);
            this.btnEntSelectAllVisible.TabIndex = 1;
            this.btnEntSelectAllVisible.Text = "Select all visible";
            this.btnEntSelectAllVisible.UseVisualStyleBackColor = true;
            this.btnEntSelectAllVisible.Click += new System.EventHandler(this.btnEntSelectAllVisible_Click);
            // 
            // btnEntUnselectAll
            // 
            this.btnEntUnselectAll.Location = new System.Drawing.Point(106, 6);
            this.btnEntUnselectAll.Name = "btnEntUnselectAll";
            this.btnEntUnselectAll.Size = new System.Drawing.Size(75, 23);
            this.btnEntUnselectAll.TabIndex = 2;
            this.btnEntUnselectAll.Text = "Unselect all";
            this.btnEntUnselectAll.UseVisualStyleBackColor = true;
            this.btnEntUnselectAll.Click += new System.EventHandler(this.btnEntUnselectAll_Click);
            // 
            // btnEntShowAll
            // 
            this.btnEntShowAll.Location = new System.Drawing.Point(187, 6);
            this.btnEntShowAll.Name = "btnEntShowAll";
            this.btnEntShowAll.Size = new System.Drawing.Size(69, 23);
            this.btnEntShowAll.TabIndex = 3;
            this.btnEntShowAll.Text = "Show all";
            this.btnEntShowAll.UseVisualStyleBackColor = true;
            this.btnEntShowAll.Click += new System.EventHandler(this.btnEntShowAll_Click);
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
            this.splitAttRel.Panel1.Controls.Add(this.lblAttUnShown);
            this.splitAttRel.Panel1.Controls.Add(this.statusAttributes);
            this.splitAttRel.Panel1.Controls.Add(this.lblAttNoMatch);
            this.splitAttRel.Panel1.Controls.Add(this.gbAttributes);
            // 
            // splitAttRel.Panel2
            // 
            this.splitAttRel.Panel2.Controls.Add(this.pnRelationshipGrid);
            this.splitAttRel.Panel2.Controls.Add(this.lblRelUnShown);
            this.splitAttRel.Panel2.Controls.Add(this.statusRelationships);
            this.splitAttRel.Panel2.Controls.Add(this.lblRelNoMatch);
            this.splitAttRel.Panel2.Controls.Add(this.gbRelationships);
            this.splitAttRel.Size = new System.Drawing.Size(677, 538);
            this.splitAttRel.SplitterDistance = 332;
            this.splitAttRel.TabIndex = 4;
            // 
            // pnAttributeGrid
            // 
            this.pnAttributeGrid.Controls.Add(this.chkAttAll);
            this.pnAttributeGrid.Controls.Add(this.gridAttributes);
            this.pnAttributeGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnAttributeGrid.Location = new System.Drawing.Point(0, 316);
            this.pnAttributeGrid.Name = "pnAttributeGrid";
            this.pnAttributeGrid.Size = new System.Drawing.Size(332, 174);
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
            this.gridAttributes.Size = new System.Drawing.Size(332, 174);
            this.gridAttributes.TabIndex = 2;
            this.gridAttributes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // lblAttUnShown
            // 
            this.lblAttUnShown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAttUnShown.ForeColor = System.Drawing.Color.Red;
            this.lblAttUnShown.Location = new System.Drawing.Point(0, 490);
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
            this.statusAttributes.Location = new System.Drawing.Point(0, 516);
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
            this.lblAttNoMatch.Location = new System.Drawing.Point(0, 247);
            this.lblAttNoMatch.Name = "lblAttNoMatch";
            this.lblAttNoMatch.Size = new System.Drawing.Size(332, 69);
            this.lblAttNoMatch.TabIndex = 7;
            this.lblAttNoMatch.Text = "No attributes match current filter";
            this.lblAttNoMatch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAttNoMatch.Visible = false;
            // 
            // gbAttributes
            // 
            this.gbAttributes.Controls.Add(this.pnAttExclude);
            this.gbAttributes.Controls.Add(this.pnAttSearch);
            this.gbAttributes.Controls.Add(this.llAttributeExpander);
            this.gbAttributes.Controls.Add(this.pnAttInclude);
            this.gbAttributes.Controls.Add(this.pnAttManaged);
            this.gbAttributes.Controls.Add(this.pnAttCustom);
            this.gbAttributes.Controls.Add(this.pnAttBehavior);
            this.gbAttributes.Controls.Add(this.panel2);
            this.gbAttributes.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbAttributes.Location = new System.Drawing.Point(0, 0);
            this.gbAttributes.Name = "gbAttributes";
            this.gbAttributes.Size = new System.Drawing.Size(332, 247);
            this.gbAttributes.TabIndex = 2;
            this.gbAttributes.TabStop = false;
            this.gbAttributes.Text = "Attributes";
            // 
            // pnAttExclude
            // 
            this.pnAttExclude.Controls.Add(this.chkAttExclUnRequired);
            this.pnAttExclude.Controls.Add(this.label19);
            this.pnAttExclude.Controls.Add(this.label17);
            this.pnAttExclude.Controls.Add(this.chkAttUniques);
            this.pnAttExclude.Controls.Add(this.chkAttExclLogical);
            this.pnAttExclude.Controls.Add(this.picAttReloadRecords);
            this.pnAttExclude.Controls.Add(this.chkAttExclInternal);
            this.pnAttExclude.Controls.Add(this.chkAttUsed);
            this.pnAttExclude.Controls.Add(this.chkAttExclCreMod);
            this.pnAttExclude.Controls.Add(this.chkAttExclOwners);
            this.pnAttExclude.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnAttExclude.Location = new System.Drawing.Point(3, 120);
            this.pnAttExclude.Name = "pnAttExclude";
            this.pnAttExclude.Size = new System.Drawing.Size(326, 62);
            this.pnAttExclude.TabIndex = 5;
            // 
            // chkAttExclUnRequired
            // 
            this.chkAttExclUnRequired.AutoSize = true;
            this.chkAttExclUnRequired.Location = new System.Drawing.Point(235, 2);
            this.chkAttExclUnRequired.Name = "chkAttExclUnRequired";
            this.chkAttExclUnRequired.Size = new System.Drawing.Size(78, 17);
            this.chkAttExclUnRequired.TabIndex = 13;
            this.chkAttExclUnRequired.Text = "Unrequired";
            this.chkAttExclUnRequired.UseVisualStyleBackColor = true;
            this.chkAttExclUnRequired.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Exclude";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "Records data";
            // 
            // chkAttUniques
            // 
            this.chkAttUniques.AutoSize = true;
            this.chkAttUniques.Enabled = false;
            this.chkAttUniques.Location = new System.Drawing.Point(165, 38);
            this.chkAttUniques.Name = "chkAttUniques";
            this.chkAttUniques.Size = new System.Drawing.Size(72, 17);
            this.chkAttUniques.TabIndex = 6;
            this.chkAttUniques.Text = ">1 values";
            this.chkAttUniques.UseVisualStyleBackColor = true;
            this.chkAttUniques.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // chkAttExclLogical
            // 
            this.chkAttExclLogical.AutoSize = true;
            this.chkAttExclLogical.Location = new System.Drawing.Point(99, 2);
            this.chkAttExclLogical.Name = "chkAttExclLogical";
            this.chkAttExclLogical.Size = new System.Drawing.Size(60, 17);
            this.chkAttExclLogical.TabIndex = 1;
            this.chkAttExclLogical.Text = "Logical";
            this.chkAttExclLogical.UseVisualStyleBackColor = true;
            this.chkAttExclLogical.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // picAttReloadRecords
            // 
            this.picAttReloadRecords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAttReloadRecords.Image = global::Rappen.XTB.LCG.Properties.Resources.icons8_reset_32__2_1;
            this.picAttReloadRecords.Location = new System.Drawing.Point(240, 38);
            this.picAttReloadRecords.Margin = new System.Windows.Forms.Padding(2);
            this.picAttReloadRecords.Name = "picAttReloadRecords";
            this.picAttReloadRecords.Size = new System.Drawing.Size(16, 16);
            this.picAttReloadRecords.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAttReloadRecords.TabIndex = 9;
            this.picAttReloadRecords.TabStop = false;
            this.toolTip1.SetToolTip(this.picAttReloadRecords, "Reloading record datas");
            this.picAttReloadRecords.Click += new System.EventHandler(this.picAttReloadRecords_Click);
            // 
            // chkAttExclInternal
            // 
            this.chkAttExclInternal.AutoSize = true;
            this.chkAttExclInternal.Location = new System.Drawing.Point(165, 2);
            this.chkAttExclInternal.Name = "chkAttExclInternal";
            this.chkAttExclInternal.Size = new System.Drawing.Size(61, 17);
            this.chkAttExclInternal.TabIndex = 2;
            this.chkAttExclInternal.Text = "Internal";
            this.chkAttExclInternal.UseVisualStyleBackColor = true;
            this.chkAttExclInternal.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // chkAttUsed
            // 
            this.chkAttUsed.AutoSize = true;
            this.chkAttUsed.Location = new System.Drawing.Point(99, 38);
            this.chkAttUsed.Name = "chkAttUsed";
            this.chkAttUsed.Size = new System.Drawing.Size(44, 17);
            this.chkAttUsed.TabIndex = 5;
            this.chkAttUsed.Text = "Any";
            this.chkAttUsed.UseVisualStyleBackColor = true;
            this.chkAttUsed.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // chkAttExclCreMod
            // 
            this.chkAttExclCreMod.AutoSize = true;
            this.chkAttExclCreMod.Location = new System.Drawing.Point(165, 20);
            this.chkAttExclCreMod.Name = "chkAttExclCreMod";
            this.chkAttExclCreMod.Size = new System.Drawing.Size(108, 17);
            this.chkAttExclCreMod.TabIndex = 4;
            this.chkAttExclCreMod.Text = "Created/Modified";
            this.chkAttExclCreMod.UseVisualStyleBackColor = true;
            this.chkAttExclCreMod.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // chkAttExclOwners
            // 
            this.chkAttExclOwners.AutoSize = true;
            this.chkAttExclOwners.Location = new System.Drawing.Point(99, 20);
            this.chkAttExclOwners.Name = "chkAttExclOwners";
            this.chkAttExclOwners.Size = new System.Drawing.Size(62, 17);
            this.chkAttExclOwners.TabIndex = 3;
            this.chkAttExclOwners.Text = "Owners";
            this.toolTip1.SetToolTip(this.chkAttExclOwners, "Relationships for Owner fields");
            this.chkAttExclOwners.UseVisualStyleBackColor = true;
            this.chkAttExclOwners.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // pnAttSearch
            // 
            this.pnAttSearch.Controls.Add(this.txtAttSearch);
            this.pnAttSearch.Controls.Add(this.label2);
            this.pnAttSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnAttSearch.Location = new System.Drawing.Point(3, 181);
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
            this.llAttributeExpander.Location = new System.Drawing.Point(275, 0);
            this.llAttributeExpander.Name = "llAttributeExpander";
            this.llAttributeExpander.Size = new System.Drawing.Size(51, 13);
            this.llAttributeExpander.TabIndex = 4;
            this.llAttributeExpander.TabStop = true;
            this.llAttributeExpander.Text = "Hide filter";
            this.llAttributeExpander.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGroupBoxExpander_LinkClicked);
            // 
            // pnAttInclude
            // 
            this.pnAttInclude.Controls.Add(this.chkAttRequired);
            this.pnAttInclude.Controls.Add(this.label15);
            this.pnAttInclude.Controls.Add(this.chkAttPrimaryAttribute);
            this.pnAttInclude.Controls.Add(this.chkAttPrimaryKey);
            this.pnAttInclude.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnAttInclude.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnAttInclude.Location = new System.Drawing.Point(3, 94);
            this.pnAttInclude.Name = "pnAttInclude";
            this.pnAttInclude.Size = new System.Drawing.Size(326, 26);
            this.pnAttInclude.TabIndex = 4;
            // 
            // chkAttRequired
            // 
            this.chkAttRequired.AutoSize = true;
            this.chkAttRequired.Location = new System.Drawing.Point(235, 5);
            this.chkAttRequired.Name = "chkAttRequired";
            this.chkAttRequired.Size = new System.Drawing.Size(69, 17);
            this.chkAttRequired.TabIndex = 12;
            this.chkAttRequired.Text = "Required";
            this.chkAttRequired.UseVisualStyleBackColor = true;
            this.chkAttRequired.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(42, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Include";
            // 
            // chkAttPrimaryAttribute
            // 
            this.chkAttPrimaryAttribute.AutoSize = true;
            this.chkAttPrimaryAttribute.Location = new System.Drawing.Point(165, 5);
            this.chkAttPrimaryAttribute.Name = "chkAttPrimaryAttribute";
            this.chkAttPrimaryAttribute.Size = new System.Drawing.Size(54, 17);
            this.chkAttPrimaryAttribute.TabIndex = 1;
            this.chkAttPrimaryAttribute.Text = "Name";
            this.chkAttPrimaryAttribute.UseVisualStyleBackColor = true;
            this.chkAttPrimaryAttribute.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // chkAttPrimaryKey
            // 
            this.chkAttPrimaryKey.AutoSize = true;
            this.chkAttPrimaryKey.Location = new System.Drawing.Point(99, 5);
            this.chkAttPrimaryKey.Name = "chkAttPrimaryKey";
            this.chkAttPrimaryKey.Size = new System.Drawing.Size(37, 17);
            this.chkAttPrimaryKey.TabIndex = 0;
            this.chkAttPrimaryKey.Text = "ID";
            this.chkAttPrimaryKey.UseVisualStyleBackColor = true;
            this.chkAttPrimaryKey.CheckedChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // pnAttManaged
            // 
            this.pnAttManaged.Controls.Add(this.triAttManaged);
            this.pnAttManaged.Controls.Add(this.label14);
            this.pnAttManaged.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnAttManaged.Location = new System.Drawing.Point(3, 68);
            this.pnAttManaged.Name = "pnAttManaged";
            this.pnAttManaged.Size = new System.Drawing.Size(326, 26);
            this.pnAttManaged.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Managed";
            // 
            // pnAttCustom
            // 
            this.pnAttCustom.Controls.Add(this.triAttCustom);
            this.pnAttCustom.Controls.Add(this.label13);
            this.pnAttCustom.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnAttCustom.Location = new System.Drawing.Point(3, 42);
            this.pnAttCustom.Name = "pnAttCustom";
            this.pnAttCustom.Size = new System.Drawing.Size(326, 26);
            this.pnAttCustom.TabIndex = 2;
            // 
            // triAttCustom
            // 
            this.triAttCustom.AutoSize = true;
            this.triAttCustom.Checked = true;
            this.triAttCustom.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.triAttCustom.Location = new System.Drawing.Point(99, 5);
            this.triAttCustom.Name = "triAttCustom";
            this.triAttCustom.Size = new System.Drawing.Size(119, 17);
            this.triAttCustom.TabIndex = 5;
            this.triAttCustom.Text = "System and Custom";
            this.triAttCustom.TextChecked = "Custom";
            this.triAttCustom.TextIndeterminate = "System and Custom";
            this.triAttCustom.TextUnchecked = "System";
            this.toolTip1.SetToolTip(this.triAttCustom, "Click to flip beween all option, only system attributes, only customized attribut" +
        "es.\r\nFiltering by metadata property: IsCustomAttribute");
            this.triAttCustom.UseVisualStyleBackColor = true;
            this.triAttCustom.CheckStateChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Customized";
            // 
            // pnAttBehavior
            // 
            this.pnAttBehavior.Controls.Add(this.label16);
            this.pnAttBehavior.Controls.Add(this.chkAttCheckAll);
            this.pnAttBehavior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnAttBehavior.Location = new System.Drawing.Point(3, 16);
            this.pnAttBehavior.Name = "pnAttBehavior";
            this.pnAttBehavior.Size = new System.Drawing.Size(326, 26);
            this.pnAttBehavior.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 6);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Behavior";
            // 
            // chkAttCheckAll
            // 
            this.chkAttCheckAll.AutoSize = true;
            this.chkAttCheckAll.Location = new System.Drawing.Point(99, 6);
            this.chkAttCheckAll.Name = "chkAttCheckAll";
            this.chkAttCheckAll.Size = new System.Drawing.Size(221, 17);
            this.chkAttCheckAll.TabIndex = 0;
            this.chkAttCheckAll.Text = "Check all visible when checking an entity";
            this.chkAttCheckAll.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAttShowAll);
            this.panel2.Controls.Add(this.btnAttSelectAllVisible);
            this.panel2.Controls.Add(this.btnAttUnselectAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 207);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 37);
            this.panel2.TabIndex = 7;
            // 
            // btnAttShowAll
            // 
            this.btnAttShowAll.Location = new System.Drawing.Point(187, 6);
            this.btnAttShowAll.Name = "btnAttShowAll";
            this.btnAttShowAll.Size = new System.Drawing.Size(69, 23);
            this.btnAttShowAll.TabIndex = 3;
            this.btnAttShowAll.Text = "Show all";
            this.btnAttShowAll.UseVisualStyleBackColor = true;
            this.btnAttShowAll.Click += new System.EventHandler(this.btnEntShowAll_Click);
            // 
            // btnAttSelectAllVisible
            // 
            this.btnAttSelectAllVisible.Location = new System.Drawing.Point(7, 6);
            this.btnAttSelectAllVisible.Name = "btnAttSelectAllVisible";
            this.btnAttSelectAllVisible.Size = new System.Drawing.Size(93, 23);
            this.btnAttSelectAllVisible.TabIndex = 1;
            this.btnAttSelectAllVisible.Text = "Select all visible";
            this.btnAttSelectAllVisible.UseVisualStyleBackColor = true;
            this.btnAttSelectAllVisible.Click += new System.EventHandler(this.btnEntSelectAllVisible_Click);
            // 
            // btnAttUnselectAll
            // 
            this.btnAttUnselectAll.Location = new System.Drawing.Point(106, 6);
            this.btnAttUnselectAll.Name = "btnAttUnselectAll";
            this.btnAttUnselectAll.Size = new System.Drawing.Size(75, 23);
            this.btnAttUnselectAll.TabIndex = 2;
            this.btnAttUnselectAll.Text = "Unselect all";
            this.btnAttUnselectAll.UseVisualStyleBackColor = true;
            this.btnAttUnselectAll.Click += new System.EventHandler(this.btnEntUnselectAll_Click);
            // 
            // pnRelationshipGrid
            // 
            this.pnRelationshipGrid.Controls.Add(this.chkRelAll);
            this.pnRelationshipGrid.Controls.Add(this.gridRelationships);
            this.pnRelationshipGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRelationshipGrid.Location = new System.Drawing.Point(0, 316);
            this.pnRelationshipGrid.Name = "pnRelationshipGrid";
            this.pnRelationshipGrid.Size = new System.Drawing.Size(341, 174);
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
            this.gridRelationships.ContextMenuStrip = this.ctxRelationshipMenu;
            this.gridRelationships.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRelationships.EnableHeadersVisualStyles = false;
            this.gridRelationships.Location = new System.Drawing.Point(0, 0);
            this.gridRelationships.Name = "gridRelationships";
            this.gridRelationships.RowHeadersVisible = false;
            this.gridRelationships.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRelationships.Size = new System.Drawing.Size(341, 174);
            this.gridRelationships.TabIndex = 2;
            this.gridRelationships.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            // 
            // ctxRelationshipMenu
            // 
            this.ctxRelationshipMenu.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.ctxRelationshipMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxRelAddRemAccount});
            this.ctxRelationshipMenu.Name = "ctxRelationshipMenu";
            this.ctxRelationshipMenu.Size = new System.Drawing.Size(193, 26);
            // 
            // ctxRelAddRemAccount
            // 
            this.ctxRelAddRemAccount.Name = "ctxRelAddRemAccount";
            this.ctxRelAddRemAccount.Size = new System.Drawing.Size(192, 22);
            this.ctxRelAddRemAccount.Text = "Add/Remove Account";
            this.ctxRelAddRemAccount.Click += new System.EventHandler(this.ctxRelAddRemAccount_Click);
            // 
            // lblRelUnShown
            // 
            this.lblRelUnShown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRelUnShown.ForeColor = System.Drawing.Color.Red;
            this.lblRelUnShown.Location = new System.Drawing.Point(0, 490);
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
            this.statusRelationships.Location = new System.Drawing.Point(0, 516);
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
            this.lblRelNoMatch.Location = new System.Drawing.Point(0, 247);
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
            this.gbRelationships.Controls.Add(this.panRel4);
            this.gbRelationships.Controls.Add(this.panRelType);
            this.gbRelationships.Controls.Add(this.panRel3);
            this.gbRelationships.Controls.Add(this.panRel2);
            this.gbRelationships.Controls.Add(this.panRel1);
            this.gbRelationships.Controls.Add(this.llRelationshipExpander);
            this.gbRelationships.Controls.Add(this.panel3);
            this.gbRelationships.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbRelationships.Location = new System.Drawing.Point(0, 0);
            this.gbRelationships.Name = "gbRelationships";
            this.gbRelationships.Size = new System.Drawing.Size(341, 247);
            this.gbRelationships.TabIndex = 3;
            this.gbRelationships.TabStop = false;
            this.gbRelationships.Text = "Relationships";
            // 
            // panRelSearch
            // 
            this.panRelSearch.Controls.Add(this.txtRelSearch);
            this.panRelSearch.Controls.Add(this.label3);
            this.panRelSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panRelSearch.Location = new System.Drawing.Point(3, 181);
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
            // panRel4
            // 
            this.panRel4.Controls.Add(this.chkRelExclDupRecords);
            this.panRel4.Controls.Add(this.chkRelExclCreMod);
            this.panRel4.Controls.Add(this.chkRelExclRegarding);
            this.panRel4.Controls.Add(this.label5);
            this.panRel4.Controls.Add(this.chkRelExclOwners);
            this.panRel4.Controls.Add(this.chkRelExclOrphans);
            this.panRel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panRel4.Location = new System.Drawing.Point(3, 120);
            this.panRel4.Name = "panRel4";
            this.panRel4.Size = new System.Drawing.Size(335, 44);
            this.panRel4.TabIndex = 9;
            // 
            // chkRelExclDupRecords
            // 
            this.chkRelExclDupRecords.AutoSize = true;
            this.chkRelExclDupRecords.Location = new System.Drawing.Point(231, 23);
            this.chkRelExclDupRecords.Name = "chkRelExclDupRecords";
            this.chkRelExclDupRecords.Size = new System.Drawing.Size(84, 17);
            this.chkRelExclDupRecords.TabIndex = 5;
            this.chkRelExclDupRecords.Text = "Duplications";
            this.chkRelExclDupRecords.UseVisualStyleBackColor = true;
            this.chkRelExclDupRecords.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRelExclCreMod
            // 
            this.chkRelExclCreMod.AutoSize = true;
            this.chkRelExclCreMod.Location = new System.Drawing.Point(99, 23);
            this.chkRelExclCreMod.Name = "chkRelExclCreMod";
            this.chkRelExclCreMod.Size = new System.Drawing.Size(108, 17);
            this.chkRelExclCreMod.TabIndex = 4;
            this.chkRelExclCreMod.Text = "Created/Modified";
            this.chkRelExclCreMod.UseVisualStyleBackColor = true;
            this.chkRelExclCreMod.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRelExclRegarding
            // 
            this.chkRelExclRegarding.AutoSize = true;
            this.chkRelExclRegarding.Location = new System.Drawing.Point(231, 5);
            this.chkRelExclRegarding.Name = "chkRelExclRegarding";
            this.chkRelExclRegarding.Size = new System.Drawing.Size(80, 17);
            this.chkRelExclRegarding.TabIndex = 3;
            this.chkRelExclRegarding.Text = "Regardings";
            this.toolTip1.SetToolTip(this.chkRelExclRegarding, "Relationships for Regarding fields");
            this.chkRelExclRegarding.UseVisualStyleBackColor = true;
            this.chkRelExclRegarding.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Exclude";
            // 
            // chkRelExclOwners
            // 
            this.chkRelExclOwners.AutoSize = true;
            this.chkRelExclOwners.Location = new System.Drawing.Point(162, 5);
            this.chkRelExclOwners.Name = "chkRelExclOwners";
            this.chkRelExclOwners.Size = new System.Drawing.Size(62, 17);
            this.chkRelExclOwners.TabIndex = 1;
            this.chkRelExclOwners.Text = "Owners";
            this.toolTip1.SetToolTip(this.chkRelExclOwners, "Relationships for Owner fields");
            this.chkRelExclOwners.UseVisualStyleBackColor = true;
            this.chkRelExclOwners.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRelExclOrphans
            // 
            this.chkRelExclOrphans.AutoSize = true;
            this.chkRelExclOrphans.Location = new System.Drawing.Point(99, 5);
            this.chkRelExclOrphans.Name = "chkRelExclOrphans";
            this.chkRelExclOrphans.Size = new System.Drawing.Size(66, 17);
            this.chkRelExclOrphans.TabIndex = 0;
            this.chkRelExclOrphans.Text = "Orphans";
            this.toolTip1.SetToolTip(this.chkRelExclOrphans, "Relationships where the \"other\" entity is not selected");
            this.chkRelExclOrphans.UseVisualStyleBackColor = true;
            this.chkRelExclOrphans.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // panRelType
            // 
            this.panRelType.Controls.Add(this.chkRelNN);
            this.panRelType.Controls.Add(this.label9);
            this.panRelType.Controls.Add(this.chkRelN1);
            this.panRelType.Controls.Add(this.chkRel1N);
            this.panRelType.Dock = System.Windows.Forms.DockStyle.Top;
            this.panRelType.Location = new System.Drawing.Point(3, 94);
            this.panRelType.Name = "panRelType";
            this.panRelType.Size = new System.Drawing.Size(335, 26);
            this.panRelType.TabIndex = 11;
            // 
            // chkRelNN
            // 
            this.chkRelNN.AutoSize = true;
            this.chkRelNN.Location = new System.Drawing.Point(231, 5);
            this.chkRelNN.Name = "chkRelNN";
            this.chkRelNN.Size = new System.Drawing.Size(45, 17);
            this.chkRelNN.TabIndex = 3;
            this.chkRelNN.Text = "N:N";
            this.chkRelNN.UseVisualStyleBackColor = true;
            this.chkRelNN.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Type";
            // 
            // chkRelN1
            // 
            this.chkRelN1.AutoSize = true;
            this.chkRelN1.Location = new System.Drawing.Point(162, 5);
            this.chkRelN1.Name = "chkRelN1";
            this.chkRelN1.Size = new System.Drawing.Size(43, 17);
            this.chkRelN1.TabIndex = 1;
            this.chkRelN1.Text = "N:1";
            this.chkRelN1.UseVisualStyleBackColor = true;
            this.chkRelN1.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkRel1N
            // 
            this.chkRel1N.AutoSize = true;
            this.chkRel1N.Location = new System.Drawing.Point(99, 5);
            this.chkRel1N.Name = "chkRel1N";
            this.chkRel1N.Size = new System.Drawing.Size(43, 17);
            this.chkRel1N.TabIndex = 0;
            this.chkRel1N.Text = "1:N";
            this.toolTip1.SetToolTip(this.chkRel1N, "Relationships where the \"other\" entity is not selected");
            this.chkRel1N.UseVisualStyleBackColor = true;
            this.chkRel1N.CheckedChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // panRel3
            // 
            this.panRel3.Controls.Add(this.triRelManaged);
            this.panRel3.Controls.Add(this.label6);
            this.panRel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panRel3.Location = new System.Drawing.Point(3, 68);
            this.panRel3.Name = "panRel3";
            this.panRel3.Size = new System.Drawing.Size(335, 26);
            this.panRel3.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Managed";
            // 
            // panRel2
            // 
            this.panRel2.Controls.Add(this.triRelCustom);
            this.panRel2.Controls.Add(this.label7);
            this.panRel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panRel2.Location = new System.Drawing.Point(3, 42);
            this.panRel2.Name = "panRel2";
            this.panRel2.Size = new System.Drawing.Size(335, 26);
            this.panRel2.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Customized";
            // 
            // panRel1
            // 
            this.panRel1.Controls.Add(this.label8);
            this.panRel1.Controls.Add(this.chkRelCheckAll);
            this.panRel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panRel1.Location = new System.Drawing.Point(3, 16);
            this.panRel1.Name = "panRel1";
            this.panRel1.Size = new System.Drawing.Size(335, 26);
            this.panRel1.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Behavior";
            // 
            // chkRelCheckAll
            // 
            this.chkRelCheckAll.AutoSize = true;
            this.chkRelCheckAll.Location = new System.Drawing.Point(99, 6);
            this.chkRelCheckAll.Name = "chkRelCheckAll";
            this.chkRelCheckAll.Size = new System.Drawing.Size(221, 17);
            this.chkRelCheckAll.TabIndex = 0;
            this.chkRelCheckAll.Text = "Check all visible when checking an entity";
            this.chkRelCheckAll.UseVisualStyleBackColor = true;
            // 
            // llRelationshipExpander
            // 
            this.llRelationshipExpander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llRelationshipExpander.AutoSize = true;
            this.llRelationshipExpander.Location = new System.Drawing.Point(284, 0);
            this.llRelationshipExpander.Name = "llRelationshipExpander";
            this.llRelationshipExpander.Size = new System.Drawing.Size(51, 13);
            this.llRelationshipExpander.TabIndex = 4;
            this.llRelationshipExpander.TabStop = true;
            this.llRelationshipExpander.Text = "Hide filter";
            this.llRelationshipExpander.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llGroupBoxExpander_LinkClicked);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRelShowAll);
            this.panel3.Controls.Add(this.btnRelSelectAllVisible);
            this.panel3.Controls.Add(this.btnRelUnselectAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 207);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(335, 37);
            this.panel3.TabIndex = 12;
            // 
            // btnRelShowAll
            // 
            this.btnRelShowAll.Location = new System.Drawing.Point(187, 6);
            this.btnRelShowAll.Name = "btnRelShowAll";
            this.btnRelShowAll.Size = new System.Drawing.Size(69, 23);
            this.btnRelShowAll.TabIndex = 3;
            this.btnRelShowAll.Text = "Show all";
            this.btnRelShowAll.UseVisualStyleBackColor = true;
            this.btnRelShowAll.Click += new System.EventHandler(this.btnEntShowAll_Click);
            // 
            // btnRelSelectAllVisible
            // 
            this.btnRelSelectAllVisible.Location = new System.Drawing.Point(7, 6);
            this.btnRelSelectAllVisible.Name = "btnRelSelectAllVisible";
            this.btnRelSelectAllVisible.Size = new System.Drawing.Size(93, 23);
            this.btnRelSelectAllVisible.TabIndex = 1;
            this.btnRelSelectAllVisible.Text = "Select all visible";
            this.btnRelSelectAllVisible.UseVisualStyleBackColor = true;
            this.btnRelSelectAllVisible.Click += new System.EventHandler(this.btnEntSelectAllVisible_Click);
            // 
            // btnRelUnselectAll
            // 
            this.btnRelUnselectAll.Location = new System.Drawing.Point(106, 6);
            this.btnRelUnselectAll.Name = "btnRelUnselectAll";
            this.btnRelUnselectAll.Size = new System.Drawing.Size(75, 23);
            this.btnRelUnselectAll.TabIndex = 2;
            this.btnRelUnselectAll.Text = "Unselect all";
            this.btnRelUnselectAll.UseVisualStyleBackColor = true;
            this.btnRelUnselectAll.Click += new System.EventHandler(this.btnEntUnselectAll_Click);
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
            // triEntManaged
            // 
            this.triEntManaged.AutoSize = true;
            this.triEntManaged.Checked = true;
            this.triEntManaged.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.triEntManaged.Location = new System.Drawing.Point(99, 5);
            this.triEntManaged.Name = "triEntManaged";
            this.triEntManaged.Size = new System.Drawing.Size(153, 17);
            this.triEntManaged.TabIndex = 7;
            this.triEntManaged.Text = "Unmanaged and Managed";
            this.triEntManaged.TextChecked = "Unmanaged";
            this.triEntManaged.TextIndeterminate = "Unmanaged and Managed";
            this.triEntManaged.TextUnchecked = "Managed";
            this.toolTip1.SetToolTip(this.triEntManaged, "Click to flip beween all option, only unmanaged entities, only managed entities.\r" +
        "\nFiltered by metadata property: IsManaged");
            this.triEntManaged.UseVisualStyleBackColor = true;
            this.triEntManaged.CheckStateChanged += new System.EventHandler(this.filter_entity_Changed);
            // 
            // triAttManaged
            // 
            this.triAttManaged.AutoSize = true;
            this.triAttManaged.Checked = true;
            this.triAttManaged.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.triAttManaged.Location = new System.Drawing.Point(99, 5);
            this.triAttManaged.Name = "triAttManaged";
            this.triAttManaged.Size = new System.Drawing.Size(153, 17);
            this.triAttManaged.TabIndex = 8;
            this.triAttManaged.Text = "Unmanaged and Managed";
            this.triAttManaged.TextChecked = "Unmanaged";
            this.triAttManaged.TextIndeterminate = "Unmanaged and Managed";
            this.triAttManaged.TextUnchecked = "Managed";
            this.toolTip1.SetToolTip(this.triAttManaged, "Click to flip beween all option, only unmanaged attributes, only managed attribut" +
        "es.\r\nFiltered by metadata property: IsManaged");
            this.triAttManaged.UseVisualStyleBackColor = true;
            this.triAttManaged.CheckStateChanged += new System.EventHandler(this.filter_attribute_Changed);
            // 
            // triRelManaged
            // 
            this.triRelManaged.AutoSize = true;
            this.triRelManaged.Checked = true;
            this.triRelManaged.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.triRelManaged.Location = new System.Drawing.Point(99, 5);
            this.triRelManaged.Name = "triRelManaged";
            this.triRelManaged.Size = new System.Drawing.Size(153, 17);
            this.triRelManaged.TabIndex = 9;
            this.triRelManaged.Text = "Unmanaged and Managed";
            this.triRelManaged.TextChecked = "Unmanaged";
            this.triRelManaged.TextIndeterminate = "Unmanaged and Managed";
            this.triRelManaged.TextUnchecked = "Managed";
            this.toolTip1.SetToolTip(this.triRelManaged, "Click to flip beween all option, only unmanaged relationships, only managed relat" +
        "ionships.\r\nFiltered by metadata property: IsManaged");
            this.triRelManaged.UseVisualStyleBackColor = true;
            this.triRelManaged.CheckStateChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // triRelCustom
            // 
            this.triRelCustom.AutoSize = true;
            this.triRelCustom.Checked = true;
            this.triRelCustom.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.triRelCustom.Location = new System.Drawing.Point(99, 5);
            this.triRelCustom.Name = "triRelCustom";
            this.triRelCustom.Size = new System.Drawing.Size(119, 17);
            this.triRelCustom.TabIndex = 6;
            this.triRelCustom.Text = "System and Custom";
            this.triRelCustom.TextChecked = "Custom";
            this.triRelCustom.TextIndeterminate = "System and Custom";
            this.triRelCustom.TextUnchecked = "System";
            this.toolTip1.SetToolTip(this.triRelCustom, "Click to flip beween all option, only system relationships, only customized relat" +
        "ionships.\r\nFiltering by metadata property: IsCustomAttribute");
            this.triRelCustom.UseVisualStyleBackColor = true;
            this.triRelCustom.CheckStateChanged += new System.EventHandler(this.filter_relationship_Changed);
            // 
            // chkEntShowUncountable
            // 
            this.chkEntShowUncountable.AutoSize = true;
            this.chkEntShowUncountable.Location = new System.Drawing.Point(218, 41);
            this.chkEntShowUncountable.Name = "chkEntShowUncountable";
            this.chkEntShowUncountable.Size = new System.Drawing.Size(87, 17);
            this.chkEntShowUncountable.TabIndex = 13;
            this.chkEntShowUncountable.Text = "Uncountable";
            this.toolTip1.SetToolTip(this.chkEntShowUncountable, "Some entities can\'t let us to count the records. Shall those also be shown?");
            this.chkEntShowUncountable.UseVisualStyleBackColor = true;
            this.chkEntShowUncountable.CheckedChanged += new System.EventHandler(this.filter_entity_Changed);
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
            this.Size = new System.Drawing.Size(1028, 594);
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
            this.statusEntities.ResumeLayout(false);
            this.statusEntities.PerformLayout();
            this.gbEntities.ResumeLayout(false);
            this.gbEntities.PerformLayout();
            this.pnEntSearch.ResumeLayout(false);
            this.pnEntSearch.PerformLayout();
            this.pnEntIntersect.ResumeLayout(false);
            this.pnEntIntersect.PerformLayout();
            this.pnEntManaged.ResumeLayout(false);
            this.pnEntManaged.PerformLayout();
            this.pnEntCustom.ResumeLayout(false);
            this.pnEntCustom.PerformLayout();
            this.pnEntSolution.ResumeLayout(false);
            this.pnEntSolution.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitAttRel.Panel1.ResumeLayout(false);
            this.splitAttRel.Panel1.PerformLayout();
            this.splitAttRel.Panel2.ResumeLayout(false);
            this.splitAttRel.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitAttRel)).EndInit();
            this.splitAttRel.ResumeLayout(false);
            this.pnAttributeGrid.ResumeLayout(false);
            this.pnAttributeGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAttributes)).EndInit();
            this.statusAttributes.ResumeLayout(false);
            this.statusAttributes.PerformLayout();
            this.gbAttributes.ResumeLayout(false);
            this.gbAttributes.PerformLayout();
            this.pnAttExclude.ResumeLayout(false);
            this.pnAttExclude.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAttReloadRecords)).EndInit();
            this.pnAttSearch.ResumeLayout(false);
            this.pnAttSearch.PerformLayout();
            this.pnAttInclude.ResumeLayout(false);
            this.pnAttInclude.PerformLayout();
            this.pnAttManaged.ResumeLayout(false);
            this.pnAttManaged.PerformLayout();
            this.pnAttCustom.ResumeLayout(false);
            this.pnAttCustom.PerformLayout();
            this.pnAttBehavior.ResumeLayout(false);
            this.pnAttBehavior.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnRelationshipGrid.ResumeLayout(false);
            this.pnRelationshipGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRelationships)).EndInit();
            this.ctxRelationshipMenu.ResumeLayout(false);
            this.statusRelationships.ResumeLayout(false);
            this.statusRelationships.PerformLayout();
            this.gbRelationships.ResumeLayout(false);
            this.gbRelationships.PerformLayout();
            this.panRelSearch.ResumeLayout(false);
            this.panRelSearch.PerformLayout();
            this.panRel4.ResumeLayout(false);
            this.panRel4.PerformLayout();
            this.panRelType.ResumeLayout(false);
            this.panRelType.PerformLayout();
            this.panRel3.ResumeLayout(false);
            this.panRel3.PerformLayout();
            this.panRel2.ResumeLayout(false);
            this.panRel2.PerformLayout();
            this.panRel1.ResumeLayout(false);
            this.panRel1.PerformLayout();
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnAttManaged;
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
        private System.Windows.Forms.Panel pnEntIntersect;
        private System.Windows.Forms.CheckBox chkEntExclUnselected;
        private System.Windows.Forms.CheckBox chkEntExclIntersect;
        private System.Windows.Forms.Panel pnEntManaged;
        private System.Windows.Forms.Panel pnEntCustom;
        private System.Windows.Forms.Timer tmEntSearch;
        private System.Windows.Forms.Timer tmAttSearch;
        private System.Windows.Forms.Panel pnAttInclude;
        private System.Windows.Forms.CheckBox chkAttPrimaryAttribute;
        private System.Windows.Forms.CheckBox chkAttPrimaryKey;
        private System.Windows.Forms.Panel pnAttBehavior;
        private System.Windows.Forms.Panel pnAttributeGrid;
        private System.Windows.Forms.Panel pnEntityGrid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnWindowTopSpacer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkAttCheckAll;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripLabel tslAbout;
        private System.Windows.Forms.CheckBox chkAttExclLogical;
        private System.Windows.Forms.ToolStripButton btnOptions;
        private System.Windows.Forms.ToolStripMenuItem btnOpenConfig;
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
        private System.Windows.Forms.Panel panRel4;
        private System.Windows.Forms.CheckBox chkRelExclRegarding;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkRelExclOwners;
        private System.Windows.Forms.CheckBox chkRelExclOrphans;
        private System.Windows.Forms.Panel panRel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panRel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panRel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkRelCheckAll;
        private System.Windows.Forms.StatusStrip statusRelationships;
        private System.Windows.Forms.ToolStripStatusLabel statusRelationshipsShowing;
        private System.Windows.Forms.ToolStripStatusLabel statusRelationshipsSelected;
        private System.Windows.Forms.Timer tmRelSearch;
        private System.Windows.Forms.Panel panRelType;
        private System.Windows.Forms.CheckBox chkRelNN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkRelN1;
        private System.Windows.Forms.CheckBox chkRel1N;
        private System.Windows.Forms.Label lblEntNoMatch;
        private System.Windows.Forms.Label lblAttNoMatch;
        private System.Windows.Forms.Label lblRelNoMatch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem btnSaveConfig;
        private System.Windows.Forms.Timer tmHideNotification;
        private System.Windows.Forms.ToolStripSplitButton btnGenerate;
        private System.Windows.Forms.ToolStripMenuItem btnSaveCsAs;
        private System.Windows.Forms.ToolStripDropDownButton menuOpen;
        private System.Windows.Forms.ToolStripMenuItem btnOpenGeneratedFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.CheckBox chkRelExclCreMod;
        private System.Windows.Forms.CheckBox chkRelExclDupRecords;
        private System.Windows.Forms.CheckBox chkAttExclOwners;
        private System.Windows.Forms.CheckBox chkAttExclCreMod;
        private System.Windows.Forms.CheckBox chkAttExclInternal;
        private System.Windows.Forms.CheckBox chkEntExclNoRecords;
        private System.Windows.Forms.CheckBox chkAttUsed;
        private System.Windows.Forms.PictureBox picAttReloadRecords;
        private System.Windows.Forms.CheckBox chkAttUniques;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox chkAttRequired;
        private System.Windows.Forms.ContextMenuStrip ctxRelationshipMenu;
        private System.Windows.Forms.ToolStripMenuItem ctxRelAddRemAccount;
        private System.Windows.Forms.Label lblRelUnShown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEntSelectAllVisible;
        private System.Windows.Forms.Button btnEntUnselectAll;
        private System.Windows.Forms.Button btnEntShowAll;
        private System.Windows.Forms.Label lblEntUnShown;
        private System.Windows.Forms.Label lblAttUnShown;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnAttSelectAllVisible;
        private System.Windows.Forms.Button btnAttUnselectAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRelSelectAllVisible;
        private System.Windows.Forms.Button btnRelUnselectAll;
        private System.Windows.Forms.Button btnAttShowAll;
        private System.Windows.Forms.Button btnRelShowAll;
        private System.Windows.Forms.Panel pnAttExclude;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkAttExclUnRequired;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.CheckBox chkEntExclMS;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel4;
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
    }
}
