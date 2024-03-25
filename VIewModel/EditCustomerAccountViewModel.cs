using ListOfCustomers_New.Commands;
using ListOfCustomers_New.Interfaces;
using ListOfCustomers_New.Models;
using ListOfCustomers_New.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ListOfCustomers_New.VIewModel
{
    class EditCustomerAccountViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string ID { get; set; }
        public string Number { get; set; }
        public string CustomerID { get; set; }
        public bool Active { get; set; }
        public string Ammount { get; set; }
        public string Rate { get; set; }
        public string DateOpen { get; set; }
        public string DateClose { get; set; }
        public string TypeOfAccount { get; set; }
        public ICommand SaveAccountsCommand { get; set; }

        public EditCustomerAccountViewModel(object param, Form_EditAccountOfCustomers form)
        {
            IAccounts<Accounts_1> cst = param as IAccounts<Accounts_1>;
            SaveAccountsCommand = new RelayCommand(SaveAccounts, CanSaveAccounts);

            if (cst != null)
            {
                ID = cst.ID;
                CustomerID = cst.CustomerID;
                Number = cst.Number;
                Rate = cst.Rate;
                TypeOfAccount = cst.TypeOfAccount;
                Ammount = AccountTurnover.GetAccAmmount(cst.ID).ToString();
                DateOpen = cst.DateOpen;
                DateClose = cst.DateClose;

            }
            else
            
            {
                ID = FileService<IAccounts<Accounts_1>>.Return_ID();
                CustomerID = form.CustomerID_;
                TypeOfAccount = form.TypeOfAccount_;
                DateOpen = DateTime.Now.ToString();
                if (TypeOfAccount == "DepositAccount")
                {
                    Number = DepositAccount.GenerateNumberAccount();
                }
                else 
                {
                    Number = NotDepositAccount.GenerateNumberAccount();
                }
            }
        }

        private bool CanSaveAccounts(object obj)
        {
            return true;
        }

        private void SaveAccounts(object obj)
        {
            if (TypeOfAccount == "DepositAccount") { 
            Window window = obj as Window;
                IAccounts<Accounts_1> str = new DepositAccount(ID, Number,CustomerID,Ammount,Rate,DateOpen,DateClose,TypeOfAccount);
                FileService<IAccounts<Accounts_1>>.Save(str);
            window.Close();
            }
            else
            {
                Window window = obj as Window;
                IAccounts<Accounts_1> str = new NotDepositAccount(ID, Number, CustomerID, Ammount, Rate, DateOpen, DateClose, TypeOfAccount);
                FileService<IAccounts<Accounts_1>>.Save(str);
                window.Close();
            }
        }
    }

   
}
