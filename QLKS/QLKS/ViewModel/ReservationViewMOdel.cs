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
    public class ReservationViewMOdel : BaseViewModel 
    {
        public ICommand OpenAddCommand { get; set; }

        public ICommand OpenEditCommand { get; set; }

        private ObservableCollection<RESERVATION> _ListReservation { get; set; }
        public ObservableCollection<RESERVATION> ListReservation { get => _ListReservation; set { _ListReservation = value; OnPropertyChanged(); } }

        private string _Name { get; set; }

        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Status { get; set; }

        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

        private string _Category { get; set; }

        public string Category { get => _Category; set { _Category = value; OnPropertyChanged(); } }
        private RESERVATION _SelectedItem { get; set; }
        public RESERVATION SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    Name = _SelectedItem.IdCustomer.ToString();
                }
                OnPropertyChanged();
            }
        }
        public ReservationViewMOdel()
        {
            Load();
            OpenAddCommand = new RelayCommand<MainWindow>((p) => true, (p) =>
            {

                wd_AddNewReservation wdAddReservation = new wd_AddNewReservation();

                //wdAddRooms.txbName.Text = "";
                wdAddReservation.ShowDialog();

                AddReservationViewModel add = wdAddReservation.DataContext as AddReservationViewModel;
                if (add.check)
                    ListReservation.Insert(0, add.reservation);
                Load();
            });
        }

        void Load()
        {
            ListReservation = new ObservableCollection<RESERVATION>(DataProvider.Ins.DB.RESERVATIONs);
        }
    }
}
