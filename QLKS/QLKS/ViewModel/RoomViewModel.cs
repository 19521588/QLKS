using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.ViewModel;
using QLKS.Model;
using System.Windows.Input;
using QLKS.Convert;
using QLKS.UserControlss;
using QLKS.DATA;

namespace QLKS.ViewModel
{
    public class RoomViewModel : BaseViewModel
    {
        public ICommand OpenAddCommand { get; set; }

        public ICommand OpenEditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand RefreshCommand { get; set; }

        private ObservableCollection<ROOM> _ListRoom { get; set; }
        public ObservableCollection<ROOM> ListRoom { get => _ListRoom; set { _ListRoom = value; OnPropertyChanged(); } }

        private string _Name { get; set; }

        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Status { get; set; }

        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

        private string _Category { get; set; }

        public string Category { get => _Category; set { _Category = value; OnPropertyChanged(); } }
        private ROOM _SelectedItem { get; set; }
        public ROOM SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Name = _SelectedItem.Name.ToString();
                    //Status = _SelectedItem.Status.ToString();
                    
                    Category = _SelectedItem.IdCategoryRoom.ToString();
                }
                OnPropertyChanged();
            }
        }
        public RoomViewModel()
        {
            GetModel get = new GetModel();
            LoadRoom();
            OpenAddCommand = new RelayCommand<MainWindow>((p) => true, (p) =>
            {

                wd_AddNewRoom wdAddRooms = new wd_AddNewRoom();

                wdAddRooms.txbName.Text = "";
                wdAddRooms.ShowDialog();

                AddRoomViewModel add = wdAddRooms.DataContext as AddRoomViewModel;
                if (add.check)
                    ListRoom.Insert(0, add.room);
            });
            OpenEditCommand = new RelayCommand<MainWindow>((p) => {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                wd_EditRoom wdAddRooms = new wd_EditRoom(SelectedItem);

                wdAddRooms.txbName.Text = SelectedItem.Name;
                //wdAddRooms.cbCategory.SelectedItem = SelectedItem.CATEGORY_ROOM;
                wdAddRooms.ShowDialog();
                LoadRoom();
            });
            DeleteCommand = new RelayCommand<MainWindow>((p) => {
                if (SelectedItem == null) return false;
                return true;
            }, (p) =>
            {
                var Temp = DataProvider.Ins.DB.ROOMs.Where(x => x.Name == SelectedItem.Name);
                if (Temp.Count() == 0)
                {
                    DeleteModel delete = new DeleteModel();
                    delete.DeleteRoom(SelectedItem);
                    ListRoom.Remove(SelectedItem);
                }    
            });
            SearchCommand = new RelayCommand<uc_RoomManage>((p) =>
            {            
                return true;
            }, (p) =>
            {
                UnicodeConvert uni = new UnicodeConvert();

                ObservableCollection<ROOM> _ListTemp = new ObservableCollection<ROOM>();
                ObservableCollection<ROOM> _ListNew = get.getListRoom();

                foreach (var item in _ListNew)
                {
                    if (uni.RemoveUnicode(item.Name).ToLower().Contains(uni.RemoveUnicode(p.txbRoomSearch.Text)))
                        _ListTemp.Add(item);
                }
                ListRoom = _ListTemp;
            });
            RefreshCommand = new RelayCommand<MainWindow>((p) => 
            {
                return true;
            }, (p) =>
            {
                LoadRoom();
            });

            void LoadRoom()
            {

                ListRoom = new ObservableCollection<ROOM>();
                ObservableCollection<ROOM> temp = get.getListRoom();
                for (int i = temp.Count() - 1; i >= 0; i--)
                {
                    ListRoom.Add(temp[i]);
                }
            }
        }

        
    }
}
