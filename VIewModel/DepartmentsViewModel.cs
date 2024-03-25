using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ListOfCustomers_New.Models;
using ListOfCustomers_New.Commands;
using ListOfCustomers_New.Views;
using System.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ListOfCustomers_New.VIewModel
{
    class DepartmentsViewModel:INotifyPropertyChanged
    {
        public Departments Departments1 { get ; set; }
        public Departments Departments { get { return Departments1; } set { Departments1 = value; OnPropertyChanged(nameof(Departments1)); } }
        public ObservableCollection<Departments> ListDepartments_1 { get; set; }
        public ObservableCollection<Departments> ListDepartments { get { return ListDepartments_1; } set {
                ListDepartments_1 = value;
                OnPropertyChanged(nameof(ListDepartments)); }
        }
        public ICommand AddDepartmentsCommand { get; set; }
        public ICommand EditDepartmentsCommand { get; set; }
        public ICommand DeleteDepartmentsCommand { get; set; }

        public DepartmentsViewModel()
        {
            AddDepartmentsCommand = new RelayCommand(AddDepartments, CanAddDepartments);
      
            EditDepartmentsCommand = new RelayCommand(EditDepartments, CanEditDepartments);

            DeleteDepartmentsCommand = new RelayCommand(DeleteDepartments, CanDeleteDepartments);

            ListDepartments = FileService<Departments>.GetListOfValues();
        }

        ////////////////////////////////////////////////////////////////////
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        ////////////////////////////////////////////////////////////////////

        private bool CanDeleteDepartments(object obj)
        {
            return true;
        }

        private void DeleteDepartments(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanEditDepartments(object obj)
        {
            return true;
        }

        private void EditDepartments(object obj)
        {
            Departments depStr = obj as Departments;
            Form_EditDepartments form = new Form_EditDepartments(obj);
            
            form.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form.Box_ID.IsEnabled = false;
            form.Show();
        }

        private bool CanAddDepartments(object obj)
        {
            return true;
        }
        private void AddDepartments(object obj)
        {
            Window owner = obj as Window;
            Form_EditDepartments form = new Form_EditDepartments(obj);
            form.Owner = owner;
            form.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            form.Box_ID.IsEnabled = false;
            form.Show();
        }
    }
}
