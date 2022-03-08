using QLKS.DATA;
using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.ViewModel
{
    public class BillTemplateViewModel:BaseViewModel
    {
        private string _SurChargeText { get; set; }
        public string SurChargeText { get => _SurChargeText; set { _SurChargeText = value; OnPropertyChanged(); } }
        private string _DiscountText { get; set; }
        public string DiscountText { get => _DiscountText; set { _DiscountText = value; OnPropertyChanged(); } }
        private int _SurCharge { get; set; }
        public int SurCharge { get => _SurCharge; set { _SurCharge = value; OnPropertyChanged(); } }
        private int _Discount { get; set; }
        public int Discount { get => _Discount; set { _Discount = value; OnPropertyChanged(); } }
        private BillDetail _BillDetail { get; set; }
        public BillDetail BillDetail { get => _BillDetail; set { _BillDetail = value; OnPropertyChanged(); } }
        private Bill _Bill { get; set; }
        public Bill Bill { get => _Bill; set { _Bill = value; OnPropertyChanged(); } }
        private ObservableCollection<ListBillInfo> _BillInfo { get; set; }
        public ObservableCollection<ListBillInfo> BillInfo { get => _BillInfo; set { _BillInfo = value; OnPropertyChanged(); } }

        public BillTemplateViewModel(Bill bill)
        {
            LoadData(bill);
        }
        public void LoadData(Bill bill)
        {
            Bill = bill;
            BillInfo = new ObservableCollection<ListBillInfo>();
            GetModel getModel=new GetModel();
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
            BillDetail.RoomCharge = bill.Total.Value - BillDetail.ServiceCharge;

            if (bill.Surcharge == 0)
            {
                SurChargeText = "Phụ thu(0%):";

            }
            else
            {
                SurChargeText = "Phụ thu(" +bill.SurchargePercent + "%)";
            }
            if (bill.Discount == 0)
            {
                DiscountText = "Giảm giá(0%):";

            }
            else
            {
                DiscountText = "Giảm giá(" + bill.DiscountPercent + "%)";
            }
            Discount = int.Parse(bill.Discount.ToString());
            SurCharge = int.Parse(bill.Surcharge.ToString());
        }
    }
}
