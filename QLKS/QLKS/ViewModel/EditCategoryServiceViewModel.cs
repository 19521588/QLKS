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
    public class EditCategoryServiceViewModel : BaseViewModel
    {
        private string _Name { get; set; }
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private int _Id { get; set; }
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }

        public ICommand CloseEditWindowCommand { get; set; }
        public ICommand EditCategoryServiceCommand { get; set; }

        public EditCategoryServiceViewModel(CATEGORY_SERVICE category_service)
        {
            Name = category_service.Name;
            Id = category_service.IdCategoryService;

            //Đóng cửa số thêm dịch vụ
            CloseEditWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                p.Close();
            }
            );

            // Sửa loại dịch vụ 

            //Cập nhật thồn tin dịch vụ
            EditCategoryServiceCommand = new RelayCommand<wd_EditCategoryService>((p) =>
            {
                if (String.IsNullOrEmpty(p.txtTenLoaiDV.Text))
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var in4 = DataProvider.Ins.DB.CATEGORY_SERVICE.Where(y => y.IdCategoryService == Id).SingleOrDefault();
                in4.Name = Name;
                DataProvider.Ins.DB.SaveChanges();

                p.Close();
            }
            );
        }
    }
}
