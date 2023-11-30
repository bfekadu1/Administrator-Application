namespace Adminstrator_Application.UI
{
    partial class AddUserToDepartement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUserToDepartement));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtUsers = new DevExpress.XtraEditors.TextEdit();
            this.btnAddUserToRole = new DevExpress.XtraEditors.SimpleButton();
            this.txtUserToAdded = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsers.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(612, 56);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(36, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(142, 23);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Add User Form";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(552, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(58, 52);
            this.panelControl2.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.simpleButton1.Location = new System.Drawing.Point(0, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.simpleButton1.Size = new System.Drawing.Size(58, 52);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtUsers
            // 
            this.txtUsers.Location = new System.Drawing.Point(160, 208);
            this.txtUsers.Name = "txtUsers";
            this.txtUsers.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Italic);
            this.txtUsers.Properties.Appearance.Options.UseFont = true;
            this.txtUsers.Size = new System.Drawing.Size(284, 28);
            this.txtUsers.TabIndex = 2;
            // 
            // btnAddUserToRole
            // 
            this.btnAddUserToRole.Appearance.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUserToRole.Appearance.Options.UseFont = true;
            this.btnAddUserToRole.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddUserToRole.ImageOptions.Image")));
            this.btnAddUserToRole.Location = new System.Drawing.Point(316, 338);
            this.btnAddUserToRole.Name = "btnAddUserToRole";
            this.btnAddUserToRole.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAddUserToRole.Size = new System.Drawing.Size(153, 44);
            this.btnAddUserToRole.TabIndex = 3;
            this.btnAddUserToRole.Text = "Add User";
            this.btnAddUserToRole.Click += new System.EventHandler(this.btnAddUserToRole_Click);
            // 
            // txtUserToAdded
            // 
            this.txtUserToAdded.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserToAdded.FormattingEnabled = true;
            this.txtUserToAdded.Location = new System.Drawing.Point(160, 142);
            this.txtUserToAdded.Name = "txtUserToAdded";
            this.txtUserToAdded.Size = new System.Drawing.Size(284, 31);
            this.txtUserToAdded.TabIndex = 5;
            this.txtUserToAdded.SelectedIndexChanged += new System.EventHandler(this.txtUserToAdded_SelectedIndexChanged);
            // 
            // AddUserToDepartement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 459);
            this.Controls.Add(this.txtUserToAdded);
            this.Controls.Add(this.btnAddUserToRole);
            this.Controls.Add(this.txtUsers);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddUserToDepartement";
            this.Text = "AddUserToDepartement";
           // this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddUserToDepartement_FormClosed);
            this.Load += new System.EventHandler(this.AddUserToDepartement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUsers.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtUsers;
        private DevExpress.XtraEditors.SimpleButton btnAddUserToRole;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox txtUserToAdded;
    }
}