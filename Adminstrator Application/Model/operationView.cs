using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminstrator_Application.Model
{
    public class operationView
    {
        public string description { get; set; }
        public string name { get; set; }    
        public bool is_final {  get; set; }   
        public bool manual { get; set;}
        public string color { get; set; }
    }
}
