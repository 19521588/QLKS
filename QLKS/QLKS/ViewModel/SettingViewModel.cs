using QLKS.DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class SettingViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        private int _SurCharge { get; set; }
        public int SurCharge { get => _SurCharge; set { _SurCharge = value; OnPropertyChanged(); } }
        private int _Discount { get; set; }
        public int Discount { get => _Discount; set { _Discount = value; OnPropertyChanged(); } }
        public SettingViewModel()
        {
            EditModel editModel = new EditModel();
            GetModel getModel = new GetModel();

            SurCharge = int.Parse(getModel.GetSetting().Surcharge.ToString());
            Discount = int.Parse(getModel.GetSetting().Discount.ToString());

            CloseCommand = new RelayCommand<wd_Setting>(
            (p) =>
            { return true; },
            (p) =>
            {
                p.Close();
            }
            );
           SaveCommand = new RelayCommand<wd_Setting>(
           (p) =>
           { return true; },
           (p) =>
           {
              
               if (MessageBox.Show("Bạn có chắc chắn muốn lưu thay đổi này", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
               {
                   
                   var setting = getModel.GetSetting();
                   if (SurCharge==setting.Surcharge && Discount==setting.Discount)
                   {
                       p.Close();
                   }
                   else
                   {
                       editModel.EditSetting(SurCharge, Discount);
                       p.Close();
                   }
               }

                   
           }
           );
        }

    }

}
