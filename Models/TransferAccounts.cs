using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Models
{
    class TransferAccounts
    {
        public string ID { get; set; }
        public string Date { get; set; }
        public string CustomerID { get; set; }
        public string AccountID { get; set; }
        public string Number { get; set; }
        public string AccountGetID { get; set; }
        public string NumberGet { get; set; }
        public string Type { get; set; }  //refill or Transfer 
        public string Amount { get; set; }

        public TransferAccounts(string id, string date, string customerID, string accountID, string number, string accountGetID, string numberGet, string type, string amount)

        {
            this.ID = id;
            this.Date = date;
            this.CustomerID = customerID;
            this.AccountID = accountID;
            this.Number = number;
            this.AccountGetID = accountGetID;
            this.NumberGet = numberGet;
            this.Type = type;
            this.Amount = amount;

        }
    }
}
