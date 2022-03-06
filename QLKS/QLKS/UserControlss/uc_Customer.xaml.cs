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
using System.Windows.Navigation;
using System.Windows.Shapes;
using QLKS.ViewModel;

namespace QLKS.UserControlss
{
    /// <summary>
    /// Interaction logic for uc_Customer.xaml
    /// </summary>
    public partial class uc_Customer : UserControl
    {
        private CustomerViewmodel customerViewmodel { get; set; }
        public uc_Customer()
        {
            InitializeComponent();
            this.DataContext = (customerViewmodel = new CustomerViewmodel());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
