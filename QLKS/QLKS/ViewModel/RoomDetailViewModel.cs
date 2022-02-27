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
        private ObservableCollection<SelectService> _ListService { get; set; }
        public ObservableCollection<SelectService> ListService { get => _ListService; set { _ListService = value; OnPropertyChanged(); } }
        public RENTAL Rental { get; set; }
        public RENTALDETAIL RentalDetail { get; set; }
        public RoomDetailViewModel()
        {

        }
        public RoomDetailViewModel(ListRoom listRoom,USER User)
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
                   if(listRoom.Status=="Phòng đã đặt")
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
                   else
                    {
                        wd_AddNewReservation wdAddReservation = new wd_AddNewReservation(false);

                        wdAddReservation.ShowDialog();
                    }
                }

            });
            LoadCbCommand = new RelayCommand<ComboBox>((p) =>
            {
                return true;
            }, (p) =>
            {

                p.Text = listRoom.Room.Clean;

            });
            SaveCommand = new RelayCommand<RoomDetail>((p) =>
            {
                return true;
            }, (p) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn lưu  thay đổi", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.IdReservation == listRoom.Reservation.IdReservation).SingleOrDefault();
                    var rentaldetail = DataProvider.Ins.DB.RENTALDETAILs.Where(x => x.IdRental == rental.IdRental).ToList();
                    var room = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == rental.IdRoom).SingleOrDefault();
                    if (p.cbDonDep.Text != room.Clean)
                    {
                        room.Clean = p.cbDonDep.Text;
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    if (rentaldetail != null)
                    {
                        foreach (var item in rentaldetail)
                        {
                            DataProvider.Ins.DB.RENTALDETAILs.Remove(item);
                            DataProvider.Ins.DB.SaveChanges();
                        }
                    }
                    foreach(var item in ListService)
                    {
                        var temp = new RENTALDETAIL();
                        temp.IdService = item.Service.IdService;
                        temp.Total = item.Total;
                        temp.Amount=item.Amount;
                        temp.IdRental = rental.IdRental;
                        DataProvider.Ins.DB.RENTALDETAILs.Add(temp);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    p.Close();
                }
            });
            AddServiceCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                DetailRoom_AddService AddService = new DetailRoom_AddService(ListService);
                AddService.ShowDialog();

                AddServiceDRViewModel list = AddService.DataContext as AddServiceDRViewModel;
                if (list.IsSave)
                {
                    ListService = list.SelectListService;
                }

            });
           PaymentCommand = new RelayCommand<RoomDetail>((p) =>
            {
                return true;
            }, (p) =>
            {
                var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.IdReservation == listRoom.Reservation.IdReservation).SingleOrDefault();
                Bill_Detail BillDetail = new Bill_Detail(ListService,rental.IdRental ,false,User);
                BillDetail.ShowDialog();

                BillDetailViewModel temp = BillDetail.DataContext as BillDetailViewModel;
                if (temp.IsSave)
                {
                    var reservationDetail = DataProvider.Ins.DB.RESERVATION_DETAIL.Where(x => x.IdReservation == listRoom.Reservation.IdReservation && x.IdRoom==listRoom.Room.IdRoom).SingleOrDefault();
                    reservationDetail.Status = "Phòng đã thanh toán";
                    DataProvider.Ins.DB.SaveChanges();
                    p.Close();
                }


            });
        }
        public void Load(ListRoom listRoom)
        {
            RoomDetail = listRoom;
            if (listRoom.Status == "Phòng trống")
                RoomDetail.TenKH = "";
            if (listRoom.Status == "Phòng đang thuê") LoadService(listRoom);
        }
        public void LoadService(ListRoom listRoom)
        {
            ListService = new ObservableCollection<SelectService>();
            var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.IdReservation == listRoom.Reservation.IdReservation).SingleOrDefault();
            var rentaldetail = DataProvider.Ins.DB.RENTALDETAILs.Where(x => x.IdRental == rental.IdRental).ToList();
            if (rentaldetail != null)
            {
                int i = 1;
                foreach (var item in rentaldetail)
                {
                    SelectService temp = new SelectService();

                    var service = DataProvider.Ins.DB.SERVICEs.Where(x => x.IdService == item.IdService).SingleOrDefault();
                    temp.Service = service;
                    temp.Total = item.Total;
                    temp.Amount = item.Amount;
                    temp.STT = i;
                    i++;
                    ListService.Add(temp);
                }
            }

        }

    }
}
