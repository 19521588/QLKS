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
        public AddCategoryServiceViewModel()
        {
            //Đóng cửa số thêm loại dịch vụ
            CloseAddWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                p.Close();
            }
            );
        }
    }
}
