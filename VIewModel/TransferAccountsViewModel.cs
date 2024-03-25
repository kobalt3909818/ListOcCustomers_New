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

     class TransferAccountsViewModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<TransferAccounts> ListOfTransfers { get; set; }
        public ICommand AddTransferCommand { get; set; }
        public ICommand ViewTransferCommand { get; set; }
        public Window Form { get; set; }
        public string ID { get; set; }
        public string CustomerID { get; set; }
        public string AccountID { get; set; }
  
        public TransferAccountsViewModel  (object param, object obj)
        {
            var cst = param as IAccounts<Accounts_1>;
            AccountID = cst.ID;
            CustomerID = cst.CustomerID;
            ListOfTransfers = FileService<TransferAccounts>.GetListOfValues(CustomerID, AccountID); 
            AddTransferCommand = new RelayCommand(AddTransfer, CanAddTransfer);
            ViewTransferCommand = new RelayCommand(ViewTransfer, CanViewTransfer);

        }

        private bool CanViewTransfer(object obj)
        {
            return true;
        }

        private void ViewTransfer(object obj)
        {
            Dictionary<string, string> str_param = new Dictionary<string, string>();
            str_param.Add("CustmerID", CustomerID);
            str_param.Add("AccountID", AccountID);
            str_param.Add("TypeOfTransfer", "");
            Form_EditTransfer form_edit = new Form_EditTransfer(obj, str_param);
            form_edit.Owner = Form;
            form_edit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form_edit.ID.IsEnabled = false;
            form_edit.Customer_ID.IsEnabled = false;
            form_edit.AccountID.IsEnabled = false;
            form_edit.TypeID.IsEnabled = false;
            form_edit.Amount.IsEnabled = false;
            form_edit.AccountGetID.IsEnabled = false;
            form_edit.Save.IsEnabled = false;


            form_edit.Show();
        }
        /// <summary>
        /// Метод определяет можно ли добавить Транзакцию
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanAddTransfer(object obj)
        {
            return true;
        }

        private void AddTransfer(object obj)
        {
            Dictionary<string, string> str_param = new Dictionary<string, string>();
            str_param.Add("CustmerID", CustomerID);
            str_param.Add("AccountID", AccountID);
            str_param.Add("TypeOfTransfer", "1");
            Form_EditTransfer form_edit = new Form_EditTransfer(obj, str_param);
            form_edit.Owner = Form;
            form_edit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form_edit.ID.IsEnabled = false;
            form_edit.Customer_ID.IsEnabled = false;
            form_edit.AccountID.IsEnabled = false;

            form_edit.Show();
        }
    }
}
