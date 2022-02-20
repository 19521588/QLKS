using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.ViewModel
{
    public class PhongViewModel : BaseViewModel
    {
        private ObservableCollection<ListRoom> _SingleRoom { get; set; }
        public ObservableCollection<ListRoom> SingleRoom { get => _SingleRoom; set { _SingleRoom = value; OnPropertyChanged(); } }

        public List<ROOM> list { get; set; }

        public PhongViewModel()
        {
            
            Load();
            
        }
        void Load()
        {
            SingleRoom = new ObservableCollection<ListRoom>();
            var rooms = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs);
            foreach(var item in rooms)
            {
                ListRoom temp = new ListRoom();
                var category_rooms = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == item.IdCategoryRoom && x.IdCategoryRoom==1).SingleOrDefault();
                temp.Room = item;
                if(item.Status== "Phòng trống")
                {
                    temp.IsDay = true;
                    temp.SoGio = 0;
                    temp.SoNgayO = 0;
                    temp.TenKH = "Phòng trống";
                    temp.CategoryRoom = category_rooms.Name;
                    temp.DonDep = item.Clean;
                }
                SingleRoom.Add(temp);
            }
        }
        

    }
}
