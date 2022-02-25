using QLKS.Model;
using QuanLyGaraOto.Convert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ChangePasswordViewModel(USER user)
        {
            CloseCommand = new RelayCommand<wd_ChangePassword>(
            (p) =>
            { return true; },
            (p) =>
            {

                p.Close();
            }
            );

            ChangeCommand = new RelayCommand<wd_ChangePassword>(
            (p) => 
            { 
                if (String.IsNullOrEmpty(p.txbCurentPass.Password) || String.IsNullOrEmpty(p.txbNewPass.Password) || String.IsNullOrEmpty(p.txbConfirmPass.Password))
                {
                    return false;
                }    
                return true; 
            },
            (p) =>
            {
                HashConvert hash = new HashConvert();
                //string passEncode = hash.GetHash(Password);
                if (p.txbNewPass.Password != p.txbConfirmPass.Password)
                {
                    MessageBox.Show("Mật khẩu mới không khớp!");
                }    
                else if (user.Password != hash.GetHash(p.txbCurentPass.Password))
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng!");
                }
                else
                {
                    var Temp = DataProvider.Ins.DB.USERS.Where(x => x.Users_Id == user.Users_Id).SingleOrDefault();
                    Temp.Password = hash.GetHash(p.txbNewPass.Password);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Thành công");
                    p.Close();
                }
            });
        }
    }
}
