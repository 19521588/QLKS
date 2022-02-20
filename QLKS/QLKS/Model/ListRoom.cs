using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    public class ListRoom : BaseViewModel
    {
        private ROOM _Room { get; set; }
        public ROOM Room { get => _Room; set { _Room = value; OnPropertyChanged(); } }
        private String _CategoryRoom { get; set; }
        public String CategoryRoom { get => _CategoryRoom; set { _CategoryRoom = value; OnPropertyChanged(); } }
        private String _TenKH { get; set; }
        public String TenKH { get => _TenKH; set { _TenKH = value; OnPropertyChanged(); } }
        private bool _IsDay { get; set; }
        public bool IsDay { get => _IsDay; set { _IsDay = value; OnPropertyChanged(); } }
        private int _SoNgayO { get; set; }
        public int SoNgayO { get => _SoNgayO; set { _SoNgayO = value; OnPropertyChanged(); } }
        private int _SoGio { get; set; }
        public int SoGio { get => _SoGio; set { _SoGio = value; OnPropertyChanged(); } }
        private String _DonDep { get; set; }
        public String DonDep { get => _DonDep; set { _DonDep = value; OnPropertyChanged(); } }

    }
}
