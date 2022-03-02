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
    }
}
