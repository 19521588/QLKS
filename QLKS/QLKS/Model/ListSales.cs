
using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    public class ListSales : BaseViewModel
    {
        private string _CategoryRoom { get; set; }
        public string CategoryRoom { get => _CategoryRoom; set { _CategoryRoom = value; OnPropertyChanged(); } }
        private int _STT { get; set; }
        public int STT { get => _STT; set { _STT = value; OnPropertyChanged(); } }
        private int _TotalMoney { get; set; }
        public int TotalMoney { get => _TotalMoney; set { _TotalMoney = value; OnPropertyChanged(); } }

        private float _Rate { get; set; }
        public float Rate { get => _Rate; set { _Rate = value; OnPropertyChanged(); } }
    }
}
