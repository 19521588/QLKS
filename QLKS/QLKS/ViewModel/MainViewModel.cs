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

namespace QLKS.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        #region
        public static MainWindow mainWindow { get; set; }
        private ObservableCollection<ItemMenuMainWindow> _myListItems;

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

        public ICommand LogOutCommand { get; set; }
        #endregion
        public MainViewModel()
        {
                
            LoadedWindowCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) =>
            {
                initListViewMenu();
            });
            ItemClickCommand = new RelayCommand<ItemMenuMainWindow>((p) => { return true; }, (p) =>
            {
                DoStuff(p);
            });
            LogOutCommand = new RelayCommand<MainWindow>((p) => { return true; }, (p) =>
            {
                DialogCustoms dialog = new DialogCustoms("Bạn có muốn đăng xuất ?", "Thông báo", DialogCustoms.YesNo);
                if (dialog.ShowDialog() == true)
                {
                    dialog.Close();
                }
            });
            

        }
        public void DoStuff(ItemMenuMainWindow item)
        {
            MessageBox.Show(item.name + " element clicked");
        }
        public void initListViewMenu()
        {
            MyListItems = new ObservableCollection<ItemMenuMainWindow>();
            //Khoi tao Menu

            MyListItems.Add(new ItemMenuMainWindow() { name = "Trang Chủ", foreColor = "Gray", kind_Icon = "Home" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "Phòng", foreColor = "#FFF08033", kind_Icon = "HomeCity" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "Đặt Phòng", foreColor = "Green", kind_Icon = "BookAccount" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "Hóa đơn", foreColor = "#FFD41515", kind_Icon = "Receipt" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL nhân Viên", foreColor = "#FFD41515", kind_Icon = "Account" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL khách hàng", foreColor = "#FFD41515", kind_Icon = "Account" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL phòng", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL loại phòng", foreColor = "#FFE6A701", kind_Icon = "StarCircle" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL dịch vụ", foreColor = "Blue", kind_Icon = "FaceAgent" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL loại dịch vụ", foreColor = "Blue", kind_Icon = "FaceAgent" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL tiện nghi", foreColor = "#FFF08033", kind_Icon = "Fridge" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "QL chi tiết tiện nghi", foreColor = "#FFF08033", kind_Icon = "Fridge" });
            MyListItems.Add(new ItemMenuMainWindow() { name = "Thống kê", foreColor = "#FF0069C1", kind_Icon = "ChartAreaspline" });
          

           
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
