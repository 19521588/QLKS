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
    public class AddCategoryServiceViewModel: BaseViewModel
    {
        public ICommand CloseAddWindowCommand { get; set; }

        public ICommand AddCategoryServiceCommand { get; set; }
        public AddCategoryServiceViewModel()
        {
            //Đóng cửa số thêm loại dịch vụ
            CloseAddWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                p.Close();
            }
            );

            //Thêm dịch vụ
            AddCategoryServiceCommand = new RelayCommand<wd_AddCategoryService>((p) => {
                if (String.IsNullOrEmpty(p.txtTenLoaiDV.Text))
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm loại dịch vụ này", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    var new_category_service = new CATEGORY_SERVICE()
                    {
                        Name = p.txtTenLoaiDV.Text,
                    };
                    DataProvider.Ins.DB.CATEGORY_SERVICE.Add(new_category_service);
                    DataProvider.Ins.DB.SaveChanges();
                    p.Close();
                }

                
            });
        }
    }
}
