using LiveCharts;
using LiveCharts.Wpf;
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
    public class StatisticalViewModel:BaseViewModel
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public ICommand YearChangedCommand_Revenue { get; set; }
        public ICommand YearChangedCommand_Car { get; set; }
        private int _SelectedYear_Revenue { get; set; }
        public int SelectedYear_Revenue
        {
            get => _SelectedYear_Revenue; set
            {
                _SelectedYear_Revenue = value;
                OnPropertyChanged();
            }
        }
        private int _SelecteYear_Reservation { get; set; }
        public int SelecteYear_Reservation
        {
            get => _SelecteYear_Reservation; set
            {
                _SelecteYear_Reservation = value;
                OnPropertyChanged();
            }
        }
        private Dictionary<string, int> _ItemSource_Year { get; set; }
        public Dictionary<string, int> ItemSource_Year
        {
            get => _ItemSource_Year; set
            {
                _ItemSource_Year = value;
                OnPropertyChanged();
            }
        }
        private long _Revenue { get; set; }
        public long Revenue
        {
            get => _Revenue; set
            {
                _Revenue = value;
                OnPropertyChanged();
            }
        }
        
        private int _Rental_Room_Day { get; set; }
        public int Rental_Room_Day
        {
            get => _Rental_Room_Day; set
            {
                _Rental_Room_Day = value;
                OnPropertyChanged();
            }
        }
        private int _Rental_Room_Month { get; set; }
        public int Rental_Room_Month
        {
            get => _Rental_Room_Month; set
            {
                _Rental_Room_Month = value;
                OnPropertyChanged();
            }
        }
        public List<string> _Labels_Room { get; set; }
        public List<string> Labels_Room
        {
            get => _Labels_Room; set
            {
                _Labels_Room = value;
                OnPropertyChanged();
            }
        }
        public Func<double, string> Formatter_Room { get; set; }
        public Func<ChartPoint, string> PointLabel_Room { get; set; }
        private Separator _Separator { get; set; }
        public Separator Separator
        {
            get => _Separator; set
            {
                _Separator = value;
                OnPropertyChanged();
            }
        }
        public StatisticalViewModel()
        {
            Labels_Room = new List<string>();
            ItemSource_Year = new Dictionary<string, int>();
            LoadData();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Doanh thu phòng",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Doanh thu DV",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "SL phòng đặt",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };

            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
        }
        public void LoadData()
        {
            Revenue = 0;
           
            DateTime time = DateTime.Now;

            ObservableCollection<Bill> receipts = new ObservableCollection<Bill>
                (DataProvider.Ins.DB.Bills.OrderBy(x => x.Date_Bill));

            if (receipts.Count > 0)
            {
                ItemSource_Year.Clear();

                int firstYear = receipts.First().Date_Bill.Value.Year;
                ItemSource_Year.Add("Năm " + firstYear.ToString(), firstYear);

                foreach (var receipt in receipts)
                {
                    if (receipt.Date_Bill.Value.Year <= ItemSource_Year.Last().Value) continue;
                    int year = receipt.Date_Bill.Value.Year;
                    ItemSource_Year.Add("Năm " + year.ToString(), year);
                }
            }

            foreach (var receipt in DataProvider.Ins.DB.Bills.Where(x => x.Date_Bill.Value.Month == time.Month && x.Date_Bill.Value.Year == time.Year))
            {
                Revenue += (long)receipt.Total;
            }
            var rental = DataProvider.Ins.DB.RENTALs.Where(x => x.DateRental.Value.Month == time.Month && x.DateRental.Value.Year == time.Year);
            Rental_Room_Month = rental.Count();
            Rental_Room_Day = rental.Count(x=>x.DateRental.Value.Day==time.Day);
        }


    }
}
