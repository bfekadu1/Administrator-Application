using Adminstrator_Application.Model;
using DevExpress.XtraEditors;
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
    public partial class stockMangement : UserControl
    {
        Admin_App_DataAccess.DataAccess dataAccess= new Admin_App_DataAccess.DataAccess();
        List<Model.MenuDefination> menuDefinations = new List<Model.MenuDefination>();
        List<Model.VoucherList> voucherLists = new List<Model.VoucherList>();
        Font fnt= new Font("Times New Roman",12,FontStyle.Regular);
        XtraTabControl tabControl1 = new XtraTabControl();
        
        public string pageTitle;

        public stockMangement()
        {
            InitializeComponent();
        }

        private void stockMangement_Load(object sender, EventArgs e)
        {
            menuDefinations.Clear();
            menuDefinations = dataAccess.GetMenuDefination();
            
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.SelectedPageChanged += TabControl1_SelectedPageChanged;
            this.Controls.Add(tabControl1);
            foreach (var menuDefination in menuDefinations)
            {
                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Dock = DockStyle.Fill;
                tabPage.Text = menuDefination.parent;
                tabPage.Name = menuDefination.parent;
                tabPage.Appearance.Header.Font = fnt;
                tabControl1.TabPages.Add(tabPage);
                
            }
        }

        private void TabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            XtraTabPage selectedPage = tabControl1.SelectedTabPage;
            if (selectedPage != null)
            {
                 pageTitle = selectedPage.Text;
                voucherLists.Clear();
                voucherLists = dataAccess.GetVoucherLists(pageTitle);
                vouchers vcs = new vouchers();
                vcs.Dock= DockStyle.Fill;   
                vcs.setVoucherList(voucherLists);
                selectedPage.Controls.Add(vcs);
            }

            
           
            
          


        }
    }
}
