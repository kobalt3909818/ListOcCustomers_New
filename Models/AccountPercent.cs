using ListOfCustomers_New.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListOfCustomers_New.Models
{
    class AccountPercent
    {

        public string ID { get; set; }
        public string Number { get; set; }
        public string IDAccount { get; set; }
        public string Ammount { get; set; }
        public string Date { get; set; }

        public static ObservableCollection<AccountPercent> ListOfAccountPercent = new ObservableCollection<AccountPercent>();

        public static ObservableCollection<AccountPercent> ListOfPercentsALL = new ObservableCollection<AccountPercent>();

        public AccountPercent(string id, string date, string number, string idAccount, string ammount)
        {
            this.ID = id;
            this.Date = date;
            this.Number = number;
            this.IDAccount = idAccount;
            this.Ammount = ammount;

        }

        /// <summary>
        /// Основной метод расчета процентов по счету 
        /// </summary>
        /// <returns></returns>
        public static  void CalculatePercents(DateTime calculationDate)
        {
            ObservableCollection<IAccounts<Accounts_1>> ListofAccount = FileService<IAccounts<Accounts_1>>.GetListOfValues();
            GetListOfPercentsByDate(calculationDate);

            foreach (var item in ListofAccount)
            {
                if (item.TypeOfAccount == "DepositAccount"& item.DateClose=="")
                {
                    //Проверим есть ли уже начисленные проценты     
                    AccountPercent strPercent = ListOfPercentsALL.Where(x => x.IDAccount.Equals(item.ID)).FirstOrDefault();
                    if (strPercent == null)
                    {
                        DateTime d1 = Convert.ToDateTime(item.DateOpen);
                        if (CheckDate(calculationDate, d1))
                        {
                            float ammount = Convert.ToInt32(AccountTurnover.GetAccAmmount(item.ID).ToString());
                            if (ammount > 0) { 
                            string id = FileService<AccountPercent>.Return_ID();
                            ListOfAccountPercent.Add(new AccountPercent(id, DateTime.Now.ToString(), item.Number, item.ID, ReturnAmmount(item.Rate, ammount)));
                            }
                        }
                    }
                }
            }
            SavePercents();
        }

        /// <summary>
        /// Метод сохраняет полученный список процентов
        /// </summary>
        public static void SavePercents()
        {
            foreach (var item in ListOfAccountPercent)
            {
                FileService<AccountPercent>.Save(new AccountPercent(item.ID, item.Date, item.Number, item.ID, item.Ammount));
            }
        }


        /// <summary>
        /// Метод осуществляет проверку двух дат Дату расчета и даты начисления процентов или открытия счета если дата счета + 30 дней равно текущей даты расчета тогда
        /// начисляем проценты
        /// </summary>
        /// <param name="calculationDate"></param>
        /// <param name="d1"></param>
        /// <returns></returns>
        private static bool CheckDate(DateTime calculationDate, DateTime d1)
        {
            DateTime d2 = Convert.ToDateTime(d1).AddDays(30);
            if (d2.ToString("dd/MM/yyyy") == calculationDate.ToString("dd/MM/yyyy"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Метод возвращает список начисленных процентов на дату 
        /// </summary>
        public static void GetListOfPercentsByDate(DateTime calculationDate)
        {
            ListOfPercentsALL = FileService<AccountPercent>.GetListOfValues();
            foreach (var item in ListOfPercentsALL)
            {
                DateTime d1 = Convert.ToDateTime(item.Date);
                if (CheckDate(calculationDate, d1))
                {
                    ListOfAccountPercent.Add(new AccountPercent(item.ID, item.Date, item.Number, item.IDAccount, item.Ammount));
                }
            }
        }

        /// <summary>
        /// Метод производит расчет процентов по депозиту 
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="ammount"></param>
        /// <returns></returns>
        private static string ReturnAmmount(string rate, float ammount)
        {
            string AmmountOfPercent = ((Convert.ToInt32(ammount) * Convert.ToInt32(rate) / 100) / 12).ToString();

            return AmmountOfPercent;
        }
    }
}
