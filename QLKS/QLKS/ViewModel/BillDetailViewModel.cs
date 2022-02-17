using QLKS.Model;
using QLKS.Template;
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
    public class BillDetailViewModel:BaseViewModel
    {
        #region Command
        public ICommand CloseCommand { get; set; }
     
        public ICommand PrintCommand { get; set; }
        #endregion

        private int _TotalMoney { get; set; }
        public int TotalMoney { get => _TotalMoney; set { _TotalMoney = value; OnPropertyChanged(); } }
        private BillDetail _BillDetail { get; set; }
        public BillDetail BillDetail { get => _BillDetail; set { _BillDetail = value; OnPropertyChanged(); } }
        private ObservableCollection<ListBillInfo> _BillInfo { get; set; }
        public ObservableCollection<ListBillInfo> BillInfo { get => _BillInfo; set { _BillInfo = value; OnPropertyChanged(); } }
          
        public BillDetailViewModel()
        {

        }
        public BillDetailViewModel(Bill Bill)
        {
            LoadData(Bill);

            CloseCommand = new RelayCommand<Window>((p) => {
                return true;
            }, (p) =>
            {

                p.Close();

            });
            PrintCommand = new RelayCommand<Bill_Detail>((p) => {
               
                return true;
            }, (p) =>
            {
                BillTemplate billTemplate = new BillTemplate(Bill);
                PrintViewModel printViewModel = new PrintViewModel();
                billTemplate.Show();
                billTemplate.Close();
                printViewModel.PrintBill(billTemplate);

                //for (int i = 10; i < ListRepair.Count(); i = i + 30)
                //{
                //    ObservableCollection<ListRepair> newlist = new ObservableCollection<ListRepair>();
                //    for (int j = i ; j < i + 30 ; j++)
                //    {
                //        newlist.Add(ListRepair[j]);
                //    }
                //    SubBillTemplate subBillTemplate = new SubBillTemplate(newlist);
                //    PrintViewModel subPrint = new PrintViewModel();
                //    subPrint.PrintSubBill(subBillTemplate);

                //}
            });
        }
        public void LoadData(Bill bill)
        {
            TotalMoney = bill.Total.Value;
            BillInfo = new ObservableCollection<ListBillInfo>();
            var billinfo = DataProvider.Ins.DB.BILLINFOes.Where(x=>x.IdBill==bill.IdBill);
            int i = 1;

            foreach (var item in billinfo)
            {
                ListBillInfo temp = new ListBillInfo();
                temp.BillInfo = item;
                temp.STT = i;
                temp.Total = item.Amount*item.Price;
               
                BillInfo.Add(temp);
                i++;
            }

            BillDetail = new BillDetail();
            var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.IdRental == bill.IdRental).SingleOrDefault();
            var reservation = DataProvider.Ins.DB.RESERVATIONs.Where(x => x.IdReservation == rental.IdReservation).SingleOrDefault();
            var reservationDetail = DataProvider.Ins.DB.RESERVATION_DETAIL.Where(x => x.IdReservationDetail == reservation.IdReservationDetail).SingleOrDefault();

            var room = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == rental.IdRoom).SingleOrDefault();
            var roomCategory = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == room.IdCategoryRoom).SingleOrDefault();

            var customer = DataProvider.Ins.DB.CUSTOMERs.Where(x => x.IdCustomer == reservation.IdCustomer).SingleOrDefault();

            BillDetail.StartDate = reservationDetail.Start_Date;
            BillDetail.EndDate = reservationDetail.End_Date;
            BillDetail.AmountRenter = reservationDetail.Amount;
            BillDetail.ServiceCharge = BillInfo.Sum(x=>x.Total);
            BillDetail.CCCD = customer.CCCD;
            BillDetail.Name = customer.Name;
            BillDetail.Phone = customer.Phone;
            BillDetail.RoomCharge = TotalMoney - BillDetail.ServiceCharge;


        }
        public void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đóng cửa sổ này", "Thông báo",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else e.Cancel = true;
        }
    }
}
