using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class AddConvenientViewModel : BaseViewModel
    {
        public ICommand CloseAddWindowCommand { get; set; }

        public ICommand AddConvenientCommand { get; set; }
        public AddConvenientViewModel()
        {
            //Đóng cửa số thêm dịch vụ
            CloseAddWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                p.Close();
            }
            );

            //Thêm tiện nghi
            AddConvenientCommand = new RelayCommand<wd_AddConvenient>((p) => {
                if (String.IsNullOrEmpty(p.txtTenTN.Text))
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm tiện ích này", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    var new_convenient = new CONVINIENT()
                    {
                        Name = p.txtTenTN.Text,

                    };
                    DataProvider.Ins.DB.CONVINIENTs.Add(new_convenient);
                    DataProvider.Ins.DB.SaveChanges();
                    p.Close();
                }

                
            });
        }
    }
}
