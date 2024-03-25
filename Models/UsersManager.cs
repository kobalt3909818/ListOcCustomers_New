using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Models
{
    class UsersManager
    {
       public static List<Users> ListUsers;

        public UsersManager()
        {
            ListUsers = new List<Users>();
            ListUsers.Add(new Users("Consultant"));
            ListUsers.Add(new Users("Manager"));
        }

        public static List<Users> GetUsers() 
        {
            UsersManager usMngr = new UsersManager();
            return ListUsers;
                }
    }
}
