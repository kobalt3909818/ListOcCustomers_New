using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ListOfCustomers_New.Commands;
using ListOfCustomers_New.Models;
using ListOfCustomers_New.Views;


namespace ListOfCustomers_New.VIewModel
{
    class EditDepartmentsVIewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public ICommand SaveDataCommand { get; set; }
        public ICommand CloseFormCommand { get; set; }
        public EditDepartmentsVIewModel(object param, Form_EditDepartments form)
        {
            SaveDataCommand = new RelayCommand(SaveData, CanSaveData);

             Departments depStr = param as Departments;
            if (depStr==null) { 
            ID = FileService<Departments>.Return_ID();
            }
            else
            {
                ID = depStr.ID;
                Name = depStr.Name;
            }
        }
        
        private bool CanSaveData(object obj)
        {
            return true;
        }
        private void SaveData(object obj)
        {
            Window window = obj as Window;
            Departments str = new Departments(ID, Name);
            FileService<Departments>.Save(str);
           FileService<Departments>.AddDepartments(str);
            window.Close();
        }
    }
}
		
