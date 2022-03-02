using QLKS.Convert;
using QLKS.Model;
using QLKS.UserControlss;
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
    public class CategoryServiceViewModel : BaseViewModel
    {
        private ObservableCollection<CATEGORY_SERVICE> _ListCategoryService { get; set; }
        public ObservableCollection<CATEGORY_SERVICE> ListCategoryService { get => _ListCategoryService; set { _ListCategoryService = value; OnPropertyChanged(); } }
        public ICommand OpenAddWindowCommand { get; set; }
        public ICommand OpenEditCategoryServiceWindowCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RefeshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private CATEGORY_SERVICE _SelectedItem { get; set; }
        public CATEGORY_SERVICE SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;

                if (SelectedItem != null)
                {

                }
                OnPropertyChanged();
            }
        }

        public CategoryServiceViewModel()
        {
            DeleteModel delete = new DeleteModel();
            Load();

            //Mở cửa số để thêm loại dịch vụ
            OpenAddWindowCommand = new RelayCommand<object>((p) => {
                return true;
            },
            (p) => {
                wd_AddCategoryService wd = new wd_AddCategoryService();
                wd.ShowDialog();
                Load();
            });

            //Mở cửa số để sửa loại dịch vụ
            OpenEditCategoryServiceWindowCommand = new RelayCommand<object>((p) => {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;
            },
            (p) => {
                wd_EditCategoryService wd = new wd_EditCategoryService(SelectedItem);
                wd.ShowDialog();
                Load();
            });

            //Tìm kiếm
            SearchCommand = new RelayCommand<uc_QuanLyLoaiDichVu>((p) =>
            {
                if (String.IsNullOrEmpty(p.txbTenLoaiDV.Text))
                {
                    return false;
                }
                return true;
            },
            (p) => {
                UnicodeConvert uni = new UnicodeConvert();

                ObservableCollection<CATEGORY_SERVICE> _ListTempt = new ObservableCollection<CATEGORY_SERVICE>();
                ObservableCollection<CATEGORY_SERVICE> _ListNew = new ObservableCollection<CATEGORY_SERVICE>(DataProvider.Ins.DB.CATEGORY_SERVICE);

                foreach (var item in _ListNew)
                {
                    if ((string.IsNullOrEmpty(p.txbTenLoaiDV.Text) || (!string.IsNullOrEmpty(p.txbTenLoaiDV.Text) && uni.RemoveUnicode(item.Name).ToLower().Contains(uni.RemoveUnicode(p.txbTenLoaiDV.Text).ToLower()))))
                    {
                        _ListTempt.Add(item);
                    }
                }

                ListCategoryService = _ListTempt;
            });

            //Làm mới
            RefeshCommand = new RelayCommand<uc_QuanLyLoaiDichVu>((p) =>
            {
                return true;
            },
            (p) =>
            {
                p.txbTenLoaiDV.Text = null;
                Load();
            });

            //Xóa
            DeleteCommand = new RelayCommand<uc_QuanLyLoaiDichVu>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            },
            (p) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa loại dịch vụ này", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    var in4 = DataProvider.Ins.DB.CATEGORY_SERVICE.Where(y => y.IdCategoryService == SelectedItem.IdCategoryService).SingleOrDefault();

                    ObservableCollection<SERVICE> ListService = new ObservableCollection<SERVICE>(DataProvider.Ins.DB.SERVICEs.Where(x=>x.IdCategoryService==in4.IdCategoryService)); 

                    if (ListService.Count() > 0)
                    {
                        MessageBox.Show("Loại dịch vụ này đang được sử dụng", "Xóa thất bại", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }   
                    else
                    {
                        delete.DeleteCategoryService(in4);
                        Load();
                    }                     

                }
            });
        }

        void Load()
        {
            ListCategoryService = new ObservableCollection<CATEGORY_SERVICE>(DataProvider.Ins.DB.CATEGORY_SERVICE);
        }
    }
}
