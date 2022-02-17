using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    public class ListBillInfo:BaseViewModel
    {
        private BILLINFO _BillInfo { get; set; }
        public BILLINFO BillInfo { get => _BillInfo; set { _BillInfo = value; OnPropertyChanged(); } }

        private int _STT { get; set; }
        public int STT { get => _STT; set { _STT = value; OnPropertyChanged(); } }
        private long _Total { get; set; }
        public long Total { get => _Total; set { _Total = value; OnPropertyChanged(); } }
    }
}
