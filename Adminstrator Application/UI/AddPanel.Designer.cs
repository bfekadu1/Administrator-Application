namespace Adminstrator_Application.UI
{
    partial class AddPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPanel));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnAddPanelExit = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPanelDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtCategory = new System.Windows.Forms.ComboBox();
            this.btnSavePanel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrice = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPanelDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(763, 53);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnAddPanelExit);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelControl2.Location = new System.Drawing.Point(711, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(52, 53);
            this.panelControl2.TabIndex = 0;
            // 
            // btnAddPanelExit
            // 
            this.btnAddPanelExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddPanelExit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPanelExit.ImageOptions.Image")));
            this.btnAddPanelExit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.btnAddPanelExit.Location = new System.Drawing.Point(0, 0);
            this.btnAddPanelExit.Name = "btnAddPanelExit";
            this.btnAddPanelExit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnAddPanelExit.Size = new System.Drawing.Size(52, 53);
            this.btnAddPanelExit.TabIndex = 0;
            this.btnAddPanelExit.Click += new System.EventHandler(this.btnAddPanelExit_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(140, 112);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(176, 23);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Panel Description:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(217, 176);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(99, 23);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Category:";
            // 
            // txtPanelDescription
            // 
            this.txtPanelDescription.Location = new System.Drawing.Point(355, 109);
            this.txtPanelDescription.Name = "txtPanelDescription";
            this.txtPanelDescription.Properties.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.txtPanelDescription.Properties.Appearance.Options.UseFont = true;
            this.txtPanelDescription.Size = new System.Drawing.Size(217, 30);
            this.txtPanelDescription.TabIndex = 3;
            this.txtPanelDescription.EditValueChanged += new System.EventHandler(this.txtPanelDescription_EditValueChanged);
            this.txtPanelDescription.Leave += new System.EventHandler(this.txtPanelDescription_Leave);
            // 
            // txtCategory
            // 
            this.txtCategory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.txtCategory.FormattingEnabled = true;
            this.txtCategory.Location = new System.Drawing.Point(355, 174);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(217, 31);
            this.txtCategory.TabIndex = 4;
            this.txtCategory.SelectedIndexChanged += new System.EventHandler(this.txtCategory_SelectedIndexChanged);
            this.txtCategory.SelectedValueChanged += new System.EventHandler(this.txtCategory_SelectedValueChanged);
            this.txtCategory.Leave += new System.EventHandler(this.txtCategory_Leave);
            // 
            // btnSavePanel
            // 
            this.btnSavePanel.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePanel.Appearance.Options.UseFont = true;
            this.btnSavePanel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePanel.ImageOptions.Image")));
            this.btnSavePanel.Location = new System.Drawing.Point(369, 306);
            this.btnSavePanel.Name = "btnSavePanel";
            this.btnSavePanel.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btnSavePanel.Size = new System.Drawing.Size(171, 45);
            this.btnSavePanel.TabIndex = 5;
            this.btnSavePanel.Text = "Save Panel";
            this.btnSavePanel.Click += new System.EventHandler(this.btnSavePanel_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(43, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(104, 23);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Add Panel";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(268, 246);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(53, 23);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.DecimalPlaces = 3;
            this.txtPrice.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Italic);
            this.txtPrice.Location = new System.Drawing.Point(355, 237);
            this.txtPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(217, 32);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.ValueChanged += new System.EventHandler(this.txtPrice_ValueChanged);
            this.txtPrice.Leave += new System.EventHandler(this.txtPrice_Leave);
            // 
            // AddPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 463);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnSavePanel);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtPanelDescription);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPanel";
            this.Load += new System.EventHandler(this.AddPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPanelDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnAddPanelExit;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPanelDescription;
        private System.Windows.Forms.ComboBox txtCategory;
        private DevExpress.XtraEditors.SimpleButton btnSavePanel;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.NumericUpDown txtPrice;
    }
}