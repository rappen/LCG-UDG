namespace Rappen.XTB.LCG
{
    partial class OptionsDialogUML
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
            this.SuspendLayout();
            // 
            // chkConstCamelCased
            // 
            this.chkConstCamelCased.AutoSize = true;
            this.chkConstCamelCased.Location = new System.Drawing.Point(313, 14);
            this.chkConstCamelCased.Name = "chkConstCamelCased";
            this.chkConstCamelCased.Size = new System.Drawing.Size(85, 17);
            this.chkConstCamelCased.TabIndex = 20;
            this.chkConstCamelCased.Text = "CamelCased";
            this.chkConstCamelCased.UseVisualStyleBackColor = true;
            this.chkConstCamelCased.Visible = false;
            // 
            // txtConstStripPrefix
            // 
            this.txtConstStripPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConstStripPrefix.Enabled = false;
            this.txtConstStripPrefix.Location = new System.Drawing.Point(215, 40);
            this.txtConstStripPrefix.Name = "txtConstStripPrefix";
            this.txtConstStripPrefix.Size = new System.Drawing.Size(228, 20);
            this.txtConstStripPrefix.TabIndex = 40;
            this.txtConstStripPrefix.Leave += new System.EventHandler(this.txtConstStripPrefix_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Prefix";
            // 
            // chkConstStripPrefix
            // 
            this.chkConstStripPrefix.AutoSize = true;
            this.chkConstStripPrefix.Enabled = false;
            this.chkConstStripPrefix.Location = new System.Drawing.Point(129, 42);
            this.chkConstStripPrefix.Name = "chkConstStripPrefix";
            this.chkConstStripPrefix.Size = new System.Drawing.Size(89, 17);
            this.chkConstStripPrefix.TabIndex = 30;
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
            this.cmbConstantName.Location = new System.Drawing.Point(129, 13);
            this.cmbConstantName.Name = "cmbConstantName";
            this.cmbConstantName.Size = new System.Drawing.Size(178, 21);
            this.cmbConstantName.TabIndex = 10;
            this.cmbConstantName.SelectedIndexChanged += new System.EventHandler(this.cmbConstantName_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Identifier";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(129, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 23);
            this.btnCancel.TabIndex = 101;
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
            this.btnOK.TabIndex = 102;
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
            this.cmbSortAttributes.Location = new System.Drawing.Point(129, 67);
            this.cmbSortAttributes.Name = "cmbSortAttributes";
            this.cmbSortAttributes.Size = new System.Drawing.Size(178, 21);
            this.cmbSortAttributes.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 104;
            this.label1.Text = "Sort attributes by";
            // 
            // OptionsDialogUML
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(467, 200);
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
            this.Name = "OptionsDialogUML";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Constant Options";
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
    }
}