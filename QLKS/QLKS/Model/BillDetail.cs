using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    public class BillDetail : BaseViewModel
    {
        private String _Name { get; set; }
        public String Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private String _CCCD { get; set; }
        public String CCCD { get => _CCCD; set { _CCCD = value; OnPropertyChanged(); } }
        private String _Phone { get; set; }
        public String Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }
        private int _AmountRenter { get; set; }
        public int AmountRenter { get => _AmountRenter; set { _AmountRenter = value; OnPropertyChanged(); } }
        private DateTime _StartDate { get; set; }
        public DateTime StartDate { get => _StartDate; set { _StartDate = value; OnPropertyChanged(); } }
        private DateTime _EndDate { get; set; }
        public DateTime EndDate { get => _EndDate; set { _EndDate = value; OnPropertyChanged(); } }
        private long _RoomCharge { get; set; }
        public long RoomCharge { get => _RoomCharge; set { _RoomCharge = value; OnPropertyChanged(); } }
        private long _ServiceCharge { get; set; }
        public long ServiceCharge { get => _ServiceCharge; set { _ServiceCharge = value; OnPropertyChanged(); } }

    }
}
