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
    public class ConvenientDetailViewModel : BaseViewModel
    {
        private ObservableCollection<DETAIL_CONVINIENT> _ListConvenientDetail { get; set; }
        public ObservableCollection<DETAIL_CONVINIENT> ListConvenientDetail { get => _ListConvenientDetail; set { _ListConvenientDetail = value; OnPropertyChanged(); } }

        public ICommand OpenAddWindowCommand { get; set; }

        public ICommand OpenEditWindowCommand { get; set; }

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
                
                Load();
            });
        }

        void Load()
        {
            ListConvenientDetail = new ObservableCollection<DETAIL_CONVINIENT>(DataProvider.Ins.DB.DETAIL_CONVINIENT);
        }
    }
}
