using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public AddReservationViewModel(bool IsReservation)
        {

            ListRoom = new ObservableCollection<ROOM>();
            ListAvailableRoom = new ObservableCollection<ROOM>();
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
                if (p.dtpEndDate.SelectedDate < p.dtStartDate.SelectedDate) return false;
                if (p.dtStartDate.SelectedDate == p.dtpEndDate.SelectedDate && p.tpStartTime.SelectedTime > p.tpEndTime.SelectedTime) return false;
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
                if (ListSelectRoom.Count == 0) return false;
                if (p.dtStartDate.SelectedDate > p.dtpEndDate.SelectedDate) return false;
                if (p.txbName.Text == null || p.txbCCCD.Text == null || p.txbAddress.Text == null || p.txbPhone.Text == null || p.txbNationality.Text == null || p.cbSex.Text == null || p.dtBirth.Text == null) return false;
                if (p.dtStartDate.Text == null || p.dtpEndDate == null || p.tpStartTime.Text == null || p.tpEndTime.Text == null) return false;
                return true;
            },
            (p) =>
            {
                CUSTOMER customer = new CUSTOMER() { Name = p.txbName.Text, BirthDay = DateTime.Parse(p.dtBirth.SelectedDate.ToString()), Address = p.txbAddress.Text, Phone = p.txbPhone.Text, Nationality = p.txbNationality.Text, CCCD = p.txbCCCD.Text, Sex = p.cbSex.Text };
                DataProvider.Ins.DB.CUSTOMERs.Add(customer);

                
                if (p.dtStartDate.SelectedDate == p.dtpEndDate.SelectedDate) date = 0;
                else
                {
                    TimeSpan datespan = (TimeSpan)(p.dtpEndDate.SelectedDate -  p.dtStartDate.SelectedDate);
                    date = datespan.Days;
                }
                reservation = new RESERVATION() { IdCustomer = customer.IdCustomer, Amount = Int32.Parse(p.txbAmount.Text), Start_Date = DateTime.Parse(p.dtStartDate.Text +" "+ p.tpStartTime.Text) , End_Date = DateTime.Parse(p.dtpEndDate.Text + " " + p.tpEndTime.Text), Date = date, IdEmployee = 1 };
                DataProvider.Ins.DB.RESERVATIONs.Add(reservation);

                foreach(var item in ListSelectRoom)
                {
                    var List = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == item.IdRoom).SingleOrDefault();
                    //List.Status = "Đang đặt";
                    
                    reservation_detail = new RESERVATION_DETAIL() { IdReservation = reservation.IdReservation, Status = "Đang đặt", IdRoom = item.IdRoom};
                    DataProvider.Ins.DB.RESERVATION_DETAIL.Add(reservation_detail);
                }
                DataProvider.Ins.DB.SaveChanges();
                p.Close();
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
                if (p.dtStartDate.SelectedDate < DateTime.Now) return false;
                if (p.dtStartDate.SelectedDate == null || p.dtpEndDate.SelectedDate == null || p.tpStartTime.SelectedTime == null || p.tpEndTime.SelectedTime == null) return false;
                if (p.dtStartDate.SelectedDate > p.dtpEndDate.SelectedDate) return false;
                if (p.dtStartDate.SelectedDate == p.dtpEndDate.SelectedDate && p.tpStartTime.SelectedTime > p.tpEndTime.SelectedTime) return false;
                return true;
            },
            (p) =>
            {
                foreach(var item in ListRoom)
                {
                    IsAdd = false;
                    ObservableCollection<RESERVATION_DETAIL> templist = new ObservableCollection<RESERVATION_DETAIL>(DataProvider.Ins.DB.RESERVATION_DETAIL.Where(x => x.IdRoom == item.IdRoom));
                    if (templist.Count == 0)
                        ListAvailableRoom.Add(item);
                    else
                    {
                        foreach (var detail in templist)
                        {
                            if ((detail.RESERVATION.Start_Date == p.dtStartDate.SelectedDate && (detail.RESERVATION.Start_Date >= p.tpEndTime.SelectedTime || detail.RESERVATION.Start_Date.TimeOfDay >= p.tpEndTime.SelectedTime.Value.TimeOfDay)) || detail.RESERVATION.End_Date < p.dtStartDate.SelectedDate || detail.RESERVATION.Start_Date > p.dtpEndDate.SelectedDate || (detail.RESERVATION.End_Date == p.dtStartDate.SelectedDate && detail.RESERVATION.End_Date.TimeOfDay < p.tpStartTime.SelectedTime.Value.TimeOfDay ) || (detail.RESERVATION.End_Date == p.dtStartDate.SelectedDate && detail.RESERVATION.Start_Date.TimeOfDay > p.tpEndTime.SelectedTime.Value.TimeOfDay))
                                IsAdd = true;
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
