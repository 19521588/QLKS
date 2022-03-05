using MaterialDesignThemes.Wpf;
using QLKS.Convert;
using QLKS.DATA;
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
        private CATEGORY_ROOM _SelectedCategory { get; set; }
        public CATEGORY_ROOM SelectedCategory { get => _SelectedCategory; set { _SelectedCategory = value; OnPropertyChanged(); } }

        private ObservableCollection<CATEGORY_ROOM> _ListCategoryRoom { get; set; }
        public ObservableCollection<CATEGORY_ROOM> ListCategoryRoom { get => _ListCategoryRoom; set { _ListCategoryRoom = value; OnPropertyChanged(); } }

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
        public ICommand SelectionChangedCommand { get; set; }
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
                Selection(p);

            });
            SearchCommand = new RelayCommand<uc_Phong>((p) =>
            {

                if (String.IsNullOrEmpty(p.txbTimKiem.Text) && String.IsNullOrEmpty(p.dtpChonNgay.Text) && String.IsNullOrEmpty(p.tpGio.Text))
                    return false;
                return true;
            },
            (p) =>
            {
                Selection(p);
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
               p.cbCategoryRoom.SelectedItem = null;
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
            SelectionChangedCommand = new RelayCommand<uc_Phong>((p) =>
             {
                 return true;
             },
            (p) =>
            {
                Selection(p);
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
                  
                    Load();
                }
            );
        }
        public void Load()
        {
            GetModel getModel = new GetModel();
            ListCategoryRoom = getModel.getListCategoryRoom();
            var a = new CATEGORY_ROOM();
            a.Name = "Tất cả loại phòng";
            
            ListCategoryRoom.Add(a);
            SingleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom( DateTime.Now));
            //DoubleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(2, DateTime.Now));
            //FamilyRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(3, DateTime.Now));

        }
        public void LoadTemp(DateTime time)
        {
            TempSingleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom( time));
            //TempDoubleRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(2, time));
            //TempFamilyRoom = new ObservableCollection<ListRoom>(LoadbyCategoryRoom(3, time));
        }
        public List<ListRoom> LoadbyCategoryRoom(DateTime time)

        {
            GetModel getModel = new GetModel();
            var list = new List<ListRoom>();
            var rooms = getModel.getListRoom();
            foreach (var item in rooms)
            {

                var category_rooms = getModel.GetCategoryRoomById(item.IdCategoryRoom);
                if (category_rooms != null)
                {
                    ListRoom temp = new ListRoom();
                    temp.Room = item;
                    var reservation = getModel.getReservationNotPaymentAtTime(time, item.IdRoom);

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

                        var reservation_detail = getModel.getReservationDetailByIdAndIdRoom(reservation.IdReservation,item.IdRoom);


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

                            var customer = getModel.GetCustomerById(reservation.IdCustomer);
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
                UnicodeConvert uni = new UnicodeConvert();

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

                return list.Where(p => uni.RemoveUnicode(p.Room.Name).ToLower().Contains(uni.RemoveUnicode(code).ToLower())).ToList();
            }

        }
        public void Selection(uc_Phong p)
        {
            RadioButton radioTinhTrang = new RadioButton();
            radioTinhTrang.Content = "Tất cả phòng";
            RadioButton radioDonDep = new RadioButton();
            radioDonDep.Content = "Tất cả";

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

            DateTime dateTime = new DateTime();
            DateTime.TryParse(p.dtpChonNgay.Text + " " + p.tpGio.Text, out dateTime);
            LoadTemp(dateTime);
            if (p.cbCategoryRoom.SelectedItem == null)
            {
                SingleRoom = new ObservableCollection<ListRoom>(LoadbyStatus(TempSingleRoom, radioTinhTrang.Content.ToString(), radioDonDep.Content.ToString(), "Tất cả loại phòng", p.txbTimKiem.Text));

            }
            else
            {
                var temp = p.cbCategoryRoom.SelectedItem as CATEGORY_ROOM;
                SingleRoom = new ObservableCollection<ListRoom>(LoadbyStatus(TempSingleRoom, radioTinhTrang.Content.ToString(), radioDonDep.Content.ToString(), temp.Name.ToString(), p.txbTimKiem.Text));

            }
        }
    }
}
