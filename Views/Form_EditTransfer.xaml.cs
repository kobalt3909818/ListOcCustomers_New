using ListOfCustomers_New.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ListOfCustomers_New.Views
{
    /// <summary>
    /// Логика взаимодействия для Form_EditTransfer.xaml
    /// </summary>
    public partial class Form_EditTransfer : Window
    {
        Object Obj;
        public string CustomerID_;
        public string AccountID_;
        public string TypeOfTransfer_;
        public string TypeOperation_;


        public Form_EditTransfer(object obj, Dictionary<string, string> str_params)
        {
            InitializeComponent();
            Loaded += TransferForm_Loaded;
            this.Obj = obj;
            this.CustomerID_ = str_params["CustmerID"];
            this.AccountID_ = str_params["AccountID"];
            this.TypeOfTransfer_ = str_params["TypeOfTransfer"];
            if (str_params.ContainsKey("TypeOperation")) 
            {
                this.TypeOperation_ = str_params["TypeOperation"];
            }
            

        }
        private void TransferForm_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new EditTransferViewModel(Obj, this);
        }
    }
}
