using LiveCharts;
using LiveCharts.Wpf;
using QLKS.DATA;
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
    public class StatisticalViewModel : BaseViewModel
    {


        public ICommand YearChangedCommand_Revenue { get; set; }
        public ICommand YearChangedCommand_Rental { get; set; }
        private int _SelectedYear_Revenue { get; set; }
        public int SelectedYear_Revenue
        {
            get => _SelectedYear_Revenue; set
            {
                _SelectedYear_Revenue = value;
                OnPropertyChanged();
            }
        }
        private int _SelectedYear_Rental { get; set; }
        public int SelectedYear_Rental
        {
            get => _SelectedYear_Rental; set
            {
                _SelectedYear_Rental = value;
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
        private SeriesCollection _SeriesCollection_Rental { get; set; }
        public SeriesCollection SeriesCollection_Rental
        {
            get => _SeriesCollection_Rental; set
            {
                _SeriesCollection_Rental = value;
                OnPropertyChanged();
            }
        }
        public List<string> Labels_Rental { get; set; }
        public List<string> _Labels_Rental
        {
            get => _Labels_Rental; set
            {
                _Labels_Rental = value;
                OnPropertyChanged();
            }
        }
        public Func<double, string> Formatter_Rental { get; set; }
        public Func<ChartPoint, string> PointLabel_Rental { get; set; }
        private Separator _Separator { get; set; }
        public Separator Separator
        {
            get => _Separator; set
            {
                _Separator = value;
                OnPropertyChanged();
            }
        }


        private SeriesCollection _Revenue_SeriesCollection { get; set; }
        public SeriesCollection Revenue_SeriesCollection
        {
            get => _Revenue_SeriesCollection; set
            {
                _Revenue_SeriesCollection = value;
                OnPropertyChanged();
            }
        }
        private List<string> _Revenue_Labels { get; set; }
        public List<string> Revenue_Labels
        {
            get => _Revenue_Labels; set
            {
                _Revenue_Labels = value;
                OnPropertyChanged();
            }
        }
        public Func<double, string> Revenue_Formatter { get; set; }

        public Func<ChartPoint, string> PointLabel_Revenue { get; set; }

        public StatisticalViewModel()
        {
            Revenue_Labels = new List<string>();
            Labels_Rental = new List<string>();
            ItemSource_Year = new Dictionary<string, int>();
            LoadData();

            if (ItemSource_Year.Count > 0)
            {
                if (ItemSource_Year.Last().Value < DateTime.Now.Year)
                {
                    SelectedYear_Revenue = ItemSource_Year.First().Value;
                    SelectedYear_Rental = ItemSource_Year.First().Value;

                    LoadDataToChart_Revenue(SelectedYear_Revenue);
                    LoadDataToChart_Rental(SelectedYear_Rental);

                }
                else
                {
                    SelectedYear_Revenue = SelectedYear_Rental = DateTime.Now.Year;
                    LoadDataToChart_Revenue(SelectedYear_Revenue);
                    LoadDataToChart_Rental(SelectedYear_Rental);
                }
            }
            Separator = new Separator { Step = 1 };

            Revenue_Formatter = value => value.ToString();
            PointLabel_Revenue = ChartPoint =>
                    string.Format("{0} ({1:P})", ChartPoint.Y, ChartPoint.Participation);

            Formatter_Rental = value => value.ToString();
            PointLabel_Rental = ChartPoint =>
                    string.Format("{0} ({1:P})", ChartPoint.Y, ChartPoint.Participation);


            YearChangedCommand_Revenue = new RelayCommand<uc_Home>((p) => { return true; }, (p) =>
            {
                LoadDataToChart_Revenue(SelectedYear_Revenue);
            });
            YearChangedCommand_Rental = new RelayCommand<uc_Home>((p) => { return true; }, (p) =>
            {
                LoadDataToChart_Rental(SelectedYear_Rental);
            });

        }
        public void LoadData()
        {
            Revenue = 0;

            DateTime time = DateTime.Now;
            GetModel getModel = new GetModel();

            ObservableCollection<Bill> receipts = new ObservableCollection<Bill>
                (getModel.GetListBillOrderByDateBill());

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

            Revenue=(long)receipts.Where(x => x.Date_Bill.Value.Month == time.Month && x.Date_Bill.Value.Year == time.Year).Sum(y=>y.Total);
            var rental = getModel.GetListRentalByTime(time);
            Rental_Room_Month = rental.Count();
            Rental_Room_Day = rental.Count(x => x.DateRental.Value.Day == time.Day);

        }
        public void LoadDataToChart_Revenue(int year)
        {
            GetModel getModel = new GetModel();
            ObservableCollection<Bill> receipts = new ObservableCollection<Bill>
                (getModel.GetListBillByYearAndOrderByDateBill(year));

            Revenue_Labels.Clear();
            ChartValues<long> values_service = new ChartValues<long>();
            ChartValues<long> values_room = new ChartValues<long>();
            ChartValues<long> values_total = new ChartValues<long>();

            for (int i = 1; i <= 12; i++)
            {
                if (receipts.Count == 0 || i < receipts.First().Date_Bill.Value.Month)
                {
                    values_service.Add(0);
                    values_room.Add(0);
                    values_total.Add(0);
                    Revenue_Labels.Add(i.ToString());
                    continue;
                }

                Revenue_Labels.Add(i.ToString());
                long totalMoney_sercvice = 0;
                long totalMoney_room = 0;
                long total = 0;

                while (receipts.Count() > 0 && i == receipts.First().Date_Bill.Value.Month)
                {
                    var billinfo = getModel.GetListBillInfo();
                    if (billinfo.Count() > 0)
                    {
                        foreach (var item in billinfo)
                        {
                            if (item.IdBill == receipts.First().IdBill)
                                totalMoney_sercvice += item.Amount * item.Price;
                        }
                    }
                    total += (uint)receipts.First().Total;
                    receipts.Remove(receipts.First());
                }


                values_service.Add(totalMoney_sercvice);
                totalMoney_room = total - totalMoney_sercvice;
                values_room.Add(totalMoney_room);
                values_total.Add(total);
            }

            Revenue_SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Doanh thu dịch vụ",
                    Values = values_service,
                    DataLabels = true
                },
                new LineSeries
                {
                    Title = "Doanh thu phòng",
                    Values = values_room,
                    DataLabels = true
                },
                 new LineSeries
                {
                    Title = "Tổng doanh thu",
                    Values = values_total,
                    DataLabels = true
                }

            };
        }
        public void LoadDataToChart_Rental(int year)
        {
            GetModel getModel = new GetModel();
            ObservableCollection<Bill> bill = new ObservableCollection<Bill>
                (getModel.GetListBillByYearAndOrderByDateBill(year));
            Labels_Rental.Clear();
            ChartValues<long> values = new ChartValues<long>();

            for (int i = 1; i <= 12; i++)
            {
                Labels_Rental.Add(i.ToString());
                if (bill.Count == 0 || i < bill.First().Date_Bill.Value.Month)
                {
                    values.Add(0);
                    continue;
                }

                values.Add((long)bill.Where(x => x.Date_Bill.Value.Month == i).LongCount());
            }

            SeriesCollection_Rental = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Phòng",
                    Values = values,
                    DataLabels = true,
                    LineSmoothness = 0
                }
            };
        }


    }
}
