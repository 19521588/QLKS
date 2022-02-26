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
                if (MessageBox.Show("Bạn có chắc chắn muốn thay đổi mật khẩu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    HashConvert hash = new HashConvert();                   
                    if (p.txbNewPass.Password != p.txbConfirmPass.Password)
                    {
                        MessageBox.Show("Mật khẩu mới không khớp!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else if (user.Password != hash.GetHash(p.txbCurentPass.Password))
                    {
                        MessageBox.Show("Mật khẩu hiện tại không đúng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        var Temp = DataProvider.Ins.DB.USERS.Where(x => x.Users_Id == user.Users_Id).SingleOrDefault();
                        Temp.Password = hash.GetHash(p.txbNewPass.Password);
                        DataProvider.Ins.DB.SaveChanges();
                        MessageBox.Show("Thành công","Thông báo",MessageBoxButton.OK,MessageBoxImage.Information);
                        p.Close();
                    }
                }                
            });
        }
    }
}
