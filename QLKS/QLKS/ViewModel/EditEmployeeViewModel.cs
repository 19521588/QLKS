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
    public class EditEmployeeViewModel : BaseViewModel
    {
        public ICommand EditCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        private bool _check { get; set; }
        public bool check { get => _check; set { _check = value; OnPropertyChanged(); } }

        private EMPLOYEE _employee { get; set; }

        public EMPLOYEE employee { get => _employee; set { _employee = value; OnPropertyChanged(); } }

        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }

        private String _SelectedCategory { get; set; }

        public String SelectedCategory { get => _SelectedCategory; set { _SelectedCategory = value; OnPropertyChanged(); } }
        public EditEmployeeViewModel(EMPLOYEE employee)
        {
            SelectedCategory = employee.Sex;

            EditCommand = new RelayCommand<wd_EditEmployee>(
                (p) =>
                {

                    var Temp = DataProvider.Ins.DB.EMPLOYEEs.Where(x => x.Name == p.txbName.Text);
                    if ((Temp == null || Temp.Count() != 0) && p.txbName.Text != employee.Name) return false;
                    if (string.IsNullOrEmpty(p.txbName.Text) || string.IsNullOrEmpty(p.txbCCCD.Text) || string.IsNullOrEmpty(p.txbPhone.Text) || string.IsNullOrEmpty(p.txbAddress.Text))
                        return false;
                    if (p.txbName.Text == employee.Name && p.txbAddress.Text == employee.Address.ToString() && p.txbCCCD.Text == employee.CCCD.ToString() && p.txbPhone.Text == employee.Phone.ToString() && p.txbPosition.Text == employee.Position.ToString() && p.txbSalary.Text == employee.Salary.ToString() && SelectedCategory == employee.Sex) return false;
                    Regex regex = new Regex(@"^[0-9]+$");
                    if (employee == null) return false;
                    return true;

                },
                (p) =>
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin nhân viên", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        var List = DataProvider.Ins.DB.EMPLOYEEs.Where(x => x.IdEmployee == employee.IdEmployee).SingleOrDefault();
                        List.Name = p.txbName.Text;
                        List.Address = p.txbAddress.Text;
                        List.CCCD = p.txbCCCD.Text;
                        List.Phone = p.txbPhone.Text;
                        List.BirthDay = p.dtpBirth.SelectedDate;
                        List.Position = p.txbPosition.Text;
                        List.Salary = p.txbSalary.Text;
                        List.Sex = p.cbSex.Text;
                        DataProvider.Ins.DB.SaveChanges();
                        OnPropertyChanged("List");
                        IsClose = false;
                        p.Close();
                    }
                }
                );

            CloseCommand = new RelayCommand<wd_EditEmployee>(
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
