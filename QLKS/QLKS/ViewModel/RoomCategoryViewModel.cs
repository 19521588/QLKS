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
    public class RoomCategoryViewModel : BaseViewModel
    {

        public ICommand OpenAddCommand { get; set; }
        public ICommand OpenEditCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<CATEGORY_ROOM> _ListCategory { get; set; }
        public ObservableCollection<CATEGORY_ROOM> ListCategory { get => _ListCategory; set { _ListCategory = value; OnPropertyChanged(); } }

        private string _Name { get; set; }

        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Status { get; set; }

        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

        private string _Category { get; set; }

        public string Category { get => _Category; set { _Category = value; OnPropertyChanged(); } }
        private CATEGORY_ROOM _SelectedItem { get; set; }
        public CATEGORY_ROOM SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Name = _SelectedItem.Name.ToString();

                }
                OnPropertyChanged();
            }
        }

        public RoomCategoryViewModel()
        {
            ListCategory = new ObservableCollection<CATEGORY_ROOM>(DataProvider.Ins.DB.CATEGORY_ROOM);
            OpenAddCommand = new RelayCommand<MainWindow>((p) => true, (p) =>
            {

                wd_AddNewCategoryRoom wdAddCategoryRoom = new wd_AddNewCategoryRoom();

                wdAddCategoryRoom.txbName.Text = "";
                wdAddCategoryRoom.ShowDialog();

                AddRoomCategoryViewModel add = wdAddCategoryRoom.DataContext as AddRoomCategoryViewModel;
                if (add.check)
                    ListCategory.Insert(0, add.category);
            });
            OpenEditCommand = new RelayCommand<MainWindow>((p) =>
            {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                wd_EditCategoryRoom wdAddRooms = new wd_EditCategoryRoom(SelectedItem);

                wdAddRooms.txbName.Text = SelectedItem.Name;
                wdAddRooms.txbBeds.Text = SelectedItem.Beds.ToString();
                wdAddRooms.txbPriceDay.Text = SelectedItem.Price_Day.ToString();
                wdAddRooms.txbPriceHour.Text = SelectedItem.Price_Hour.ToString();
                wdAddRooms.ShowDialog();
                Load();
            });
            DeleteCommand = new RelayCommand<MainWindow>((p) =>
            {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {

            });
            SearchCommand = new RelayCommand<uc_RoomCategoryManage>((p) =>
            {
                return true;
            }, (p) =>
            {
                UnicodeConvert uni = new UnicodeConvert();

                ObservableCollection<CATEGORY_ROOM> _ListTemp = new ObservableCollection<CATEGORY_ROOM>();
                ObservableCollection<CATEGORY_ROOM> _ListNew = new ObservableCollection<CATEGORY_ROOM>(DataProvider.Ins.DB.CATEGORY_ROOM);

                foreach (var item in _ListNew)
                {
                    if (uni.RemoveUnicode(item.Name).ToLower().Contains(uni.RemoveUnicode(p.txbCategoryRoomSearch.Text)) || item.Beds == Int32.Parse(p.txbBedSearch.Text))
                        _ListTemp.Add(item);
                }
                ListCategory = _ListTemp;
            });
            RefreshCommand = new RelayCommand<MainWindow>((p) =>
            {
                return true;
            }, (p) =>
            {
                Load();
            });
            void Load()
            {
                ListCategory = new ObservableCollection<CATEGORY_ROOM>(DataProvider.Ins.DB.CATEGORY_ROOM);
            }
        }
    }
}
