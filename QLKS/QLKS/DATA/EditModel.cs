using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.DATA
{
    public class EditModel
    {
        public void EditCategoryRoom(CATEGORY_ROOM item, string name, string beds, string price_hour, string price_day )
        {
            if(name!="")
            {
                item.Name=name;
            }
            if (beds != "")
            {
                item.Beds = Int32.Parse(beds);
            }
            if (price_hour != "")
            {
                item.Price_Hour = Int32.Parse(price_hour);
            }
            if (price_day != "")
            {
                item.Price_Day = Int32.Parse(price_day);
            }
            DataProvider.Ins.DB.SaveChanges();
        }
    }
}
