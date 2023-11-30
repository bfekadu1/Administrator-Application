namespace Adminstrator_Application.UI
{
    partial class addOperation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addOperation));
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.operationLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCloseAddOperation = new DevExpress.XtraEditors.SimpleButton();
            this.isFinal = new DevExpress.XtraEditors.CheckEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnOperationColorPick = new DevExpress.XtraEditors.ColorEdit();
            this.lblSelectedColor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOperationSave = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationLookUpEdit.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.isFinal.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOperationColorPick.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(245, 310);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEdit1.Properties.Appearance.Options.UseFont = true;
            this.checkEdit1.Properties.Caption = "";
            this.checkEdit1.Size = new System.Drawing.Size(23, 24);
            this.checkEdit1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(144, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Operation:";
            // 
            // operationLookUpEdit
            // 
            this.operationLookUpEdit.Location = new System.Drawing.Point(245, 182);
            this.operationLookUpEdit.Name = "operationLookUpEdit";
            this.operationLookUpEdit.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationLookUpEdit.Properties.Appearance.Options.UseFont = true;
            this.operationLookUpEdit.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.operationLookUpEdit.Properties.AppearanceDropDown.Options.UseFont = true;
            this.operationLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.operationLookUpEdit.Properties.NullText = "Select Operation";
            this.operationLookUpEdit.Size = new System.Drawing.Size(273, 28);
            this.operationLookUpEdit.TabIndex = 5;
            this.operationLookUpEdit.EditValueChanged += new System.EventHandler(this.operationLookUpEdit_EditValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnCloseAddOperation);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 55);
            this.panel1.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 33);
            this.label5.TabIndex = 5;
            this.label5.Text = "Add Operation";
            // 
            // btnCloseAddOperation
            // 
            this.btnCloseAddOperation.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCloseAddOperation.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseAddOperation.ImageOptions.Image")));
            this.btnCloseAddOperation.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.BottomCenter;
            this.btnCloseAddOperation.Location = new System.Drawing.Point(530, 0);
            this.btnCloseAddOperation.Name = "btnCloseAddOperation";
            this.btnCloseAddOperation.Size = new System.Drawing.Size(84, 55);
            this.btnCloseAddOperation.TabIndex = 0;
            this.btnCloseAddOperation.Click += new System.EventHandler(this.btnCloseAddOperation_Click);
            // 
            // isFinal
            // 
            this.isFinal.Location = new System.Drawing.Point(245, 266);
            this.isFinal.Name = "isFinal";
            this.isFinal.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isFinal.Properties.Appearance.Options.UseFont = true;
            this.isFinal.Properties.Caption = "";
            this.isFinal.Size = new System.Drawing.Size(23, 24);
            this.isFinal.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnOperationColorPick);
            this.panel3.Controls.Add(this.lblSelectedColor);
            this.panel3.Controls.Add(this.btnOperationSave);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.isFinal);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.operationLookUpEdit);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.checkEdit1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(616, 469);
            this.panel3.TabIndex = 1;
            // 
            // btnOperationColorPick
            // 
            this.btnOperationColorPick.EditValue = System.Drawing.Color.Empty;
            this.btnOperationColorPick.Location = new System.Drawing.Point(245, 222);
            this.btnOperationColorPick.Name = "btnOperationColorPick";
            this.btnOperationColorPick.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.btnOperationColorPick.Size = new System.Drawing.Size(62, 22);
            this.btnOperationColorPick.TabIndex = 14;
            this.btnOperationColorPick.EditValueChanged += new System.EventHandler(this.btnOperationColorPick_EditValueChanged);
            // 
            // lblSelectedColor
            // 
            this.lblSelectedColor.AutoSize = true;
            this.lblSelectedColor.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedColor.Location = new System.Drawing.Point(324, 222);
            this.lblSelectedColor.Name = "lblSelectedColor";
            this.lblSelectedColor.Size = new System.Drawing.Size(56, 22);
            this.lblSelectedColor.TabIndex = 13;
            this.lblSelectedColor.Text = "Color";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(11, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 2);
            this.panel2.TabIndex = 12;
            // 
            // btnOperationSave
            // 
            this.btnOperationSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperationSave.Appearance.Options.UseFont = true;
            this.btnOperationSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnOperationSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.TopLeft;
            this.btnOperationSave.Location = new System.Drawing.Point(36, 61);
            this.btnOperationSave.Name = "btnOperationSave";
            this.btnOperationSave.Size = new System.Drawing.Size(85, 89);
            this.btnOperationSave.TabIndex = 11;
            this.btnOperationSave.Text = "Save";
            this.btnOperationSave.Click += new System.EventHandler(this.btnOperationSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(144, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Color:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(144, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Is Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(144, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Manual:";
            // 
            // addOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(616, 469);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "addOperation";
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationLookUpEdit.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.isFinal.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOperationColorPick.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit checkEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit operationLookUpEdit;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnCloseAddOperation;
        private DevExpress.XtraEditors.CheckEdit isFinal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btnOperationSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblSelectedColor;
        private DevExpress.XtraEditors.ColorEdit btnOperationColorPick;
    }
}