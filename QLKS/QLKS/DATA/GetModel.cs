using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DATA
{
    public class GetModel
    {
        public CUSTOMER GetCustomerById(int idCustomer)
        {
            return DataProvider.Ins.DB.CUSTOMERs.Where(x => x.IdCustomer == idCustomer).SingleOrDefault();
        }
        public ObservableCollection<CUSTOMER> getListCustomer()
        {
            ObservableCollection<CUSTOMER> list = new ObservableCollection<CUSTOMER>(DataProvider.Ins.DB.CUSTOMERs);
            return list;
        }

        //Danh sách phòng
        public ROOM GetRoomById(int idRoom)
        {
            return DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == idRoom).SingleOrDefault();
        }
        public ObservableCollection<ROOM> getListRoom()
        {
            ObservableCollection<ROOM> list = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs);
            return list;
        }

        public ObservableCollection<ROOM> getListAvailableRoom(DateTime startday, DateTime endday)
        {
            ObservableCollection<ROOM> list = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs);
            return list;
        }
        public CATEGORY_ROOM GetCategoryRoomById(int idCategoryRoom)
        {
            return DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == idCategoryRoom).SingleOrDefault();
        }

        public ObservableCollection<CATEGORY_ROOM> getListCategoryRoom()
        {
            ObservableCollection<CATEGORY_ROOM> list = new ObservableCollection<CATEGORY_ROOM>(DataProvider.Ins.DB.CATEGORY_ROOM);
            return list;
        }
        public EMPLOYEE GetEmployeeById(int idEmployee)
        {
            return DataProvider.Ins.DB.EMPLOYEEs.Where(x => x.IdEmployee == idEmployee).SingleOrDefault();
        }

        public ROOM getRoom(int idRoom)
        {
            return DataProvider.Ins.DB.ROOMs.Where(x => x.IdRoom == idRoom).SingleOrDefault();
        }

        public CATEGORY_ROOM getCategoryRoom(int idcategory)
        {
            return DataProvider.Ins.DB.CATEGORY_ROOM.Where(x => x.IdCategoryRoom == idcategory).SingleOrDefault();
        }

        public EMPLOYEE getEmployee(int idEmployee)
        {
            return DataProvider.Ins.DB.EMPLOYEEs.Where(x => x.IdEmployee == idEmployee).SingleOrDefault();
        }

        public CUSTOMER getCustomer(int idCustomer)
        {
            return DataProvider.Ins.DB.CUSTOMERs.Where(x => x.IdCustomer == idCustomer).SingleOrDefault();
        }

        public SERVICE getService(int idService)
        {
            return DataProvider.Ins.DB.SERVICEs.Where(x => x.IdService == idService).SingleOrDefault();
        }

        public CATEGORY_SERVICE getCategoryService(int idCategoryService)
        {
            return DataProvider.Ins.DB.CATEGORY_SERVICE.Where(x => x.IdCategoryService == idCategoryService).SingleOrDefault();
        }

        public CONVINIENT getConvinient(int idConvinient)
        {
            return DataProvider.Ins.DB.CONVINIENTs.Where(x => x.IdConvinient == idConvinient).SingleOrDefault();
        }    

        public DETAIL_CONVINIENT getDetailConvinient(int idDetail)
        {
            return DataProvider.Ins.DB.DETAIL_CONVINIENT.Where(x => x.IdConvinientDetail == idDetail).SingleOrDefault();
        }    

        public ObservableCollection<EMPLOYEE> getListEmployee()
        {
            ObservableCollection<EMPLOYEE> list = new ObservableCollection<EMPLOYEE>(DataProvider.Ins.DB.EMPLOYEEs);
            return list;
        }
        public RESERVATION GetReservationById(int idReservation)
        {
            return DataProvider.Ins.DB.RESERVATIONs.Where(x => x.IdReservation == idReservation).SingleOrDefault();
        }

        public ObservableCollection<RESERVATION> getListReservation()
        {
            ObservableCollection<RESERVATION> list = new ObservableCollection<RESERVATION>(DataProvider.Ins.DB.RESERVATIONs);
            return list;
        }
        public RESERVATION getReservationNotPaymentAtTime(DateTime time, int IdRoom)
        {
            return DataProvider.Ins.DB.RESERVATIONs.Where(x => x.End_Date >= time && x.Start_Date <= time && x.RESERVATION_DETAIL.FirstOrDefault().IdRoom == IdRoom && x.RESERVATION_DETAIL.FirstOrDefault().Status != "Phòng đã thanh toán").SingleOrDefault();
        }
        public RESERVATION_DETAIL getReservationDetailByIdAndIdRoom(int IdReservation, int IdRoom)
        {
            return DataProvider.Ins.DB.RESERVATION_DETAIL.Where(x => x.IdRoom == IdRoom && x.IdReservation == IdReservation).SingleOrDefault();

        }
        public RENTAL GetRentalById(int idRental)
        {
            return DataProvider.Ins.DB.RENTALs.Where(x => x.IdRental == idRental).SingleOrDefault();
        }
        public List<RENTAL> GetListRentalByTime(DateTime time)
        {
            return DataProvider.Ins.DB.RENTALs.Where(x => x.DateRental.Value.Month == time.Month && x.DateRental.Value.Year == time.Year).ToList();
        }
        public List<BILLINFO> GetListBillInfo()
        {
            return DataProvider.Ins.DB.BILLINFOes.ToList();
        }
        public List<BILLINFO> GetListBillInfoByIdBill(int idBill)
        {
            return DataProvider.Ins.DB.BILLINFOes.Where(x => x.IdBill == idBill).ToList();
        }
        public List<Bill> GetListBillOrderByDateBill()
        {
            return DataProvider.Ins.DB.Bills.OrderBy(x => x.Date_Bill).ToList();
        }
        public Bill GetLastBill()
        {
            return DataProvider.Ins.DB.Bills.ToList().Last();
        }
        public List<Bill> GetListBillByYearAndOrderByDateBill(int year)
        {
            return DataProvider.Ins.DB.Bills.Where(x => x.Date_Bill.Value.Year == year).OrderBy(x => x.Date_Bill).ToList();
        }
        public List<Bill> GetListBillByTime(string year, string month)
        {
            return DataProvider.Ins.DB.Bills.Where(x => x.Date_Bill.Value.Year.ToString() == year && x.Date_Bill.Value.Month.ToString() == month).ToList();
        }
        public SALES_REPORT GetSaleReportByTime(int year,int month)
        {
            return DataProvider.Ins.DB.SALES_REPORT.Where(x => x.SalesReport_Date.Value.Year == year && x.SalesReport_Date.Value.Month == month).SingleOrDefault();
        }
        public ObservableCollection<SALES_REPORT> getListSaleReport()
        {
            ObservableCollection<SALES_REPORT> list = new ObservableCollection<SALES_REPORT>(DataProvider.Ins.DB.SALES_REPORT);
            return list;
        }
        public List<SALES_REPORT_DETAIL> GetListSalesReportDetailByIdSaleReport(int idSaleReport)
        {
            return DataProvider.Ins.DB.SALES_REPORT_DETAIL.Where(x => x.IdSalesReport == idSaleReport).ToList();
        }
        public List<USER> GetUserByUserNameAndPassword(string UserName, string  password)
        {
            return DataProvider.Ins.DB.USERS.Where(x => x.UserName == UserName && x.Password == password).ToList();
        }
        public SETTING GetSetting()
        {
            return DataProvider.Ins.DB.SETTINGs.First();
        }
    }
}
