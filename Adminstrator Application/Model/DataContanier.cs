using DevExpress.XtraReports.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminstrator_Application.Model
{
    public class DataContanier
    {
        private static DataContanier instance;

        public int SharedData { get; set; }
        public bool SharedData1 { get; set; }
        public string sharedData2 { get; set; }
        public bool sharedData3 { get; set; }
        private DataContanier() { }

        public static DataContanier Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataContanier();
                }
                return instance;
            }
        }
    }
}
