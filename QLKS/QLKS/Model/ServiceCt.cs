using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.Model
{
    public class ServiceCt:BaseViewModel
    {
        private int _STT { get; set; }
        public int STT { get => _STT; set { _STT = value; OnPropertyChanged(); } }
        private SERVICE _Service { get; set; }
        public SERVICE Service { get => _Service; set { _Service = value; OnPropertyChanged(); } }
        private String _Category { get; set; }
        public String Category { get => _Category; set { _Category = value; OnPropertyChanged(); } }

    }
}
