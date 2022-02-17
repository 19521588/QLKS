using QLKS.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class PrintViewModel:BaseViewModel
    {
        public ICommand PrintBillCommand { get; set; }
        public PrintViewModel()
        {
           
            PrintBillCommand = new RelayCommand<BillTemplate>((p) => true, (p) => PrintBill(p));
            

        }
        public void PrintBill(BillTemplate billTemplate)
        {

            billTemplate.Height = billTemplate.Height ;
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(billTemplate.All, "hoadon");
            }

        }
    }
}
