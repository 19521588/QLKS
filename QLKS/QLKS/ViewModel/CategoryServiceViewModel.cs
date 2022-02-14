using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.ViewModel
{
    public class CategoryServiceViewModel : BaseViewModel
    {
        private ObservableCollection<CATEGORY_SERVICE> _ListCategoryService { get; set; }
        public ObservableCollection<CATEGORY_SERVICE> ListCategoryService { get => _ListCategoryService; set { _ListCategoryService = value; OnPropertyChanged(); } }

        public CategoryServiceViewModel()
        {
            Load();
        }

        void Load()
        {
            ListCategoryService = new ObservableCollection<CATEGORY_SERVICE>();
            ObservableCollection<CATEGORY_SERVICE> temp = new ObservableCollection<CATEGORY_SERVICE>(DataProvider.Ins.DB.CATEGORY_SERVICE);
            for (int i = temp.Count() - 1; i >= 0; i--)
            {
                ListCategoryService.Add(temp[i]);
            }
        }
    }
}
