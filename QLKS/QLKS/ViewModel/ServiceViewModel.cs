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
    public class ServiceViewModel : BaseViewModel
    {
        private ObservableCollection<SERVICE> _ListService { get; set; }
        public ObservableCollection<SERVICE> ListService { get => _ListService; set { _ListService = value; OnPropertyChanged(); } }

        public ICommand OpenAddWindowCommand { get; set; }

        public ICommand OpenEditServiceWindowCommand { get; set; }

        public ServiceViewModel()
        {
            Load();

            //Mở cửa số để thêm dịch vụ
            OpenAddWindowCommand = new RelayCommand<object>((p) => {
                return true; 
            }, 
            (p) => {
                wd_AddService wd = new wd_AddService();
                wd.ShowDialog();
                Load();
            });

            //Mở cửa số để sửa dịch vụ
            OpenEditServiceWindowCommand = new RelayCommand<object>((p) => {
                return true;
            },
            (p) => {
                wd_EditService wd = new wd_EditService();
                wd.ShowDialog();
                Load();
            });

        }

        void Load()
        {
            ListService = new ObservableCollection<SERVICE>(DataProvider.Ins.DB.SERVICEs);
        }
    }
}
