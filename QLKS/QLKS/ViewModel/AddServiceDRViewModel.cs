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
    public class AddServiceDRViewModel:BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        private ObservableCollection<ListService> _TempListService { get; set; }
        public ObservableCollection<ListService> TempListService { get => _TempListService; set { _TempListService = value; OnPropertyChanged(); } }
        private ObservableCollection<ServiceCt> _ListService { get; set; }
        public ObservableCollection<ServiceCt> ListService { get => _ListService; set { _ListService = value; OnPropertyChanged(); } }
        private ObservableCollection<CATEGORY_SERVICE> _CategoryService { get; set; }
        public ObservableCollection<CATEGORY_SERVICE> CategoryService { get => _CategoryService; set { _CategoryService = value; OnPropertyChanged(); } }

        public AddServiceDRViewModel(ObservableCollection<ListService> listService)
        {
            Load();
            CloseCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {

                p.Close();

            });
        }
        public void Load()
        {
            ListService = new ObservableCollection<ServiceCt>();
            CategoryService= new ObservableCollection<CATEGORY_SERVICE>(DataProvider.Ins.DB.CATEGORY_SERVICE);
            var service = DataProvider.Ins.DB.SERVICEs.ToList();
            int i = 1;
            foreach (var item in service)
            {
                var temp = new ServiceCt();
                var category = DataProvider.Ins.DB.CATEGORY_SERVICE.Where(x => x.IdCategoryService == item.IdService).SingleOrDefault();
                temp.Service = item;
                temp.Category = category.Name;
                temp.STT = i;
                ListService.Add(temp);
                i++;
            }
        }
    }
}
