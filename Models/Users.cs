using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Models
{
    public class Users
    {
       public string Name { get; set; }

        public Users(string name)
        {
            Name = name;
        }
    }
}
