using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class AddReservationViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand LoadListRoomCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }


        private bool _check { get; set; }
        public bool check { get => _check; set { _check = value; OnPropertyChanged(); } }

        private RESERVATION _reservation { get; set; }

        public RESERVATION reservation { get => _reservation; set { _reservation = value; OnPropertyChanged(); } }

        private ObservableCollection<RESERVATION_DETAIL> _ListReservation { get; set; }

        public ObservableCollection<RESERVATION_DETAIL> ListReservation { get => _ListReservation; set { _ListReservation = value; OnPropertyChanged(); } }

        private ObservableCollection<ROOM> _ListRoom { get; set; }

        public ObservableCollection<ROOM> ListRoom { get => _ListRoom; set { _ListRoom = value; OnPropertyChanged(); } }

        private ObservableCollection<ROOM> _ListAvailableRoom { get; set; }

        public ObservableCollection<ROOM> ListAvailableRoom { get => _ListAvailableRoom; set { _ListAvailableRoom = value; OnPropertyChanged(); } }

        private ObservableCollection<ROOM> _ListSelectRoom { get; set; }

        public ObservableCollection<ROOM> ListSelectRoom { get => _ListSelectRoom; set { _ListSelectRoom = value; OnPropertyChanged(); } }

        private ROOM _SelectedRoom { get; set; }

        public ROOM SelectedRoom { get => _SelectedRoom; set { _SelectedRoom = value; OnPropertyChanged(); } }

        private ROOM _SelectedItem { get; set; }

        public ROOM SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        public int date;

        public RESERVATION_DETAIL reservation_detail;

        private bool _IsAdd { get; set; }
        public bool IsAdd { get => _IsAdd; set { _IsAdd = value; OnPropertyChanged(); } }
        private bool _IsSave { get; set; }
        public bool IsSave { get => _IsSave; set { _IsSave = value; OnPropertyChanged(); } }
        private string _Title { get; set; }
        public string Title { get => _Title; set { _Title = value; OnPropertyChanged(); } }
        private bool _VisGrid { get; set; }
        public bool VisGrid { get => _VisGrid; set { _VisGrid = value; OnPropertyChanged(); } }

        public AddReservationViewModel(bool IsReservation, int IdRoom)
        {
            if (IsReservation)
            {
                Title = "Đặt phòng";
                VisGrid = true;
            }
            else
            {
                Title = "Thuê phòng " + DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == IdRoom).SingleOrDefault().Name;
                VisGrid = false;
            }
            IsSave = false;
            ListRoom = new ObservableCollection<ROOM>();
            ListSelectRoom = new ObservableCollection<ROOM>();
            ListReservation = new ObservableCollection<RESERVATION_DETAIL>();
            ObservableCollection<ROOM> temp = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs.Where(x => x.Name != "Phòng trống"));
            for (int i = temp.Count() - 1; i >= 0; i--)
            {
                ListRoom.Add(temp[i]);
            }
            LoadedWindowCommand = new RelayCommand<wd_AddNewReservation>(
            (p) =>
            {

                return true;
            },
            (p) =>
            {
                if (!IsReservation)
                {
                    p.dtStartDate.SelectedDate = DateTime.Now;
                    p.tpStartTime.SelectedTime = DateTime.Now;
                    p.dtStartDate.IsEnabled = false;
                    p.tpStartTime.IsEnabled = false;
                }
            }
            );



            AddCommand = new RelayCommand<wd_AddNewReservation>(
            (p) =>
            {
                if (p.dtStartDate.SelectedDate.Value.Date > p.dtpEndDate.SelectedDate.Value.Date) return false;
                if (p.dtStartDate.SelectedDate == p.dtpEndDate.SelectedDate)
                {
                    var zero = new TimeSpan(0, 0, 0);
                    var twelve = new TimeSpan(12, 0, 0);
                    if (p.tpEndTime.SelectedTime.Value.TimeOfDay == twelve)
                    {
                        if (p.tpStartTime.SelectedTime.Value.Hour > 12) return true;
                    }
                    if (p.tpEndTime.SelectedTime.Value.TimeOfDay == zero)
                    {
                        if (p.tpStartTime.SelectedTime.Value.Hour < 12) return true;
                    }
                    else
                    {
                        if (DateTime.Compare(p.tpStartTime.SelectedTime.Value, p.tpEndTime.SelectedTime.Value) == 1) return false;
                    }
                }
                if (SelectedRoom == null) return false;
                return true;
            },
            (p) =>
            {
                //RESERVATION_DETAIL res_detail = new RESERVATION_DETAIL() {IdRoom = SelectedRoom.IdRoom};
                ListSelectRoom.Add(SelectedRoom);
                ListAvailableRoom.Remove(SelectedRoom);
                //ListReservation.Add(res_detail);
                //p.Close();
            }
            );

            SaveCommand = new RelayCommand<wd_AddNewReservation>(
            (p) =>
            {
                if (IsReservation)
                {
                    if (ListSelectRoom.Count == 0) return false;
                }
                if (p.dtStartDate.SelectedDate == null || p.dtpEndDate.SelectedDate == null || p.tpStartTime.SelectedTime == null || p.tpEndTime.SelectedTime == null) return false;
                if (p.txbName.Text == "" || p.txbCCCD.Text == "" || p.txbAddress.Text == "" || p.txbPhone.Text == "" || p.txbNationality.Text == "" || p.cbSex.Text == "" || p.dtBirth.Text == "" || p.txbAmount.Text == "") return false;

                if (p.dtStartDate.SelectedDate.Value.Date > p.dtpEndDate.SelectedDate.Value.Date) return false;

                if (p.dtStartDate.SelectedDate.Value.Date == p.dtpEndDate.SelectedDate.Value.Date)
                {
                    var zero = new TimeSpan(0, 0, 0);
                    var twelve = new TimeSpan(12, 0, 0);
                    if (p.tpEndTime.SelectedTime.Value.TimeOfDay == twelve)
                    {
                        if (p.tpStartTime.SelectedTime.Value.Hour > 12) return true;
                    }

                    if (p.tpEndTime.SelectedTime.Value.TimeOfDay == zero)
                    {
                        if (p.tpStartTime.SelectedTime.Value.Hour > 12) return false;
                    }
                    else
                    {
                        if (DateTime.Compare(p.tpStartTime.SelectedTime.Value, p.tpEndTime.SelectedTime.Value) == 1) return false;
                    }
                }
                return true;
            },
            (p) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn " + Title.ToLower(), "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    CUSTOMER customer = new CUSTOMER() { Name = p.txbName.Text, BirthDay = DateTime.Parse(p.dtBirth.SelectedDate.ToString()), Address = p.txbAddress.Text, Phone = p.txbPhone.Text, Nationality = p.txbNationality.Text, CCCD = p.txbCCCD.Text, Sex = p.cbSex.Text };
                    DataProvider.Ins.DB.CUSTOMERs.Add(customer);


                    if (p.dtStartDate.SelectedDate == p.dtpEndDate.SelectedDate) date = 0;
                    else
                    {
                        TimeSpan datespan = (TimeSpan)(p.dtpEndDate.SelectedDate - p.dtStartDate.SelectedDate);
                        date = datespan.Days;
                    }

                    DateTime timeStart= DateTime.Parse(p.dtStartDate.Text + " " + p.tpStartTime.Text);
                    DateTime timeEnd = DateTime.Parse(p.dtpEndDate.Text + " " + p.tpEndTime.Text);
                    var timeStartFinal = timeStart;
                    var timeEndFinal = timeEnd;
                    var zero = new TimeSpan(0, 0, 0);
                    var twelve = new TimeSpan(12, 0, 0);
                    if (p.tpStartTime.SelectedTime.Value.TimeOfDay == zero)
                    {
                        timeStartFinal = new DateTime(timeStart.Year, timeStart.Month, timeStart.Day, 12, timeStart.Minute, timeStart.Second);
                    }
                    if (p.tpStartTime.SelectedTime.Value.TimeOfDay == twelve)
                    {
                        timeStartFinal = new DateTime(timeStart.Year, timeStart.Month, timeStart.Day+1, 0, timeStart.Minute, timeStart.Second);
                    }
                    if (p.tpEndTime.SelectedTime.Value.TimeOfDay == zero)
                    {
                        timeEndFinal = new DateTime(timeEnd.Year, timeEnd.Month, timeEnd.Day, 12, timeEnd.Minute, timeEnd.Second);
                    }
                    if (p.tpEndTime.SelectedTime.Value.TimeOfDay == twelve)
                    {
                        timeEndFinal = new DateTime(timeEnd.Year, timeEnd.Month, timeEnd.Day + 1, 0, timeEnd.Minute, timeEnd.Second);
                    }


                    reservation = new RESERVATION() { IdCustomer = customer.IdCustomer, Amount = Int32.Parse(p.txbAmount.Text), Start_Date = timeStartFinal, End_Date = timeEndFinal, Date = date, IdEmployee = 1 };

                    

                    DataProvider.Ins.DB.RESERVATIONs.Add(reservation);

                    if (IsReservation)
                    {
                        foreach (var item in ListSelectRoom)
                        {
                            var List = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == item.IdRoom).SingleOrDefault();
                            //List.Status = "Đang đặt";

                            reservation_detail = new RESERVATION_DETAIL() { IdReservation = reservation.IdReservation, Status = "Phòng đã đặt", IdRoom = item.IdRoom };
                            DataProvider.Ins.DB.RESERVATION_DETAIL.Add(reservation_detail);
                        }
                    }
                    else
                    {

                        reservation_detail = new RESERVATION_DETAIL() { IdReservation = reservation.IdReservation, Status = "Phòng đã đặt", IdRoom = IdRoom };
                        DataProvider.Ins.DB.RESERVATION_DETAIL.Add(reservation_detail);
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    IsSave = true;
                    p.Close();
                }

            }
            );


            CloseCommand = new RelayCommand<wd_AddNewReservation>(
            (p) =>
            { return true; },
            (p) =>
            {
                p.Close();
            }
            );

            LoadListRoomCommand = new RelayCommand<wd_AddNewReservation>(
            (p) =>
            {
                //if (p.dtStartDate.SelectedDate < DateTime.Now) return false;
                if (p.dtStartDate.SelectedDate == null || p.dtpEndDate.SelectedDate == null || p.tpStartTime.SelectedTime == null || p.tpEndTime.SelectedTime == null) return false;
                if (p.dtStartDate.SelectedDate.Value.Date > p.dtpEndDate.SelectedDate.Value.Date) return false;
                if (p.dtStartDate.SelectedDate == p.dtpEndDate.SelectedDate)
                {
                    var zero = new TimeSpan(0, 0, 0);
                    var twelve = new TimeSpan(12, 0, 0);
                    if (p.tpEndTime.SelectedTime.Value.TimeOfDay == twelve)
                    {
                        if (p.tpStartTime.SelectedTime.Value.Hour > 12) return true;
                    }
                    if (p.tpEndTime.SelectedTime.Value.TimeOfDay == zero)
                    {
                        if (p.tpStartTime.SelectedTime.Value.Hour < 12) return true;
                    }
                    else
                    {
                        if (DateTime.Compare(p.tpStartTime.SelectedTime.Value, p.tpEndTime.SelectedTime.Value) == 1) return false;
                    }
                }
                return true;
            },
            (p) =>
            {
                ListAvailableRoom = new ObservableCollection<ROOM>();
                foreach (var item in ListRoom)
                {
                    IsAdd = false;
                    ObservableCollection<RESERVATION_DETAIL> templist = new ObservableCollection<RESERVATION_DETAIL>(DataProvider.Ins.DB.RESERVATION_DETAIL.Where(x => x.IdRoom == item.IdRoom));
                    if (templist.Count == 0)
                    {
                        ListAvailableRoom.Add(item);
                    }
                    else
                    {
                        IsAdd = true;
                        foreach (var detail in templist)
                        {

                            //if ((detail.RESERVATION.End_Date == p.dtStartDate.SelectedDate && detail.RESERVATION.End_Date.TimeOfDay < p.tpStartTime.SelectedTime.Value.TimeOfDay) || (detail.RESERVATION.Start_Date == p.dtpEndDate.SelectedDate && detail.RESERVATION.Start_Date.TimeOfDay > p.tpEndTime.SelectedTime.Value.TimeOfDay))
                            if (detail.Status != "Phòng đã thanh toán")
                            {

                                if (detail.RESERVATION.End_Date < p.dtStartDate.SelectedDate || detail.RESERVATION.Start_Date > p.dtpEndDate.SelectedDate || (detail.RESERVATION.End_Date == p.dtStartDate.SelectedDate && detail.RESERVATION.End_Date.TimeOfDay < p.tpStartTime.SelectedTime.Value.TimeOfDay))
                                    IsAdd = false;
                            }
                        }
                        if (IsAdd)
                        {
                            ListAvailableRoom.Add(item);
                        }
                    }
                }
            }
            );
        }
       

    }

  
}

