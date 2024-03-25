using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Any
{
    public  class Constants
    {
        private static string  User { get; set; }
        public  Constants(string user)
        {
            User = user;
        }
        public static void SetConstants(string user) 
        {
           Constants cnst = new Constants(user);
        }
        public static string GetConstant()
        {
            return User;
        }
    }
}
