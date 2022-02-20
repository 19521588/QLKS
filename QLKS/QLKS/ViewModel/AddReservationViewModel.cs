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
    public class AddReservationViewModel : BaseViewModel
    {
        public ICommand AddCommand { get; set; }

        public ICommand CloseCommand { get; set; }
        private bool _check { get; set; }
        public bool check { get => _check; set { _check = value; OnPropertyChanged(); } }

        private RESERVATION _reservation { get; set; }

        public RESERVATION reservation { get => _reservation; set { _reservation = value; OnPropertyChanged(); } }

        private ObservableCollection<RESERVATION_DETAIL> _ListReservation { get; set; }

        public ObservableCollection<RESERVATION_DETAIL> ListReservation { get => _ListReservation; set { _ListReservation = value; OnPropertyChanged(); } }

        private ObservableCollection<ROOM> _ListRoom { get; set; }

        public ObservableCollection<ROOM> ListRoom { get => _ListRoom; set { _ListRoom = value; OnPropertyChanged(); } }

        private ROOM _SelectedRoom { get; set; }

        public ROOM SelectedRoom { get => _SelectedRoom; set { _SelectedRoom = value; OnPropertyChanged(); } }

        private RENTALDETAIL _SelectedItem { get; set; }

        public RENTALDETAIL SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }

        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }
        public AddReservationViewModel()
        {

            ListRoom = new ObservableCollection<ROOM>();
            ListReservation = new ObservableCollection<RESERVATION_DETAIL>();
            ObservableCollection<ROOM> temp = new ObservableCollection<ROOM>(DataProvider.Ins.DB.ROOMs.Where(x => x.Name != "Trống"));
            for (int i = temp.Count() - 1; i >= 0; i--)
            {
                ListRoom.Add(temp[i]);
            }

            

            AddCommand = new RelayCommand<wd_AddNewReservation>(
            (p) =>
            {
                if(SelectedRoom == null) return false;
                return true;
            },
            (p) =>
            {
                RESERVATION_DETAIL res_detail = new RESERVATION_DETAIL() {IdReservationDetail = -1,Amount = 2, Start_Date = DateTime.Parse(p.dtStartDate.SelectedDate.ToString()), End_Date = DateTime.Parse(p.dtStartDate.SelectedDate.ToString()), Start_Time = DateTime.Parse(p.dtStartDate.SelectedDate.ToString()), End_Time = DateTime.Parse(p.dtStartDate.SelectedDate.ToString()) };
                ListRoom.Remove(SelectedRoom);
                
                ListReservation.Add(res_detail);
                //p.Close();
            }
            );


            CloseCommand = new RelayCommand<wd_AddNewReservation>(
            (p) =>
            { return true; },
            (p) =>
            {
                p.Close();
            }
            );
        }
    }
}
