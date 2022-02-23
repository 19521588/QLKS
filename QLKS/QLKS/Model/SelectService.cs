using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    public class SelectService:BaseViewModel
    {
        private int _STT { get; set; }
        public int STT { get => _STT; set { _STT = value; OnPropertyChanged(); } }
        private SERVICE _Service { get; set; }
        public SERVICE Service { get => _Service; set { _Service = value; OnPropertyChanged(); } }
        private int _Amount { get; set; }
        public int Amount { get => _Amount; set { _Amount = value; OnPropertyChanged(); } }
        private int _Total { get; set; }
        public int Total { get => _Total; set { _Total = value; OnPropertyChanged(); } }
    }
}
