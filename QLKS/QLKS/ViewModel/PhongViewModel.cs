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
        public List<ROOM> list { get; set; }
        public ICommand SelectCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand LoadDatePickerCommand { get; set; }
        public ICommand LoadTimePickerCommand { get; set; }

        public PhongViewModel()
        {
            DateTimeNow = DateTime.Now;
            Load();

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
        }
        public void Load()
        {
            SingleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(1));
            DoubleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(2));
            FamilyRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(3));
            TempSingleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(1));
            TempDoubleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(2));
            TempFamilyRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(3));

        }
        public List<ListRoom> LoadbyCategoryRoom(int type)

        {
            var list = new List<ListRoom>();
            var rooms = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs);
            foreach (var item in rooms)
            {

                var category_rooms = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == item.IdCategoryRoom && x.IdCategoryRoom == type).SingleOrDefault();
                if (category_rooms != null)
                {
                    ListRoom temp = new ListRoom();
                    temp.Room = item;
                    if (item.Clean == "")
                    {
                        temp.IsDay = false;
                        temp.SoGio = 0;
                        temp.SoNgayO = 0;
                        temp.TenKH = "Phòng trống";
                        temp.CategoryRoom = category_rooms.Name;
                        temp.DonDep = item.Clean;
                    }
                    else
                    {
                        var reservation_detail = DataProvider.Ins.DB.RESERVATION_DETAIL.Where(x => x.IdRoom == item.IdRoom && (x.Status == "Đang đặt" || x.Status == "Đang thuê    ")).SingleOrDefault();
                        var reservation = DataProvider.Ins.DB.RESERVATIONs.Where(x => x.IdReservation == reservation_detail.IdReservation).SingleOrDefault();
                        var customer = DataProvider.Ins.DB.CUSTOMERs.Where(x => x.IdCustomer == reservation.IdCustomer).SingleOrDefault();
                        temp.SoNgayO = reservation.Date.Value;
                        if (reservation.Date.Value == 0)
                        {
                            temp.SoGio = reservation.End_Date.Hour - reservation.Start_Date.Hour;
                            temp.IsDay = false;
                        }
                        else
                        {
                            temp.SoGio = 0;
                            temp.IsDay = true;
                        }
                        temp.TenKH = customer.Name;
                        temp.CategoryRoom = category_rooms.Name;
                        temp.DonDep = item.Clean;


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
                    return list.Where(p => p.Room.Clean == clean).ToList();
                if (status == "Tất cả phòng" && type != "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => p.CategoryRoom == type).ToList();
                if (status != "Tất cả phòng" && type == "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => p.Room.Clean == status).ToList();
                //cặp
                if (status != "Tất cả phòng" && type != "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => p.Room.Clean == status && p.CategoryRoom == type).ToList();
                if (status != "Tất cả phòng" && type == "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.Room.Clean == status && p.Room.Clean == clean).ToList();
                if (status == "Tất cả phòng" && type != "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.CategoryRoom == type && p.Room.Clean == clean).ToList();
                if (status != "Tất cả phòng" && type != "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.CategoryRoom == type && p.Room.Clean == clean && p.Room.Clean == status).ToList();

                return list.ToList();
            }
            else
            {
                if (status == "Tất cả phòng" && type == "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.Room.Clean == clean && p.Room.Name == code).ToList();
                if (status == "Tất cả phòng" && type != "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => p.CategoryRoom == type && p.Room.Name == code).ToList();
                if (status != "Tất cả phòng" && type == "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p =>/* p.Room.Status == status &&*/ p.Room.Name == code).ToList();
                //cặp
                if (status != "Tất cả phòng" && type != "Tất cả loại phòng" && clean == "Tất cả")
                    return list.Where(p => /*p.Room.Status == status &&*/ p.CategoryRoom == type && p.Room.Name == code).ToList();
                if (status != "Tất cả phòng" && type == "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => /*p.Room.Status == status &&*/ p.Room.Clean == clean && p.Room.Name == code).ToList();
                if (status == "Tất cả phòng" && type != "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.CategoryRoom == type && p.Room.Clean == clean && p.Room.Name == code).ToList();
                if (status != "Tất cả phòng" && type != "Tất cả loại phòng" && clean != "Tất cả")
                    return list.Where(p => p.CategoryRoom == type && p.Room.Clean == clean && /*p.Room.Status == status &&*/ p.Room.Name == code).ToList();

                return list.Where(p => p.Room.Name == code).ToList();
            }

        }
    }
}
