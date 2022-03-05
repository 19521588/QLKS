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
    }
}
