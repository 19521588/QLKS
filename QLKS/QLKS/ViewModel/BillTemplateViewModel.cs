﻿using QLKS.Model;
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
            var reservationDetail = DataProvider.Ins.DB.RESERVATION_DETAIL.Where(x => x.IdReservationDetail == reservation.IdReservationDetail).SingleOrDefault();

            var room = DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == rental.IdRoom).SingleOrDefault();
            var roomCategory = DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == room.IdCategoryRoom).SingleOrDefault();

            var customer = DataProvider.Ins.DB.CUSTOMERs.Where(x => x.IdCustomer == reservation.IdCustomer).SingleOrDefault();

            BillDetail.StartDate = reservationDetail.Start_Date;
            BillDetail.EndDate = reservationDetail.End_Date;
            BillDetail.AmountRenter = reservationDetail.Amount;
            BillDetail.ServiceCharge = BillInfo.Sum(x => x.Total);
            BillDetail.CCCD = customer.CCCD;
            BillDetail.Name = customer.Name;
            BillDetail.Phone = customer.Phone;
            BillDetail.RoomCharge = bill.Total.Value - BillDetail.ServiceCharge;


        }
    }
}