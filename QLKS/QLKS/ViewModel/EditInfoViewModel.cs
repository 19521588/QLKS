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
    public class EditInfoViewModel:BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand EditCommand { get; set; }
        private String _SelectedSex { get; set; }
        public String SelectedSex { get => _SelectedSex; set { _SelectedSex = value; OnPropertyChanged(); } }
        public EditInfoViewModel(EMPLOYEE employee)
        {
            SelectedSex = employee.Sex;

            //Đóng cửa số 
            CloseCommand = new RelayCommand<EditInfo>((p) => { return true; }, (p) => {

                p.Close();
            }
            );

            EditCommand = new RelayCommand<EditInfo>(
               (p) =>
               {

                   var Temp = DataProvider.Ins.DB.EMPLOYEEs.Where(x => x.Name == p.txbName.Text);
                   if ((Temp == null || Temp.Count() != 0) && p.txbName.Text != employee.Name) return false;
                   if (string.IsNullOrEmpty(p.txbName.Text) || string.IsNullOrEmpty(p.txbCCCD.Text) || string.IsNullOrEmpty(p.txbPhone.Text) || string.IsNullOrEmpty(p.txbAddress.Text))
                       return false;
                   if (p.txbName.Text == employee.Name && p.txbAddress.Text == employee.Address.ToString() && p.txbCCCD.Text == employee.CCCD.ToString() && p.txbPhone.Text == employee.Phone.ToString() && p.cbSex.Text == employee.Sex && p.dtpBirth.SelectedDate.ToString() == employee.BirthDay.ToString()) return false;
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
                       List.Sex = p.cbSex.Text;
                       DataProvider.Ins.DB.SaveChanges();
                       OnPropertyChanged("List");                      
                       p.Close();
                   }
               }
               );
        }
    }
}
