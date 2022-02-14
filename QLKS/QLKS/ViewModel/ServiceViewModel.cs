using QLKS.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS.ViewModel
{
    public class ServiceViewModel : BaseViewModel
    {
        private ObservableCollection<SERVICE> _ListService { get; set; }
        public ObservableCollection<SERVICE> ListService { get => _ListService; set { _ListService = value; OnPropertyChanged(); } }

        public ServiceViewModel()
        {
            Load();
        }

        void Load()
        {
            ListService = new ObservableCollection<SERVICE>();
            ObservableCollection<SERVICE> temp = new ObservableCollection<SERVICE>(DataProvider.Ins.DB.SERVICEs);
            for (int i = temp.Count() - 1; i >= 0; i--)
            {
                ListService.Add(temp[i]);
            }
        }
    }
}
