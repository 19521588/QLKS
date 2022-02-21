using QLKS.Convert;
using QLKS.Model;
using QLKS.UserControlss;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class ConvenientDetailViewModel : BaseViewModel
    {
        private ObservableCollection<DETAIL_CONVINIENT> _ListConvenientDetail { get; set; }
        public ObservableCollection<DETAIL_CONVINIENT> ListConvenientDetail { get => _ListConvenientDetail; set { _ListConvenientDetail = value; OnPropertyChanged(); } }
        private ObservableCollection<ROOM> _ListRoom { get; set; }
        public ObservableCollection<ROOM> ListRoom { get => _ListRoom; set { _ListRoom = value; OnPropertyChanged(); } }
        private ObservableCollection<CONVINIENT> _ListConvenient { get; set; }
        public ObservableCollection<CONVINIENT> ListConvenient { get => _ListConvenient; set { _ListConvenient = value; OnPropertyChanged(); } }

        public ICommand OpenAddWindowCommand { get; set; }
        public ICommand OpenEditWindowCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RefeshCommand { get; set; }

        private DETAIL_CONVINIENT _SelectedItem { get; set; }
        public DETAIL_CONVINIENT SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;

                if (SelectedItem != null)
                {

                }
                OnPropertyChanged();
            }
        }
        public ConvenientDetailViewModel()
        {
            Load();

            //Mở cửa số để thêm dịch vụ
            OpenAddWindowCommand = new RelayCommand<object>((p) => {
                return true;
            },
            (p) => {
                wd_AddConvenientDetail wd = new wd_AddConvenientDetail();
                wd.ShowDialog();
                Load();
            });

            //Mở cửa số để sửa dịch vụ
            OpenEditWindowCommand = new RelayCommand<object>((p) => {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;
            },
            (p) => {
                wd_EditConvenientDetail wd = new wd_EditConvenientDetail(SelectedItem);
                wd.ShowDialog();
                Load();
            });

            //Tìm kiếm
            SearchCommand = new RelayCommand<uc_QuanLyChiTietTienNghi>((p) =>
            {
                if (String.IsNullOrEmpty(p.cbConvinient.Text) && String.IsNullOrEmpty(p.cbRoom.Text))
                {
                    return false;
                }
                return true;
            },
            (p) => {
                UnicodeConvert uni = new UnicodeConvert();

                ObservableCollection<DETAIL_CONVINIENT> _ListTempt = new ObservableCollection<DETAIL_CONVINIENT>();
                ObservableCollection<DETAIL_CONVINIENT> _ListNew = new ObservableCollection<DETAIL_CONVINIENT>(DataProvider.Ins.DB.DETAIL_CONVINIENT);

                foreach (var item in _ListNew)
                {
                    if ((string.IsNullOrEmpty(p.cbRoom.Text) || (!string.IsNullOrEmpty(p.cbRoom.Text) && uni.RemoveUnicode(item.ROOM.Name).ToLower().Contains(uni.RemoveUnicode(p.cbRoom.Text).ToLower())))
                        && (string.IsNullOrEmpty(p.cbConvinient.Text) || (!string.IsNullOrEmpty(p.cbConvinient.Text) && uni.RemoveUnicode(item.CONVINIENT.Name).ToLower().Contains(uni.RemoveUnicode(p.cbConvinient.Text).ToLower()))))
                    {
                        _ListTempt.Add(item);
                    }
                }

                ListConvenientDetail = _ListTempt;
            });

            //Làm mới
            RefeshCommand = new RelayCommand<uc_QuanLyDichVu>((p) =>
            {
                return true;
            },
            (p) =>
            {
                p.txbTenDV.Text = null;
                p.cbCategoryService.Text = null;
                Load();
            });
        }

        void Load()
        {
            ListConvenientDetail = new ObservableCollection<DETAIL_CONVINIENT>(DataProvider.Ins.DB.DETAIL_CONVINIENT);
            ListRoom = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs);
            ListConvenient = new ObservableCollection<CONVINIENT>(DataProvider.Ins.DB.CONVINIENTs);
        }
    }
}
