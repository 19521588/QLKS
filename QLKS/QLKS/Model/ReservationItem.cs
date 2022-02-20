using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    class ReservationItem : BaseViewModel
    {
        private RESERVATION_DETAIL _reservation_detail { get; set; }

        public RESERVATION_DETAIL reservation_detail { get => _reservation_detail; set { _reservation_detail = value; OnPropertyChanged(); } }
    }
}
