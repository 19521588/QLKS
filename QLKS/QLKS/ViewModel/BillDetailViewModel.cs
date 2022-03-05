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
