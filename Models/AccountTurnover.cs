using ListOfCustomers_New.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Interfaces
{
    class AccountTurnover
    {
        public string AccountID { get; set; }
        public string TypeOfTurnover { get; set; }
        public string Amount { get; set; }
        public AccountTurnover(string accountID, string typeOfTurnOver, string amount)
        {
            this.AccountID = accountID;
            this.TypeOfTurnover = typeOfTurnOver;
            this.Amount = amount;
        }

        /// <summary>
        /// Метод Зачисления сумм на счет клиента
        /// </summary>
        /// <param name="IDAccount"></param>
        /// <returns></returns>
        public static float GetAccAmmount(string IDAccount)
        {
            float TotalAmmount = 0;
            float Ammount = 0;
            ObservableCollection<AccountTurnover> listOfTurnovers = FileService<AccountTurnover>.ReadTurnOvers();
            foreach (var item in listOfTurnovers)
            {
                if (item.AccountID.Equals(IDAccount))
                {
                    try
                    {
                        Ammount = Convert.ToInt32(item.Amount);
                    }
                    catch (Exception)
                    {
                        Ammount = 0;
                    }
                    //////////////////////////////////////////////////////////////////
                    if (Ammount > 0)
                    {
                        if (item.TypeOfTurnover.Equals("1"))
                        {
                            TotalAmmount = TotalAmmount + Ammount;
                        }
                        else
                        {
                            TotalAmmount = TotalAmmount - Ammount;
                        }
                    }
                    //////////////////////////////////////////////////////////////////
                }
            }
            return TotalAmmount;
        }
    }
}
