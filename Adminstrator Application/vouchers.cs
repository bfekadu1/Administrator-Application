using Adminstrator_Application.Admin_App_DataAccess;
using Adminstrator_Application.Model;
using Adminstrator_Application.UI;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adminstrator_Application
{
    public partial class vouchers : UserControl
    {
        public int typeId;
        object value1 = null;
        object value2 = null;
        public int operationId { get; set; }
        XtraTabPage selectedPage = new XtraTabPage();
        Font fnt = new Font("Times New Roman", 12, FontStyle.Regular);
        public Button button;
        public Button buttonToStoreList;
        public string id1, id2;
        public List<Model.VoucherList> voucherList;
        Admin_App_DataAccess.DataAccess dataAccess = new Admin_App_DataAccess.DataAccess();
        List<Model.Store> storeList = new List<Model.Store>();
        List<Model.StoreMapGrid> storeMapGridsTo = new List<Model.StoreMapGrid>();
        List<Model.operationView> operationViews = new List<operationView>();
        List<Model.ReferenceGridView> referenceViews = new List<ReferenceGridView>();
        Model.configuration configuration = new Model.configuration();

        public void setVoucherList(List<Model.VoucherList> voucherList)
        {
            this.voucherList = voucherList;
        }
        public vouchers()
        {
            InitializeComponent();

            ptyGridConfig.SelectedObject = configuration;
            gridOperation.DataSource = null;
            gridReference.DataSource = null;
        }

        private void vouchers_Load(object sender, EventArgs e)
        {
            foreach (var vochuers in voucherList)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Text = vochuers.name;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Height = 30;
                btn.Tag = "button";
                btn.Font = fnt;
                btn.Click += Btn_Click1;
                listVochuers.Controls.Add(btn);

            }
            storeList.Clear();
            storeList = dataAccess.GetStores();
            foreach (var store in storeList)
            {
                Button btn = new Button();
                btn.Text = store.description;
                btn.Dock = DockStyle.Top;
                btn.FlatStyle = FlatStyle.Flat;
                btn.Font = fnt;
                btn.Height = 30;
                btn.Tag = "button";
                btn.Click += Btn_Click;
                listStores.Controls.Add(btn);
            }
            selectedPage = xtraTabControl2.SelectedTabPage;
        }

        private void Btn_Click1(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            id1 = btn.Text;

            typeId = voucherList.Where(voucherList => voucherList.name == btn.Text).
                Select(voucherList => voucherList.id).FirstOrDefault();
            populateGridOperation(typeId);
            populateGridReference(typeId);
            if (dataAccess.isConfigurationExsits(typeId))
            {
                Dictionary<string, bool> dataFromDatabase = dataAccess.GetConfiguration(typeId);
                foreach (var property in configuration.GetType().GetProperties())
                {
                    string propertyName = property.Name;
                    if (dataFromDatabase.TryGetValue(propertyName, out bool propertyValue))
                    {
                        // Convert the propertyValue to the appropriate type
                        object convertedValue = Convert.ChangeType(propertyValue, property.PropertyType);

                        // Set the property value
                        property.SetValue(configuration, convertedValue);
                    }
                }
                ptyGridConfig.SelectedObject = null;
                ptyGridConfig.SelectedObject = configuration;
            }
            else
            {
                Model.configuration conf = new Model.configuration();
                ptyGridConfig.SelectedObject = null;
                ptyGridConfig.SelectedObject = conf;
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            id2 = btn.Text;
            button = btn;

        }
        private void xtraTabControl2_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            selectedPage = xtraTabControl2.SelectedTabPage;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

        }
        private void btnBackward_Click(object sender, EventArgs e)
        {

        }
        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {

        }
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {

        }

        private void btnNewOperation_Click(object sender, EventArgs e)
        {
            addOperation addOperations = new addOperation();
            addOperations.setTypeId(typeId);
            addOperations.ShowDialog();
            populateGridOperation(typeId);
        }
        private void btnOperationSave_Click(object sender, EventArgs e)
        {
            operationId = DataContanier.Instance.SharedData;
            bool value = DataContanier.Instance.SharedData1;
            MessageBox.Show(operationId.ToString() + value.ToString());
        }
        private void btnForwared_Click(object sender, EventArgs e)
        {
            listStores.Controls.Remove(button);

            storeMapGridsTo.Add(new Model.StoreMapGrid
            {
                Default = true,
                Description = button.Text,
            });
            gridTo.DataSource = storeMapGridsTo;
            gridTo.RefreshDataSource();

        }
        private void btnRemoveOperation_Click(object sender, EventArgs e)
        {
            if (value2 == null || value1 == null)
            {
                MessageBox.Show("you havn't selected an operation");
                return;
            }
            int voucherId = dataAccess.GetVoucherId(value2.ToString());
            //int operationId = dataAccess.GetOperationId(value1.ToString());
            dataAccess.RemoveVoucherOperation(voucherId, operationId);
            populateGridOperation(voucherId);
        }
        private void gridView3_RowClick(object sender, RowClickEventArgs e)
        {
            int rowHandle = e.RowHandle;
            foreach (GridColumn column in gridView3.Columns)
            {
                string fieldName = column.FieldName;
                if (fieldName == "description")
                {
                    value1 = gridView3.GetRowCellValue(rowHandle, column);
                }
                else if (fieldName == "name")
                {
                    value2 = gridView3.GetRowCellValue(rowHandle, column);
                }
            }
        }
        private void btnAddNewReference_Click(object sender, EventArgs e)
        {
            AddReference addReference = new AddReference();
            addReference.setReferingId(typeId);
            addReference.ShowDialog();
            populateGridReference(typeId);
        }

        private void btnSaveProperty_Click(object sender, EventArgs e)
        {
            dataAccess.deleteConfiguration(typeId);
            Model.configuration conf = (Model.configuration)ptyGridConfig.SelectedObject;
            dataAccess.SaveConfiguration(typeId, conf);
        }
        private void populateGridOperation(int voucherId)
        {
            typeId = voucherId;
            operationViews.Clear();
            operationViews = dataAccess.GetOperationview(typeId);
            gridOperation.DataSource = operationViews;
            gridOperation.RefreshDataSource();
        }
        private void gridView4_RowClick(object sender, RowClickEventArgs e)// reference grid rowclick event raised
        {
            //int rowHandle = e.RowHandle;
            //foreach (GridColumn column in gridView4.Columns)
            //{
            //    string fieldName = column.FieldName;
            //    if (fieldName == "description")
            //    {
            //        value1 = gridView3.GetRowCellValue(rowHandle, column);
            //    }
            //    else if (fieldName == "name")
            //    {
            //        value2 = gridView3.GetRowCellValue(rowHandle, column);
            //    }
            //}
            //MessageBox.Show(string.Join(",", value1, value2));
        }

        private void btnRemoveReference_Click(object sender, EventArgs e)//used to remove the refernece from the refering voucher
        {

        }
        private void populateGridReference(int voucherId)
        {
            typeId = voucherId;
            referenceViews.Clear();
            referenceViews = dataAccess.GetReferenceViews(typeId);
            gridReference.DataSource = referenceViews;

            gridReference.RefreshDataSource();
        }
        public void showPropertyGrid(object selectedObject)
        {
            ptyGridConfig.SelectedObject = selectedObject;
        }
    }
}
