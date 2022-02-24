using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using QLKS.Model;

namespace QLKS.ViewModel
{
    public class ReservationDetailViewModel : BaseViewModel
    {
        ICommand CloseCommand { get; set; }

        private ObservableCollection<RESERVATION_DETAIL> _ListReservationDetail { get; set; }
        public ObservableCollection<RESERVATION_DETAIL> ListReservationDetail { get => _ListReservationDetail; set { _ListReservationDetail = value; OnPropertyChanged(); } }

        private RESERVATION _Reservation { get; set; }
        public RESERVATION Reservation { get => _Reservation; set { _Reservation = value;OnPropertyChanged(); } }
        public ReservationDetailViewModel(RESERVATION reservation)
        {
            Reservation = reservation;

            ListReservationDetail = new ObservableCollection<RESERVATION_DETAIL>(DataProvider.Ins.DB.RESERVATION_DETAIL.Where(x=> x.IdReservation == reservation.IdReservation));

            CloseCommand = new RelayCommand<wd_ReservationDetail>(
            (p) =>
            { return true; },
            (p) =>
            {
                p.Close();
            }
            );
        }
    }
}
