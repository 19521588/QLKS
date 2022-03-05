using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DATA
{
    public class GetModel
    {
        public RENTAL GetRentalById(int idRental)
        {
            return DataProvider.Ins.DB.RENTALs.Where(x => x.IdRental == idRental).SingleOrDefault();
        }
        public List<RENTAL> GetRentalByTime(DateTime time)
        {
            return DataProvider.Ins.DB.RENTALs.Where(x => x.DateRental.Value.Month == time.Month && x.DateRental.Value.Year == time.Year).ToList();
        }
        public List<BILLINFO> GetBillInfo()
        {
            return DataProvider.Ins.DB.BILLINFOes.ToList();
        }
        public List<BILLINFO> GetBillInfoByIdBill(int idBill)
        {
            return DataProvider.Ins.DB.BILLINFOes.Where(x => x.IdBill == idBill).ToList();
        }
        public List<Bill> GetBillOrderByDateBill()
        {
            return DataProvider.Ins.DB.Bills.OrderBy(x => x.Date_Bill).ToList();
        }
        public List<Bill> GetBillByYearAndOrderByDateBill(int year)
        {
            return DataProvider.Ins.DB.Bills.Where(x => x.Date_Bill.Value.Year == year).OrderBy(x => x.Date_Bill).ToList();
        }
    }
}
