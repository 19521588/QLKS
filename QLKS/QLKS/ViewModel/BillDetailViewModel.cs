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
    public class BillDetailViewModel : BaseViewModel
    {
        #region Command
        public ICommand CloseCommand { get; set; }

        public ICommand PrintCommand { get; set; }
        #endregion

        private int _TotalMoney { get; set; }
        public int TotalMoney { get => _TotalMoney; set { _TotalMoney = value; OnPropertyChanged(); } }
        private string _btText { get; set; }
        public string btText { get => _btText; set { _btText = value; OnPropertyChanged(); } }
        private bool _IsSave { get; set; }
        public bool IsSave { get => _IsSave; set { _IsSave = value; OnPropertyChanged(); } }
        private BillDetail _BillDetail { get; set; }
        public BillDetail BillDetail { get => _BillDetail; set { _BillDetail = value; OnPropertyChanged(); } }
        private ObservableCollection<ListBillInfo> _BillInfo { get; set; }
        public ObservableCollection<ListBillInfo> BillInfo { get => _BillInfo; set { _BillInfo = value; OnPropertyChanged(); } }

        public BillDetailViewModel()
        {
            IsSave = false;
        }
        public BillDetailViewModel(ObservableCollection<SelectService> detailPayment, int IdRental, bool IsPrint,USER User)
        {
            IsSave = false;
            Init(detailPayment, IdRental, IsPrint);
            PrintCommand = new RelayCommand<Bill_Detail>((p) =>
            {

                return true;
            }, (p) =>
            {
                if (!IsPrint)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        var bill = new Bill();
                        var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.IdRental ==IdRental).SingleOrDefault();
                        var room = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == rental.IdRoom).SingleOrDefault();
                        bill.Name = DataProvider.Ins.DB.EMPLOYEEs.Where(x=>x.IdEmployee==User.IdEmployee).SingleOrDefault().Name;
                        bill.Total = TotalMoney;
                        bill.Date_Bill = DateTime.Now;
                        bill.IdRental = IdRental;
                        bill.CategoryRoom= DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == room.IdCategoryRoom).SingleOrDefault().Name;
                        DataProvider.Ins.DB.Bills.Add(bill);
                        DataProvider.Ins.DB.SaveChanges();
                        foreach (var item in detailPayment)
                        {
                            var billInfo = new BILLINFO();
                            billInfo.IdBill = DataProvider.Ins.DB.Bills.ToList().Last().IdBill;
                            billInfo.Service = item.Service.Name;
                            billInfo.Price = item.Service.Price;
                            billInfo.Amount = item.Amount;
                            DataProvider.Ins.DB.BILLINFOes.Add(billInfo);
                            DataProvider.Ins.DB.SaveChanges();
                        }
                        IsPrint = !IsPrint;
                        IsSave = true;
                        LoadData(DataProvider.Ins.DB.Bills.ToList().Last(), IsPrint);
                    }

                }
                else
                {
                    BillTemplate billTemplate = new BillTemplate(DataProvider.Ins.DB.Bills.ToList().Last());
                    PrintViewModel printViewModel = new PrintViewModel();
                    billTemplate.Show();
                    billTemplate.Close();
                    printViewModel.PrintBill(billTemplate);
                }



            })
            {

            };
        }
        public BillDetailViewModel(Bill Bill, bool IsPrint)
        {
            IsSave = false;
            LoadData(Bill, IsPrint);

            CloseCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {

                p.Close();

            });
            PrintCommand = new RelayCommand<Bill_Detail>((p) =>
            {

                return true;
            }, (p) =>
            {
                if (IsPrint)
                {
                    BillTemplate billTemplate = new BillTemplate(Bill);
                    PrintViewModel printViewModel = new PrintViewModel();
                    billTemplate.Show();
                    billTemplate.Close();
                    printViewModel.PrintBill(billTemplate);
                }



            });
        }
        public void LoadData(Bill bill, bool isPrint)
        {
            if (isPrint)
            {
                btText = "In hóa đơn";
            }
            else
            {
                btText = "Thanh toán";
            }
            TotalMoney = bill.Total.Value;
            BillInfo = new ObservableCollection<ListBillInfo>();
            var billinfo = DataProvider.Ins.DB.BILLINFOes.Where(x => x.IdBill == bill.IdBill);
            int i = 1;

            foreach (var item in billinfo)
            {
                ListBillInfo temp = new ListBillInfo();
                temp.BillInfo = item;
                temp.STT = i;
                temp.Total = item.Amount * item.Price;

                BillInfo.Add(temp);
                i++;
            }

            BillDetail = new BillDetail();
            var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.IdRental == bill.IdRental).SingleOrDefault();
            var reservation = DataProvider.Ins.DB.RESERVATIONs.Where(x => x.IdReservation == rental.IdReservation).SingleOrDefault();


            var room = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == rental.IdRoom).SingleOrDefault();
            var roomCategory = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == room.IdCategoryRoom).SingleOrDefault();

            var customer = DataProvider.Ins.DB.CUSTOMERs.Where(x => x.IdCustomer == reservation.IdCustomer).SingleOrDefault();

            BillDetail.StartDate = reservation.Start_Date;
            BillDetail.EndDate = reservation.End_Date;
            BillDetail.AmountRenter = reservation.Amount;
            BillDetail.ServiceCharge = BillInfo.Sum(x => x.Total);
            BillDetail.CCCD = customer.CCCD;
            BillDetail.Name = customer.Name;
            BillDetail.Phone = customer.Phone;
            BillDetail.RoomCharge = TotalMoney - BillDetail.ServiceCharge;


        }

        public void Init(ObservableCollection<SelectService> detailPayment, int IdRental, bool IsPrint)
        {
            if (IsPrint)
            {
                btText = "In hóa đơn";
            }
            else
            {
                btText = "Thanh toán";
            }
         
            BillInfo = new ObservableCollection<ListBillInfo>();
            
            int i = 1;

            foreach (var item in detailPayment)
            {
                var billInfo = new BILLINFO();
                billInfo.IdBill = i;
                billInfo.Amount = item.Amount;
                billInfo.IdBill = i;
                billInfo.Service = item.Service.Name;
                billInfo.Price = item.Service.Price;
   
                ListBillInfo temp = new ListBillInfo();
                temp.BillInfo = billInfo;
                temp.STT = i;
                temp.Total = item.Total;

                BillInfo.Add(temp);
                i++;
            }

            BillDetail = new BillDetail();
            var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.IdRental == IdRental).SingleOrDefault();
            var reservation = DataProvider.Ins.DB.RESERVATIONs.Where(x => x.IdReservation == rental.IdReservation).SingleOrDefault();


            var room = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == rental.IdRoom).SingleOrDefault();
            var roomCategory = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == room.IdCategoryRoom).SingleOrDefault();

            var customer = DataProvider.Ins.DB.CUSTOMERs.Where(x => x.IdCustomer == reservation.IdCustomer).SingleOrDefault();

            BillDetail.StartDate = reservation.Start_Date;
            BillDetail.EndDate = reservation.End_Date;
            BillDetail.AmountRenter = reservation.Amount;
            BillDetail.ServiceCharge = BillInfo.Sum(x => x.Total);
            BillDetail.CCCD = customer.CCCD;
            BillDetail.Name = customer.Name;
            BillDetail.Phone = customer.Phone;

            if((reservation.End_Date.Day - reservation.Start_Date.Day)!=0)
            {
                BillDetail.RoomCharge = int.Parse(roomCategory.Price_Day.ToString()) * (reservation.End_Date.Day - reservation.Start_Date.Day);
            }
            else
            {
                BillDetail.RoomCharge = int.Parse(roomCategory.Price_Hour.ToString()) * (reservation.End_Date.Hour - reservation.Start_Date.Hour);

            }
            TotalMoney = int.Parse((BillDetail.RoomCharge + BillDetail.ServiceCharge).ToString());

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
