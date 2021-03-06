using QLKS.DATA;
using QLKS.Model;
using QLKS.ViewModel;
using QuanLyGaraOto.Convert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLKS.ViewModel
{

    public class LoginViewModel : BaseViewModel
    {
        public bool IsLogin { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        private USER _User;
        public USER User { get => _User; set { _User = value; OnPropertyChanged(); } }
        public ICommand PasswordChangedCommand { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }
     

        public LoginViewModel()
        {
            IsClose = true;

            IsLogin = false;
            Password = "";
            UserName = "";
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                Login(p);
            });
            CloseCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                p.Close();
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }
        void Login(Window p)
        {
            GetModel getModel = new GetModel();
            if (p == null)
            {
                return;
            }
            HashConvert hash = new HashConvert();
            string passEncode = hash.GetHash(Password);
            var accCount = getModel.GetUserByUserNameAndPassword(UserName, passEncode).Count();

            if (accCount > 0)
            {
                User = getModel.GetUserByUserNameAndPassword(UserName, passEncode).SingleOrDefault();
                IsLogin = true;
                IsClose = false;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản và mật khẩu!");
            }

        }
        public void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsClose)
            {
                if (MessageBox.Show("Bạn chắc chắn muốn đóng ứng dụng", "Thông báo",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    e.Cancel = false;
                }
                else e.Cancel = true;
            }
        }

    }
}