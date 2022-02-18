using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class EditConvenientViewModel : BaseViewModel
    {
        public ICommand CloseEditWindowCommand { get; set; }
        public ICommand EditConvenientCommand { get; set; }
        private string _Name { get; set; }
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private int _Id { get; set; }
        public int Id { get => _Id; set { _Id = value; OnPropertyChanged(); } }
        public EditConvenientViewModel(CONVINIENT convinient)
        {
            Name = convinient.Name;
            Id = convinient.IdConvinient;

            //Đóng cửa số
            CloseEditWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                p.Close();
            }
            );

            //Cập nhật thông tin
            EditConvenientCommand = new RelayCommand<wd_EditConvenient>((p) =>
            {
                if (String.IsNullOrEmpty(p.txtTenTN.Text))
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var in4 = DataProvider.Ins.DB.CONVINIENTs.Where(y => y.IdConvinient == Id).SingleOrDefault();
                in4.Name = Name;
                DataProvider.Ins.DB.SaveChanges();

                p.Close();
            }
            );
        }
    }
}
