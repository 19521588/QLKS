using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class CustomerViewmodel : BaseViewModel
    {
        public ICommand OpenAddCommand { get; set; }

        public ICommand OpenEditCommand { get; set; }

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
            Load();
            OpenAddCommand = new RelayCommand<MainWindow>((p) => true, (p) =>
            {

                wd_AddCustomer wdAddCustomer = new wd_AddCustomer();


                wdAddCustomer.ShowDialog();

                AddCustomerViewModel add = wdAddCustomer.DataContext as AddCustomerViewModel;
                if (add.check)
                    ListCustomer.Insert(0, add.customer);
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
        }

        void Load()
        {
            ListCustomer = new ObservableCollection<CUSTOMER>(DataProvider.Ins.DB.CUSTOMERs);
        }
    }
}
