using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfCustomers_New.Models;
using ListOfCustomers_New.Commands;
using ListOfCustomers_New.Views;
using ListOfCustomers_New.Any;
using System.Collections.ObjectModel;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ListOfCustomers_New.VIewModel
{
    class EditCustomerViewModel :INotifyPropertyChanged
    {
        public ObservableCollection<Customers> ListOfCustomers { get; set; }
        public ObservableCollection<Departments> ListOfDepartments { get; set; }
        public string ID { get; set; }
        public string Department { get; set ;  }
        public string First_Name { get; set; }
        public string Second_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Telephone { get; set; }
        public string Pasport { get; set; }
        public ICommand SaveCustomersCommand { get; set; }

        private Departments SelectedDepatment_;

        public event PropertyChangedEventHandler PropertyChanged;

        public Departments SelectedDepartment
        {
            get { return SelectedDepatment_; }
            set { SelectedDepatment_ = value; OnPropertyChanged(nameof(SelectedDepartment)); }
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public EditCustomerViewModel(object param, Form_EditCustomers form)
        {
            Customers cst = param as Customers;
            SaveCustomersCommand = new RelayCommand(SaveCustomers, CanSaveCustomers);

            if (cst != null)
            {
                ID = cst.ID;
                First_Name = cst.First_Name;
                Second_Name = cst.Second_Name;
                Middle_Name = cst.Middle_Name;
                Telephone = cst.Telephone;
                Pasport = cst.Pasport;
                ListOfDepartments = FileService<Departments>.ListOfValues;
                Department = cst.Department;
                SelectedDepartment = FileService<Departments>.Get_by_ID(cst.Department);
                if (Constants.GetConstant()=="Consultant")
                {
                    form.Pasport.Visibility = System.Windows.Visibility.Hidden;
                    form.label_Pasport.Visibility = System.Windows.Visibility.Hidden;
                    form.label_FirstName.IsEnabled = false;
                    form.First_Name.IsEnabled = false;
                    form.label_SecondName.IsEnabled = false;
                    form.Second_Name.IsEnabled = false;
                    form.label_MiddleName.IsEnabled = false;
                    form.Middle_Name.IsEnabled = false;
                    form.label_Department.IsEnabled = false;
                    form.Departments.IsEnabled = false;
                }
                else
                {
                    form.Pasport.Visibility = System.Windows.Visibility.Visible;
                    form.label_Pasport.Visibility = System.Windows.Visibility.Visible;
                }
            }
            else
            {
                ID = FileService<Customers>.Return_ID();
                ListOfDepartments = FileService<Departments>.GetListOfValues();
            }
        }

        /// <summary>
        /// Метод обработчик события кнопки Save
        /// </summary>
        /// <param name="obj"></param> Передает форма  как объект 
        private void SaveCustomers(object obj)
        {
            Window window = obj as Window;
            Customers str = new Customers(ID, First_Name, Second_Name, Middle_Name, Telephone, Pasport, SelectedDepartment.ID);
            FileService<Customers>.Save(str);
            window.Close();
        }
        private bool CanSaveCustomers(object obj)
        {
            return true;
        }
    }
}

