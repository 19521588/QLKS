using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS.Model;

namespace QLKS.Model
{
    public class DeleteModel
    {
        public void DeleteEMPLOYEE(EMPLOYEE itemDelete)
        {
            DataProvider.Ins.DB.EMPLOYEEs.Remove(itemDelete);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void DeleteCustomer(CUSTOMER itemDelete)
        {
            DataProvider.Ins.DB.CUSTOMERs.Remove(itemDelete);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void DeleteRoom(ROOM itemDelete)
        {
            DataProvider.Ins.DB.ROOMs.Remove(itemDelete);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void DeleteCategoryRoom(CATEGORY_ROOM itemDelete)
        {
            DataProvider.Ins.DB.CATEGORY_ROOM.Remove(itemDelete);
            DataProvider.Ins.DB.SaveChanges();
        }
    }
}
