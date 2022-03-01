using QLKS.Convert;
using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class AddServiceDRViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand TxbChangedCommand { get; set; }
        public ICommand CbChangedCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand AmountChangedCommand { get; set; }

        private ServiceCt _SelectedItem { get; set; }
        public ServiceCt SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }
        private bool _isSave { get; set; }
        public bool IsSave { get => _isSave; set { _isSave = value; OnPropertyChanged(); } }
        private SelectService _SelectedValue { get; set; }
        public SelectService SelectedValue { get => _SelectedValue; set { _SelectedValue = value; OnPropertyChanged(); } }

        private CATEGORY_SERVICE _SelectedCategory { get; set; }
        public CATEGORY_SERVICE SelectedCategory { get => _SelectedCategory; set { _SelectedCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<SelectService> _SelectListService { get; set; }
        public ObservableCollection<SelectService> SelectListService { get => _SelectListService; set { _SelectListService = value; OnPropertyChanged(); } }
        private ObservableCollection<ServiceCt> _ListService { get; set; }
        public ObservableCollection<ServiceCt> ListService { get => _ListService; set { _ListService = value; OnPropertyChanged(); } }
        private ObservableCollection<ServiceCt> _TempListService { get; set; }
        public ObservableCollection<ServiceCt> TempListService { get => _TempListService; set { _TempListService = value; OnPropertyChanged(); } }

        private ObservableCollection<CATEGORY_SERVICE> _CategoryService { get; set; }
        public ObservableCollection<CATEGORY_SERVICE> CategoryService { get => _CategoryService; set { _CategoryService = value; OnPropertyChanged(); } }

        public AddServiceDRViewModel(ObservableCollection<SelectService> listService)
        {
            Load(listService);
            TempListService = ListService;
            CloseCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                IsSave = false;
                p.Close();

            });

            CbChangedCommand = new RelayCommand<DetailRoom_AddService>((p) =>
            {
                return true;
            }, (p) =>
            {

                var temp = p.cbTimKiemLoaiDV.SelectedItem as CATEGORY_SERVICE;
                ListService = new ObservableCollection<ServiceCt>(LoadByChanged(TempListService, temp.Name, p.txbTimKiem.Text));

            });
            TxbChangedCommand = new RelayCommand<DetailRoom_AddService>((p) =>
            {
                return true;
            }, (p) =>
            {
                var temp = p.cbTimKiemLoaiDV.SelectedItem as CATEGORY_SERVICE;
                ListService = new ObservableCollection<ServiceCt>(LoadByChanged(TempListService, temp.Name, p.txbTimKiem.Text));

            });
            DeleteCommand = new RelayCommand<DetailRoom_AddService>((p) =>
            {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                SelectListService.Remove(SelectedValue);
                if (SelectListService.Count() != 0)
                {
                    int i = 1;
                    foreach (var item in SelectListService)
                    {
                        item.STT = i;
                        i++;
                    }
                }
            });
            SaveCommand = new RelayCommand<DetailRoom_AddService>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn lưu  thay đổi", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    IsSave = true;
                    p.Close();
                }
            });

            AddCommand = new RelayCommand<DetailRoom_AddService>((p) =>
            {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                if (SelectListService.Where(x => x.Service == SelectedItem.Service).Count() != 0)
                {
                    SelectListService.Where(x => x.Service == SelectedItem.Service).SingleOrDefault().Amount++;
                    var amount = SelectListService.Where(x => x.Service == SelectedItem.Service).SingleOrDefault().Amount;
                    var price = SelectListService.Where(x => x.Service == SelectedItem.Service).SingleOrDefault().Service.Price;
                    SelectListService.Where(x => x.Service == SelectedItem.Service).SingleOrDefault().Total = amount * price;
                }
                else
                {
                    var temp = new SelectService();
                    int i = SelectListService.Count();
                    temp.STT = i + 1;
                    temp.Service = SelectedItem.Service;
                    temp.Amount = 1;
                    temp.Total = temp.Amount * SelectedItem.Service.Price;
                    SelectListService.Add(temp);
                }

            });

        }
        public void Load(ObservableCollection<SelectService> listService)
        {
            ListService = new ObservableCollection<ServiceCt>();
            SelectListService = new ObservableCollection<SelectService>();
            CategoryService = new ObservableCollection<CATEGORY_SERVICE>(DataProvider.Ins.DB.CATEGORY_SERVICE);
            var a = new CATEGORY_SERVICE();
            a.Name = "Tất cả";
            CategoryService.Add(a);
            var service = DataProvider.Ins.DB.SERVICEs.ToList();
            int i = 1;
            foreach (var item in service)
            {
                var temp = new ServiceCt();
                var category = DataProvider.Ins.DB.CATEGORY_SERVICE.Where(x => x.IdCategoryService == item.IdCategoryService).SingleOrDefault();
                temp.Service = item;
                temp.Category = category.Name;
                temp.STT = i;
                ListService.Add(temp);
                i++;
            }
            if(listService!=null)
            {
                SelectListService=listService;
            }
           
            SelectedCategory = a;
        }
        public List<ServiceCt> LoadByChanged(ObservableCollection<ServiceCt> list, string cbCategory, string txbSearch)
        {
            UnicodeConvert uni = new UnicodeConvert();
            if (cbCategory != "Tất cả" && txbSearch != "")
            {

                return list.Where(x => x.Category == cbCategory && uni.RemoveUnicode(x.Service.Name).ToLower().Contains(uni.RemoveUnicode(txbSearch).ToLower())).ToList();
            }
            if (cbCategory != "Tất cả" && txbSearch == "")
            {
                return list.Where(x => x.Category == cbCategory).ToList();
            }
            if (cbCategory == "Tất cả" && txbSearch != "")
            {
                return list.Where(x => uni.RemoveUnicode(x.Service.Name).ToLower().Contains(uni.RemoveUnicode(txbSearch).ToLower())).ToList();
            }

            return list.ToList();
        }
    }
}
