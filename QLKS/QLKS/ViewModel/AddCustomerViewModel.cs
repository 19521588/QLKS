using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class AddCustomerViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }

        public ICommand CloseCommand { get; set; }
        private bool _check { get; set; }
        public bool check { get => _check; set { _check = value; OnPropertyChanged(); } }

        private CUSTOMER _customer{ get; set; }

        public CUSTOMER customer { get => _customer; set { _customer = value; OnPropertyChanged(); } }

        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }
        public AddCustomerViewModel()
        {
            AddCommand = new RelayCommand<wd_AddCustomer>(
                (p) =>
                {
                    var List = DataProvider.Ins.DB.ROOMs.Where(x => x.Name == p.txbName.Text);
                    if (List == null || List.Count() != 0) return false;
                    if (string.IsNullOrEmpty(p.txbName.Text) || string.IsNullOrEmpty(p.txbCCCD.Text) || string.IsNullOrEmpty(p.txbPhone.Text) || string.IsNullOrEmpty(p.txbAddress.Text) || string.IsNullOrEmpty(p.txbNationality.Text) || string.IsNullOrEmpty(p.cbSex.Text))
                        return false;
                    Regex regex = new Regex(@"^[0-9]+$");
                    return true;
                },
                (p) =>
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn thêm nhân viên mới", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        customer = new CUSTOMER() { Name = p.txbName.Text, Address = p.txbAddress.Text, BirthDay = DateTime.Parse(p.dtBirth.SelectedDate.ToString()), Nationality = p.txbNationality.Text, CCCD = p.txbCCCD.Text, Phone = p.txbPhone.Text, Sex = p.cbSex.Text };
                        DataProvider.Ins.DB.CUSTOMERs.Add(customer);
                        DataProvider.Ins.DB.SaveChanges();
                        check = true;
                        IsClose = false;
                        p.Close();
                    }
                });
            CloseCommand = new RelayCommand<wd_AddCustomer>(
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
