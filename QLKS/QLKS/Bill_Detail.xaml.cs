using QLKS.Model;
using QLKS.ViewModel;
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

namespace QLKS
{
    /// <summary>
    /// Interaction logic for Bill_Detail.xaml
    /// </summary>
    public partial class Bill_Detail : Window
    {
        BillDetailViewModel viewModel { get; set; }
        public Bill_Detail()
        {
            InitializeComponent();
            
        }
        public Bill_Detail(Bill Bill)
        {
            InitializeComponent();
            this.DataContext = viewModel = new BillDetailViewModel(Bill);
        }
    }
}
