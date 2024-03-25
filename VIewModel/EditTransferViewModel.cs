using ListOfCustomers_New.Commands;
using ListOfCustomers_New.Interfaces;
using ListOfCustomers_New.Models;
using ListOfCustomers_New.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ListOfCustomers_New.VIewModel
{
    class EditTransferViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SaveTransferCommand { get; set; }
        public string ID { get; set; }
        public string Date { get; set; }
        public string CustomerID { get; set; }
        public string AccountID { get; set; }
        public string Number { get; set; }
        public string AccountGetID { get; set; }
        public string NumberGet { get; set; }
        public string TypeID { get; set; }  //refill or Transfer 
        public string TypeOperation { get; set; }  //refill or Transfer 
        public string Amount { get; set; }
        public ObservableCollection<IAccounts<Accounts_1>> ListAccounts { get; set; }
        public ObservableCollection<IAccounts<Accounts_1>> ListGetAccounts { get; set; }
        public ObservableCollection<TypeOfTransfers> ListOfTransfers { get; set; }
        public IAccounts<Accounts_1> SelectedAccount { get;set; }
        public IAccounts<Accounts_1> SelectedGetAccount { get; set; }
        public TypeOfTransfers SelectedType { get; set; }

        /// <summary>
        /// ///////////////////
        /// </summary>
        /// <param name="param"></param>
        /// <param name="form"></param>
        public EditTransferViewModel(object param, Form_EditTransfer form)
        {
            
            AccountID  = form.AccountID_;
            CustomerID = form.CustomerID_;
            TypeID = form.TypeOfTransfer_;
            TypeOperation = form.TypeOperation_;


            if (TypeID != "" & AccountID!="") 
            { 
            Amount = AccountTurnover.GetAccAmmount(AccountID).ToString();
            }

            SaveTransferCommand = new RelayCommand(SaveAccounts, CanSaveAccounts);

            TransferAccounts cst = param as TransferAccounts;

            if (cst != null)
            {
                ID = cst.ID;
                CustomerID = cst.CustomerID;
                AccountID  = cst.AccountID;
                AccountGetID = cst.AccountGetID;
                Number     = cst.Number;
                Date       = cst.Date;
                TypeID     = cst.Type;
                Amount     = cst.Amount;
                
               ListGetAccounts =  FileService<IAccounts<Accounts_1>>.ListOfValues;
               ListAccounts = FileService<IAccounts<Accounts_1>>.ListOfValues;
               ListOfTransfers = TypeOfTransfers.GetTypeOfTransfers();
               SelectedAccount = FileService<IAccounts<Accounts_1>>.Get_by_ID(cst.AccountID);
               SelectedGetAccount = FileService<IAccounts<Accounts_1>>.Get_by_ID(cst.AccountGetID);
               SelectedType = TypeOfTransfers.Get_By_ID(TypeID);

            }
            else
            {
                if (TypeOperation == "Close") 
                {

                ID = FileService<TransferAccounts>.Return_ID();
                IAccounts<Accounts_1> acc  = FileService<IAccounts<Accounts_1>>.Get_by_ID(AccountID);
                //Находим те счета которые отличаются от текущего
                var str = FileService<IAccounts<Accounts_1>>.ListOfValues.Where(x => x.ID != AccountID).FirstOrDefault();
                    
                ListGetAccounts = new ObservableCollection<IAccounts<Accounts_1>>();
                ListGetAccounts.Add(str);
                }
                else
                {
                    ListGetAccounts = FileService<IAccounts<Accounts_1>>.ListOfValues;
                }

                ListAccounts = FileService<IAccounts<Accounts_1>>.ListOfValues;
                ListOfTransfers = TypeOfTransfers.GetTypeOfTransfers();
                SelectedAccount = FileService<IAccounts<Accounts_1>>.Get_by_ID(AccountID);
                SelectedType = TypeOfTransfers.Get_By_ID(TypeID);

            }
        }

        private bool CanSaveAccounts(object obj)
        {
            return true;
        }

        /// <summary>
        /// Сохраняем значения формы в базу данных 
        /// </summary>
        /// <param name="obj"></param>
        private void SaveAccounts(object obj)
        {
            Window window = obj as Window;
            IAccounts<Accounts_1> StrAccount = FileService<IAccounts<Accounts_1>>.Get_by_ID(AccountID);
           if (TypeOperation == "Close")
           { 
            //Поменяем дату и сохраним  в базу 
            StrAccount.DateClose = DateTime.Today.ToString();
            FileService<IAccounts<Accounts_1>>.Save(StrAccount);
            }
            TransferAccounts str = new TransferAccounts(ID,Date,CustomerID,AccountID,SelectedAccount.Number , SelectedGetAccount.ID, SelectedGetAccount.Number, SelectedType.ID ,Amount );
            FileService<TransferAccounts>.Save(str);
            window.Close(); ;
        }
    }
}
