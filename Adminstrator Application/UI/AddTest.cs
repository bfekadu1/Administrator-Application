using Adminstrator_Application.Admin_App_DataAccess;
using Adminstrator_Application.Logic;
using Adminstrator_Application.Model;
using DevExpress.Utils.ScrollAnnotations;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.HashCodeHelper;


namespace Adminstrator_Application.UI
{
    public partial class AddTest : Form
    {
        public int x, y;
        public int? panel_id;
        int initialX,initialY;
        int count;
        SimpleButton btnAdd = new SimpleButton();
        SimpleButton btnRemove = new SimpleButton();
        LabelControl lbl = new LabelControl();
        TextBox txtUoM= new TextBox();
        TextBox txt = new TextBox();
        LabelControl lblUoM = new LabelControl();
        LabelControl lblMax = new LabelControl();
        LabelControl lblMin = new LabelControl();
        NumericUpDown numMax= new NumericUpDown();
        NumericUpDown numMin= new NumericUpDown();
        DataAccess dataAccess = new DataAccess();
        Logic.Logic logics = new Logic.Logic();
        List<OrderClass> orderClasses = new List<OrderClass>();
        List<CheckBox> checkBoxes = new List<CheckBox>();
        List<TestType> testTypes = new List<TestType>
        {
            new TestType{id=1,Type="checkbox"},
            new TestType{id=2,Type="numeric"},
            new TestType{id=3,Type="TextField"}
        };

        public AddTest()
        {
            InitializeComponent();
            this.Controls.Remove(groupBox1);
            orderClasses=dataAccess.GetOrderClasses();
            txtParentPanel.DataSource=orderClasses;
            txtParentPanel.DisplayMember = "description";
            txtParentPanel.ValueMember = "id";
            txtParentPanel.SelectedValue = -1;
            txtType.DataSource = testTypes;
            txtType.DisplayMember = "Type";
            txtType.ValueMember = "id";
            txtType.SelectedValue = -1;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxes.Clear();
            
            foreach (Control control in pnlTypeInfoContainer.Controls.OfType<Control>().ToList())
            {
                if(  control.Tag as string == "buttonAdd")
                {
                    ((SimpleButton)control).Click-= BtnAdd_Click;
                }
                else if(control.Tag as string == "buttonRemove")
                {
                    ((SimpleButton)control).Click -= BtnRemove_Click;
                }
                pnlTypeInfoContainer.Controls.Remove(control);
                
            }

            if (txtType.Text == "checkbox" )
            {
                //button for adding the checkbox
                this.Controls.Add(groupBox1);
                
                btnAdd.Text = "Add";
                btnAdd.Location = new Point(45,32);
                btnAdd.Size = new Size(75, 23);
                btnAdd.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Default;
                btnAdd.BackColor = Color.Silver;
                btnAdd.Font = new Font("Century Gothic", 12,FontStyle.Italic);
                btnAdd.Tag = "buttonAdd";
                btnAdd.Click += BtnAdd_Click;
                pnlTypeInfoContainer.Controls.Add(btnAdd);
                //button for removing the checkbox

                btnRemove.Text = "Remove";
                btnRemove.Location = new Point(45+btnAdd.Width + 10, 32);
                btnRemove.Size = new Size(75, 23);
                btnRemove.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Default;
                btnRemove.BackColor = Color.Silver;
                btnRemove.Font = new Font("Century Gothic", 13, FontStyle.Italic);
                btnRemove.Tag = "buttonRemove";
                btnRemove.Click += BtnRemove_Click;
                pnlTypeInfoContainer.Controls.Add(btnRemove);
                // label for the check box;
                
                lbl.Text = txtType.Text + " Description:";
                lbl.Location = new Point(45, 32 + btnAdd.Height + 20);
                lbl.Font = new Font("Century Gothic", 10, FontStyle.Italic);
                pnlTypeInfoContainer.Controls.Add(lbl);
                // text input for the check box description
                
                txt.Location = new Point(45+lbl.Width+5, 32 + btnAdd.Height + 20);
                txt.Size = new Size(130, 27);
                txt.Font = new Font("Century Gothic", 10, FontStyle.Italic);
                pnlTypeInfoContainer.Controls.Add(txt);
                x = 45;
                y = 32 + btnAdd.Height + 20;
            }
            else if (txtType.Text == "numeric")
            {
                this.Controls.Add(groupBox1);
                lblUoM.Text = "UoM: ";
                lblUoM.Location = new Point(42,35);
                lblUoM.Font = new Font("Century Gothic", 10, FontStyle.Italic);
                pnlTypeInfoContainer.Controls.Add(lblUoM);

                txtUoM.Location = new Point(45+lblUoM.Width + 20, 32);
                txtUoM.Font = new Font("Century Gothic", 10, FontStyle.Italic);
                txtUoM.Size = new Size(130, 27);
                pnlTypeInfoContainer.Controls.Add(txtUoM );

                lblMax.Text = "MAX: ";
                lblMax.Location = new Point(42,35+lblUoM.Height + 25);
                lblMax.Font = new Font("Century Gothic", 10, FontStyle.Italic);
                pnlTypeInfoContainer.Controls.Add(lblMax);

                numMax.Location = new Point(45 + lblMax.Width + 20, 32 + lblUoM.Height + 25);
                numMax.Font = new Font("Century Gothic", 10, FontStyle.Italic);
                numMax.Size = new Size(130, 27);
                pnlTypeInfoContainer.Controls.Add(numMax);

                lblMin.Text = "MIN:  ";
                lblMin.Location = new Point(42, 35 + lblUoM.Height + lblMax.Height + 50);
                lblMin.Font = new Font("Century Gothic", 10, FontStyle.Italic);
                pnlTypeInfoContainer.Controls.Add(lblMin);

                numMin.Location = new Point(45 + lblMin.Width + 20, 32 + lblUoM.Height + lblMax.Height + 50);
                numMin.Font = new Font("Century Gothic", 10, FontStyle.Italic);
                numMin.Size = new Size(130, 27);
                pnlTypeInfoContainer.Controls.Add(numMin);





            }
            else if (txtType.Text == "TextField")
            {
                this.Controls.Remove(groupBox1);
            }
        }
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            var lastChk = checkBoxes.Last();
            pnlTypeInfoContainer.Controls.Remove(lastChk);  
            checkBoxes.Remove(lastChk);
            //throw new NotImplementedException();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {

            count += 1;
            if(txt.Text!="") {
                CheckBox chk = new CheckBox();
                chk.Location = new Point(x, y + 50);
                //chk.Size = new Size(90, 20);
                chk.Text = txt.Text;
                chk.Font = new Font("Century Gothic", 10, FontStyle.Italic);
                pnlTypeInfoContainer.Controls.Add(chk);
                y += 30;
                initialY += 80;
                txt.Text = "";
                checkBoxes.Add(chk);
               }  
            else if (txt.Text == "")
            {
                 MessageBox.Show("please write the checkbox description");
            }
        }
        private void txtDescription_Leave(object sender, EventArgs e)
        {
            if (!logics.ValidateField(txtDescription.Text))
            {
                txtDescription.BackColor = Color.LightPink;
                txtDescription.Focus();
            }
        }
        private void txtParentPanel_Leave(object sender, EventArgs e)
        {
            if (!logics.ValidateField(txtDescription.Text))
            {
                txtParentPanel.BackColor = Color.LightPink;
                txtParentPanel.Focus();
            }
        }
        private void txtType_Leave(object sender, EventArgs e)
        {
            if (!logics.ValidateField(txtDescription.Text))
            {
                txtType.BackColor = Color.LightPink;
                txtType.Focus();
            }
        }
        private void txtDescription_EditValueChanged(object sender, EventArgs e)
        {
            txtDescription.BackColor = SystemColors.Window;
        }
        private void txtParentPanel_SelectedValueChanged(object sender, EventArgs e)
        {
            txtParentPanel.BackColor = SystemColors.Window;
        }
        private void txtType_SelectedValueChanged(object sender, EventArgs e)
        {
            txtType.BackColor = SystemColors.Window;
        }
        private void txtParentPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel_id = txtParentPanel.SelectedValue as int?;
        }
        private void btnTestSave_Click(object sender, EventArgs e)
        {
            if (!logics.ValidateField(txtDescription.Text))
            {
                txtDescription.BackColor = Color.LightPink;
                txtDescription.Focus();
            }
            if (!logics.ValidateField(txtDescription.Text))
            {
                txtParentPanel.BackColor = Color.LightPink;
                txtParentPanel.Focus();
            }
            if (!logics.ValidateField(txtDescription.Text))
            {
                txtType.BackColor = Color.LightPink;
                txtType.Focus();
            }
            if (txtType.Text == "checkbox")
            {
                dataAccess.SaveTest(txtDescription.Text,panel_id,txtType.Text);
                int testId=dataAccess.GetTestId(txtDescription.Text);
                dataAccess.SaveTestExtended(testId, checkBoxes);
                txtDescription.Text = "";
                txtType.SelectedValue = -1;
                txtParentPanel.SelectedValue = -1;
                foreach(CheckBox ch in checkBoxes)
                {
                    pnlTypeInfoContainer.Controls.Remove(ch);
                }
                checkBoxes.Clear();
                y = y - 80 * count;
                count = 0;
                this.Controls.Remove(groupBox1);
            }
            else if (txtType.Text=="numeric")
            {
                dataAccess.SaveTest(txtDescription.Text, panel_id,txtType.Text);
                int testId = dataAccess.GetTestId(txtDescription.Text);
                List<TestDetail> testDetail = new List<TestDetail>
                {
                    new TestDetail
                    {
                        UoM=txtUoM.Text,
                        max=decimal.Parse(numMax.Text),
                        min=decimal.Parse(numMin.Text),
                    }
                };
                dataAccess.SaveOrderExtended(testId, testDetail);
                testDetail.Clear();
                txtUoM.Text = "";
                int defaultNum = 0;
                numMax.Text = defaultNum.ToString();
                numMin.Text = defaultNum.ToString();
                txtDescription.Text = "";
                txtType.SelectedValue = -1;
                txtParentPanel.SelectedValue = -1;
                this.Controls.Remove(groupBox1);
            }
            else if(txtType.Text== "TextField")
            {
                dataAccess.SaveTest(txtDescription.Text, panel_id, txtType.Text);
                txtDescription.Text = "";
                txtType.SelectedValue = -1;
                txtParentPanel.SelectedValue = -1;

            }

        }
    }
}
