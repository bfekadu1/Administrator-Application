using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminstrator_Application.Model
{
    public class Person
    {
        public string Id { get; set; }
        public string first_name { get; set; }
        public string middile_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public DateTime date_registered { get; set; }
        public int type_id { get; set; }
        public int phone { get; set; }
        public bool active { get; set; }
        public string remark { get; set; }
    }
}
