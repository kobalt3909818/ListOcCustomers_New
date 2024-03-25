using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Interfaces
{
    interface IAccounts<out T>
        where T:Accounts
    {
         string ID { get; set; }
         string Number { get; set; }
         string CustomerID { get; set; }
         string Ammount { get; set; }
         string Rate { get; set; }
         string DateOpen { get; set; }
         string DateClose { get; set; }
         string TypeOfAccount { get; set; }

    }
}
