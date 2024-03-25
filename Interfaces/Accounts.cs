using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Interfaces
{
    public class Accounts
    {
        public string ID { get; set; }
        public string Number { get; set; }
        public string CustomerID { get; set; }
        public string Ammount { get; set; }
        public string Rate { get; set; }
        public string DateOpen { get; set; }
        public string DateClose { get; set; }
        public string TypeOfAccount { get; set; }

        public Accounts(string ID, string Number, string CustomerID, string Ammount, string Rate, string DateOpen, string DateClose, string TypeOfAccount)
        {
            this.ID = ID;
            this.Number = Number;
            this.CustomerID = CustomerID;
            this.Ammount = Ammount;
            this.Rate = Rate;
            this.DateOpen = DateOpen;
            this.DateClose = DateClose;
            this.TypeOfAccount = TypeOfAccount;

        }

        public interface IAccounts<T> 
        where T:Accounts
        { }

    }
}
