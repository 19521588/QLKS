using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    public class ListService : BaseViewModel
    {
        private RENTALDETAIL _RentalDetail { get; set; }
        public RENTALDETAIL RentalDetail { get => _RentalDetail; set { _RentalDetail = value; OnPropertyChanged(); } }

        private int _STT { get; set; }
        public int STT { get => _STT; set { _STT = value; OnPropertyChanged(); } }
        private SERVICE _Service { get; set; }
        public SERVICE Service { get => _Service; set { _Service = value; OnPropertyChanged(); } }

    }
}
