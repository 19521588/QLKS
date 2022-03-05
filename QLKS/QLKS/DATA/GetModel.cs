using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DATA
{
    class GetModel
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
    }
}
