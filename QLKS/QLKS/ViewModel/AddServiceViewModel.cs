using QLKS.DATA;
using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class AddServiceViewModel : BaseViewModel
    {
        public ICommand CloseAddWindowCommand { get; set; }

        public ICommand AddServiceCommand { get; set; }

        private ObservableCollection<CATEGORY_SERVICE> _ListCategory;
        public ObservableCollection<CATEGORY_SERVICE> ListCategory { get => _ListCategory; set { _ListCategory = value; OnPropertyChanged(); } }

        public AddServiceViewModel()
        {
            AddModel add = new AddModel();

            //Khởi tạo List
            ListCategory = new ObservableCollection<CATEGORY_SERVICE>(DataProvider.Ins.DB.CATEGORY_SERVICE);

            //Đóng cửa số thêm dịch vụ
            CloseAddWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                p.Close();
            }
            );

            //Thêm dịch vụ
            AddServiceCommand = new RelayCommand<wd_AddService>((p) => {
                if (String.IsNullOrEmpty(p.txtTenDichVu.Text) || String.IsNullOrEmpty(p.txtGia.Text) || String.IsNullOrEmpty(p.cmbMaLoai.Text)) {
                    return false;
                }
                return true;
            }, 
            (p) => 
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm dịch vụ này", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    int id_category = DataProvider.Ins.DB.CATEGORY_SERVICE.Where(x => x.Name == p.cmbMaLoai.Text).SingleOrDefault().IdCategoryService;
                    var new_service = new SERVICE()
                    {
                        Name = p.txtTenDichVu.Text,
                        IdCategoryService = id_category,
                        Price = Int32.Parse(p.txtGia.Text)
                    };
                    add.AddService(new_service);
                    p.Close();
                }
                
            });

        }
    }
}
