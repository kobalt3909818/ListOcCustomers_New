using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ListOfCustomers_New.Interfaces;
using System.ComponentModel;
using System.Windows.Input;
using ListOfCustomers_New.Models;
using ListOfCustomers_New.Commands;
using ListOfCustomers_New.Views;

namespace ListOfCustomers_New.VIewModel
{
    class CustomersAccountsViewModel : INotifyPropertyChanged
    {
        public Window Form { get; set; }
        public string CustomerID { get; set; }
        public ObservableCollection<IAccounts<Accounts_1>> ListOfCustomersAccounts{ get; set; }
   
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand EditCustomersAccountCommand { get; set; }
        public ICommand AddDepositAccountCommand { get; set; }
        public ICommand CloseAccountCommand { get; set; }
        public ICommand AddNotDepositAccountCommand { get; set; }
        public ICommand DeleteCustomerAccountCommand { get; set; }
        public ICommand TransferAccountCommand { get; set; }
        public CustomersAccountsViewModel(object param, object obj)
        {
            var cst = param as Customers;
            CustomerID = cst.ID;

            ListOfCustomersAccounts = FileService<IAccounts<Accounts_1>>.GetListOfValues(CustomerID);
            ///Commands/// 
            AddDepositAccountCommand = new RelayCommand(AddDepositAccount, CanAddDepositAccountCommand);
            EditCustomersAccountCommand = new RelayCommand(EditCustomerAccount, CanEditCustomerAccountCommand);
            AddNotDepositAccountCommand = new RelayCommand(AddNotDepositAccount, CanAddNotDepositAccountCommand);
            DeleteCustomerAccountCommand = new RelayCommand(DeleteCustomerAccount, CanDeleteCustomerAccountCommand);
            TransferAccountCommand = new RelayCommand(TransferAccount, CanTransferAccountCommand);
            CloseAccountCommand = new RelayCommand(CloseAccount, CanCloseAccount);
        }

        /// <summary>
        /// Метод определяет есть ли возможность закрыть счет 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanCloseAccount(object obj)
        {
           return true;
        }

        private void CloseAccount(object obj)
        {

            IAccounts<Accounts_1> str = obj as IAccounts<Accounts_1>;
            if (str.DateClose != "") 
            {
                Messages.NewMessage("This account had already closed !"); 
            } 
            else
            { 
            Dictionary<string, string> str_param = new Dictionary<string, string>();
            str_param.Add("CustmerID", CustomerID);
            str_param.Add("AccountID", str.ID);
            str_param.Add("TypeOfTransfer", "2");
            str_param.Add("TypeOperation", "Close");

                float amount = AccountTurnover.GetAccAmmount(str.ID);

            if (amount > 0) { 
            Form_EditTransfer form_edit = new Form_EditTransfer(obj, str_param);
            form_edit.Owner = Form;
            form_edit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form_edit.ID.IsEnabled = false;
            form_edit.Customer_ID.IsEnabled = false;
            form_edit.AccountID.IsEnabled = false;
            form_edit.TypeID.IsEnabled = false;
            form_edit.Amount.IsEnabled = false;
            form_edit.Show();
            }
            else 
            {

                str.DateClose = DateTime.Today.ToString();
                if (str.TypeOfAccount == "1")
                {
                    Window window = obj as Window;
                    FileService<IAccounts<Accounts_1>>.Save(str);
                }
                else
                {
                    Window window = obj as Window;
                    FileService<IAccounts<Accounts_1>>.Save(str);
                }
            }

            }
        }

        /// <summary>
        /// Метод возможности редактирвоания Транзакций клиента
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanTransferAccountCommand(object obj)
        {
            return true;
        }

        /// <summary>
        /// Метод кнопки редактирования транзакций по счету клиента
        /// </summary>
        /// <param name="obj"></param>
        private void TransferAccount(object obj)
        {
            Dictionary<string, string> str_param = new Dictionary<string, string>();
            str_param.Add("CustmerID", CustomerID);
            Form_Transfer form_edit = new Form_Transfer(obj);
            form_edit.Owner = Form;
            form_edit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
 
            form_edit.Show();
        }

        /// <summary>
        /// Метод фильтрует записи по выбранного значению в списке ComboBOx Список Департаментов
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool Find(Accounts args)
        {
            return args.CustomerID == CustomerID;
        }

        /// <summary>
        /// Метод возможности удаления Счета клиента
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanDeleteCustomerAccountCommand(object obj)
        {
            return true;
        }

        /// <summary>
        /// Метод удаления Счета клиента
        /// </summary>
        /// <param name="obj"></param>
        private void DeleteCustomerAccount(object obj)
        {
               IAccounts<Accounts_1> str = obj as IAccounts<Accounts_1>;
                FileService<IAccounts<Accounts_1>>.RemoveRow(str);
        }

        /// <summary>
        /// Метод возможности редактирования счета Клиента
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanEditCustomerAccountCommand(object obj)
        {
            return true;
        }

        /// <summary>
        /// Метод редактирования Счета клиента
        /// </summary>
        /// <param name="obj"></param>
        private void EditCustomerAccount(object obj)
        {
            Dictionary<string, string> str_param = new Dictionary<string, string>();
            str_param.Add("CustmerID", CustomerID);
            str_param.Add("TypeOfAccount", "DepositAccount");
            Form_EditAccountOfCustomers form_edit = new Form_EditAccountOfCustomers(obj, str_param);
            form_edit.Owner = Form;
            form_edit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form_edit.ID.IsEnabled = false;
            form_edit.Customer_ID.IsEnabled = false;
            form_edit.DateOpen.IsEnabled = false;
            form_edit.DateClose.IsEnabled = false;
            form_edit.TypeAccount.IsEnabled = false;
            form_edit.Ammount.IsEnabled = false;
            form_edit.Number.IsEnabled = false;
            form_edit.Rate.IsEnabled = false;

            form_edit.Show();
        }

        /// <summary>
        /// Метод возможности Добавления нового счета Клиента (Депозитный)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanAddDepositAccountCommand(object obj)
        {
            return true;
        }

        /// <summary>
        /// Метод возможности Добавления нового счета Клиента (НеДепозитный)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanAddNotDepositAccountCommand(object obj)
        {
            return true;
        }
        /// <summary>
        /// Метод добавления нового счета (Депозитный) 
        /// </summary>
        /// <param name="obj"></param>
        private void AddDepositAccount(object obj)
        {

            Dictionary<string,string> str_param = new Dictionary<string, string>();
            str_param.Add("CustmerID",CustomerID);
            str_param.Add("TypeOfAccount", "DepositAccount");
            Form_EditAccountOfCustomers form_edit = new Form_EditAccountOfCustomers(obj, str_param);
            form_edit.Owner = Form;
            form_edit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form_edit.ID.IsEnabled = false;
            form_edit.Customer_ID.IsEnabled = false;
            form_edit.DateOpen.IsEnabled = false;
            form_edit.DateClose.IsEnabled = false;
            form_edit.TypeAccount.IsEnabled = false;
            form_edit.Ammount.IsEnabled = false;
            form_edit.Number.IsEnabled = false;


            form_edit.Show();
        }
        /// <summary>
        /// Метод добавления нового счета (Не Депозитный)
        /// </summary>
        /// <param name="obj"></param>
        private void AddNotDepositAccount(object obj)
        {

            Dictionary<string, string> str_param = new Dictionary<string, string>();
            str_param.Add("CustmerID", CustomerID);
            str_param.Add("TypeOfAccount", "NotDepositAccount");
            Form_EditAccountOfCustomers form_edit = new Form_EditAccountOfCustomers(obj, str_param);
            form_edit.Owner = Form;
            form_edit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form_edit.ID.IsEnabled = false;
            form_edit.Customer_ID.IsEnabled = false;
            form_edit.DateOpen.IsEnabled = false;
            form_edit.DateClose.IsEnabled = false;
            form_edit.TypeAccount.IsEnabled = false;
            form_edit.Ammount.IsEnabled = false;
            form_edit.Number.IsEnabled = false;

            form_edit.Show();
        }
    }
}
