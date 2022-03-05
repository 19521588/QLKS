using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QLKS.Model;
using QLKS.DATA;
using System.Windows;

namespace QLKS.ViewModel
{
    public class SelectCustomerViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private ObservableCollection<CUSTOMER> _ListCustomer { get; set; }
        public ObservableCollection<CUSTOMER> ListCustomer { get => _ListCustomer; set{ _ListCustomer = value; OnPropertyChanged(); } }

        private CUSTOMER _SelectedItem { get; set; }
        public CUSTOMER SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        private CUSTOMER _customer { get; set; }
        public CUSTOMER customer { get => _customer; set { _customer = value; OnPropertyChanged(); } }

        public SelectCustomerViewModel()
        {
            GetModel get = new GetModel();
            ListCustomer = get.getListCustomer();

            AddCommand = new RelayCommand<wd_SelectCustomer>(
                (p) =>
                {
                    if (SelectedItem == null) return false;

                    return true;
                },
                (p) =>
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn thêm phòng mới", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        customer = SelectedItem;
                        p.Close();
                    }
                });
            CloseCommand = new RelayCommand<wd_SelectCustomer>(
            (p) =>
            { return true; },
            (p) =>
            {
                p.Close();
            }
            );
        }
    }
}
