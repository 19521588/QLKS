using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class BillDetailViewModel:BaseViewModel
    {
        #region Command
        public ICommand CloseCommand { get; set; }
     
        public ICommand PrintCommand { get; set; }
        #endregion

        private int _TotalMoney { get; set; }
        public int TotalMoney { get => _TotalMoney; set { _TotalMoney = value; OnPropertyChanged(); } }
        private BillDetail _BillDetail { get; set; }
        public BillDetail BillDetail { get => _BillDetail; set { _BillDetail = value; OnPropertyChanged(); } }
        private ObservableCollection<ListBillInfo> _BillInfo { get; set; }
        public ObservableCollection<ListBillInfo> BillInfo { get => _BillInfo; set { _BillInfo = value; OnPropertyChanged(); } }
          
        public BillDetailViewModel()
        {

        }
        public BillDetailViewModel(Bill Bill)
        {

        }
    }
}
