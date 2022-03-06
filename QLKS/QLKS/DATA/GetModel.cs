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
        public ObservableCollection<CUSTOMER> getListCustomer()
        {
            ObservableCollection<CUSTOMER> list = new ObservableCollection<CUSTOMER>(DataProvider.Ins.DB.CUSTOMERs);
            return list;
        }

        //Danh sách phòng
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

        public ObservableCollection<CATEGORY_ROOM> getListCategoryRoom()
        {
            ObservableCollection<CATEGORY_ROOM> list = new ObservableCollection<CATEGORY_ROOM>(DataProvider.Ins.DB.CATEGORY_ROOM);
            return list;
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

        public ObservableCollection<RESERVATION> getListReservation()
        {
            ObservableCollection<RESERVATION> list = new ObservableCollection<RESERVATION>(DataProvider.Ins.DB.RESERVATIONs);
            return list;
        }
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
