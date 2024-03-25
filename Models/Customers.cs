using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ListOfCustomers_New.Interfaces;

namespace ListOfCustomers_New.Models
{
    public class Customers : INotifyPropertyChanged
    {
        private string iD;
        private string first_Name;
        private string second_Name;
        private string middle_Name;
        private string telephone;
        private string pasport;
        private string department;

        public string ID
        {
            get => iD; set
            {
                iD = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string First_Name
        {
            get => first_Name; set
            {
                first_Name = value;
                OnPropertyChanged(nameof(First_Name));
            }
        }

        public string Second_Name { get => second_Name; set
            {
                second_Name = value;
                OnPropertyChanged(nameof(Second_Name));
            }
        }

        public string Middle_Name { get => middle_Name; set
            {
                middle_Name = value;
                OnPropertyChanged(nameof(Middle_Name));
            }
        }

        public string Telephone { get => telephone; set  
            {
                telephone = value;
                OnPropertyChanged(nameof(Telephone));
            }
        }

        public string Pasport { get => pasport; set
            {
                pasport = value;
                OnPropertyChanged(nameof(Pasport));
            }
        }
        public string Department
        {
            get => department; set
            {
                department = value;
                OnPropertyChanged(nameof(Department));
            }
        }

        public Customers(string ID = "", string First_Name = "", string Second_Name = "", string Middle_Name = "", string Telephone = "", string Pasport = "" , string Department = "")

        {
            this.ID = ID;
            this.First_Name = First_Name;
            this.Second_Name = Second_Name;
            this.Middle_Name = Middle_Name;
            this.Telephone = Telephone;
            this.Pasport = Pasport;
            this.Department = Department;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
