using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QLKS.ViewModel;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for wd_AddEmployee.xaml
    /// </summary>
    public partial class wd_AddEmployee : Window
    {
        private AddEmployeeViewModel addEmployeeViewModel { get; set; }
        
        public wd_AddEmployee()
        {
            InitializeComponent();
            this.DataContext = (addEmployeeViewModel = new AddEmployeeViewModel());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
