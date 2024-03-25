using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Interfaces
{
    public class Accounts_1:Accounts
    {
    
        public Accounts_1(string ID, string Number, string CustomerID, string Ammount, string Rate, string DateOpen, string DateClose, string TypeOfAccount) : base(ID, Number, CustomerID, Ammount, Rate, DateOpen, DateClose, TypeOfAccount)
        {
        }
       
    }
}
