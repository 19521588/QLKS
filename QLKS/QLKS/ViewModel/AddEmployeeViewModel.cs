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
    public class AddEmployeeViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }

        public ICommand CloseCommand { get; set; }
        private bool _check { get; set; }
        public bool check { get => _check; set { _check = value; OnPropertyChanged(); } }

        private EMPLOYEE _employee { get; set; }

        public EMPLOYEE employee { get => _employee; set { _employee = value; OnPropertyChanged(); } }

        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }
        public AddEmployeeViewModel()
        {
            AddCommand = new RelayCommand<wd_AddEmployee>(
                (p) =>
                {
                    var List = DataProvider.Ins.DB.ROOMs.Where(x => x.Name == p.txbName.Text);
                    if (List == null || List.Count() != 0) return false;
                    if (string.IsNullOrEmpty(p.txbName.Text) || string.IsNullOrEmpty(p.txbCCCD.Text) || string.IsNullOrEmpty(p.txbPhone.Text) || string.IsNullOrEmpty(p.txbAddress.Text))
                        return false;
                    Regex regex = new Regex(@"^[0-9]+$");
                    return true;
                },
                (p) =>
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn thêm nhân viên mới", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        employee = new EMPLOYEE() { Name = p.txbName.Text, Address = p.txbAddress.Text, BirthDay = DateTime.Parse( p.dtpBirth.SelectedDate.ToString()), Position = p.txbPosition.Text ,CCCD = p.txbCCCD.Text,Phone = p.txbPhone.Text, Salary = p.txbSalary.Text, Sex = p.cbSex.Text};
                        DataProvider.Ins.DB.EMPLOYEEs.Add(employee);
                        DataProvider.Ins.DB.SaveChanges();
                        check = true;
                        IsClose = false;
                        p.Close();
                    }
                });
            CloseCommand = new RelayCommand<wd_AddEmployee>(
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
