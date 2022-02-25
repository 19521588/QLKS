using QLKS.Model;
using QLKS.UserControlss;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace QLKS.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        #region uc_view

        private uc_Home Home_UC;
        private uc_DatPhong DatPhong_UC;
        private uc_Employee NhanVien_UC;
        private uc_RoomManage QuanLyPhong_UC;
        private uc_Customer QuanLyKhachHang_UC;
        private uc_RoomCategoryManage QuanLyLoaiPhong_UC;
        private uc_QuanLyDichVu QuanLyDichVu_UC;
        private uc_QuanLyTienNghi QuanLyTienNghi_UC;
        private uc_QuanLyChiTietTienNghi QuanLyChiTietTienNghi_UC;
        private uc_QuanLyLoaiDichVu QuanLyLoaiDichVu_UC;
        private uc_Bill HoaDon_UC;
        private uc_Phong Phong_UC;
        //private uc_ThongKe ThongKe_UC;
        #endregion
        #region
        public static MainWindow mainWindow { get; set; }
        private ObservableCollection<ItemMenuMainWindow> _myListItems;

        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }
        private string _Name { get; set; }
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }
        private USER _User { get; set; }
        public USER User { get => _User; set { _User = value; OnPropertyChanged(); } }

        public ObservableCollection<ItemMenuMainWindow> MyListItems
        {
            get => _myListItems;
            set
            {
                _myListItems = value;
                OnPropertyChanged(nameof(MyListItems));
            }
        }
        private string _Title_Main { get; set; }
        public string Title_Main { get => _Title_Main; set { _Title_Main = value; OnPropertyChanged(); } }

        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand ItemClickCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ICommand ChangePasswordCommand { get; set; }

        public ICommand LogOutCommand { get; set; }
        public ICommand CloseSideBarCommand { get; set; }
     
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        #endregion
        public MainViewModel()
        {
            initListViewMenu();
            LoadedWindowCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) =>
            {
              
                LoadLoginWindow(p);

            });
            EditCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) =>
            {

                //ditInfo editInfoWd = new EditInfo(User);
                //editInfoWd.ShowDialog();
                wd_EditEmployee wdEditEmployee = new wd_EditEmployee(User.EMPLOYEE);

                wdEditEmployee.txbName.Text = User.EMPLOYEE.Name;
                wdEditEmployee.txbCCCD.Text = User.EMPLOYEE.CCCD.ToString();
                wdEditEmployee.txbPhone.Text = User.EMPLOYEE.Phone.ToString();
                wdEditEmployee.txbAddress.Text = User.EMPLOYEE.Address.ToString();
                wdEditEmployee.txbPosition.Text = User.EMPLOYEE.Position.ToString();
                wdEditEmployee.txbSalary.Text = User.EMPLOYEE.Salary.ToString();
                wdEditEmployee.dtpBirth.SelectedDate = User.EMPLOYEE.BirthDay;
                wdEditEmployee.cbSex.Text = User.EMPLOYEE.Sex.ToString();
                wdEditEmployee.ShowDialog();

            });

            ChangePasswordCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) =>
            {

                //ditInfo editInfoWd = new EditInfo(User);
                //editInfoWd.ShowDialog();
                wd_ChangePassword wd = new wd_ChangePassword(User);

                wd.ShowDialog();

            });

            ItemClickCommand = new RelayCommand<ItemMenuMainWindow>((p) => { return true; }, (p) =>
            {
                DoStuff(p);
            });
            LogOutCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    p.DataContext = new MainViewModel();
                   
                    LoadLoginWindow(mainWindow);
                }
            });
           

        }
        public void LoadLoginWindow(MainWindow p)
        {
            IsLoaded = true;
           
            if (p == null)
                return;
            p.Hide();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.ShowDialog();
            if (loginWindow.DataContext == null)
                return;
            var loginVM = loginWindow.DataContext as LoginViewModel;
            if (loginVM.IsLogin)
            {
                p.Show();
                mainWindow = p;
                User = loginVM.User;
                var employee = DataProvider.Ins.DB.EMPLOYEEs.Where(x => x.IdEmployee == User.IdEmployee).SingleOrDefault();
                Name = employee.Name;
            }
            else
            {
                IsClose = false;
                p.Close();
            }
        }
        public void DoStuff(ItemMenuMainWindow item)
        {
            if (item != null)
            {
                switch (item.name)
                {
                    case "Trang Chủ":
                        //Đang là Home rồi thì không set nữa
                        if (Title_Main.Equals(item.name))
                        {
                            break;
                        }
                        CurrentView = Home_UC;
                        break;
                    case "Phòng":
                        if (Phong_UC == null)
                        {
                            Phong_UC = new uc_Phong(User);
                        }
                        CurrentView = Phong_UC;
                        break;
                    case "Đặt phòng":
                        if (DatPhong_UC == null)
                        {
                            DatPhong_UC = new uc_DatPhong();
                        }
                        CurrentView = DatPhong_UC;
                        break;
                    case "Hóa đơn":
                        if (HoaDon_UC == null)
                        {
                            HoaDon_UC = new uc_Bill();
                        }
                        CurrentView = HoaDon_UC;
                        break;
                    case "QL nhân Viên":
                        if (NhanVien_UC == null)
                        {
                            NhanVien_UC = new uc_Employee();
                        }
                        CurrentView = NhanVien_UC;
                        break;
                    case "QL khách hàng":
                        if (QuanLyKhachHang_UC == null)
                        {
                            QuanLyKhachHang_UC = new uc_Customer();
                        }
                        CurrentView = QuanLyKhachHang_UC;
                        break;
                    case "QL phòng":
                        if (QuanLyPhong_UC == null)
                        {
                            QuanLyPhong_UC = new uc_RoomManage();
                        }
                        CurrentView = QuanLyPhong_UC;
                        break;
                    case "QL loại phòng":
                        if (QuanLyLoaiPhong_UC == null)
                        {
                            QuanLyLoaiPhong_UC = new uc_RoomCategoryManage();
                        }
                        CurrentView = QuanLyLoaiPhong_UC;
                        break;
                    case "QL dịch vụ":
                        if (QuanLyDichVu_UC == null)
                        {
                            QuanLyDichVu_UC = new uc_QuanLyDichVu();
                        }
                        CurrentView = QuanLyDichVu_UC;
                        break;
                    case "QL loại dịch vụ":
                        if (QuanLyLoaiDichVu_UC == null)
                        {
                            QuanLyLoaiDichVu_UC = new uc_QuanLyLoaiDichVu();
                        }
                        CurrentView = QuanLyLoaiDichVu_UC;
                        break;
                    case "QL tiện nghi":
                        if (QuanLyTienNghi_UC == null)
                        {
                            QuanLyTienNghi_UC = new uc_QuanLyTienNghi();
                        }
                        CurrentView = QuanLyTienNghi_UC;
                        break;
                    case "QL chi tiết tiện nghi":
                        if (QuanLyChiTietTienNghi_UC == null)
                        {
                            QuanLyChiTietTienNghi_UC = new uc_QuanLyChiTietTienNghi();
                        }
                        CurrentView = QuanLyChiTietTienNghi_UC;
                        break;
                    
                }
                Title_Main = item.name;
                
            }
        }
        public void initListViewMenu()
        {
            Home_UC = new uc_Home();
            CurrentView = Home_UC;
            MyListItems = new ObservableCollection<ItemMenuMainWindow>();
            //Khoi tao Menu

            MyListItems.Add(new ItemMenuMainWindow() { name = "Trang Chủ", foreColor = "Gray", kind_Icon = "Home" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "Phòng", foreColor = "#FFF08033", kind_Icon = "HomeCity" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "Đặt phòng", foreColor = "Green", kind_Icon = "BookAccount" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "Hóa đơn", foreColor = "#FFD41515", kind_Icon = "Receipt" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL nhân Viên", foreColor = "#FFD41515", kind_Icon = "Account" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL khách hàng", foreColor = "#FFD41515", kind_Icon = "Account" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL phòng", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL loại phòng", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL dịch vụ", foreColor = "Blue", kind_Icon = "FaceAgent" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL loại dịch vụ", foreColor = "Blue", kind_Icon = "FaceAgent" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL tiện nghi", foreColor = "#FFF08033", kind_Icon = "Fridge" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL chi tiết tiện nghi", foreColor = "#FFF08033", kind_Icon = "Fridge" });
           
          

           
            Title_Main = "Trang Chủ";
        }
        public class ItemMenuMainWindow
        {
            public string name { get; set; }
            public string foreColor { get; set; }
            public string kind_Icon { get; set; }

            public ItemMenuMainWindow() { }

        }
    }
}
