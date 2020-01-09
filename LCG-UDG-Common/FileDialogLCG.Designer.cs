namespace Rappen.XTB.LCG
{
    partial class FileDialogLCG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileDialogLCG));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbCommonAttributes = new System.Windows.Forms.ComboBox();
            this.lblNamespace = new System.Windows.Forms.Label();
            this.txtNamespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnOutputFolder = new System.Windows.Forms.Button();
            this.pnFileCommonName = new System.Windows.Forms.Panel();
            this.txtCommonFilename = new System.Windows.Forms.TextBox();
            this.txtCommonFileSuffix = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFileName = new System.Windows.Forms.ComboBox();
            this.rbFilePerEntity = new System.Windows.Forms.RadioButton();
            this.rbFileCommon = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.pnFileCommonName.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(129, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 110;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(262, 159);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 23);
            this.btnOK.TabIndex = 100;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 124);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 13);
            this.label18.TabIndex = 14;
            this.label18.Text = "Common Class";
            // 
            // cmbCommonAttributes
            // 
            this.cmbCommonAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCommonAttributes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCommonAttributes.FormattingEnabled = true;
            this.cmbCommonAttributes.Items.AddRange(new object[] {
            "None",
            "Attributes shared by more than one entity",
            "Attributes shared by all selected entities"});
            this.cmbCommonAttributes.Location = new System.Drawing.Point(132, 120);
            this.cmbCommonAttributes.Name = "cmbCommonAttributes";
            this.cmbCommonAttributes.Size = new System.Drawing.Size(299, 21);
            this.cmbCommonAttributes.TabIndex = 8;
            // 
            // lblNamespace
            // 
            this.lblNamespace.AutoSize = true;
            this.lblNamespace.Location = new System.Drawing.Point(12, 97);
            this.lblNamespace.Name = "lblNamespace";
            this.lblNamespace.Size = new System.Drawing.Size(64, 13);
            this.lblNamespace.TabIndex = 4;
            this.lblNamespace.Text = "Namespace";
            // 
            // txtNamespace
            // 
            this.txtNamespace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNamespace.Location = new System.Drawing.Point(132, 93);
            this.txtNamespace.Name = "txtNamespace";
            this.txtNamespace.Size = new System.Drawing.Size(299, 20);
            this.txtNamespace.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 103;
            this.label3.Text = "Output folder";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFolder.Location = new System.Drawing.Point(132, 13);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(261, 20);
            this.txtOutputFolder.TabIndex = 1;
            // 
            // btnOutputFolder
            // 
            this.btnOutputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnOutputFolder.Image")));
            this.btnOutputFolder.Location = new System.Drawing.Point(399, 12);
            this.btnOutputFolder.Name = "btnOutputFolder";
            this.btnOutputFolder.Size = new System.Drawing.Size(32, 24);
            this.btnOutputFolder.TabIndex = 2;
            this.btnOutputFolder.UseVisualStyleBackColor = true;
            this.btnOutputFolder.Click += new System.EventHandler(this.btnOutputFolder_Click);
            // 
            // pnFileCommonName
            // 
            this.pnFileCommonName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnFileCommonName.Controls.Add(this.txtCommonFilename);
            this.pnFileCommonName.Controls.Add(this.txtCommonFileSuffix);
            this.pnFileCommonName.Location = new System.Drawing.Point(132, 63);
            this.pnFileCommonName.Name = "pnFileCommonName";
            this.pnFileCommonName.Size = new System.Drawing.Size(299, 26);
            this.pnFileCommonName.TabIndex = 5;
            // 
            // txtCommonFilename
            // 
            this.txtCommonFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommonFilename.Location = new System.Drawing.Point(0, 4);
            this.txtCommonFilename.Name = "txtCommonFilename";
            this.txtCommonFilename.Size = new System.Drawing.Size(253, 20);
            this.txtCommonFilename.TabIndex = 6;
            // 
            // txtCommonFileSuffix
            // 
            this.txtCommonFileSuffix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommonFileSuffix.Location = new System.Drawing.Point(251, 4);
            this.txtCommonFileSuffix.Name = "txtCommonFileSuffix";
            this.txtCommonFileSuffix.ReadOnly = true;
            this.txtCommonFileSuffix.Size = new System.Drawing.Size(48, 20);
            this.txtCommonFileSuffix.TabIndex = 5;
            this.txtCommonFileSuffix.TabStop = false;
            this.txtCommonFileSuffix.Text = ".cs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 106;
            this.label7.Text = "File name";
            // 
            // cmbFileName
            // 
            this.cmbFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFileName.FormattingEnabled = true;
            this.cmbFileName.Items.AddRange(new object[] {
            "Display Name",
            "Schema Name",
            "Logical Name"});
            this.cmbFileName.Location = new System.Drawing.Point(132, 67);
            this.cmbFileName.Name = "cmbFileName";
            this.cmbFileName.Size = new System.Drawing.Size(159, 21);
            this.cmbFileName.TabIndex = 109;
            this.cmbFileName.Visible = false;
            // 
            // rbFilePerEntity
            // 
            this.rbFilePerEntity.AutoSize = true;
            this.rbFilePerEntity.Location = new System.Drawing.Point(296, 41);
            this.rbFilePerEntity.Name = "rbFilePerEntity";
            this.rbFilePerEntity.Size = new System.Drawing.Size(107, 17);
            this.rbFilePerEntity.TabIndex = 4;
            this.rbFilePerEntity.TabStop = true;
            this.rbFilePerEntity.Text = "One file per entity";
            this.rbFilePerEntity.UseVisualStyleBackColor = true;
            this.rbFilePerEntity.CheckedChanged += new System.EventHandler(this.rbFileCommon_CheckedChanged);
            // 
            // rbFileCommon
            // 
            this.rbFileCommon.AutoSize = true;
            this.rbFileCommon.Checked = true;
            this.rbFileCommon.Location = new System.Drawing.Point(133, 41);
            this.rbFileCommon.Name = "rbFileCommon";
            this.rbFileCommon.Size = new System.Drawing.Size(104, 17);
            this.rbFileCommon.TabIndex = 3;
            this.rbFileCommon.TabStop = true;
            this.rbFileCommon.Text = "One common file";
            this.rbFileCommon.UseVisualStyleBackColor = true;
            this.rbFileCommon.CheckedChanged += new System.EventHandler(this.rbFileCommon_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "File structure";
            // 
            // GenerateDialogLCG
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(467, 200);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.rbFilePerEntity);
            this.Controls.Add(this.cmbCommonAttributes);
            this.Controls.Add(this.lblNamespace);
            this.Controls.Add(this.rbFileCommon);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNamespace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.btnOutputFolder);
            this.Controls.Add(this.pnFileCommonName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbFileName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerateDialogLCG";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Options";
            this.pnFileCommonName.ResumeLayout(false);
            this.pnFileCommonName.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbCommonAttributes;
        private System.Windows.Forms.Label lblNamespace;
        private System.Windows.Forms.TextBox txtNamespace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Button btnOutputFolder;
        private System.Windows.Forms.Panel pnFileCommonName;
        private System.Windows.Forms.TextBox txtCommonFilename;
        private System.Windows.Forms.TextBox txtCommonFileSuffix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFileName;
        private System.Windows.Forms.RadioButton rbFilePerEntity;
        private System.Windows.Forms.RadioButton rbFileCommon;
        private System.Windows.Forms.Label label6;
    }
}