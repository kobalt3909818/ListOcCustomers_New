using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ListOfCustomers_New.Models;
using ListOfCustomers_New.Commands;
using ListOfCustomers_New.Views;
using ListOfCustomers_New.Any;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ListOfCustomers_New.VIewModel
{
    public class CustomersViewModel : INotifyPropertyChanged 
    {
        public Window Form { get; set; }
        public Customers Customers1 { get; set; }
        public Customers Customers { get { return Customers1; } set { Customers1 = value; OnPropertyChanged(nameof(Customers1)); } }
        public ObservableCollection<Customers> ListOfCustomers1 { get; set; }
        public ObservableCollection<Customers> ListOfCustomers { get { return ListOfCustomers1; } set { ListOfCustomers1 = value; OnPropertyChanged(nameof(ListOfCustomers1)); } }
        public ObservableCollection<Departments> ListDepartments { get; set; }

        private Departments SelectedDepatment_;
        public Departments SelectedDepartment
        {
            get { return SelectedDepatment_; }
            set { SelectedDepatment_ = value; OnPropertyChanged(nameof(SelectedDepartment)); }
        }

       
        ////////////////////////////////////////////////////////////////////////////
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) 
        {
            if (propertyName == "SelectedDepartment"&& SelectedDepartment!=null) 
            {
                if (SelectedDepartment != null)
                    ((ListOfCustomers_New.Views.Form_Customers)Form).ListOfCustomers.ItemsSource = FileService<Customers>.ListOfValues.Where(Find);
            }
        }

        ////////////////////////////////////////////////////////////////////////////
        public ICommand EditCustomersCommand { get; set; }
        public ICommand EditCustomersAccountsCommand { get; set; }
        public ICommand DeleteCustomersCommand { get; set; }
        public ICommand AddCustomersCommand { get; set; }
        public CustomersViewModel(object obj)
        {
            Form = obj as Window;
 
            ListOfCustomers = FileService<Customers>.GetListOfValues();

            EditCustomersCommand = new RelayCommand(EditCustomers, CanEditCustomers);
            EditCustomersAccountsCommand = new RelayCommand(EditCustomersAccounts, CanEditCustomersAccounts);
            DeleteCustomersCommand = new RelayCommand(DeleteCustomers, CanDeleteCustomers);
            AddCustomersCommand = new RelayCommand(AddCustomer, CanAddCustomer);
      
            ListDepartments = FileService<Departments>.GetListOfValues();
        }

        /// <summary>
        /// Метод возможности редактирования Счета клиента
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanEditCustomersAccounts(object obj)
        {
            return true;
        }

        /// <summary>
        /// Открывает форму редактирования Счета Клиента 
        /// </summary>
        /// <param name="obj"></param>
        private void EditCustomersAccounts(object obj)
        {
            Form_CustomersAccounts form_edit = new Form_CustomersAccounts(obj);
            form_edit.Owner = Form;
            form_edit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form_edit.Show();
        }

        /// <summary>
        /// Метод фильтрует записи по выбранного значению в списке ComboBOx Список Департаментов
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool Find(Customers args)
        {
            return args.Department == (SelectedDepartment as Departments).ID;
        }

        /// <summary>
        /// Метод обработчик кнопки открыть форму редактирования контрагента 
        /// </summary>
        /// <param name="obj"></param>
        private void EditCustomers(object obj)
        {
            Form_EditCustomers form_edit = new Form_EditCustomers(obj);
            form_edit.Owner = Form;
            form_edit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form_edit.Box_ID.IsEnabled = false;
            form_edit.Show();
        }

        /// <summary>
        /// Метод проверяет есть ли возможность редактировать форму контрагентов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanEditCustomers(object obj)
        {
            return true;
        }

        /// <summary>
        /// Метод обработчик события кнопки добавить контрагента в список 
        /// </summary>
        /// <param name="obj"></param>
        private void AddCustomer(object obj)
        {
            Window owner = obj as Window;
            Form_EditCustomers form_edit= new Form_EditCustomers(obj);
            form_edit.Owner = owner;
            form_edit.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form_edit.Box_ID.IsEnabled = false;
            form_edit.Show();
        }
        /// <summary>
        /// Проверяет есть ли возможноть добавить контрагента
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanAddCustomer(object obj)
        {
            if (Constants.GetConstant() == "Consultant")
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Метод удаляет из списка контрагента
        /// </summary>
        /// <param name="obj"></param>
        private void DeleteCustomers(object obj)
        {
            Customers str = obj as Customers;
            FileService<Customers>.RemoveRow(str);
        }

        /// <summary>
        /// Метод проверяет есть ли возможность удалить из списка контрагента
        /// </summary>
        /// <param name="obj"></param>
        private bool CanDeleteCustomers(object obj)
        {
            if (Constants.GetConstant() == "Consultant")
            {
                return false;
            }
            return true;
        }
    }
}
