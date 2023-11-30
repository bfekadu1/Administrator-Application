using DevExpress.XtraGrid.Views.BandedGrid.Handler;
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
    public partial class StoreMap : UserControl
    {
        List<Model.Store> storeList= new List<Model.Store>();
        Admin_App_DataAccess.DataAccess dataAccess = new Admin_App_DataAccess.DataAccess();
        public StoreMap()
        {
            InitializeComponent();
           
        }

        private void StoreMap_Load(object sender, EventArgs e)
        {
            storeList.Clear();
            storeList = dataAccess.GetStores();
            foreach(var store in storeList)
            {
                Button btn= new Button();
                btn.Text = store.description;
                btn.Dock = DockStyle.Top;
                btn.FlatStyle= FlatStyle.Flat;
                btn.Height = 25;
                ListStore.Controls.Add(btn);
            }
        }
    }
}
