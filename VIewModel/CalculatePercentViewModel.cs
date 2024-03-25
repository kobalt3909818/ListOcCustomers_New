using ListOfCustomers_New.Commands;
using ListOfCustomers_New.Models;
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
    class CalculatePercentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<AccountPercent> ListOfPercents_ { get; set; }
        public ObservableCollection<AccountPercent> ListOfPercents { get; set ; }

        public ICommand CalculatePercentCommand { get; set; }
        public Window Form { get; set; }
        public DateTime CalculationDate { get; set; }

        public DateTime CalculationDate_
        {
            get { return CalculationDate; }
            set { CalculationDate = value; }
        }

        public CalculatePercentViewModel(object obj)
        {
            Form = obj as Window;
            CalculatePercentCommand = new RelayCommand(CalculatePercent, CanCalculatePercent);
            ListOfPercents = FileService<AccountPercent>.GetListOfValues();
        }

        /// <summary>
        /// Метод определяет может ли расчитываться процент  
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private bool CanCalculatePercent(object obj)
        {
            return true;
        }

        /// <summary>
        /// Метод расчета процентов
        /// </summary>
        /// <param name="obj"></param>
        private void CalculatePercent(object obj)
        {
            AccountPercent.CalculatePercents(CalculationDate);

            ListOfPercents = FileService<AccountPercent>.ListOfValues;
            ((ListOfCustomers_New.Views.Form_CalculateOfPercent)Form).ListOfPercents.ItemsSource = ListOfPercents;

        }
    }
}