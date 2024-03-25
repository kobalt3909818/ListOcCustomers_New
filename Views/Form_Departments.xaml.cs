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
using ListOfCustomers_New.VIewModel;

namespace ListOfCustomers_New.Views
{
    /// <summary>
    /// Логика взаимодействия для Form_Departments.xaml
    /// </summary>
    public partial class Form_Departments : Window
    {
        public Form_Departments()
        {
            InitializeComponent();
            Loaded += CustomersForm_Loaded;
        }

        private void CustomersForm_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = new DepartmentsViewModel();
        }



    }
}
