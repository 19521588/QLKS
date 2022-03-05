using QLKS.Convert;
using QLKS.DATA;
using QLKS.Model;
using QLKS.UserControlss;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class CustomerViewmodel : BaseViewModel
    {
        public ICommand OpenAddCommand { get; set; }
        public ICommand OpenEditCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        private string _Name { get; set; }

        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private ObservableCollection<CUSTOMER> _ListCustomer { get; set; }

        public ObservableCollection<CUSTOMER> ListCustomer { get => _ListCustomer; set { _ListCustomer = value; OnPropertyChanged(); } }

        private CUSTOMER _SelectedItem { get; set; }
        public CUSTOMER SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Name = _SelectedItem.Name.ToString();

                }
                OnPropertyChanged();
            }
        }
        public CustomerViewmodel()
        {
            GetModel get = new GetModel();
            Load();
            OpenAddCommand = new RelayCommand<MainWindow>((p) => true, (p) =>
            {

                wd_AddCustomer wdAddCustomer = new wd_AddCustomer();


                wdAddCustomer.ShowDialog();

                AddCustomerViewModel add = wdAddCustomer.DataContext as AddCustomerViewModel;
                if (add.check)
                    ListCustomer.Insert(0, add.customer);
            });

            DeleteCommand = new RelayCommand<MainWindow>((p) => {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                var Temp = DataProvider.Ins.DB.RESERVATIONs.Where(x => x.IdCustomer == SelectedItem.IdCustomer);
                if (Temp.Count() == 0)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xóa nhân viên", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        DeleteModel delete = new DeleteModel();
                        delete.DeleteCustomer(SelectedItem);
                        ListCustomer.Remove(SelectedItem);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Không thể xóa khách hàng này", "Thông báo", MessageBoxButton.OK);
                }
            });

            OpenEditCommand = new RelayCommand<MainWindow>((p) => {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                wd_EditCustomer wdEditCustomer = new wd_EditCustomer(SelectedItem);

                wdEditCustomer.txbName.Text = SelectedItem.Name;
                wdEditCustomer.txbCCCD.Text = SelectedItem.CCCD.ToString();
                wdEditCustomer.txbPhone.Text = SelectedItem.Phone.ToString();
                wdEditCustomer.txbAddress.Text = SelectedItem.Address.ToString();
                wdEditCustomer.txbNationality.Text = SelectedItem.Nationality.ToString();
                wdEditCustomer.cbSex.Text = SelectedItem.Sex.ToString();
                wdEditCustomer.dtBirth.SelectedDate = SelectedItem.BirthDay;
                wdEditCustomer.ShowDialog();
                Load();
            });
            SearchCommand = new RelayCommand<uc_Customer>((p) =>
            {
                return true;
            }, (p) =>
            {
                UnicodeConvert uni = new UnicodeConvert();

                ObservableCollection<CUSTOMER> _ListTemp = new ObservableCollection<CUSTOMER>();
                ObservableCollection<CUSTOMER> _ListNew = get.getListCustomer();

                foreach (var item in _ListNew)
                {
                    if ((string.IsNullOrEmpty(p.txbNameSearch.Text) || (!string.IsNullOrEmpty(p.txbNameSearch.Text) && uni.RemoveUnicode(item.Name).ToLower().Contains(uni.RemoveUnicode(p.txbNameSearch.Text).ToLower())))
                        && (string.IsNullOrEmpty(p.txbPhoneSearch.Text) || (!string.IsNullOrEmpty(p.txbPhoneSearch.Text) && uni.RemoveUnicode(item.Phone).ToLower().Contains(uni.RemoveUnicode(p.txbPhoneSearch.Text).ToLower()))))
                    {
                        _ListTemp.Add(item);
                    }
                }
                ListCustomer = _ListTemp;
            });
            RefreshCommand = new RelayCommand<MainWindow>((p) =>
            {
                return true;
            }, (p) =>
            {
                Load();
            });

            void Load()
            {
                ListCustomer = get.getListCustomer();
            }
        }

        
    }
}
