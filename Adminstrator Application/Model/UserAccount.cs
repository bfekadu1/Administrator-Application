using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adminstrator_Application.Model
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string person_id { get; set; }
        public string user_name {  get; set; }
        public string password { get; set; }
        public bool active {  get; set; }
    }
}
