using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.ViewModel;
using QLKS.Model;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class RoomViewModel : BaseViewModel
    {
        public ICommand OpenAddCommand { get; set; }

        public ICommand OpenEditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

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

            });
        }

        void LoadRoom()
        {
            ListRoom = new ObservableCollection<ROOM>();
            ObservableCollection<ROOM> temp = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs);
            for (int i = temp.Count() - 1; i >= 0; i--)
            {
                ListRoom.Add(temp[i]);
            }
        }
    }
}
