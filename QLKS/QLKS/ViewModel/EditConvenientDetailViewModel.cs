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
    public class EditConvenientDetailViewModel : BaseViewModel
    {
        private int _IdConvenientDetail { get; set; }
        public int IdConvenientDetail { get => _IdConvenientDetail; set { _IdConvenientDetail = value; OnPropertyChanged(); } }

        private String _Room { get; set; }
        public String Room { get => _Room; set { _Room = value; OnPropertyChanged(); } }

        private String _Convinient { get; set; }
        public String Convinient { get => _Convinient; set { _Convinient = value; OnPropertyChanged(); } }

        private int _Amount { get; set; }
        public int Amount { get => _Amount; set { _Amount = value; OnPropertyChanged(); } }

        private ObservableCollection<ROOM> _ListRoom;
        public ObservableCollection<ROOM> ListRoom { get => _ListRoom; set { _ListRoom = value; OnPropertyChanged(); } }

        private ObservableCollection<CONVINIENT> _ListConvenient;
        public ObservableCollection<CONVINIENT> ListConvenient { get => _ListConvenient; set { _ListConvenient = value; OnPropertyChanged(); } }

        public ICommand CloseWindowCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public EditConvenientDetailViewModel(DETAIL_CONVINIENT detail_convenient)
        {
            //Load dữ liệu combobox
            ListRoom = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs);
            ListConvenient = new ObservableCollection<CONVINIENT>(DataProvider.Ins.DB.CONVINIENTs);

            //Load dữ liệu hiển thị
            IdConvenientDetail = detail_convenient.IdConvinientDetail;
            Room = DataProvider.Ins.DB.ROOMs.Where(y => y.IdRoom == detail_convenient.IdRoom).SingleOrDefault().Name;
            Convinient = DataProvider.Ins.DB.CONVINIENTs.Where(y => y.IdConvinient == detail_convenient.IdConvinient).SingleOrDefault().Name;
            Amount = detail_convenient.Amount;


            //Đóng cửa sổ
            CloseWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {

                p.Close();
            }
            );

            //Sửa
            EditCommand = new RelayCommand<wd_EditConvenientDetail>((p) => {
                if (String.IsNullOrEmpty(p.cmbSoPhong.Text) || String.IsNullOrEmpty(p.cmbTienNghi.Text) || String.IsNullOrEmpty(p.txtSoLuong.Text))
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thay đổi mật khẩu", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    var in4 = DataProvider.Ins.DB.DETAIL_CONVINIENT.Where(y => y.IdConvinientDetail == IdConvenientDetail).SingleOrDefault();
                    in4.Amount = Amount;
                    in4.IdRoom = DataProvider.Ins.DB.ROOMs.Where(z => z.Name == Room).SingleOrDefault().IdRoom;
                    in4.IdConvinient = DataProvider.Ins.DB.CONVINIENTs.Where(z => z.Name == Convinient).SingleOrDefault().IdConvinient;
                    DataProvider.Ins.DB.SaveChanges();
                    p.Close();
                }
                
            });
        }
    }
}
