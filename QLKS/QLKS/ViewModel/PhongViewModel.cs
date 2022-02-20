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
        private ObservableCollection<ROOM> _ListRoom { get; set; }
        public ObservableCollection<ROOM> ListRoom { get => _ListRoom; set { _ListRoom = value; OnPropertyChanged(); } }

        public List<ROOM> list { get; set; }

        public PhongViewModel()
        {
            Load();
            
        }
        void Load()
        {
            ListRoom = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs);
            list = new List<ROOM>();
            foreach(var item in ListRoom)
            {
                list.Add(item);
            }
        }
    }
}
