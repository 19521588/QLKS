using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using QLKS.DATA;
using QLKS.Model;
using QLKS.ViewModel;

namespace QLKS.ViewModel
{
    public class EditCustomerViewModel : BaseViewModel
    {
        public ICommand EditCommand { get; set; }

        public ICommand CloseCommand { get; set; }
        private bool _check { get; set; }
        public bool check { get => _check; set { _check = value; OnPropertyChanged(); } }

        private CUSTOMER _customer { get; set; }

        public CUSTOMER customer { get => _customer; set { _customer = value; OnPropertyChanged(); } }

        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }

        private String _SelectedCategory { get; set; }

        public String SelectedCategory { get => _SelectedCategory; set { _SelectedCategory = value; OnPropertyChanged(); } }
        public EditCustomerViewModel(CUSTOMER customer)
        {
            GetModel get = new GetModel();
            EditModel edit = new EditModel();
            SelectedCategory = customer.Sex;
            EditCommand = new RelayCommand<wd_EditCustomer>(
                (p) =>
                {

                    var Temp = DataProvider.Ins.DB.EMPLOYEEs.Where(x => x.Name == p.txbName.Text);
                    if ((Temp == null || Temp.Count() != 0) && p.txbName.Text != customer.Name) return false;
                    if (string.IsNullOrEmpty(p.txbName.Text) || string.IsNullOrEmpty(p.txbCCCD.Text) || string.IsNullOrEmpty(p.txbPhone.Text) || string.IsNullOrEmpty(p.txbAddress.Text))
                        return false;
                    if (p.txbName.Text == customer.Name && p.txbAddress.Text == customer.Address.ToString() && p.txbCCCD.Text == customer.CCCD.ToString() && p.txbPhone.Text == customer.Phone.ToString() && p.txbNationality.Text == customer.Nationality.ToString() && p.dtBirth.SelectedDate == customer.BirthDay && SelectedCategory == customer.Sex) return false;
                    Regex regex = new Regex(@"^[0-9]+$");
                    if (customer == null) return false;
                    return true;

                },
                (p) =>
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin nhân viên", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        var List = get.getCustomer(customer.IdCustomer);
                        edit.EditCustomer(List, p.txbName.Text, p.txbAddress.Text, p.dtBirth.SelectedDate.Value, p.txbPhone.Text, p.txbCCCD.Text, p.cbSex.Text,p.txbNationality.Text);
                        //List.Name = p.txbName.Text;
                        //List.Address = p.txbAddress.Text;
                        //List.CCCD = p.txbCCCD.Text;
                        //List.Phone = p.txbPhone.Text;
                        //List.BirthDay = p.dtBirth.SelectedDate;
                        //List.Nationality = p.txbNationality.Text;
                        //List.Sex = p.cbSex.Text;
                        //DataProvider.Ins.DB.SaveChanges();
                        OnPropertyChanged("List");
                        IsClose = false;
                        p.Close();
                    }
                }
                );

            CloseCommand = new RelayCommand<wd_EditCustomer>(
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
