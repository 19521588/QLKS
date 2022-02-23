using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class RoomDetailViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand AddServiceCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand PaymentCommand { get; set; }
        public ICommand CheckInCommand { get; set; }
        public ICommand LoadCbCommand { get; set; }
        
        private ListRoom _RoomDetail { get; set; }
        public ListRoom RoomDetail { get => _RoomDetail; set { _RoomDetail = value; OnPropertyChanged(); } }
        private ObservableCollection<ListService> _ListService { get; set; }
        public ObservableCollection<ListService> ListService { get => _ListService; set { _ListService = value; OnPropertyChanged(); } }
        public RENTAL Rental { get; set; }
        public RENTALDETAIL RentalDetail { get; set; }
        public RoomDetailViewModel()
        {

        }
        public RoomDetailViewModel(ListRoom listRoom)
        {
            Load(listRoom);

            CloseCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {

                p.Close();

            });
            CheckInCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {

                if (MessageBox.Show("Bạn có chắc chắn muốn nhận phòng", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var reservationDetail = DataProvider.Ins.DB.RESERVATION_DETAIL.Where(x => x.IdReservation == listRoom.Reservation.IdReservation && x.IdRoom == listRoom.Room.IdRoom).SingleOrDefault();
                    reservationDetail.Status = "Phòng đang thuê";
                    Rental = new RENTAL();
                    Rental.IdReservation = listRoom.Reservation.IdReservation;
                    Rental.IdRoom = listRoom.Room.IdRoom;
                    Rental.DateRental = DateTime.Now;
                    DataProvider.Ins.DB.RENTALs.Add(Rental);
                    DataProvider.Ins.DB.SaveChanges();
                    listRoom.Status = "Phòng đang thuê";
                    Load(listRoom);
                }

            });
            LoadCbCommand = new RelayCommand<ComboBox>((p) =>
            {
                return true;
            }, (p) =>
            {

                p.Text = listRoom.Room.Clean;

            });
            AddServiceCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                DetailRoom_AddService AddService = new DetailRoom_AddService(ListService);
                AddService.ShowDialog();

            });
        }
        public void Load(ListRoom listRoom)
        {
            RoomDetail = listRoom;
            if (listRoom.Status == "Phòng trống")
                RoomDetail.TenKH = "";
            if (listRoom.Status == "phòng đang thuê") LoadService(listRoom);
        }
        public void LoadService(ListRoom listRoom)
        {
            ListService = new ObservableCollection<ListService>();
            var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.IdReservation == listRoom.Reservation.IdReservation).SingleOrDefault();
            var rentaldetail = DataProvider.Ins.DB.RENTALDETAILs.Where(x => x.IdRentalDetail == rental.IdRental);
            if (rentaldetail != null)
            {
                int i = 1;
                foreach (var item in rentaldetail)
                {
                    ListService temp = new ListService();

                    var service = DataProvider.Ins.DB.SERVICEs.Where(x => x.IdService == item.IdService).SingleOrDefault();
                    temp.RentalDetail = item;
                    temp.Service = service;
                    temp.STT = i;
                    i++;
                    ListService.Add(temp);
                }
            }

        }

    }
}
