using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adminstrator_Application.UI
{
    public partial class AddReference : Form
    {
        public int voucherType;
        public int referingId;
        public void setReferingId(int referingId)
        {
            this.referingId= referingId;
        }
        Font Fnt = new Font("Times New Roman", 11, FontStyle.Regular);
        Admin_App_DataAccess.DataAccess dataAccess= new Admin_App_DataAccess.DataAccess();
        List<CheckEdit>checkEdits = new List<CheckEdit>();
        List<Model.ReferencedVoucher>referencedVouchers = new List<Model.ReferencedVoucher>();
        List<Model.Operation> operations = new List<Model.Operation>();
        List<Model.operationDescription>operationDescriptions = new List<Model.operationDescription>();
        public AddReference()
        {
            InitializeComponent();
            referencedVouchers.Clear();
            referencedVouchers=dataAccess.GetReferencedVouchers();
            lookUpEditReferred.Properties.DataSource = referencedVouchers;
            lookUpEditReferred.Properties.DisplayMember = "name";
            lookUpEditReferred.Properties.ValueMember = "id";
            lookUpEditReferred.Properties.Columns.Clear();
            lookUpEditReferred.Properties.Columns.Add(new LookUpColumnInfo("name"));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void lookUpEditReferred_EditValueChanged(object sender, EventArgs e)
        {
            
            panelOperation.Controls.Clear();
            object vouchId = lookUpEditReferred.EditValue;
            if (vouchId == null)
            {
                return;
            }
            else
            {
                voucherType = (int)vouchId;
                operations.Clear();
                operations = dataAccess.GetOperations(voucherType);
                int x = 0, y = 0;
                foreach (var operation in operations)
                {
                    CheckEdit checkEdit = new CheckEdit();
                    checkEdit.Font = Fnt;
                    checkEdit.Text = operation.value;
                    checkEdit.Tag = "checkedit";
                    checkEdit.Location = new Point(x, y);
                    checkEdit.CheckedChanged += CheckEdit_CheckedChanged;
                    y = y + checkEdit.Height + 5;
                    
                    if (dataAccess.isReferenceExist(voucherType, referingId))
                    {
                        operationDescriptions.Clear();
                        operationDescriptions = dataAccess.GetOperationReference(referingId, voucherType);
                        if (operationDescriptions.Count > 0)
                        {
                            foreach (var operationDescription in operationDescriptions)
                            {
                                if (checkEdit.Text == operationDescription.description)
                                {
                                    checkEdit.Checked = true;
                                    panelOperation.Controls.Add(checkEdit);
                                }
                                else
                                {
                                    panelOperation.Controls.Add(checkEdit);
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            panelOperation.Controls.Add(checkEdit);
                        }
                    }
                    else 
                    {
                        operationDescriptions.Clear();
                        operationDescriptions = dataAccess.GetOperationDescriptions(voucherType);
                        if (operationDescriptions.Count > 0)
                        {
                            foreach (var operationDescription in operationDescriptions)
                            {
                                if (checkEdit.Text == operationDescription.description)
                                {
                                    checkEdit.Checked = true;
                                    panelOperation.Controls.Add(checkEdit);
                                }
                                else
                                {
                                    panelOperation.Controls.Add(checkEdit);
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            panelOperation.Controls.Add(checkEdit);
                        }
                    }
                                 
                }
            }
            
        }

        private void CheckEdit_CheckedChanged(object sender, EventArgs e)
        {
        //    CheckEdit checkEdit = (CheckEdit)sender;
        //    checkEdits.Clear();
        //    checkEdits.Add(checkEdit);

            //throw new NotImplementedException();
        }
        

        private void btnAddReference_Click(object sender, EventArgs e)
        {
            checkEdits.Clear();
            foreach (Control control in panelOperation.Controls)
            {
                if (control is CheckEdit checkEdit)
                {
                   checkEdits.Add(checkEdit);
                }
            }

            //referingID
            //vouchIdreferedId
            
            dataAccess.RemoveReference(referingId, voucherType);
            foreach (var checkEdits in checkEdits)
            {
                
                if (checkEdits.Checked == true)
                {
                   
                    int definationId = dataAccess.GetOperationId(checkEdits.Text,voucherType);
                    //int operationId = dataAccess.GetVoucherOperationId(definationId);
                    dataAccess.SaveReference(referingId, voucherType, definationId);
                }
                else
                {
                    continue;
                }
                
            }
            reset();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void reset()
        {
            lookUpEditReferred.EditValue = null;
            panelOperation.Controls.Clear();
        }
    }
}
