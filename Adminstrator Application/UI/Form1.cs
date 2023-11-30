using Adminstrator_Application.Admin_App_DataAccess;
using Adminstrator_Application.Model;
using Adminstrator_Application.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Tab;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Adminstrator_Application
{
    public partial class AdminApp : Form
    {
        string id;
        public bool isButttonClicked = false;
        public string clickedDescription;
        public int deptId;
        Button lastClickedButton = null;
        bool ischecked = false;
        bool accountExits = false;
        bool isTabPrivilge;
        bool isTabUserMemberShip=true;
        Logic.Logic logics = new Logic.Logic();
        List<Person> persons = new List<Person>();
        DataAccess dataAccess= new DataAccess();
        
        List<PersonType> personsType = new List<PersonType>();
        List<UserAccount> userAccounts = new List<UserAccount>();
        List<UserAccount> userAccount= new List<UserAccount>();
        List<PersonType> personTypes = new List<PersonType>();
        List<UserDepartement>userDepartements= new List<UserDepartement>();
        List<CategoryView> categoryViews = new List<CategoryView>();
        List<OrderCategory> orderCategories = new List<OrderCategory>();
        List<panelView> panelViews = new List<panelView>();
        List<OrderClass> orderClasses = new List<OrderClass>();
        public List<UserDepartement> user_departments { get; set;}
        public void setUser_departements(List<UserDepartement> userDepartments)
        {
            user_departments= userDepartments;
        }
        public int usrId { get;set; }
        public int departmentId { get; set; }
        public void setDepartemntId( int departId)
        {
            departmentId= departId;
        }
        public AdminApp()
        {
            InitializeComponent();
            orderCategories= dataAccess.GetOrderCategories();
            panelViews= dataAccess.GetPanelViews();
            grdPanel.DataSource = panelViews;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void AdminApp_Load(object sender, EventArgs e)
        {
            //xtraTabControl1.TabPages.Add(tabSetting);
            // TODO: This line of code loads data into the 'hAHCDataSet1.TestView' table. You can move, or remove it, as needed.
            this.testViewTableAdapter1.Fill(this.hAHCDataSet1.TestView);
            // TODO: This line of code loads data into the 'hAHCDataSet.TestView' table. You can move, or remove it, as needed.
            
            txtId.Text = logics.GenerateId(1);
            id= txtId.Text;
            personsType=dataAccess.GetPersonTypes();
            txtProfession.DataSource = personsType;
            txtProfession.DisplayMember = "description";
            txtProfession.ValueMember = "Id";
            populateSrcSearchLookUpEdit();
            LoadUserPage();
            categoryViews = dataAccess.GetCategoryViews();
            grdCategoryView.DataSource= categoryViews;
            orderClasses= dataAccess.GetOrderClasses();
        }
        public void populateSrcSearchLookUpEdit()
        {
            persons.Clear();
            persons = dataAccess.GetPerson();
            srcPersonSearch.Properties.DataSource = persons;
            srcPersonSearch.Properties.NullText = "Search Person";
            srcPersonSearch.Properties.DisplayMember = "first_name";
            srcPersonSearch.Properties.ValueMember = "first_name";

            srcAddUserAccount.Properties.DataSource = persons;
            srcAddUserAccount.Properties.NullText = "Search Person ";
            srcAddUserAccount.Properties.DisplayMember = "first_name";
            srcAddUserAccount.Properties.ValueMember = "first_name";
        }

        #region person tab
        // create person tab
        private void srcPersonSearch_EditValueChanged(object sender, EventArgs e)
        {
            ischecked = true;
            Person selectedPerson = (Person)srcPersonSearch.GetSelectedDataRow();
            if (selectedPerson != null)
            {
                txtId.Text=selectedPerson.Id;
                txtFirstName.Text = selectedPerson.first_name;
                txtMiddileName.Text = selectedPerson.middile_name;
                txtLastName.Text = selectedPerson.last_name;
                txtAge.Text = selectedPerson.age.ToString();
                txtPhone.Text= selectedPerson.phone.ToString();
                txtGender.Text= selectedPerson.gender.ToString();

                int selectedTypeId = selectedPerson.type_id;
                txtProfession.SelectedValue = selectedTypeId;
            }

        }
        private void btnCreatePerson_Click(object sender, EventArgs e)
        {


            List<Person> savedPerson = new List<Person>
            {
                new Person{

                           Id=txtId.Text,
                           first_name=txtFirstName.Text,
                           middile_name=txtMiddileName.Text,
                           last_name=txtLastName.Text,
                           age=int.Parse(txtAge.Text),
                           gender= txtGender.Text,
                           phone=int.Parse(txtPhone.Text),
                           type_id=txtProfession.SelectedIndex,
                           active=true
                        }
            };

            if (ischecked==true)
            {
               dataAccess.Update(txtId.Text,savedPerson);
            }
            else
            {
                dataAccess.CreatePerson(txtId.Text,savedPerson);
                dataAccess.SaveIdValue(txtId.Text, 1);
                txtId.Text = logics.UpdateId(1, txtId.Text);
                id= txtId.Text;
                
                populateSrcSearchLookUpEdit();
            }
           
           
           //persons.Add(savedPerson[0]);
           savedPerson.Clear();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ischecked = false;
            txtId.Text = id;
            txtFirstName.Text = "";
            txtMiddileName.Text = "";
            txtLastName.Text = "";
            txtAge.Text = "";
            txtGender.Text = "";
            txtPhone.Text = "";
            txtProfession.SelectedIndex = 0;
        }

        #endregion person tab
        #region user account tab
        //user account tab 
        private void srcAddUserAccount_EditValueChanged(object sender, EventArgs e)
        {

            //Person selectedPerson = (Person)srcAddUserAccount.GetSelectedDataRow();
            var selectedPerson= srcAddUserAccount.EditValue as Person;
            txtUserId.Text = selectedPerson.Id;

           

            if (selectedPerson != null)
            {
                
                if (!dataAccess.CheckUserAccountExit(selectedPerson.Id))
                {
                    userAccount.Clear();
                   // userAccount = dataAccess.GetUserAccount(txtUserId.Text);
                    txtPassword.Enabled = true;
                    txtReTypePassword.Enabled = true;
                    btnCreateUserAccount.Enabled = true;    
                }
                else
                {
                    userAccount.Clear();
                    userAccount = dataAccess.GetUserAccount(txtUserId.Text);
                    txtUserName.Text= userAccount[0].user_name;
                    btnCreateUserAccount.Enabled = false;
                    txtPassword.Enabled = false;
                    txtReTypePassword.Enabled = false;
                    
                }
            }
            
        }
        private void btnCreateUserAccount_Click(object sender, EventArgs e)
        {
            List<UserAccount> users = new List<UserAccount>
            {
                new UserAccount
                {
                    person_id=txtUserId.Text,
                    user_name = txtUserName.Text,
                    password = txtPassword.Text,
                    active= true
                }
            };
            
           dataAccess.SaveAccount(txtUserId.Text,users);
            

            users.Clear();
        }
        private void btnNewUserAccount_Click(object sender, EventArgs e)
        {
            
            txtUserId.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtUserName.Enabled=true;
            txtPassword.Enabled=true;
            txtReTypePassword.Enabled = true;
        }
        public void LoadUserPage()
        {
            personsType.Clear();
            personTypes.Clear();
           
            personTypes =dataAccess.GetPersonTypes();
            foreach(var personType in personTypes)
            {
                Button button = new Button();
                button.Text = personType.description;
                button.Dock = DockStyle.Top;
                button.FlatStyle= FlatStyle.Flat;
                button.Height = 34;
                button.Font = new Font("Times new Roman", 14, FontStyle.Bold);
                button.MouseEnter += Button_MouseEnter;
                button.MouseLeave += Button_MouseLeave;
                button.Click += Button_Click;
                listDepartment.Controls.Add(button);

            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            isButttonClicked = true;
            Button button = (Button)sender;
            if (lastClickedButton != null)
            {
                lastClickedButton.BackColor = SystemColors.Control;
                lastClickedButton.ForeColor = Color.Black;
            }
            lastClickedButton = button;
            button.BackColor = Color.Green;
            button.ForeColor = Color.White;
            clickedDescription=button.Text;
            deptId= personTypes.Where(personType=> personType.description==clickedDescription).
                Select(personType=> personType.Id).FirstOrDefault();
            
                userDepartements.Clear();
                grdUsers.RefreshDataSource();

                userDepartements = dataAccess.GetDepartmentUsers(clickedDescription);
                grdUsers.DataSource = userDepartements;

            
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            if (!isButttonClicked)
            {
                Button button = (Button)sender;
                button.BackColor = Color.White;
                button.ForeColor = Color.Black;
            }

        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            if (!isButttonClicked)
            {
                Button button = (Button)sender;
                button.BackColor = Color.LightGreen;
                button.ForeColor = Color.White;
            }

        }
        private void btnAddNewUserToDepa_Click(object sender, EventArgs e)
        {
            if (isTabUserMemberShip == true)
            {
                AddUserToDepartement add= new AddUserToDepartement();
                add.setdepartment(clickedDescription);
                add.setdeptId(deptId);
                add.ShowDialog();
            }
            else if (isTabPrivilge == true)
            {
                MessageBox.Show("privilage tab is selected");
            }
            
        }
        public void populateGridView()
        {
            userDepartements.Clear();
            grdUsers.RefreshDataSource();
            grdUsers.DataSource = user_departments;

        }
        private void listDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            userDepartements.Clear();
            grdUsers.RefreshDataSource();

            userDepartements = dataAccess.GetDepartmentUsers(clickedDescription);
            grdUsers.DataSource = userDepartements;
        }
        private void xtraTabControl5_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if(e.Page==tabprivilge)
            {
                isTabUserMemberShip = false;
                isTabPrivilge = true;
                
            }
            if (e.Page == tabUserMember)
            {
                isTabPrivilge = false;
                isTabUserMemberShip=true;
            }
        }

        #endregion
        #region category tab
        private void btnAddNewCategory_Click(object sender, EventArgs e)
        {
            AddCategory addCategory = new AddCategory();
            addCategory.ShowDialog();
            refersheGrid();
        }
        private void btnCategoryRefershe_Click(object sender, EventArgs e)
        {
            categoryViews.Clear();
            grdCategoryView.RefreshDataSource();

            categoryViews = dataAccess.GetCategoryViews();
            grdCategoryView.DataSource= categoryViews;
        }
        public void refersheGrid()
        {
            categoryViews.Clear();
            grdCategoryView.RefreshDataSource();

            categoryViews = dataAccess.GetCategoryViews();
            grdCategoryView.DataSource = categoryViews;
        }
        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            
            GridView gridView = (GridView)grdCategoryView.MainView;
            int selectedRowHandle = gridView.FocusedRowHandle;
            object  selectedValue = gridView.GetFocusedRowCellValue("description");  
            string SelectedCategory= (string)selectedValue;
            DialogResult result = MessageBox.Show("Do you want to delete the selected row?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
               
                gridView.DeleteRow(selectedRowHandle);
            }
            dataAccess.DeleteCategory(SelectedCategory);
            refersheGrid();
            
        }
        private void grdCategoryView_DoubleClick(object sender, EventArgs e)
        {
            orderCategories.Clear();
            orderCategories=dataAccess.GetOrderCategories();

            AddCategory addCategory= new AddCategory();
            GridView gridView = (GridView)grdCategoryView.MainView;
            int selectedRowHandle = gridView.FocusedRowHandle;
            object selectedDescriptionValue = gridView.GetFocusedRowCellValue("description");
            string selectedDescription= (string)selectedDescriptionValue;
            object selectedCategoryValue = gridView.GetFocusedRowCellValue("Type_Description");
            string selectedCategory= (string)selectedCategoryValue;

            int id= orderCategories.Where(orderCategory=>orderCategory.description==selectedDescription).
                Select(orderCategory=>orderCategory.id).FirstOrDefault();
            addCategory.setUpdateId(id);
            addCategory.setUpdatedDescription(selectedDescription);
            addCategory.setUpdatedCategory(selectedCategory);
            addCategory.setIsUpdate(true);
            
            addCategory.ShowDialog();
            refersheGrid();
        }


        #endregion
        public void refershePanelView()
        {
            panelViews.Clear();
            grdPanel.RefreshDataSource();
            panelViews = dataAccess.GetPanelViews();
            grdPanel.DataSource = panelViews;
        }
        // here is where category and panel issue to be fixed 
        private void btnAddNewPanel_Click(object sender, EventArgs e)
        {
           // orderCategories.Clear();
            //orderCategories=dataAccess.GetOrderCategories();
            AddPanel addPanel = new AddPanel();
            //addPanel.setOrdCatgories(orderCategories);
            addPanel.ShowDialog();
            refershePanelView();
        }
        private void btnRemovePanel_Click(object sender, EventArgs e)
        {
            GridView gridView = (GridView)grdPanel.MainView;
            int selectedRowHandle = gridView.FocusedRowHandle;
            object selectedValue = gridView.GetFocusedRowCellValue("Panel");
            string SelectedPanel = (string)selectedValue;
            DialogResult result = MessageBox.Show("Do you want to delete the selected row?", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                gridView.DeleteRow(selectedRowHandle);
            }
            dataAccess.DeletePanel(SelectedPanel);
            refershePanelView();
        }
        private void btnRefershePanel_Click(object sender, EventArgs e)
        {
            refershePanelView();
        }        
        private void xtraTabControl6_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabCategory)
            {
                refersheGrid();
            }
            else if(e.Page==tabPanel)
            {
                refershePanelView();
            }
        }
        private void grdPanel_DoubleClick(object sender, EventArgs e)
        {
            orderClasses.Clear();
            orderClasses = dataAccess.GetOrderClasses();

            AddPanel addPanel = new AddPanel();

            GridView gridView = (GridView)grdPanel.MainView;
            int selectedRowHandle = gridView.FocusedRowHandle;
            object selectedPanelDescriptionValue = gridView.GetFocusedRowCellValue("Panel");
            string selectedPanelDescription = (string)selectedPanelDescriptionValue;
            object selectedCategoryValue = gridView.GetFocusedRowCellValue("Category");
            string selectedCategory = (string)selectedCategoryValue;
            object selectedPriceValue = gridView.GetFocusedRowCellValue("Price");
            int selectedPrice = Convert.ToInt32(selectedPriceValue);

            int id = orderClasses.Where(orderClass => orderClass.description == selectedPanelDescription).
                Select(OrderClass => OrderClass.id).FirstOrDefault();
            addPanel.setUpdatedPanelId(id);
            addPanel.setUpdatedPanelDescription(selectedPanelDescription);
            addPanel.setUpdatedCategory(selectedCategory);
            addPanel.setUpdatePanelPrice(selectedPrice);
            addPanel.setIsUpdate(true);

            addPanel.ShowDialog();
            refershePanelView();
        }
        private void btnAddTest_Click(object sender, EventArgs e)
        {
            AddTest addTest= new AddTest();
            addTest.ShowDialog();
            this.testViewTableAdapter1.Fill(this.hAHCDataSet1.TestView);
        }

        private void btnRemoveTest_Click(object sender, EventArgs e)
        {
            //dataAccess.RemoveTest();
        }

        private void xtraTabControl1_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {

        }

        private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            //XtraTabPage selectedTabPage = xtraTabControl2.SelectedTabPage;
            //if(selectedTabPage ==tab)
            //{
            //    stockMangement stk = new stockMangement();
            //    stk.Dock = DockStyle.Fill;
            //    tab.Controls.Add(stk);
            //    //MessageBox.Show("tab setting selected");
            //}
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            XtraTabPage selectedTabPage = xtraTabControl1.SelectedTabPage;
            if (selectedTabPage == tabGeneral)
            {
                stockMangement stk = new stockMangement();
                stk.Dock = DockStyle.Fill;
                tabGeneral.Controls.Add(stk);
            }
        }
    }
}
