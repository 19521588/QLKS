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
        public void EditRoom(ROOM item, string name, int idcategory )
        {
            if(name!="")
            {
                item.Name = name;
            }
            if(idcategory != 0){
                item.IdCategoryRoom = idcategory;
            }
            DataProvider.Ins.DB.SaveChanges();
        }
        public void EditEmployee(EMPLOYEE employee, string name, string address, DateTime birth, string phone, string cccd, string sex, string position, string salary )
        {
            if(name != "")
            {
                employee.Name = name;
            }   
            if(address != "")
            {
                employee.Address = address;
            }   
            if(birth != null)
            {
                employee.BirthDay = birth;
            }   
            if(phone != "")
            {
                employee.Phone = phone;
            }   
            if(cccd != "")
            {
                employee.CCCD = cccd;
            }   
            if(sex != "")
            {
                employee.Sex = sex;
            }   
            if(position != "")
            {
                employee.Position = position;
            }   
            if(salary != "")
            {
                employee.Salary = position;
            }
            DataProvider.Ins.DB.SaveChanges();
        }
        public void EditCustomer(CUSTOMER customer, string name, string address, DateTime birth, string phone, string cccd, string sex, string nationality)
        {
            if (name != "")
            {
                customer.Name = name;
            }
            if (address != "")
            {
                customer.Address = address;
            }
            if (birth != null)
            {
                customer.BirthDay = birth;
            }
            if (phone != "")
            {
                customer.Phone = phone;
            }
            if (cccd != "")
            {
                customer.CCCD = cccd;
            }
            if (sex != "")
            {
                customer.Sex = sex;
            }
            if (nationality != "")
            {
                customer.Nationality = nationality;
            }
            DataProvider.Ins.DB.SaveChanges();
        }

        public void EditService(SERVICE service, string name, int idcategory, int price)
        {
            if(name != "")
            {
                service.Name = name;
            }    
            if(price != 0)
            {
                service.Price = price;
            }    
            if(idcategory != 0)
            {
                service.IdCategoryService = idcategory;
            }
            DataProvider.Ins.DB.SaveChanges();
        }   
        public void EditCategoryService(CATEGORY_SERVICE categoryService, string name)
        {
            if(name != "")
            {
                categoryService.Name = name;
            }
            DataProvider.Ins.DB.SaveChanges();
        }

        public void EditConvinient(CONVINIENT convinient, string name)
        {
            if(name != "")
            {
                convinient.Name = name;
            }
            DataProvider.Ins.DB.SaveChanges();
        }

        public void EditConvinientDetail(DETAIL_CONVINIENT detail, int idconvinient,int idroom, int amount)
        {
            if(amount != 0)
            {
                detail.Amount = amount;
            }
            detail.IdConvinient = idconvinient;
            detail.IdRoom = idroom;
            DataProvider.Ins.DB.SaveChanges();
        }
    }
}
