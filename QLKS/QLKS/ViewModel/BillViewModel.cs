using QLKS.Convert;
using QLKS.Model;
using QLKS.UserControlss;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class BillViewModel : BaseViewModel
    {
        private ListBill _SelectedItem { get; set; }
        public ListBill SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }
        private ObservableCollection<ListBill> _Temp { get; set; }
        public ObservableCollection<ListBill> Temp { get => _Temp; set { _Temp = value; OnPropertyChanged(); } }
        #region search
        private string _CustomerName { get; set; }
        public string CustomerName { get => _CustomerName; set { _CustomerName = value; OnPropertyChanged(); } }

        private CATEGORY_ROOM _SelectedCategory { get; set; }
        public CATEGORY_ROOM SelectedCategory { get => _SelectedCategory; set { _SelectedCategory = value; OnPropertyChanged(); } }
        
        private ObservableCollection<CATEGORY_ROOM> _ListCategoryRoom { get; set; }
        public ObservableCollection<CATEGORY_ROOM> ListCategoryRoom { get => _ListCategoryRoom; set { _ListCategoryRoom = value; OnPropertyChanged(); } }
        private string _IdHD { get; set; }
        public string IdHD { get => _IdHD; set { _IdHD = value; OnPropertyChanged(); } }
        #endregion

        #region Command


        public ICommand SearchCommand { get; set; }
        public ICommand RefeshCommand { get; set; }
        public ICommand SelectionChanged { get; set; }
        public ICommand DetailCommand { get; set; }
        public ICommand ViewSelectionChanged { get; set; }

        #endregion

        private int _ViewSelectedIndex { get; set; }
        public int ViewSelectedIndex { get => _ViewSelectedIndex; set { _ViewSelectedIndex = value; OnPropertyChanged(); } }
        private string _ViewSelectedValue { get; set; }
        public string ViewSelectedValue { get => _ViewSelectedValue; set { _ViewSelectedValue = value; OnPropertyChanged(); } }
        
        private DateTime _SelectedDate { get; set; }
        public DateTime SelectedDate { get => _SelectedDate; set { _SelectedDate = value; OnPropertyChanged(); } }

        private ObservableCollection<ListBill> _ListBill { get; set; }
        public ObservableCollection<ListBill> ListBill { get => _ListBill; set { _ListBill = value; OnPropertyChanged(); } }
        private ObservableCollection<ListBill> _TempListBill { get; set; }
        public ObservableCollection<ListBill> TempListBill { get => _TempListBill; set { _TempListBill = value; OnPropertyChanged(); } }



        public BillViewModel()
        {
            Load_Bill();

            RefeshCommand = new RelayCommand<uc_Bill>
               ((p) =>
               {
                   return true;
               }, (p) =>
               {
                   p.dpReceptionDate.SelectedDate = null;
                   CustomerName = "";
                   IdHD = "";
                   SelectedCategory = null;
                  
                   LoadList();
               }
           );
            SearchCommand = new RelayCommand<uc_Bill>
               ((p) =>
               {
                   if (string.IsNullOrEmpty(p.dpReceptionDate.Text)
                   && string.IsNullOrEmpty(p.txbMaHD.Text)
                   && (string.IsNullOrEmpty(p.cbCategoryRoom.Text))
                   && string.IsNullOrEmpty(CustomerName)
                   ) return false;

                  

                   return true;
               }, (p) =>
               {
                   LoadList();
                   UnicodeConvert uni = new UnicodeConvert();
                   TempListBill = new ObservableCollection<ListBill>();


                   foreach (var item in ListBill)
                   {
                       if (
                       ((!string.IsNullOrEmpty(p.txbMaHD.Text) && uni.RemoveUnicode(item.Bill.IdBill.ToString()).ToLower().Contains(uni.RemoveUnicode(IdHD).ToLower()))
                       || (string.IsNullOrEmpty(p.txbMaHD.Text)))

                       && ((string.IsNullOrEmpty(p.cbCategoryRoom.Text) || (!string.IsNullOrEmpty(p.cbCategoryRoom.Text) && item.CategoryRoom == p.cbCategoryRoom.Text))
                        )
                       && ((!string.IsNullOrEmpty(p.txbCustomerName.Text) && uni.RemoveUnicode(item.Bill.Name).ToLower().Contains(uni.RemoveUnicode(CustomerName).ToLower()))
                       || (string.IsNullOrEmpty(p.txbCustomerName.Text)))

                     

                       && ((!string.IsNullOrEmpty(p.dpReceptionDate.Text)) && (item.Bill.Date_Bill == p.dpReceptionDate.SelectedDate.Value.Date)
                       || (string.IsNullOrEmpty(p.dpReceptionDate.Text)))) TempListBill.Add(item);
                   }
                   ListBill = TempListBill;
               }
           );
            SelectionChanged = new RelayCommand<DataGrid>
               ((p) =>
               {
                   return true;
               }, (p) =>
               {
                   Temp = new ObservableCollection<ListBill>(p.SelectedItems.Cast<ListBill>().ToList());
               }
           );
            DetailCommand = new RelayCommand<object>
                ((p) =>
                {
                    if (SelectedItem == null) return false;
                    return true;
                }, (p) =>
                {
                    if (Temp.Count() > 1)
                    {
                        MessageBox.Show("Vui lòng chỉ chọn 1 dòng để xem thông tin", "Lỗi chọn nhiều dữ liệu cùng lúc", MessageBoxButton.OK);
                    }
                    else
                    {
                        Bill_Detail BillDetail = new Bill_Detail(SelectedItem.Bill,true);
                        BillDetail.ShowDialog();
   
                    }

                }
            );
            ViewSelectionChanged = new RelayCommand<object>
                ((p) =>
                {
                    return true;
                }, (p) =>
                {
                    LoadList();
                }
            );
        }

        public void Load_Bill()
        {
            ViewSelectedIndex = 0;

            ListCategoryRoom = new ObservableCollection<CATEGORY_ROOM>(DataProvider.Ins.DB.CATEGORY_ROOM);
            ListBill = new ObservableCollection<ListBill>();
            var ListReception = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills);
            
            foreach (var item in ListReception)
            {
                ListBill temp = new ListBill();
                
                var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.IdRental == item.IdRental).SingleOrDefault();

                var room = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == rental.IdRoom).SingleOrDefault();

                var category_room = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == room.IdCategoryRoom).SingleOrDefault();

                temp.Bill = item;
                temp.CategoryRoom = category_room.Name;
                ListBill.Add(temp);
            }

        }
        public void LoadList()
        {
            if (ViewSelectedIndex == 0) Load_Bill();
            else LoadData_AtDay();

        }
        public void LoadData_AtDay()
        {
            var ListReception = new ObservableCollection<Bill>(DataProvider.Ins.DB.Bills);
            ListBill = new ObservableCollection<ListBill>();
            foreach (var item in ListReception)
            {
                if (item.Date_Bill.Value.Date.Day == DateTime.Now.Date.Day
                      && item.Date_Bill.Value.Date.Month == DateTime.Now.Date.Month
                      && item.Date_Bill.Value.Date.Year == DateTime.Now.Date.Year)
                {
                    ListBill temp = new ListBill();

                    var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.IdRental == item.IdRental).SingleOrDefault();

                    var room = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == rental.IdRoom).SingleOrDefault();

                    var category_room = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == room.IdCategoryRoom).SingleOrDefault();

                    temp.Bill = item;
                    temp.CategoryRoom = category_room.Name;
                    ListBill.Add(temp);
                }
            }
        }
    }

}
