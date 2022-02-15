using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
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
        private long _Room_revenue { get; set; }
        public long Room_revenue
        {
            get => _Room_revenue; set
            {
                _Room_revenue = value;
                OnPropertyChanged();
            }
        }
        
        private long _Service_revenue { get; set; }
        public long Service_revenue
        {
            get => _Service_revenue; set
            {
                _Service_revenue = value;
                OnPropertyChanged();
            }
        }
        private int _Total_Reservation { get; set; }
        public int Total_Reservation
        {
            get => _Total_Reservation; set
            {
                _Total_Reservation = value;
                OnPropertyChanged();
            }
        }
        public StatisticalViewModel()
        {

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
    }
}
