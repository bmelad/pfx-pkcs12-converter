namespace PFXConverter
{
    partial class frmPfxConverter
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
            this.lblStep1 = new System.Windows.Forms.Label();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.txtSourcePassword = new System.Windows.Forms.TextBox();
            this.lblStep3 = new System.Windows.Forms.Label();
            this.cmbOutputFormat = new System.Windows.Forms.ComboBox();
            this.lblStep5 = new System.Windows.Forms.Label();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblStep4 = new System.Windows.Forms.Label();
            this.txtDestinationPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblStep1
            // 
            this.lblStep1.AutoSize = true;
            this.lblStep1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStep1.Location = new System.Drawing.Point(12, 26);
            this.lblStep1.Name = "lblStep1";
            this.lblStep1.Size = new System.Drawing.Size(190, 13);
            this.lblStep1.TabIndex = 0;
            this.lblStep1.Text = "Step #1 - Choose the source file:";
            // 
            // btnBrowseSource
            // 
            this.btnBrowseSource.Location = new System.Drawing.Point(231, 21);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSource.TabIndex = 1;
            this.btnBrowseSource.Text = "Browse...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStep2.Location = new System.Drawing.Point(12, 50);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(207, 13);
            this.lblStep2.TabIndex = 0;
            this.lblStep2.Text = "Step #2 - Enter the PFX\'s password:";
            // 
            // txtSourcePassword
            // 
            this.txtSourcePassword.Location = new System.Drawing.Point(232, 47);
            this.txtSourcePassword.Name = "txtSourcePassword";
            this.txtSourcePassword.Size = new System.Drawing.Size(125, 21);
            this.txtSourcePassword.TabIndex = 2;
            this.txtSourcePassword.UseSystemPasswordChar = true;
            this.txtSourcePassword.TextChanged += new System.EventHandler(this.txtSourcePassword_TextChanged);
            // 
            // lblStep3
            // 
            this.lblStep3.AutoSize = true;
            this.lblStep3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStep3.Location = new System.Drawing.Point(12, 75);
            this.lblStep3.Name = "lblStep3";
            this.lblStep3.Size = new System.Drawing.Size(212, 13);
            this.lblStep3.TabIndex = 0;
            this.lblStep3.Text = "Step #3 - Choose the output format:";
            // 
            // cmbOutputFormat
            // 
            this.cmbOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutputFormat.FormattingEnabled = true;
            this.cmbOutputFormat.Items.AddRange(new object[] {
            "PEM (Base64)",
            "JKS (Java Keystore)",
            "PSE (SAP Proprietary)"});
            this.cmbOutputFormat.Location = new System.Drawing.Point(232, 72);
            this.cmbOutputFormat.Name = "cmbOutputFormat";
            this.cmbOutputFormat.Size = new System.Drawing.Size(125, 21);
            this.cmbOutputFormat.TabIndex = 3;
            this.cmbOutputFormat.SelectedIndexChanged += new System.EventHandler(this.cmbOutputFormat_SelectedIndexChanged);
            // 
            // lblStep5
            // 
            this.lblStep5.AutoSize = true;
            this.lblStep5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStep5.Location = new System.Drawing.Point(12, 126);
            this.lblStep5.Name = "lblStep5";
            this.lblStep5.Size = new System.Drawing.Size(199, 13);
            this.lblStep5.TabIndex = 0;
            this.lblStep5.Text = "Step #5 - Choose the output path:";
            // 
            // btnBrowseDestination
            // 
            this.btnBrowseDestination.Location = new System.Drawing.Point(231, 121);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDestination.TabIndex = 5;
            this.btnBrowseDestination.Text = "Browse...";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnConvert.Location = new System.Drawing.Point(282, 161);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 6;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblStep4
            // 
            this.lblStep4.AutoSize = true;
            this.lblStep4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStep4.Location = new System.Drawing.Point(12, 100);
            this.lblStep4.Name = "lblStep4";
            this.lblStep4.Size = new System.Drawing.Size(216, 13);
            this.lblStep4.TabIndex = 0;
            this.lblStep4.Text = "Step #4 - Enter the output password:";
            // 
            // txtDestinationPassword
            // 
            this.txtDestinationPassword.Location = new System.Drawing.Point(232, 97);
            this.txtDestinationPassword.Name = "txtDestinationPassword";
            this.txtDestinationPassword.Size = new System.Drawing.Size(125, 21);
            this.txtDestinationPassword.TabIndex = 4;
            this.txtDestinationPassword.UseSystemPasswordChar = true;
            this.txtDestinationPassword.TextChanged += new System.EventHandler(this.txtDestinationPassword_TextChanged);
            // 
            // frmPfxConverter
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 198);
            this.Controls.Add(this.cmbOutputFormat);
            this.Controls.Add(this.txtDestinationPassword);
            this.Controls.Add(this.txtSourcePassword);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnBrowseDestination);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.lblStep5);
            this.Controls.Add(this.lblStep4);
            this.Controls.Add(this.lblStep3);
            this.Controls.Add(this.lblStep2);
            this.Controls.Add(this.lblStep1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPfxConverter";
            this.Text = "PFX Converter For Dummies [by Elad Ben-Matityahu]";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmPfxConverter_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmPfxConverter_DragEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStep1;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.TextBox txtSourcePassword;
        private System.Windows.Forms.Label lblStep3;
        private System.Windows.Forms.ComboBox cmbOutputFormat;
        private System.Windows.Forms.Label lblStep5;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblStep4;
        private System.Windows.Forms.TextBox txtDestinationPassword;
    }
}

