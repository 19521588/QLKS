using MaterialDesignThemes.Wpf;
using QLKS.Model;
using QLKS.UserControlss;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static QLKS.ViewModel.MainViewModel;

namespace QLKS.ViewModel
{
    public class PhongViewModel : BaseViewModel
    {
        private ObservableCollection<ListRoom> _SingleRoom { get; set; }
        public ObservableCollection<ListRoom> SingleRoom { get => _SingleRoom; set { _SingleRoom = value; OnPropertyChanged(); } }
        private ObservableCollection<ListRoom> _DoubleRoom { get; set; }
        public ObservableCollection<ListRoom> DoubleRoom { get => _DoubleRoom; set { _DoubleRoom = value; OnPropertyChanged(); } }
        private ObservableCollection<ListRoom> _FamilyRoom { get; set; }
        public ObservableCollection<ListRoom> FamilyRoom { get => _FamilyRoom; set { _FamilyRoom = value; OnPropertyChanged(); } }
        private ObservableCollection<ListRoom> _TempSingleRoom { get; set; }
        public ObservableCollection<ListRoom> TempSingleRoom { get => _TempSingleRoom; set { _TempSingleRoom = value; OnPropertyChanged(); } }
        private ObservableCollection<ListRoom> _TempDoubleRoom { get; set; }
        public ObservableCollection<ListRoom> TempDoubleRoom { get => _TempDoubleRoom; set { _TempDoubleRoom = value; OnPropertyChanged(); } }
        private ObservableCollection<ListRoom> _TempFamilyRoom { get; set; }
        public ObservableCollection<ListRoom> TempFamilyRoom { get => _TempFamilyRoom; set { _TempFamilyRoom = value; OnPropertyChanged(); } }
        private DateTime _DateTimeNow { get; set; }
        public DateTime DateTimeNow { get => _DateTimeNow; set { _DateTimeNow = value; OnPropertyChanged(); } }
        private ListRoom _SelectedItem { get; set; }
        public ListRoom SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }
        public List<ROOM> list { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand LoadDatePickerCommand { get; set; }
        public ICommand LoadTimePickerCommand { get; set; }
        public ICommand ItemClickCommand { get; set; }

        public PhongViewModel(USER User)
        {
            DateTimeNow = DateTime.Now;
            Load();
            LoadTemp(DateTime.Now);
            SelectCommand = new RelayCommand<uc_Phong>((p) =>
            {
                return true;
            },
            (p) =>
            {

                RadioButton radioTinhTrang = new RadioButton();
                radioTinhTrang.Content = "Tất cả phòng";
                RadioButton radioDonDep = new RadioButton();
                radioDonDep.Content = "Tất cả";
                RadioButton radioLoaiPhong = new RadioButton();
                radioLoaiPhong.Content = "Tất cả loại phòng";
                foreach (RadioButton i in p.spTrangThai.Children)
                {
                    if (i.IsChecked.Value == true)
                    {
                        radioTinhTrang = i;
                    }
                }
                foreach (RadioButton i in p.spDonDep.Children)
                {
                    if (i.IsChecked.Value == true)
                    {
                        radioDonDep = i;
                    }
                }
                foreach (RadioButton i in p.spLoaiPhong.Children)
                {
                    if (i.IsChecked.Value == true)
                    {
                        radioLoaiPhong = i;
                    }
                }
                DateTime dateTime = new DateTime();
                DateTime.TryParse(p.dtpChonNgay.Text + " " + p.tpGio.Text, out dateTime);
                LoadTemp(dateTime);
                SingleRoom = new ObservableCollection<ListRoom>(LoadbyStatus(TempSingleRoom, radioTinhTrang.Content.ToString(), radioDonDep.Content.ToString(), radioLoaiPhong.Content.ToString(), ""));
                DoubleRoom = new ObservableCollection<ListRoom>(LoadbyStatus(TempDoubleRoom, radioTinhTrang.Content.ToString(), radioDonDep.Content.ToString(), radioLoaiPhong.Content.ToString(), ""));
                FamilyRoom = new ObservableCollection<ListRoom>(LoadbyStatus(TempFamilyRoom, radioTinhTrang.Content.ToString(), radioDonDep.Content.ToString(), radioLoaiPhong.Content.ToString(), ""));
            });
            SearchCommand = new RelayCommand<uc_Phong>((p) =>
            {

                if (String.IsNullOrEmpty(p.txbTimKiem.Text) && String.IsNullOrEmpty(p.dtpChonNgay.Text) && String.IsNullOrEmpty(p.tpGio.Text))
                    return false;
                return true;
            },
            (p) =>
            {
                RadioButton radioTinhTrang = new RadioButton();
                radioTinhTrang.Content = "Tất cả phòng";
                RadioButton radioDonDep = new RadioButton();
                radioDonDep.Content = "Tất cả";
                RadioButton radioLoaiPhong = new RadioButton();
                radioLoaiPhong.Content = "Tất cả loại phòng";
                foreach (RadioButton i in p.spTrangThai.Children)
                {
                    if (i.IsChecked.Value == true)
                    {
                        radioTinhTrang = i;
                    }
                }
                foreach (RadioButton i in p.spDonDep.Children)
                {
                    if (i.IsChecked.Value == true)
                    {
                        radioDonDep = i;
                    }
                }
                foreach (RadioButton i in p.spLoaiPhong.Children)
                {
                    if (i.IsChecked.Value == true)
                    {
                        radioLoaiPhong = i;
                    }
                }
                DateTime dateTime = new DateTime();
                DateTime.TryParse(p.dtpChonNgay.Text + " " + p.tpGio.Text, out dateTime);
                LoadTemp(dateTime);
                SingleRoom = new ObservableCollection<ListRoom>(LoadbyStatus(TempSingleRoom, radioTinhTrang.Content.ToString(), radioDonDep.Content.ToString(), radioLoaiPhong.Content.ToString(), p.txbTimKiem.Text));
                DoubleRoom = new ObservableCollection<ListRoom>(LoadbyStatus(TempDoubleRoom, radioTinhTrang.Content.ToString(), radioDonDep.Content.ToString(), radioLoaiPhong.Content.ToString(), p.txbTimKiem.Text));
                FamilyRoom = new ObservableCollection<ListRoom>(LoadbyStatus(TempFamilyRoom, radioTinhTrang.Content.ToString(), radioDonDep.Content.ToString(), radioLoaiPhong.Content.ToString(), p.txbTimKiem.Text));

            });
            RefreshCommand = new RelayCommand<uc_Phong>((p) =>
            {
                return true;
            },
           (p) =>
           {
               p.txbTimKiem.Text = "";
               p.dtpChonNgay.SelectedDate = DateTime.Now;
               p.tpGio.SelectedTime = DateTime.Now;

               foreach (RadioButton i in p.spTrangThai.Children)
               {
                   if (i.IsChecked.Value == true)
                   {
                       i.IsChecked = false;
                   }
               }
               foreach (RadioButton i in p.spDonDep.Children)
               {
                   if (i.IsChecked.Value == true)
                   {
                       i.IsChecked = false;
                   }
               }
               foreach (RadioButton i in p.spLoaiPhong.Children)
               {
                   if (i.IsChecked.Value == true)
                   {
                       i.IsChecked = false;
                   }
               }
               Load();
           });
            LoadDatePickerCommand = new RelayCommand<DatePicker>((p) =>
              {
                  return true;
              },
            (p) =>
            {

                p.SelectedDate = DateTime.Now;
                p.BlackoutDates.AddDatesInPast();
            });
            LoadTimePickerCommand = new RelayCommand<TimePicker>((p) =>
              {
                  return true;
              },
            (p) =>
            {
                p.SelectedTime = DateTime.Now;

            });
            ItemClickCommand = new RelayCommand<uc_Phong>
                ((p) =>
                {
                    if (SelectedItem == null)
                        return false;
                    return true;
                }, (p) =>
                {
                    RoomDetail roomDetail = new RoomDetail(SelectedItem, User);
                    roomDetail.ShowDialog();
                    RoomDetailViewModel temp = roomDetail.DataContext as RoomDetailViewModel;
                    p.txbTimKiem.Text = "";
                    p.dtpChonNgay.SelectedDate = DateTime.Now;
                    p.tpGio.SelectedTime = DateTime.Now;

                    foreach (RadioButton i in p.spTrangThai.Children)
                    {
                        if (i.IsChecked.Value == true)
                        {
                            i.IsChecked = false;
                        }
                    }
                    foreach (RadioButton i in p.spDonDep.Children)
                    {
                        if (i.IsChecked.Value == true)
                        {
                            i.IsChecked = false;
                        }
                    }
                    foreach (RadioButton i in p.spLoaiPhong.Children)
                    {
                        if (i.IsChecked.Value == true)
                        {
                            i.IsChecked = false;
                        }
                    }
                    Load();
                }
            );
        }
        public void Load()
        {
            SingleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(1, DateTime.Now));
            DoubleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(2, DateTime.Now));
            FamilyRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(3, DateTime.Now));

        }
        public void LoadTemp(DateTime time)
        {
            TempSingleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(1, time));
            TempDoubleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(2, time));
            TempFamilyRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(3, time));
        }
        public List<ListRoom> LoadbyCategoryRoom(int type, DateTime time)

        {
            var list = new List<ListRoom>();
            var rooms = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs).ToList();
            foreach (var item in rooms)
            {

                var category_rooms = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == item.IdCategoryRoom && x.IdCategoryRoom == type).SingleOrDefault();
                if (category_rooms != null)
                {
                    ListRoom temp = new ListRoom();
                    temp.Room = item;
                    var reservation = DataProvider.Ins.DB.RESERVATIONs.Where(x => x.End_Date >= time && x.Start_Date <= time && x.RESERVATION_DETAIL.FirstOrDefault().IdRoom == item.IdRoom && x.RESERVATION_DETAIL.FirstOrDefault().Status != "Phòng đã thanh toán").SingleOrDefault();

                    if (reservation == null)
                    {
                        temp.IsDay = false;
                        temp.SoGio = 0;
                        temp.SoNgayO = 0;
                        temp.TenKH = "Phòng trống";
                        temp.Status = "Phòng trống";
                        temp.CategoryRoom = category_rooms.Name;
                        temp.DonDep = "Đã dọn dẹp";
                        temp.Reservation = null;
                    }
                    else
                    {

                        var reservation_detail = DataProvider.Ins.DB.RESERVATION_DETAIL.Where(x => x.IdRoom == item.IdRoom && x.IdReservation == reservation.IdReservation).SingleOrDefault();



                        if (reservation_detail == null)
                        {
                            temp.IsDay = false;
                            temp.SoGio = 0;
                            temp.SoNgayO = 0;
                            temp.TenKH = "Phòng trống";
                            temp.Status = "Phòng trống";
                            temp.CategoryRoom = category_rooms.Name;
                            temp.DonDep = "Đã dọn dẹp";
                        }
                        else
                        {

                            var customer = DataProvider.Ins.DB.CUSTOMERs.Where(x => x.IdCustomer == reservation.IdCustomer).SingleOrDefault();
                            temp.SoNgayO = reservation.Date.Value;
                            if (reservation.Date.Value == 0)
                            {
                                if(reservation.End_Date.Hour==0)
                                {
                                    temp.SoGio =24- reservation.Start_Date.Hour;
                                }
                                else
                                {
                                    temp.SoGio = reservation.End_Date.Hour - reservation.Start_Date.Hour;
                                }
                               
                                temp.IsDay = false;
                            }
                            else
                            {
                                temp.SoGio = 0;
                                temp.IsDay = true;

                            }
                            temp.TenKH = customer.Name;
                            temp.Status = reservation_detail.Status;
                            temp.CategoryRoom = category_rooms.Name;
                            temp.DonDep = item.Clean;
                            temp.Reservation = reservation;
                        }

                    }

                    list.Add(temp);


                }


            }
            return list;
        }
        public List<ListRoom> LoadbyStatus(ObservableCollection<ListRoom> list, string status, string clean, string type, string code)
        {
            if (code == "")
            {
                if (status == "Tất cả phòng" && type == "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.DonDep == clean).ToList();
                if (status == "Tất cả phòng" && type != "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => p.CategoryRoom == type).ToList();
                if (status != "Tất cả phòng" && type == "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => p.Status == status).ToList();
                //cặp
                if (status != "Tất cả phòng" && type != "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => p.Status == status && p.CategoryRoom == type).ToList();
                if (status != "Tất cả phòng" && type == "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.Status == status && p.DonDep == clean).ToList();
                if (status == "Tất cả phòng" && type != "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.CategoryRoom == type && p.DonDep == clean).ToList();
                if (status != "Tất cả phòng" && type != "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.CategoryRoom == type && p.DonDep == clean && p.Status == status).ToList();

                return list.ToList();
            }
            else
            {
                if (status == "Tất cả phòng" && type == "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.DonDep == clean && p.Room.Name == code).ToList();
                if (status == "Tất cả phòng" && type != "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => p.CategoryRoom == type && p.Room.Name == code).ToList();
                if (status != "Tất cả phòng" && type == "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => p.Status == status && p.Room.Name == code).ToList();
                //cặp
                if (status != "Tất cả phòng" && type != "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => p.Status == status && p.CategoryRoom == type && p.Room.Name == code).ToList();
                if (status != "Tất cả phòng" && type == "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.Status == status && p.DonDep == clean && p.Room.Name == code).ToList();
                if (status == "Tất cả phòng" && type != "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.CategoryRoom == type && p.DonDep == clean && p.Room.Name == code).ToList();
                if (status != "Tất cả phòng" && type != "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.CategoryRoom == type && p.DonDep == clean && p.Status == status && p.Room.Name == code).ToList();

                return list.Where(p => p.Room.Name == code).ToList();
            }

        }
    }
}
