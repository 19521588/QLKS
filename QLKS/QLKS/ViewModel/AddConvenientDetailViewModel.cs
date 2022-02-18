using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class AddConvenientDetailViewModel : BaseViewModel
    {
        private ObservableCollection<ROOM> _ListRoom;
        public ObservableCollection<ROOM> ListRoom { get => _ListRoom; set { _ListRoom = value; OnPropertyChanged(); } }

        private ObservableCollection<CONVINIENT> _ListConvenient;
        public ObservableCollection<CONVINIENT> ListConvenient { get => _ListConvenient; set { _ListConvenient = value; OnPropertyChanged(); } }

        public ICommand CloseAddWindowCommand { get; set; }

        public ICommand AddCommand { get; set; }
        public AddConvenientDetailViewModel()
        {
            //Load dữ liệu combobox
            ListRoom = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs);
            ListConvenient = new ObservableCollection<CONVINIENT>(DataProvider.Ins.DB.CONVINIENTs);

            //Đóng cửa sổ
            CloseAddWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                p.Close();
            }
            );

            //Thêm
            AddCommand = new RelayCommand<wd_AddConvenientDetail>((p) => {
                if (String.IsNullOrEmpty(p.cmbSoPhong.Text) || String.IsNullOrEmpty(p.cmbTienNghi.Text) || String.IsNullOrEmpty(p.txtSoLuong.Text))
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {

                var new_convenient_detail = new DETAIL_CONVINIENT()
                {
                    IdRoom = DataProvider.Ins.DB.ROOMs.Where(x => x.Name == p.cmbSoPhong.Text).SingleOrDefault().IdRoom,
                    IdConvinient = DataProvider.Ins.DB.CONVINIENTs.Where(x => x.Name == p.cmbTienNghi.Text).SingleOrDefault().IdConvinient,
                    Amount = Int32.Parse(p.txtSoLuong.Text),
                   

                };
                DataProvider.Ins.DB.DETAIL_CONVINIENT.Add(new_convenient_detail);
                DataProvider.Ins.DB.SaveChanges();
                p.Close();
            });
        }
    }
}
