using QLKS.DATA;
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
        private string _SurChargeText { get; set; }
        public string SurChargeText { get => _SurChargeText; set { _SurChargeText = value; OnPropertyChanged(); } }
        private string _DiscountText { get; set; }
        public string DiscountText { get => _DiscountText; set { _DiscountText = value; OnPropertyChanged(); } }
        private int _SurCharge { get; set; }
        public int SurCharge { get => _SurCharge; set { _SurCharge = value; OnPropertyChanged(); } }
        private int _Discount { get; set; }
        public int Discount { get => _Discount; set { _Discount = value; OnPropertyChanged(); } }
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
        public BillDetailViewModel(ObservableCollection<SelectService> detailPayment, int IdRental, bool IsPrint, USER User)
        {
            IsSave = false;
            Init(detailPayment, IdRental, IsPrint);
            PrintCommand = new RelayCommand<Bill_Detail>((p) =>
            {

                return true;
            }, (p) =>
            {
                GetModel getModel = new GetModel();
                AddModel addModel = new AddModel();
                if (!IsPrint)
                {

                    if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        var bill = new Bill();
                        var rental = getModel.GetRentalById(IdRental);
                        var room = getModel.GetRoomById(rental.IdRoom);
                        bill.Name = getModel.GetEmployeeById(User.IdEmployee).Name;
                        bill.Total = TotalMoney;
                        bill.Date_Bill = DateTime.Now;
                        bill.IdRental = IdRental;
                        bill.CategoryRoom = getModel.GetCategoryRoomById(room.IdCategoryRoom).Name;
                        bill.Surcharge = int.Parse((BillDetail.RoomCharge * getModel.GetSetting().Surcharge / 100).ToString());
                        bill.Discount = int.Parse((TotalMoney * getModel.GetSetting().Discount / 100).ToString());
                        bill.SurchargePercent = getModel.GetSetting().Surcharge;
                        bill.DiscountPercent = getModel.GetSetting().Discount;
                        addModel.AddBill(bill);
                        foreach (var item in detailPayment)
                        {
                            var billInfo = new BILLINFO();
                            billInfo.IdBill = getModel.GetLastBill().IdBill;
                            billInfo.Service = item.Service.Name;
                            billInfo.Price = item.Service.Price;
                            billInfo.Amount = item.Amount;
                            addModel.AddBillInfo(billInfo);
                        }
                        IsPrint = !IsPrint;
                        IsSave = true;
                        LoadData(getModel.GetLastBill(), IsPrint);
                    }

                }
                else
                {
                    BillTemplate billTemplate = new BillTemplate(getModel.GetLastBill());
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
            GetModel getModel = new GetModel();
            var billinfo = getModel.GetListBillInfoByIdBill(bill.IdBill);
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
            var rental = getModel.GetRentalById(bill.IdRental);
            var reservation = getModel.GetReservationById(rental.IdReservation);


            var room = getModel.GetRoomById(rental.IdRoom);
            var roomCategory = getModel.GetCategoryRoomById(room.IdCategoryRoom);

            var customer = getModel.GetCustomerById(reservation.IdCustomer);

            BillDetail.StartDate = reservation.Start_Date;
            BillDetail.EndDate = reservation.End_Date;
            BillDetail.AmountRenter = reservation.Amount;
            BillDetail.ServiceCharge = BillInfo.Sum(x => x.Total);
            BillDetail.CCCD = customer.CCCD;
            BillDetail.Name = customer.Name;
            BillDetail.Phone = customer.Phone;
            BillDetail.RoomCharge = TotalMoney - BillDetail.ServiceCharge-int.Parse(bill.Surcharge.ToString())+ int.Parse(bill.Discount.ToString());

            if (bill.Surcharge == 0)
            {
                SurChargeText = "Phụ thu(0%)";

            }
            else
            {
                SurChargeText = "Phụ thu(" + bill.SurchargePercent + "%)";
            }
            if (bill.Discount == 0)
            {
                DiscountText = "Giảm giá(0%)";

            }
            else
            {
                DiscountText = "Giảm giá(" + bill.DiscountPercent + "%)";
            }
            Discount = int.Parse(bill.Discount.ToString());
            SurCharge = int.Parse(bill.Surcharge.ToString());


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
            GetModel getModel = new GetModel();

            var rental = getModel.GetRentalById(IdRental);
            var reservation = getModel.GetReservationById(rental.IdReservation);


            var room = getModel.GetRoomById(rental.IdRoom);
            var roomCategory = getModel.GetCategoryRoomById(room.IdCategoryRoom);

            var customer = getModel.GetCustomerById(reservation.IdCustomer);

            BillDetail.StartDate = reservation.Start_Date;
            BillDetail.EndDate = reservation.End_Date;
            BillDetail.AmountRenter = reservation.Amount;
            BillDetail.ServiceCharge = BillInfo.Sum(x => x.Total);
            BillDetail.CCCD = customer.CCCD;
            BillDetail.Name = customer.Name;
            BillDetail.Phone = customer.Phone;

            if (reservation.Date != 0)
            {
                BillDetail.RoomCharge = int.Parse(roomCategory.Price_Day.ToString()) * reservation.Date.Value;
            }
            else
            {
                if (reservation.Start_Date.Day != reservation.End_Date.Day)
                {
                    BillDetail.RoomCharge = int.Parse(roomCategory.Price_Hour.ToString()) * (24 + reservation.End_Date.Hour - reservation.Start_Date.Hour);
                }
                else
                {
                    if (reservation.End_Date.Hour == 0)
                    {
                        BillDetail.RoomCharge = int.Parse(roomCategory.Price_Hour.ToString()) * (24 - reservation.Start_Date.Hour);
                    }
                    else
                    {
                        BillDetail.RoomCharge = int.Parse(roomCategory.Price_Hour.ToString()) * (reservation.End_Date.Hour - reservation.Start_Date.Hour);
                    }
                }

            }
            TotalMoney = int.Parse((BillDetail.RoomCharge + BillDetail.ServiceCharge).ToString());
            if (getModel.GetSetting().Surcharge == 0)
            {
                SurChargeText = "Phụ thu(0%)";

            }
            else
            {
                SurChargeText = "Phụ thu(" + getModel.GetSetting().Surcharge + "%)";
            }
            if (getModel.GetSetting().Discount == 0)
            {
                DiscountText = "Giảm giá(0%)";

            }
            else
            {
                DiscountText = "Giảm giá(" +getModel.GetSetting().Discount+"%)";
            }
            Discount = getModel.GetSetting().Discount*TotalMoney/100;
            SurCharge = getModel.GetSetting().Surcharge* int.Parse(BillDetail.RoomCharge.ToString())/100;

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
