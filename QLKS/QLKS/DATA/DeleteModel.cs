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
        public void EMPLOYEE(EMPLOYEE itemDelete)
        {
            DataProvider.Ins.DB.EMPLOYEEs.Remove(itemDelete);
            DataProvider.Ins.DB.SaveChanges();
        }
    }
}
