using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    public class ListBill:BaseViewModel
    {
        private Bill _Bill { get; set; }
        public Bill Bill { get => _Bill; set { _Bill = value; OnPropertyChanged(); } }
        private String _CategoryRoom { get; set; }
        public String CategoryRoom { get => _CategoryRoom; set { _CategoryRoom = value; OnPropertyChanged(); } }
    }
}
