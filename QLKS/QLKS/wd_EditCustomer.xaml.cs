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
using QLKS.Model;
using QLKS.ViewModel;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for wd_EditCustomer.xaml
    /// </summary>
    public partial class wd_EditCustomer : Window
    {
        private EditCustomerViewModel editCustomerViewModel { get; set; }
        public wd_EditCustomer(CUSTOMER customer)
        {
            InitializeComponent();
            this.DataContext = (editCustomerViewModel = new EditCustomerViewModel(customer));
        }
    }
}
