using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfCustomers_New.Commands;
using ListOfCustomers_New.Views;
using ListOfCustomers_New.Models;
using ListOfCustomers_New.Any;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ListOfCustomers_New.VIewModel
{
    class MainViewModel:INotifyPropertyChanged
    {
        public List<Users> Users { get; set; }
        public string User { get; set; }
        public Window Form { get; set; }  
        public ICommand CustomersShowWindowComand { get; set; }
        public ICommand DepartmentsShowWindowComand { get; set; }
        public ICommand CalculateShowWindowComand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private Users SelectedUser_ { get; set; }
        public Users SelectedUser
        {
            get { return SelectedUser_; }
            set { SelectedUser_ = value; OnPropertyChanged(nameof(SelectedUser)); }

        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName== "SelectedUser" && Form!=null)
            {
                Constants.SetConstants(SelectedUser.Name); 
            }

        }
        public MainViewModel(object form)
        {
             Form = form as Window;

            CustomersShowWindowComand = new RelayCommand(CustomersShowWindow, CanCustomersShowWindow);

            DepartmentsShowWindowComand = new RelayCommand(DepartmentsShowWindow, CanDepartmentsShowWindow);

            CalculateShowWindowComand = new RelayCommand(CalculateShowWindow, CanCalculateShowWindow);

            Users = UsersManager.GetUsers();

             SelectedUser = Users[1];
        }

        private bool CanCalculateShowWindow(object obj)
        {
            return true;
        }

        private void CalculateShowWindow(object obj)
        {
            Form_CalculateOfPercent form = new Form_CalculateOfPercent();
            form.Show();
        }

        private bool CanDepartmentsShowWindow(object obj)
        {
            return true;
        }

        private void DepartmentsShowWindow(object obj)
        {
            Form_Departments form = new Form_Departments();
            form.Show();
        }

        private bool CanCustomersShowWindow(object obj)
        {
            return true;
        }

        private void CustomersShowWindow(object obj)
        {
            Form_Customers form = new Form_Customers();
            form.Show();
        }
    }
}
