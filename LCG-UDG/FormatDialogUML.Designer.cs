namespace Rappen.XTB.LCG
{
    partial class FormatDialogUML
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chkConstCamelCased = new System.Windows.Forms.CheckBox();
            this.txtConstStripPrefix = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkConstStripPrefix = new System.Windows.Forms.CheckBox();
            this.cmbConstantName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbSortAttributes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRelationshipLabels = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.chkShowLegend = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkFileIncludeSelection = new System.Windows.Forms.CheckBox();
            this.labelFileStructure = new System.Windows.Forms.Label();
            this.labelOutputFormat = new System.Windows.Forms.Label();
            this.cmbOutputFormat = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkTypeDetails = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rbTableSize1 = new System.Windows.Forms.RadioButton();
            this.rbTableSize10 = new System.Windows.Forms.RadioButton();
            this.rbTableSize20 = new System.Windows.Forms.RadioButton();
            this.rbTableSize50 = new System.Windows.Forms.RadioButton();
            this.rbRelSize4 = new System.Windows.Forms.RadioButton();
            this.rbRelSize3 = new System.Windows.Forms.RadioButton();
            this.rbRelSize2 = new System.Windows.Forms.RadioButton();
            this.rbRelSize1 = new System.Windows.Forms.RadioButton();
            this.panRelSizes = new System.Windows.Forms.Panel();
            this.panTableSizes = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTheme = new System.Windows.Forms.ComboBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panRelSizes.SuspendLayout();
            this.panTableSizes.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkConstCamelCased
            // 
            this.chkConstCamelCased.AutoSize = true;
            this.chkConstCamelCased.Location = new System.Drawing.Point(355, 124);
            this.chkConstCamelCased.Name = "chkConstCamelCased";
            this.chkConstCamelCased.Size = new System.Drawing.Size(85, 17);
            this.chkConstCamelCased.TabIndex = 6;
            this.chkConstCamelCased.Text = "CamelCased";
            this.chkConstCamelCased.UseVisualStyleBackColor = true;
            this.chkConstCamelCased.Visible = false;
            // 
            // txtConstStripPrefix
            // 
            this.txtConstStripPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConstStripPrefix.Enabled = false;
            this.txtConstStripPrefix.Location = new System.Drawing.Point(226, 149);
            this.txtConstStripPrefix.Name = "txtConstStripPrefix";
            this.txtConstStripPrefix.Size = new System.Drawing.Size(214, 20);
            this.txtConstStripPrefix.TabIndex = 8;
            this.txtConstStripPrefix.Leave += new System.EventHandler(this.txtConstStripPrefix_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Prefix";
            // 
            // chkConstStripPrefix
            // 
            this.chkConstStripPrefix.AutoSize = true;
            this.chkConstStripPrefix.Enabled = false;
            this.chkConstStripPrefix.Location = new System.Drawing.Point(141, 151);
            this.chkConstStripPrefix.Name = "chkConstStripPrefix";
            this.chkConstStripPrefix.Size = new System.Drawing.Size(89, 17);
            this.chkConstStripPrefix.TabIndex = 7;
            this.chkConstStripPrefix.Text = "Skip prefixes:";
            this.chkConstStripPrefix.UseVisualStyleBackColor = true;
            this.chkConstStripPrefix.CheckedChanged += new System.EventHandler(this.chkConstStripPrefix_CheckedChanged);
            // 
            // cmbConstantName
            // 
            this.cmbConstantName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConstantName.FormattingEnabled = true;
            this.cmbConstantName.Items.AddRange(new object[] {
            "Display Name",
            "Schema Name",
            "Logical Name"});
            this.cmbConstantName.Location = new System.Drawing.Point(141, 122);
            this.cmbConstantName.Name = "cmbConstantName";
            this.cmbConstantName.Size = new System.Drawing.Size(189, 21);
            this.cmbConstantName.TabIndex = 5;
            this.cmbConstantName.SelectedIndexChanged += new System.EventHandler(this.cmbConstantName_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Identifier";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(141, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 120;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(274, 351);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // cmbSortAttributes
            // 
            this.cmbSortAttributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortAttributes.FormattingEnabled = true;
            this.cmbSortAttributes.Items.AddRange(new object[] {
            "No sorting",
            "Alphabetically",
            "Required Level and Alphabetically"});
            this.cmbSortAttributes.Location = new System.Drawing.Point(141, 175);
            this.cmbSortAttributes.Name = "cmbSortAttributes";
            this.cmbSortAttributes.Size = new System.Drawing.Size(189, 21);
            this.cmbSortAttributes.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Sort attributes by";
            // 
            // chkRelationshipLabels
            // 
            this.chkRelationshipLabels.AutoSize = true;
            this.chkRelationshipLabels.Location = new System.Drawing.Point(141, 225);
            this.chkRelationshipLabels.Name = "chkRelationshipLabels";
            this.chkRelationshipLabels.Size = new System.Drawing.Size(130, 17);
            this.chkRelationshipLabels.TabIndex = 12;
            this.chkRelationshipLabels.Text = "Include lookup names";
            this.chkRelationshipLabels.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 105;
            this.label2.Text = "Relationships";
            // 
            // lblNamespace
            // 
            this.lblNamespace.AutoSize = true;
            this.lblNamespace.Location = new System.Drawing.Point(24, 99);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(27, 13);
            this.lblNamespace.TabIndex = 107;
            this.lblNamespace.Text = "Title";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamespace.Location = new System.Drawing.Point(141, 96);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(299, 20);
            this.txtNamespace.TabIndex = 4;
            // 
            // chkShowLegend
            // 
            this.chkShowLegend.AutoSize = true;
            this.chkShowLegend.Location = new System.Drawing.Point(141, 248);
            this.chkShowLegend.Name = "chkShowLegend";
            this.chkShowLegend.Size = new System.Drawing.Size(88, 17);
            this.chkShowLegend.TabIndex = 13;
            this.chkShowLegend.Text = "Show legend";
            this.chkShowLegend.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 122;
            this.label3.Text = "Info";
            // 
            // chkFileIncludeSelection
            // 
            this.chkFileIncludeSelection.AutoSize = true;
            this.chkFileIncludeSelection.Location = new System.Drawing.Point(141, 46);
            this.chkFileIncludeSelection.Name = "chkFileIncludeSelection";
            this.chkFileIncludeSelection.Size = new System.Drawing.Size(125, 17);
            this.chkFileIncludeSelection.TabIndex = 1;
            this.chkFileIncludeSelection.Text = "Include configuration";
            this.chkFileIncludeSelection.UseVisualStyleBackColor = true;
            // 
            // labelFileStructure
            // 
            this.labelFileStructure.AutoSize = true;
            this.labelFileStructure.Location = new System.Drawing.Point(24, 47);
            this.labelFileStructure.Name = "labelFileStructure";
            this.labelFileStructure.Size = new System.Drawing.Size(67, 13);
            this.labelFileStructure.TabIndex = 149;
            this.labelFileStructure.Text = "File structure";
            // 
            // labelOutputFormat
            // 
            this.labelOutputFormat.AutoSize = true;
            this.labelOutputFormat.Location = new System.Drawing.Point(24, 22);
            this.labelOutputFormat.Name = "labelOutputFormat";
            this.labelOutputFormat.Size = new System.Drawing.Size(71, 13);
            this.labelOutputFormat.TabIndex = 150;
            this.labelOutputFormat.Text = "Output format";
            // 
            // cmbOutputFormat
            // 
            this.cmbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Items.AddRange(new object[] {
            "PlantUML",
            "DBML"});
            this.cmbOutputFormat.Location = new System.Drawing.Point(141, 19);
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.Size = new System.Drawing.Size(299, 21);
            this.cmbOutputFormat.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 150;
            this.label4.Text = "Types";
            // 
            // chkTypeDetails
            // 
            this.chkTypeDetails.AutoSize = true;
            this.chkTypeDetails.Location = new System.Drawing.Point(141, 202);
            this.chkTypeDetails.Name = "chkTypeDetails";
            this.chkTypeDetails.Size = new System.Drawing.Size(85, 17);
            this.chkTypeDetails.TabIndex = 10;
            this.chkTypeDetails.Text = "Type Details";
            this.chkTypeDetails.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 151;
            this.label5.Text = "Table Size";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 152;
            this.label7.Text = "Relationship Size";
            // 
            // rbTableSize1
            // 
            this.rbTableSize1.AutoSize = true;
            this.rbTableSize1.Checked = true;
            this.rbTableSize1.Location = new System.Drawing.Point(3, 6);
            this.rbTableSize1.Name = "rbTableSize1";
            this.rbTableSize1.Size = new System.Drawing.Size(49, 17);
            this.rbTableSize1.TabIndex = 153;
            this.rbTableSize1.TabStop = true;
            this.rbTableSize1.Tag = "1";
            this.rbTableSize1.Text = "Tight";
            this.rbTableSize1.UseVisualStyleBackColor = true;
            // 
            // rbTableSize10
            // 
            this.rbTableSize10.AutoSize = true;
            this.rbTableSize10.Location = new System.Drawing.Point(58, 6);
            this.rbTableSize10.Name = "rbTableSize10";
            this.rbTableSize10.Size = new System.Drawing.Size(58, 17);
            this.rbTableSize10.TabIndex = 154;
            this.rbTableSize10.Tag = "10";
            this.rbTableSize10.Text = "Normal";
            this.rbTableSize10.UseVisualStyleBackColor = true;
            // 
            // rbTableSize20
            // 
            this.rbTableSize20.AutoSize = true;
            this.rbTableSize20.Location = new System.Drawing.Point(122, 6);
            this.rbTableSize20.Name = "rbTableSize20";
            this.rbTableSize20.Size = new System.Drawing.Size(40, 17);
            this.rbTableSize20.TabIndex = 155;
            this.rbTableSize20.Tag = "20";
            this.rbTableSize20.Text = "Big";
            this.rbTableSize20.UseVisualStyleBackColor = true;
            // 
            // rbTableSize50
            // 
            this.rbTableSize50.AutoSize = true;
            this.rbTableSize50.Location = new System.Drawing.Point(168, 6);
            this.rbTableSize50.Name = "rbTableSize50";
            this.rbTableSize50.Size = new System.Drawing.Size(51, 17);
            this.rbTableSize50.TabIndex = 156;
            this.rbTableSize50.Tag = "50";
            this.rbTableSize50.Text = "Huge";
            this.rbTableSize50.UseVisualStyleBackColor = true;
            // 
            // rbRelSize4
            // 
            this.rbRelSize4.AutoSize = true;
            this.rbRelSize4.Location = new System.Drawing.Point(171, 5);
            this.rbRelSize4.Name = "rbRelSize4";
            this.rbRelSize4.Size = new System.Drawing.Size(51, 17);
            this.rbRelSize4.TabIndex = 160;
            this.rbRelSize4.Tag = "4";
            this.rbRelSize4.Text = "Huge";
            this.rbRelSize4.UseVisualStyleBackColor = true;
            // 
            // rbRelSize3
            // 
            this.rbRelSize3.AutoSize = true;
            this.rbRelSize3.Location = new System.Drawing.Point(125, 5);
            this.rbRelSize3.Name = "rbRelSize3";
            this.rbRelSize3.Size = new System.Drawing.Size(40, 17);
            this.rbRelSize3.TabIndex = 159;
            this.rbRelSize3.Tag = "3";
            this.rbRelSize3.Text = "Big";
            this.rbRelSize3.UseVisualStyleBackColor = true;
            // 
            // rbRelSize2
            // 
            this.rbRelSize2.AutoSize = true;
            this.rbRelSize2.Checked = true;
            this.rbRelSize2.Location = new System.Drawing.Point(61, 5);
            this.rbRelSize2.Name = "rbRelSize2";
            this.rbRelSize2.Size = new System.Drawing.Size(58, 17);
            this.rbRelSize2.TabIndex = 158;
            this.rbRelSize2.TabStop = true;
            this.rbRelSize2.Tag = "2";
            this.rbRelSize2.Text = "Normal";
            this.rbRelSize2.UseVisualStyleBackColor = true;
            // 
            // rbRelSize1
            // 
            this.rbRelSize1.AutoSize = true;
            this.rbRelSize1.Location = new System.Drawing.Point(6, 5);
            this.rbRelSize1.Name = "rbRelSize1";
            this.rbRelSize1.Size = new System.Drawing.Size(49, 17);
            this.rbRelSize1.TabIndex = 157;
            this.rbRelSize1.Tag = "1";
            this.rbRelSize1.Text = "Tight";
            this.rbRelSize1.UseVisualStyleBackColor = true;
            // 
            // panRelSizes
            // 
            this.panRelSizes.Controls.Add(this.rbRelSize1);
            this.panRelSizes.Controls.Add(this.rbRelSize4);
            this.panRelSizes.Controls.Add(this.rbRelSize2);
            this.panRelSizes.Controls.Add(this.rbRelSize3);
            this.panRelSizes.Location = new System.Drawing.Point(137, 297);
            this.panRelSizes.Name = "panRelSizes";
            this.panRelSizes.Size = new System.Drawing.Size(234, 30);
            this.panRelSizes.TabIndex = 15;
            // 
            // panTableSizes
            // 
            this.panTableSizes.Controls.Add(this.rbTableSize1);
            this.panTableSizes.Controls.Add(this.rbTableSize10);
            this.panTableSizes.Controls.Add(this.rbTableSize50);
            this.panTableSizes.Controls.Add(this.rbTableSize20);
            this.panTableSizes.Location = new System.Drawing.Point(139, 268);
            this.panTableSizes.Name = "panTableSizes";
            this.panTableSizes.Size = new System.Drawing.Size(230, 25);
            this.panTableSizes.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 163;
            this.label9.Text = "Theme";
            // 
            // cmbTheme
            // 
            this.cmbTheme.FormattingEnabled = true;
            this.cmbTheme.Items.AddRange(new object[] {
            "",
            "amiga",
            "aws-orange",
            "black-knight",
            "bluegray",
            "blueprint",
            "carbon-gray",
            "cerulean",
            "cerulean-outline",
            "cloudscape-design",
            "crt-amber",
            "crt-green",
            "cyborg",
            "cyborg-outline",
            "hacker",
            "lightgray",
            "mars",
            "materia",
            "materia-outline",
            "metal",
            "mimeograph",
            "minty",
            "mono",
            "plain",
            "reddress-darkblue",
            "reddress-darkgreen",
            "reddress-darkorange",
            "reddress-darkred",
            "reddress-lightblue",
            "reddress-lightgreen",
            "reddress-lightorange",
            "reddress-lightred",
            "sandstone",
            "silver",
            "sketchy",
            "sketchy-outline",
            "spacelab",
            "spacelab-white",
            "sunlust",
            "superhero",
            "superhero-outline",
            "toy",
            "united",
            "vibrant"});
            this.cmbTheme.Location = new System.Drawing.Point(141, 69);
            this.cmbTheme.Name = "cmbTheme";
            this.cmbTheme.Size = new System.Drawing.Size(189, 21);
            this.cmbTheme.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cmbTheme, "Use an existing theme in the list, or use available online or on your disc!");
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(367, 72);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(73, 13);
            this.linkLabel1.TabIndex = 3;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Tag = "https://plantuml.com/theme";
            this.linkLabel1.Text = "Themes Docs";
            this.toolTip1.SetToolTip(this.linkLabel1, "Read docs: https://plantuml.com/theme");
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // FormatDialogUML
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(467, 388);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.cmbTheme);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panTableSizes);
            this.Controls.Add(this.panRelSizes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkTypeDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbOutputFormat);
            this.Controls.Add(this.labelOutputFormat);
            this.Controls.Add(this.labelFileStructure);
            this.Controls.Add(this.chkFileIncludeSelection);
            this.Controls.Add(this.chkShowLegend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNamespace);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.chkRelationshipLabels);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSortAttributes);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkConstCamelCased);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbConstantName);
            this.Controls.Add(this.txtConstStripPrefix);
            this.Controls.Add(this.chkConstStripPrefix);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormatDialogUML";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Format Options";
            this.panRelSizes.ResumeLayout(false);
            this.panRelSizes.PerformLayout();
            this.panTableSizes.ResumeLayout(false);
            this.panTableSizes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkConstCamelCased;
        private System.Windows.Forms.TextBox txtConstStripPrefix;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkConstStripPrefix;
        private System.Windows.Forms.ComboBox cmbConstantName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbSortAttributes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkRelationshipLabels;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNamespace;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.CheckBox chkShowLegend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkFileIncludeSelection;
        private System.Windows.Forms.Label labelFileStructure;
        private System.Windows.Forms.Label labelOutputFormat;
        private System.Windows.Forms.ComboBox cmbOutputFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkTypeDetails;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbTableSize1;
        private System.Windows.Forms.RadioButton rbTableSize10;
        private System.Windows.Forms.RadioButton rbTableSize20;
        private System.Windows.Forms.RadioButton rbTableSize50;
        private System.Windows.Forms.RadioButton rbRelSize4;
        private System.Windows.Forms.RadioButton rbRelSize3;
        private System.Windows.Forms.RadioButton rbRelSize2;
        private System.Windows.Forms.RadioButton rbRelSize1;
        private System.Windows.Forms.Panel panRelSizes;
        private System.Windows.Forms.Panel panTableSizes;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTheme;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}