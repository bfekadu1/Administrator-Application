using Adminstrator_Application.Logic;
using Adminstrator_Application.Model;
using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Utils.Filtering.ExcelFilterOptions;
using Adminstrator_Application.Logic;

namespace Adminstrator_Application.UI
{
    public partial class AddPanel : Form
    {
        Logic.Logic logics= new Logic.Logic();
        Admin_App_DataAccess.DataAccess dataAcess= new Admin_App_DataAccess.DataAccess();
        List<OrderCategory> orderCategories = new List<OrderCategory>();
        List<OrderClass> orderClasses= new List<OrderClass>();
        int? selectedCategoryId;
        int updatedCategoryId;
        public List<OrderCategory> ordCategories { get; set; }
        public int updatedPanelPrice { get; set; }
        public int updatedPanelId {  get; set; }
        public string updatedPanelDescription { get; set; }
        public string updatedCategory {  get; set; }
        public bool isUpdateTrue { get; set; }  
        public void setOrdCatgories(List<OrderCategory> orderCategories)
        {
            ordCategories = orderCategories;
        }
        public void setUpdatePanelPrice(int PanelPrice)
        {
            updatedPanelPrice = PanelPrice;
        }
        public void setUpdatedPanelId(int id)
        {
            updatedPanelId = id;
        }
        public void setUpdatedPanelDescription(string panelDescription)
        {
            updatedPanelDescription = panelDescription;
        }
        public void setUpdatedCategory(string category)
        {
            updatedCategory = category;
        }
        public void setIsUpdate(bool isUpdate)
        {
            isUpdateTrue=isUpdate;
        }
        public AddPanel()
        {
            InitializeComponent();
            orderClasses.Clear();
            orderClasses = dataAcess.GetOrderClasses();
            orderCategories.Clear();
            orderCategories= dataAcess.GetOrderCategories();
            txtCategory.DataSource= orderCategories;
            txtCategory.DisplayMember = "description";
            txtCategory.ValueMember = "id";
            txtCategory.SelectedValue = -1;
            isUpdateTrue = false;
        }
        private void btnAddPanelExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void btnSavePanel_Click(object sender, EventArgs e)
        {
            if (!logics.ValidateField(txtPrice.Text))
            {
                txtPrice.BackColor = Color.LightPink;
                txtPrice.Focus();
            }
            else
            {
                if (isUpdateTrue == true)
                {
                    selectedCategoryId = txtCategory.SelectedValue as int?;
                    int price = int.Parse(txtPrice.Text);
                    dataAcess.UpdatePanel(updatedPanelId, txtPanelDescription.Text, price, selectedCategoryId);
                }
                else
                {
                    decimal price = decimal.Parse(txtPrice.Text);
                    selectedCategoryId = txtCategory.SelectedValue as int?;
                    dataAcess.SavePanel(txtPanelDescription.Text, price, selectedCategoryId);
                }
                txtCategory.SelectedValue = -1;
                txtPanelDescription.Text = "";
                txtPrice.Value= 0;
            }
           
            
        }
        private void AddPanel_Load(object sender, EventArgs e)
        {
           
            txtPrice.Text = updatedPanelPrice.ToString();
            txtPanelDescription.Text = updatedPanelDescription;
            updatedCategoryId= orderCategories.Where(orderClasses=>orderClasses.description== updatedCategory).
                Select(orderClasses=>orderClasses.id).FirstOrDefault();
            txtCategory.SelectedValue= updatedCategoryId;

        }
        private void txtPanelDescription_Leave(object sender, EventArgs e)
        {
            if (!logics.ValidateField(txtPanelDescription.Text))
            {
                txtPanelDescription.BackColor = Color.LightPink;
                txtPanelDescription.Focus();
            }
        }
        private void txtCategory_Leave(object sender, EventArgs e)
        {
            if (!logics.ValidateField(txtCategory.Text))
            {
                txtCategory.BackColor = Color.LightPink;
                txtCategory.Focus();
            }
        }
        private void txtPrice_Leave(object sender, EventArgs e)
        {
            if (!logics.ValidateField(txtPrice.Text))
            {
                txtPrice.BackColor = Color.LightPink;
                txtPrice.Focus();
            }
        }
        private void txtPanelDescription_EditValueChanged(object sender, EventArgs e)
        {
            txtPanelDescription.BackColor = SystemColors.Window;
        }
        private void txtCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            txtCategory.BackColor = SystemColors.Window;
        }
        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {
            if(txtPrice.Value!=0)
            {
                txtPrice.BackColor = SystemColors.Window;
            }
        }

    }
}
