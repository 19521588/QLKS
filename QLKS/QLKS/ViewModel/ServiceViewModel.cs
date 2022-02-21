using QLKS.Convert;
using QLKS.Model;
using QLKS.UserControlss;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class ServiceViewModel : BaseViewModel
    {
        private ObservableCollection<SERVICE> _ListService { get; set; }
        public ObservableCollection<SERVICE> ListService { get => _ListService; set { _ListService = value; OnPropertyChanged(); } }

        private ObservableCollection<CATEGORY_SERVICE> _ListCategory;
        public ObservableCollection<CATEGORY_SERVICE> ListCategory { get => _ListCategory; set { _ListCategory = value; OnPropertyChanged(); } }

        public ICommand OpenAddWindowCommand { get; set; }
        public ICommand OpenEditServiceWindowCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RefeshCommand { get; set; }

        private SERVICE _SelectedItem { get; set; }
        public SERVICE SelectedItem
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

        public ServiceViewModel()
        {
            Load();

            ListCategory = new ObservableCollection<CATEGORY_SERVICE>(DataProvider.Ins.DB.CATEGORY_SERVICE);

            //Mở cửa số để thêm dịch vụ
            OpenAddWindowCommand = new RelayCommand<object>((p) => {
                return true; 
            }, 
            (p) => {
                wd_AddService wd = new wd_AddService();
                wd.ShowDialog();
                Load();
            });

            //Mở cửa số để sửa dịch vụ
            OpenEditServiceWindowCommand = new RelayCommand<object>((p) => {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;
            },
            (p) => {
                wd_EditService wd = new wd_EditService(SelectedItem);
                wd.ShowDialog();
                Load();
            });

            //Tìm kiếm
            SearchCommand = new RelayCommand<uc_QuanLyDichVu>((p) => 
            {
                if (String.IsNullOrEmpty(p.txbTenDV.Text) && String.IsNullOrEmpty(p.cbCategoryService.Text))
                {
                    return false;
                }
                return true;
            },
            (p) => {
                UnicodeConvert uni = new UnicodeConvert();

                ObservableCollection<SERVICE> _ListTempt = new ObservableCollection<SERVICE>();
                ObservableCollection<SERVICE> _ListNew = new ObservableCollection<SERVICE>(DataProvider.Ins.DB.SERVICEs);

                foreach (var item in _ListNew)
                {
                    if ((string.IsNullOrEmpty(p.txbTenDV.Text) || (!string.IsNullOrEmpty(p.txbTenDV.Text) && uni.RemoveUnicode(item.Name).ToLower().Contains(uni.RemoveUnicode(p.txbTenDV.Text).ToLower())))
                        && (string.IsNullOrEmpty(p.cbCategoryService.Text) || (!string.IsNullOrEmpty(p.cbCategoryService.Text) && uni.RemoveUnicode(item.CATEGORY_SERVICE.Name).ToLower().Contains(uni.RemoveUnicode(p.cbCategoryService.Text).ToLower()))))
                    {
                        _ListTempt.Add(item);
                    }
                }

                ListService = _ListTempt;
            });

            //Làm mới
            RefeshCommand = new RelayCommand<uc_QuanLyDichVu>((p) =>
            {
                return true;
            },
            (p) =>
            {             
                p.txbTenDV.Text = null;
                p.cbCategoryService.Text = null;
                Load();
            });
        }

        void Load()
        {
            ListService = new ObservableCollection<SERVICE>(DataProvider.Ins.DB.SERVICEs);
        }
    }
}
