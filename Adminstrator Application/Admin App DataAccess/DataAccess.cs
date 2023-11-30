using Adminstrator_Application.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Adminstrator_Application.Admin_App_DataAccess
{
    public class DataAccess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["HahcConnection"].ConnectionString;
        List<Model.IdDefination> idDefinations = new List<Model.IdDefination>();
        List<Model.IdValue> lastIdValues = new List<Model.IdValue>();
        List<Model.Person> persons = new List<Model.Person>();
        List<Model.PersonType> personTypes = new List<Model.PersonType>();
        List<Model.UserAccount> userAccount = new List<Model.UserAccount>();
        List<Model.UserAccount> userForDepartment = new List<Model.UserAccount>();
        List<Model.UserDepartement> userDepartements = new List<Model.UserDepartement>();
        List<Model.Functionality> functionalities = new List<Model.Functionality>();
        List<Model.OrderType> orderTypes = new List<Model.OrderType>();
        List<Model.CategoryView> categoryViews = new List<Model.CategoryView>();
        List<Model.OrderCategory> orderCategories = new List<Model.OrderCategory>();
        List<Model.panelView> panelViews = new List<panelView>();
        List<OrderClass> orderClasses = new List<OrderClass>();
        List<Model.MenuDefination> menuDefinations = new List<Model.MenuDefination>();
        List<Model.VoucherList> voucherLists = new List<Model.VoucherList>();
        List<Model.Store> stores = new List<Model.Store>();
        List<Model.Operation> operations = new List<Model.Operation>();
        List<Model.operationView> operationViews = new List<operationView>();
        List<Model.ReferencedVoucher> referencedVouchers = new List<Model.ReferencedVoucher>();
        List<Model.operationDescription> operationDescriptions = new List<operationDescription>();
        List<Model.ReferenceView> referenceViews = new List<Model.ReferenceView>();
        List<Model.ReferenceGridView> referenceGridViews = new List<Model.ReferenceGridView>();
        // List<bool> values = new List<bool>();
        List<Model.values> Values = new List<values>();
       
        #region
        public List<Model.IdDefination> GetIdDefinations()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from general.id_defination";
            var reader = cmd.ExecuteReader();
            idDefinations = LoadDataFromReader(idDefinations, reader);
            return idDefinations;
        }
        public List<Model.IdValue> GetLastIdValue(int type)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select top 1 * from general.id_value where defination=@type order by id desc";
            cmd.Parameters.AddWithValue("@type", type);
            var reader = cmd.ExecuteReader();
            lastIdValues = LoadDataFromReader(lastIdValues, reader);
            return lastIdValues;
        }
        public List<Model.Person> GetPerson()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from general.person";
            var reader = cmd.ExecuteReader();
            persons = LoadDataFromReader(persons, reader);
            return persons;
        }
        public List<Model.PersonType> GetPersonTypes()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = " select * from general.defination where description='person type'";
            var reader = cmd.ExecuteReader();
            personTypes = LoadDataFromReader(personTypes, reader);
            return personTypes;
        }
        public static List<T> LoadDataFromReader<T>(List<T> list, SqlDataReader reader) where T : new()
        {
            var properties = typeof(T).GetProperties();

            while (reader.Read())
            {
                T item = new T();

                foreach (var property in properties)
                {
                    if (!reader.IsDBNull(reader.GetOrdinal(property.Name)))
                    {
                        property.SetValue(item, reader[property.Name]);
                    }
                }

                list.Add(item);
            }

            return list;
        }
        public void CreatePerson(string id, List<Person> person)
        {
            int rowAffected = 0;
            DateTime currentDate = DateTime.Now;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "insert into general.person(Id,first_name,middile_name,last_name,gender,age,date_registered,type_Id,phone,active)" +
                    " values (@Id,@first_name,@middile_name,@last_name,@gender,@age,@date_registered,@type_Id,@phone,@active)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {

                    cmd.Parameters.AddWithValue("@Id", person[0].Id);
                    cmd.Parameters.AddWithValue("@first_name", person[0].first_name);
                    cmd.Parameters.AddWithValue("@middile_name", person[0].middile_name);
                    cmd.Parameters.AddWithValue("@last_name", person[0].last_name);
                    cmd.Parameters.AddWithValue("@gender", person[0].gender);
                    cmd.Parameters.AddWithValue("@age", person[0].age);
                    cmd.Parameters.AddWithValue("@date_registered", currentDate);
                    cmd.Parameters.AddWithValue("@type_Id", person[0].type_id);
                    cmd.Parameters.AddWithValue("@phone", person[0].phone);
                    cmd.Parameters.AddWithValue("@active", person[0].active);
                    rowAffected = cmd.ExecuteNonQuery();
                }
            }

            if (rowAffected > 0)
            {
                MessageBox.Show("Person successfully Created ");
            }
        }
        public void SaveIdValue(string id, int type)
        {
            int rowAffected = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = " insert into general.id_value(defination,current_value) values(@defination,@current_value)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@defination", type);
                    cmd.Parameters.AddWithValue("@current_value", id);
                    rowAffected = cmd.ExecuteNonQuery();
                }
                if (rowAffected > 0)
                {
                    //MessageBox.Show("user successfully saved ");
                }
            }
        }
        public void Update(string id, List<Person> person)
        {
            int rowAffected = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "update general.person set first_name=@first_name,middile_name=@middile_name,last_name=@last_name,gender=@gender,age=@age,type_Id=@type_id,phone=@phone where ID=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@first_name", person[0].first_name);
                    cmd.Parameters.AddWithValue("@middile_name", person[0].middile_name);
                    cmd.Parameters.AddWithValue("@last_name", person[0].last_name);
                    cmd.Parameters.AddWithValue("@gender", person[0].gender);
                    cmd.Parameters.AddWithValue("@age", person[0].age);
                    cmd.Parameters.AddWithValue("type_id", person[0].type_id);
                    cmd.Parameters.AddWithValue("phone", person[0].phone);
                    rowAffected = cmd.ExecuteNonQuery();
                }
                if (rowAffected > 0)
                {
                    MessageBox.Show("user successfully updated ");
                }
            }
        }
        public void SaveAccount(string id, List<UserAccount> accounts)
        {
            int rowAffected = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "insert into general.user_account (person_id,user_name,password,active) values(@person_id,@user_name,@password,@active)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@person_id", accounts[0].person_id);
                    cmd.Parameters.AddWithValue("@user_name", accounts[0].user_name);
                    cmd.Parameters.AddWithValue("@password", accounts[0].password);
                    cmd.Parameters.AddWithValue("@active", accounts[0].active);
                    rowAffected = cmd.ExecuteNonQuery();
                }
                if (rowAffected > 0)
                {
                    MessageBox.Show("account Created Successfully");
                }
            }
        }
        public bool CheckUserAccountExit(string id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from general.user_account where person_id=@person_id";
                    cmd.Parameters.AddWithValue("@person_id", id);
                    object result = cmd.ExecuteScalar();
                    return (result != null && result != DBNull.Value);
                }
            }
        }
        public List<UserAccount> GetUserAccount(string id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.CommandText = "select * from general.user_account where person_id=@id";
                    var reader = cmd.ExecuteReader();
                    userAccount = LoadDataFromReader(userAccount, reader);
                }
            }
            return userAccount;
        }
        public List<UserAccount> GetUserAccount()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = " select * from general.user_account";
            var reader = cmd.ExecuteReader();
            userForDepartment = LoadDataFromReader(userForDepartment, reader);
            return userForDepartment;
        }
        public void SaveUsersToRole(int userId, int deptId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int rowAffeted = 0;
                connection.Open();
                string query = "insert into general.role(useri_d,dept_id) values (@user_id,@dept_id)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@dept_id", deptId);
                    rowAffeted = cmd.ExecuteNonQuery();
                }
                if (rowAffeted > 0)
                {

                    MessageBox.Show("user successfully added to departement");
                }
            }

        }
        public List<Model.UserDepartement> GetDepartmentUsers(string deptName)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Parameters.AddWithValue("@deptName", deptName);
                    cmd.CommandText = "select * from general.roleView where description=@deptName";
                    var reader = cmd.ExecuteReader();
                    userDepartements = LoadDataFromReader(userDepartements, reader);
                }
            }
            return userDepartements;
        }
        public List<Model.Functionality> GetFunctionalities()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from general.functionalty";
            var reader = cmd.ExecuteReader();
            functionalities = LoadDataFromReader(functionalities, reader);
            return functionalities;
        }
        public List<Model.OrderType> GetOrderTypes()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from [order].orders_type";
            var reader = cmd.ExecuteReader();
            orderTypes = LoadDataFromReader(orderTypes, reader);
            return orderTypes;
        }
        public void SaveCategory(string description, int? type_id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int rowAffected;
                con.Open();
                string query = "insert into [order].order_category(type_id, description) values (@type_id,@description)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@type_id", type_id);
                    cmd.Parameters.AddWithValue("@description", description);
                    rowAffected = cmd.ExecuteNonQuery();
                }
                if (rowAffected > 0)
                {
                    MessageBox.Show("category saved");
                }
            }
        }
        public List<Model.CategoryView> GetCategoryViews()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from [order].categoryView";
            var reader = cmd.ExecuteReader();
            categoryViews = LoadDataFromReader(categoryViews, reader);
            return categoryViews;
        }
        public void DeleteCategory(string catgory)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int rowAffected;
                conn.Open();
                string query = " delete from [order].order_category where description=@description";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@description", catgory);
                    rowAffected = cmd.ExecuteNonQuery();
                }
                if (rowAffected > 0)
                {
                    MessageBox.Show("category successfully deleted");
                }
            }

        }
        public List<Model.OrderCategory> GetOrderCategories()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from [order].order_category";
            var reader = cmd.ExecuteReader();
            orderCategories = LoadDataFromReader(orderCategories, reader);
            return orderCategories;
        }
        public void UpdateCategory(int id, int? type_id, string description)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int rowCount = 0;
                con.Open();
                string query = "update [order].order_category set description=@description, type_id=@type_id where id=@id ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@type_id", type_id);
                    rowCount = cmd.ExecuteNonQuery();
                }
                if (rowCount > 0)
                {
                    MessageBox.Show("category successfully updated");
                }
            }

        }
        public List<Model.panelView> GetPanelViews()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from [order].panelView";
            var reader = cmd.ExecuteReader();
            panelViews = LoadDataFromReader(panelViews, reader);
            return panelViews;
        }
        public void SavePanel(string panelDescription, Decimal price, int? categoryId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int rowAffected = 0;
                con.Open();
                string query = "insert into [order].order_class(category_id,description,Price) values(@category_id,@description,@Price)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@category_id", categoryId);
                    cmd.Parameters.AddWithValue("@description", panelDescription);
                    cmd.Parameters.AddWithValue("@Price", price);
                    rowAffected = cmd.ExecuteNonQuery();
                }
                if (rowAffected > 0)
                {
                    MessageBox.Show("panel saved successfully");
                }
            }
        }
        public void DeletePanel(string panelDescription)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int rowAffected = 0;
                con.Open();
                string query = "delete from [order].order_class where description=@description";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@description", panelDescription);
                    rowAffected = cmd.ExecuteNonQuery();
                }
                if (rowAffected > 0)
                {
                    MessageBox.Show("panel remove successfully");
                }
            }
        }
        public void UpdatePanel(int updatePanelId, string panelDescription, int price, int? category)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int rowAffected = 0;
                con.Open();
                string queryy = "update [order].order_class set category_id=@category_id, description=@description, Price=@Price where id=@id";
                using (SqlCommand cmd = new SqlCommand(queryy, con))
                {
                    cmd.Parameters.AddWithValue("@id", updatePanelId);
                    cmd.Parameters.AddWithValue("@category_id", category);
                    cmd.Parameters.AddWithValue("@description", panelDescription);
                    cmd.Parameters.AddWithValue("@Price", price);
                    rowAffected = cmd.ExecuteNonQuery();
                }
                if (rowAffected > 0)
                {
                    MessageBox.Show("panel updated successfully");
                }
            }
        }
        public List<OrderClass> GetOrderClasses()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from [order].order_class";
            var reader = cmd.ExecuteReader();
            orderClasses = LoadDataFromReader(orderClasses, reader);
            return orderClasses;
        }
        public void SaveTest(string Description, int? panelId, string type)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int rowAffected = 0;
                con.Open();
                string query = "insert into [order].order_test(class_id,description,type) values(@class_id,@description,@type)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@class_id", panelId);
                    cmd.Parameters.AddWithValue("@description", Description);
                    cmd.Parameters.AddWithValue("@type", type);
                    rowAffected = cmd.ExecuteNonQuery();
                }
                if (rowAffected > 0)
                {
                    MessageBox.Show("Test Successfully registered");
                }
            }
        }
        public int GetTestId(string Description)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "select id from [order].order_test where description=@description";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@description", Description);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0);
                        }
                    }
                }
            }
            return 0;
        }
        public void SaveTestExtended(int testId, List<CheckBox> checkBoxes)
        {
            int rowAffected = 0;
            foreach (CheckBox checkBox in checkBoxes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "insert into [order].order_test_extended (order_test_id,value) values(@order_test_id,@value)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@order_test_id", testId);
                        cmd.Parameters.AddWithValue("@value", checkBox.Text);
                        rowAffected = cmd.ExecuteNonQuery();
                    }
                }
            }
            if (rowAffected > 0)
            {
                MessageBox.Show("successfull");
            }
        }
        public void SaveOrderExtended(int testId, List<TestDetail> testDetailList)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int rowAffected = 0;
                con.Open();
                string query = "insert into [order].order_test_detail(order_test_id,uom,max,min) values(@order_test_id,@uom,@max,@min)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@order_test_id", testId);
                    cmd.Parameters.AddWithValue("@uom", testDetailList[0].UoM);
                    cmd.Parameters.AddWithValue("@max", testDetailList[0].max);
                    cmd.Parameters.AddWithValue("@min", testDetailList[0].min);
                    rowAffected = cmd.ExecuteNonQuery();
                }
                if (rowAffected > 0)
                {
                    MessageBox.Show("test successfully regitered");
                }
            }
        }


        //stock invoice
        public List<Model.MenuDefination> GetMenuDefination()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = " select distinct parent from general.menu_defination where remark='voucher'";
                var reader = cmd.ExecuteReader();
                menuDefinations = LoadDataFromReader(menuDefinations, reader);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return menuDefinations;
        }
        public List<Model.VoucherList> GetVoucherLists(string parent)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.Parameters.AddWithValue("@parent", parent);
                cmd.CommandText = "select id,name from general.menu_defination where parent=@parent";
                var reader = cmd.ExecuteReader();
                voucherLists = LoadDataFromReader(voucherLists, reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return voucherLists;
        }

        public List<Model.Store> GetStores()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from general.store";
                var reader = cmd.ExecuteReader();
                stores = LoadDataFromReader(stores, reader);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return stores;
        }
        public List<Model.Operation> GetOperations(int type)
        {
          
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select id,value from general.VW_Invoice_OperationView where type=@type ";
                cmd.Parameters.AddWithValue("@type", type);
                var reader = cmd.ExecuteReader();
                operations = LoadDataFromReader(operations, reader);
            
           

            return operations;
        }
        internal void SaveOperation(int typeId, int operationId, bool checked1, string selectedColor, bool checked2)
        {
            try
            {
                int rowCount = 0;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "insert into general.operation(operation,type,color,is_final,manual) values(@operation,@type,@color,@is_final,@manual)";
                cmd.Parameters.AddWithValue("@operation", operationId);
                cmd.Parameters.AddWithValue("@type", typeId);
                cmd.Parameters.AddWithValue("@color", selectedColor);
                cmd.Parameters.AddWithValue("@is_final", checked2);
                cmd.Parameters.AddWithValue("@manual", checked1);
                rowCount = cmd.ExecuteNonQuery();
                if (rowCount > 0)
                {
                    MessageBox.Show("operation for the voucher selected successfully created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public List<Model.operationView> GetOperationview(int vouchuerId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from general.operationView where id=@voucherId";
                command.Parameters.AddWithValue("@voucherId", vouchuerId);
                var reader = command.ExecuteReader();
                operationViews = LoadDataFromReader(operationViews, reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return operationViews;
        }
       
        public void RemoveVoucherOperation(int voucherId, int operationId)
        {
            try
            {
                int rowAffected = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "delete from general.operation where type=@type and operation=@operation";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@type", voucherId);
                        command.Parameters.AddWithValue("@operation", operationId);
                        rowAffected = command.ExecuteNonQuery();
                        if (rowAffected > 0)
                        {
                            MessageBox.Show("operation deleted successfully");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        internal int GetVoucherId(string voucherName)
        {
            int voucherId = 0;
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select id from general.menu_defination where name=@value";
                cmd.Parameters.AddWithValue("@value", voucherName);
                voucherId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return voucherId;
            //throw new NotImplementedException();
        }
        internal int GetOperationId(string opeationName,int type)
        {
            int operationId = 0;
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select id from general.VW_Invoice_OperationView where value=@value and type=@type";
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@value", opeationName);
                operationId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return operationId;
            //throw new NotImplementedException();
        }
        internal List<Model.ReferencedVoucher> GetReferencedVouchers()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "  select  DISTINCT id,name from general.menu_defination where parent='Warehouse Management System'";
                var reader = cmd.ExecuteReader();
                referencedVouchers = LoadDataFromReader(referencedVouchers, reader);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return referencedVouchers;
        }
        internal List<Model.operationDescription> GetOperationDescriptions(int id)
        {
            try
            {
                SqlConnection connection= new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd= connection.CreateCommand();
                cmd.CommandText = "select description from general.operationView where id=@id";
                cmd.Parameters.AddWithValue("@id", id);
                var reader= cmd.ExecuteReader();
                operationDescriptions=LoadDataFromReader(operationDescriptions, reader);
                return operationDescriptions;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return operationDescriptions;
        }
        internal bool isReferenceExist(int id,int referingId )
        {
            object result = null;
            int rowCount = 0;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select TOP (1) operation from general.reference_defination where refering=@refering and referenced=@referenced";
            cmd.Parameters.AddWithValue("@refering", referingId);
            cmd.Parameters.AddWithValue("@referenced", id);
            result = cmd.ExecuteScalar();
            if(result!=DBNull.Value)
            {
                if (result == null)
                {
                    rowCount = 0;
                }
                else
                {
                    rowCount = 1;
                }

                if (rowCount > 0)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Entry does not exist in the table.");
                }
            }
            return false;
        }
        internal List<Model.operationDescription> GetOperationReference(int refernigId, int referencedId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "select value as description from general.referenceView where id=@referencedId and refering=@refernigId";
            command.Parameters.AddWithValue("@referencedId", referencedId);
            command.Parameters.AddWithValue("@refernigId", refernigId);
            var reader= command.ExecuteReader();
            operationDescriptions = LoadDataFromReader(operationDescriptions, reader);
            return operationDescriptions;
        }
        internal void RemoveReference(int typeId,int vouchId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "delete from general.reference_defination where refering=@refering and referenced=@referenced";
                command.Parameters.AddWithValue("@refering", typeId);
                command.Parameters.AddWithValue("@referenced", vouchId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        internal void SaveReference(int referingId, int voucherId, int operationId)
        {


            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into general.reference_defination(refering,referenced,operation) values(@refering,@referenced,@operation)";
            command.Parameters.AddWithValue("@refering", referingId);
            command.Parameters.AddWithValue("@referenced", voucherId);
            command.Parameters.AddWithValue("@operation", operationId);
            command.ExecuteNonQuery();


            // throw new NotImplementedException();
        }

        internal string getVoucherName(int Id)
        {
            string name = "";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select name from general.menu_defination where id=@id";
            cmd.Parameters.AddWithValue("@id", Id);
            name = (string)cmd.ExecuteScalar();
            return name;
            //throw new NotImplementedException();
        }

        internal void SaveConfiguration(int typeId, Model.configuration conf)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "insert into general.configuration(description,type,value) values(@description,@type,@value)";
                foreach (var property in conf.GetType().GetProperties())
                {
                    string variableName = property.Name;
                    object value = property.GetValue(conf);
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@description", variableName);
                    command.Parameters.AddWithValue("@type", typeId);
                    command.Parameters.AddWithValue("@value", value.ToString());
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("configuration saved successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            //throw new NotImplementedException();
        }
        internal List<Model.ReferenceGridView> GetReferenceViews(int typeId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from general.Reference where id=@id";
                cmd.Parameters.AddWithValue("@id", typeId);
                var reader = cmd.ExecuteReader();
                referenceGridViews = LoadDataFromReader(referenceGridViews, reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return referenceGridViews;
        }
        internal bool isConfigurationExsits(int typeId)
        {
            object result=null;
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select TOP (1) * from general.configuration where type=@typeId ";
                cmd.Parameters.AddWithValue("@typeId", typeId);
                result = cmd.ExecuteScalar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            return (result != null && result != DBNull.Value);

        }
        internal Dictionary<string, bool> GetConfiguration(int typeId)
        {
            Dictionary<string, bool> dataFromDatabase = new Dictionary<string, bool>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "select description,value from general.configuration where type=@type ";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@type", typeId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string propertyName = reader["description"].ToString();
                            bool propertyValue = Convert.ToBoolean(reader["value"]);
                            dataFromDatabase.Add(propertyName, propertyValue);
                        }

                    }
                }
            }
            return dataFromDatabase;
        }
        internal void deleteConfiguration(int typeId)
        {
            SqlConnection con =new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "delete from general.configuration where type=@type";
            cmd.Parameters.AddWithValue("@type", typeId);
            cmd.ExecuteNonQuery();
        }
        #endregion
    }
}
