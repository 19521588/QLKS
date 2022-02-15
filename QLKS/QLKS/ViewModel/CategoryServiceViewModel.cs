using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class CategoryServiceViewModel : BaseViewModel
    {
        private ObservableCollection<CATEGORY_SERVICE> _ListCategoryService { get; set; }
        public ObservableCollection<CATEGORY_SERVICE> ListCategoryService { get => _ListCategoryService; set { _ListCategoryService = value; OnPropertyChanged(); } }
        public ICommand OpenAddWindowCommand { get; set; }

        public CategoryServiceViewModel()
        {
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


        }

        void Load()
        {
            ListCategoryService = new ObservableCollection<CATEGORY_SERVICE>(DataProvider.Ins.DB.CATEGORY_SERVICE);
        }
    }
}
