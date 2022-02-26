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
    public class EditServiceViewModel : BaseViewModel
    {
        private string _Name { get; set; }
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private int _Price { get; set; }
        public int Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }
        private string _CategoryName { get; set; }
        public string CategoryName { get => _CategoryName; set { _CategoryName = value; OnPropertyChanged(); } }
        private int _Id { get; set; }
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        private int _IdCategory { get; set; }
        public int IdCategory { get => _IdCategory; set { _IdCategory = value; OnPropertyChanged(); } }

        public ICommand CloseEditWindowCommand { get; set; }
        public ICommand EditServiceCommand { get; set; }

        private ObservableCollection<CATEGORY_SERVICE> _ListCategory;
        public ObservableCollection<CATEGORY_SERVICE> ListCategory { get => _ListCategory; set { _ListCategory = value; OnPropertyChanged(); } }

        public EditServiceViewModel(SERVICE x)
        {
            //Khởi tạo data
            Name = x.Name;
            Price = x.Price;
            Id = x.IdService;
            IdCategory = (int)x.IdCategoryService;
            CategoryName = DataProvider.Ins.DB.CATEGORY_SERVICE.Where(y => y.IdCategoryService == IdCategory).SingleOrDefault().Name;

            //Khởi tạo List
            ListCategory = new ObservableCollection<CATEGORY_SERVICE>(DataProvider.Ins.DB.CATEGORY_SERVICE);

            //Đóng cửa số thêm dịch vụ
            CloseEditWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                p.Close();
            }
            );

            //Cập nhật thồn tin dịch vụ
            EditServiceCommand = new RelayCommand<wd_EditService>((p) => 
            {
                if (String.IsNullOrEmpty(p.txtTenDichVu.Text) || String.IsNullOrEmpty(p.txtGia.Text) || String.IsNullOrEmpty(p.cmbMaLoai.Text))
                {
                    return false;
                }
                return true; 
            }, 
            (p) => 
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật dịch vụ này", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    var in4 = DataProvider.Ins.DB.SERVICEs.Where(y => y.IdService == Id).SingleOrDefault();
                    in4.Name = Name;
                    in4.Price = Price;
                    in4.IdCategoryService = DataProvider.Ins.DB.CATEGORY_SERVICE.Where(z => z.Name == CategoryName).SingleOrDefault().IdCategoryService;
                    DataProvider.Ins.DB.SaveChanges();

                    p.Close();
                }
               
            }
            );
        }
    }
}
