using Adminstrator_Application.Model;
using DevExpress.XtraGrid.Extensions;
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
    public partial class AddUserToDepartement : Form
    {
        public int usrId;
        public int departementId;
        public string departementName;
        AdminApp app =new AdminApp();
        List<UserAccount> userAccounts = new List<UserAccount>();
        Admin_App_DataAccess.DataAccess dataAccess= new Admin_App_DataAccess.DataAccess();
        List<PersonType> personTypes = new List<PersonType>();
        List<UserDepartement> userDepartements = new List<UserDepartement>();
        string person_id;
        public string deparetment { get;set;}
        public int deptId {  get;set;} 
        public void setdepartment(string dep)
        {
            deparetment = dep;
        }
        public void setdeptId(int departmentId)
        {
            deptId= departmentId;
        }
        
        public AddUserToDepartement()
        {
            InitializeComponent();
            personTypes= dataAccess.GetPersonTypes();
            txtUsers.Enabled = false;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUserToDepartement_Load(object sender, EventArgs e)
        {
            userAccounts = dataAccess.GetUserAccount();
            txtUserToAdded.DataSource= userAccounts;
            txtUserToAdded.DisplayMember = "user_name";
            txtUserToAdded.ValueMember = "person_id";
        }

        private void txtUserToAdded_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserAccount selectedUser= (UserAccount)txtUserToAdded.SelectedItem;
            if (selectedUser != null)
            {
                usrId = selectedUser.Id;
                person_id = selectedUser.person_id;
                txtUsers.Enabled = true;
                txtUsers.Text = selectedUser.user_name;
            }
            
        }

        private void btnAddUserToRole_Click(object sender, EventArgs e)
        {
            int userId= userAccounts.Where(userAccount=> userAccount.person_id==person_id).
                        Select(UserAccount=> UserAccount.Id).FirstOrDefault();
           
            //MessageBox.Show(deparetment+deptId);
            dataAccess.SaveUsersToRole(userId,deptId);
            

        }

        
        //private void AddUserToDepartement_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    userDepartements = dataAccess.GetDepartmentUsers(deparetment);
        //    app.user_departments = userDepartements;
        //    app.populateGridView();
            
        //}
    }
}
