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
    /// Логика взаимодействия для Form_EditAccountOfCustomers.xaml
    /// </summary>
    public partial class Form_EditAccountOfCustomers : Window
    {
        private object Obj;
        public string CustomerID_;
        public string TypeOfAccount_;

        public Form_EditAccountOfCustomers(object obj, Dictionary<string,string> str_params)
        {
            InitializeComponent();
            Loaded += CustomersForm_Loaded;
            this.Obj = obj;
            this.CustomerID_ = str_params["CustmerID"];
            this.TypeOfAccount_ = str_params["TypeOfAccount"];
        }

        private void CustomersForm_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new EditCustomerAccountViewModel(Obj, this);
        }
    }
}
