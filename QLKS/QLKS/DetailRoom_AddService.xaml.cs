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
    /// Interaction logic for DetailRoom_AddService.xaml
    /// </summary>
    public partial class DetailRoom_AddService : Window
    {
        AddServiceDRViewModel viewModel { get; set; }

        public DetailRoom_AddService(ObservableCollection<ListService> list)
        {
            InitializeComponent();
            this.DataContext=viewModel=new AddServiceDRViewModel(list);
        }
        private void txbSoLuong_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txb = sender as TextBox;
            SelectService dvdc = (sender as TextBox).DataContext as SelectService;
            int soLuong = 1;
            if (!int.TryParse(txb.Text, out soLuong))
            {
                MessageBox.Show("Lỗi: Nhập số lượng kiểu số nguyên!", "Thông báo", MessageBoxButton.OK);
                return;
            }
            dvdc.Amount = soLuong;
            dvdc.Total = dvdc.Service.Price * soLuong;
        }
        private void txbSoLuong_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox txb = sender as TextBox;
                SelectService dvdc = (sender as TextBox).DataContext as SelectService;
                int soLuong = 1;
                if (!int.TryParse(txb.Text, out soLuong))
                {
                    MessageBox.Show("Lỗi: Nhập số lượng kiểu số nguyên!", "Thông báo", MessageBoxButton.OK);
                    return;
                }
                dvdc.Amount = soLuong;
                dvdc.Total = dvdc.Service.Price * soLuong;
            }
        }
    }
}
