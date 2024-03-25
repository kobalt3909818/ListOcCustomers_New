using ListOfCustomers_New.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ListOfCustomers_New.Models
{
    public class DepositAccount :IAccounts<Accounts_1>
    {
        public string ID { get; set; }
        public string Number { get; set; }
        public string CustomerID { get; set; }
        public string Ammount { get; set; }
        public string Rate { get; set; }
        public string DateOpen { get; set; }
        public string DateClose { get; set; }
        public string TypeOfAccount { get; set; }
        public DepositAccount(string id, string number, string customerID,  string ammount, string rate, string dateOpen, string dateClose, string typeOfAccount) 
       {
            this.ID = id;
            this.Number = number;
            this.CustomerID = customerID;
            this.Ammount = ammount;
            this.Rate = rate;
            this.DateOpen = dateOpen;
            this.DateClose = dateClose;
            this.TypeOfAccount = typeOfAccount;

        }

        public static string GenerateNumberAccount()
        {
            string number= "4607 8375 2751 ";
            Random rnd = new Random();
            int i;
            for ( i=0 ; i<=3 ; i++)
                {
                number += rnd.Next(1000).ToString();
                if (number.Length > 19) 
                {
                    number = number.Substring(0,19);
                    break;
                }
                  }

            return number;
        }

    }
}
