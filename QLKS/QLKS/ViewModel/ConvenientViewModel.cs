using QLKS.Convert;
using QLKS.Model;
using QLKS.UserControlss;
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
    public class ConvenientViewModel : BaseViewModel
    {
        private ObservableCollection<CONVINIENT> _ListConvenient { get; set; }
        public ObservableCollection<CONVINIENT> ListConvenient { get => _ListConvenient; set { _ListConvenient = value; OnPropertyChanged(); } }
        public ICommand OpenAddWindowCommand { get; set; }
        public ICommand OpenEditConvenientWindowCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand RefeshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        private CONVINIENT _SelectedItem { get; set; }
        public CONVINIENT SelectedItem
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

        public ConvenientViewModel()
        {
            DeleteModel delete = new DeleteModel();
            Load();

            //Mở cửa số để thêm tiện ích
            OpenAddWindowCommand = new RelayCommand<object>((p) => {
                return true;
            },
            (p) => {
                wd_AddConvenient wd = new wd_AddConvenient();
                wd.ShowDialog();
                Load();
            });

            //Mở cửa số để sửa tiện ích
            OpenEditConvenientWindowCommand = new RelayCommand<object>((p) => {
                if (SelectedItem == null)
                {
                    return false;
                }
                return true;
            },
            (p) => {
                wd_EditConvenient wd = new wd_EditConvenient(SelectedItem);
                wd.ShowDialog();
                Load();
            });

            //Tìm kiếm
            SearchCommand = new RelayCommand<uc_QuanLyTienNghi>((p) =>
            {
                if (string.IsNullOrEmpty(p.txbTenTN.Text))
                {
                    return false;
                }
                return true;
            },
            (p) => {
                UnicodeConvert uni = new UnicodeConvert();

                ObservableCollection<CONVINIENT> _ListTempt = new ObservableCollection<CONVINIENT>();
                ObservableCollection<CONVINIENT> _ListNew = new ObservableCollection<CONVINIENT>(DataProvider.Ins.DB.CONVINIENTs);

                foreach (var item in _ListNew)
                {
                    if ((string.IsNullOrEmpty(p.txbTenTN.Text) || (!string.IsNullOrEmpty(p.txbTenTN.Text) && uni.RemoveUnicode(item.Name).ToLower().Contains(uni.RemoveUnicode(p.txbTenTN.Text).ToLower()))))
                    {
                        _ListTempt.Add(item);
                    }
                }

                ListConvenient = _ListTempt;
            });

            //Làm mới
            RefeshCommand = new RelayCommand<uc_QuanLyTienNghi>((p) =>
            {
                return true;
            },
            (p) =>
            {
                p.txbTenTN.Text = null;
                Load();
            });

            //Xóa
            DeleteCommand = new RelayCommand<uc_QuanLyTienNghi>((p) =>
            {
                if (SelectedItem == null)
                    return false;
                return true;
            },
            (p) =>
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa tiện nghi này", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    var in4 = DataProvider.Ins.DB.CONVINIENTs.Where(y => y.IdConvinient == SelectedItem.IdConvinient).SingleOrDefault();

                    ObservableCollection<DETAIL_CONVINIENT> ListTemp = new ObservableCollection<DETAIL_CONVINIENT>(DataProvider.Ins.DB.DETAIL_CONVINIENT.Where(x => x.IdConvinient == in4.IdConvinient));

                    if (ListTemp.Count() > 0)
                    {
                        MessageBox.Show("Loại tiện nghi này đang được sử dụng", "Xóa thất bại", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        delete.DeleteConvinient(in4);
                        Load();
                    }

                }
            });
        }

        void Load()
        {
            ListConvenient = new ObservableCollection<CONVINIENT>(DataProvider.Ins.DB.CONVINIENTs);
        }
    }
}
