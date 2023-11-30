using Adminstrator_Application.Model;
using DevExpress.Utils.DPI;
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
    public partial class AddCategory : Form
    {
        public string updatedDescription { get; set; }
        public string updatedCategory {  get; set; }
        public void setUpdatedDescription(string description)
        {
            updatedDescription= description;
        }
        public void setUpdatedCategory(string category)
        {
            updatedCategory= category;
        }

        public bool isupdate;
        public int updateId;
        public void setUpdateId(int id)
        {
            updateId = id;
        }
        public void setIsUpdate(bool isUpdate)
        {
            isupdate= isUpdate;
        }

        int? selectedValue;
        int updateTypeId;
        Admin_App_DataAccess.DataAccess dataAccess= new Admin_App_DataAccess.DataAccess();
        Logic.Logic logics= new Logic.Logic();
        List<CategoryView> categoryViews = new List<CategoryView>();
        List<Model.OrderType> orderTypes = new List<Model.OrderType>();
        List<Model.OrderCategory> orderCategories = new List<Model.OrderCategory>();
        public AddCategory()
        {
            InitializeComponent();
            orderCategories = dataAccess.GetOrderCategories();
            orderTypes = dataAccess.GetOrderTypes();
            txtType.DataSource = orderTypes;
            txtType.DisplayMember = "description";
            txtType.ValueMember = "id";
            txtType.SelectedValue = -1;
            isupdate = false;
        }
        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            if (!logics.ValidateField(txtType.Text))
            {
                txtType.BackColor = Color.LightPink;
                txtType.Focus();
            }
            else
            {
                if (isupdate==true)
                {
                    selectedValue = txtType.SelectedValue as int?;
                    dataAccess.UpdateCategory(updateId, selectedValue, txtDescription.Text);
                }
                else
                {

                    dataAccess.SaveCategory(txtDescription.Text, selectedValue);
                }
                
            }
            txtDescription.Text = "";
            txtType.SelectedValue = -1;
            
        }
        private void txtDescription_Leave(object sender, EventArgs e)
        {
            if (!logics.ValidateField(txtDescription.Text))
            {
                txtDescription.BackColor = Color.LightPink;
                txtDescription.Focus();
            }
        }
        private void txtDescription_EditValueChanged(object sender, EventArgs e)
        {
            txtDescription.BackColor = SystemColors.Window;
        }
        private void txtType_Leave(object sender, EventArgs e)
        {
            if(!logics.ValidateField(txtType.Text))
            {
                txtType.BackColor = Color.LightPink;
                txtType.Focus();
            }
        }
        private void txtType_SelectedValueChanged(object sender, EventArgs e)
        {
            txtType.BackColor = SystemColors.Window;
        }
        private void txtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedValue = txtType.SelectedValue as int?;
        }
        private void AddCategory_Load(object sender, EventArgs e)
        {
            txtDescription.Text = updatedDescription;
            updateTypeId = orderCategories.Where(orderType => orderType.description == updatedDescription).
                Select(orderType => orderType.type_id).FirstOrDefault();
            txtType.SelectedValue = updateTypeId; 
        }
        private void btnAddNewCategoryExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
