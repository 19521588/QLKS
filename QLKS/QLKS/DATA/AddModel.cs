using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;
using QLKS.ViewModel;

namespace QLKS.DATA
{
    public class AddModel
    {
        public void AddEmployee(EMPLOYEE additem)
        {
            DataProvider.Ins.DB.EMPLOYEEs.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void AddService(SERVICE additem)
        {
            DataProvider.Ins.DB.SERVICEs.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void AddCategoryService(CATEGORY_SERVICE additem)
        {
            DataProvider.Ins.DB.CATEGORY_SERVICE.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void AddConvinient(CONVINIENT additem)
        {
            DataProvider.Ins.DB.CONVINIENTs.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void AddDetailConvinient(DETAIL_CONVINIENT additem)
        {
            DataProvider.Ins.DB.DETAIL_CONVINIENT.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }
        public void AddCustomer(CUSTOMER additem)
        {
            DataProvider.Ins.DB.CUSTOMERs.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void AddRoom(ROOM additem)
        {
            DataProvider.Ins.DB.ROOMs.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void AddCategoryRoom(CATEGORY_ROOM additem)
        {
            DataProvider.Ins.DB.CATEGORY_ROOM.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }
        public void AddBill(Bill additem)
        {
            DataProvider.Ins.DB.Bills.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }
        public void AddBillInfo(BILLINFO additem)
        {
            DataProvider.Ins.DB.BILLINFOes.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }
        public void AddSaleReport(SALES_REPORT additem)
        {
            DataProvider.Ins.DB.SALES_REPORT.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }
        public void AddSaleReportDetail(SALES_REPORT_DETAIL additem)
        {
            DataProvider.Ins.DB.SALES_REPORT_DETAIL.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void AddReservation(RESERVATION additem)
        {
            DataProvider.Ins.DB.RESERVATIONs.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void AddReservationDetail(RESERVATION_DETAIL additem)
        {
            DataProvider.Ins.DB.RESERVATION_DETAIL.Add(additem);
            DataProvider.Ins.DB.SaveChanges();
        }
    }
}
