using QLKS.Model;
using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Bill_Detail(Bill Bill, bool isPrint)
        {
            InitializeComponent();
            this.DataContext = viewModel = new BillDetailViewModel(Bill, isPrint);
        }
        public Bill_Detail(ObservableCollection<SelectService> detailPayment,int idRental ,bool isPrint,USER User)
        {
            InitializeComponent();
            this.DataContext = viewModel = new BillDetailViewModel(detailPayment,idRental, isPrint, User);
        }
    }
}
