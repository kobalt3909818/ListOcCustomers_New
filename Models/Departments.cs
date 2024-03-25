using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ListOfCustomers_New.Interfaces;

namespace ListOfCustomers_New.Models
{
  public  class Departments : INotifyPropertyChanged
    {
        private string iD;
        private string name;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ID
        {
            get => iD; set
            {
                iD = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        public string Name { get => name; set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public Departments(string id, string name)
        {
            ID = id;
            Name = name;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
