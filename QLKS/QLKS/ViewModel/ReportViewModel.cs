using QLKS.DATA;
using QLKS.Model;
using QLKS.Template;
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
    public class ReportViewModel : BaseViewModel
    {
        public ICommand ReportCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        
        public ICommand Report_YearChangedCommand { get; set; }
        public ICommand Report_MonthChangedCommand { get; set; }

        public ICommand ViewReportCommand { get; set; }
        public ICommand PrintReportCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        private ObservableCollection<ListSales> _ListSales;
        public ObservableCollection<ListSales> ListSales { get => _ListSales; set { _ListSales = value; OnPropertyChanged(); } }

        private SalesReport _SalesReport;
        public SalesReport SalesReport { get => _SalesReport; set { _SalesReport = value; OnPropertyChanged(); } }

        private string first_item_year { get; set; }
        public string First_item_year { get => first_item_year; set { first_item_year = value; OnPropertyChanged(); } }
        private string first_item_month { get; set; }
        public string First_item_month { get => first_item_month; set { first_item_month = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _RpitemSource_Year = new ObservableCollection<string>();
        public ObservableCollection<string> RpItemSource_Year { get => _RpitemSource_Year; set { _RpitemSource_Year = value; OnPropertyChanged(); } }

        private ObservableCollection<string> RpitemSource_Month = new ObservableCollection<string>();
        public ObservableCollection<string> RpItemSource_Month { get => RpitemSource_Month; set { RpitemSource_Month = value; OnPropertyChanged(); } }


        private int _TotalMoney;

        public int TotalMoney { get => _TotalMoney; set { _TotalMoney = value; OnPropertyChanged(); } }
        private int _IdUser;

        public int IdUser { get => _IdUser; set { _IdUser = value; OnPropertyChanged(); } }

        private string _UserName { get; set; }
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private bool _VisReport { get; set; }
        public bool VisReport { get => _VisReport; set { _VisReport = value; OnPropertyChanged(); } }

        private bool _VisViewReport { get; set; }
        public bool VisViewReport { get => _VisViewReport; set { _VisViewReport = value; OnPropertyChanged(); } }
        private bool _VisPrint { get; set; }
        public bool VisPrint { get => _VisPrint; set { _VisPrint = value; OnPropertyChanged(); } }
        private bool _IsClose { get; set; }
        public bool IsClose { get => _IsClose; set { _IsClose = value; OnPropertyChanged(); } }
        public ReportViewModel() { }
        public ReportViewModel(USER User)
        {
            IsClose = true;
            IdUser = User.Users_Id;
            GetModel getModel = new GetModel();
            UserName =getModel.GetEmployeeById(User.IdEmployee).Name;

            load_firstItem();
            LoadComboBox();
            

            ReportCommand = new RelayCommand<ReportWd>(
                (p) => { return true; },
                (p) =>
                {
                    Report_Sales(p);
                    VisButtonPrint(p);
                    VisButtonReport(p);
                });

            Report_MonthChangedCommand = new RelayCommand<ReportWd>(
              (p) => { return true; },
              (p) =>
              {
                  VisButtonPrint(p);
                  VisButtonReport(p);
                  Report_LoadToView(p);

              });

            Report_YearChangedCommand = new RelayCommand<ReportWd>(
                (p) => { return true; },
                (p) =>
                {
                    VisButtonPrint(p);
                    VisButtonReport(p);
                    Report_LoadToView(p);
                });
            CloseCommand = new RelayCommand<ReportWd>(
               (p) => { return true; },
               (p) =>
               {

                   p.Close();
               });
            ViewReportCommand = new RelayCommand<ReportWd>(
                (p) => { return true; },
                (p) =>
                {

                    string[] tmp = p.Rpcb_SelectYear.SelectedValue.ToString().Split(' ');
                    int selectedYear = Int32.Parse(tmp[1]);
                    string[] tmp1 = p.Rpcb_SelectMonth.SelectedValue.ToString().Split(' ');
                    int selectedMonth = Int32.Parse(tmp1[1]);
                    DateTime date = new DateTime(selectedYear, selectedMonth, 1);


                    ReportTemplate wd = new ReportTemplate(date);
                    wd.ShowDialog();


                });
            PrintReportCommand = new RelayCommand<ReportWd>(
                (p) => { return true; },
                (p) =>
                {
                    string[] tmp = p.Rpcb_SelectYear.SelectedValue.ToString().Split(' ');
                    int selectedYear = Int32.Parse(tmp[1]);
                    string[] tmp1 = p.Rpcb_SelectMonth.SelectedValue.ToString().Split(' ');
                    int selectedMonth = Int32.Parse(tmp1[1]);


                    SalesReport = new SalesReport();

                    SalesReport.ReportDate = selectedMonth + "/" + selectedYear;
                    var salesReport = getModel.GetSaleReportByTime(selectedYear, selectedMonth);
                    SalesReport.IdReport = salesReport.SalesReport_Id;
                    SalesReport.UserName = salesReport.SalesReport_UserName;
                    SalesReport.TotalMoney = salesReport.SalesReport_Revenue;
                    var SalesReportDetail = getModel.GetListSalesReportDetailByIdSaleReport(salesReport.SalesReport_Id);

                    int i = 1;
                    SalesReport.ListSales = new ObservableCollection<ListSales>();
                    foreach (var item in SalesReportDetail)
                    {
                        ListSales listSales = new ListSales();
                        listSales.TotalMoney = (int)item.TotalMoney;
                        listSales.Rate = (float)item.Rate;
                        listSales.STT = i;
                       
                        listSales.CategoryRoom = item.CategoryRoom;
                      
                        SalesReport.ListSales.Add(listSales);
                        i++;
                    }

                    PrintViewModel printViewModel = new PrintViewModel();
                    printViewModel.PrintSalesReport(SalesReport);


                });


        }
        public void LoadComboBox()
        {
            GetModel getModel = new GetModel();
            ObservableCollection<Bill> temp = new ObservableCollection<Bill>(getModel.GetListBillOrderByDateBill());

            foreach (var item in temp)
            {
                if (item.Date_Bill.Value.Year != DateTime.Now.Year)
                {
                    if (!(RpItemSource_Year.Any(x => x.Contains("Năm " + item.Date_Bill.Value.Year.ToString()))))
                        RpItemSource_Year.Add("Năm " + item.Date_Bill.Value.Year.ToString());
                }

            }
            for (int i = 1; i < 13; i++)
                if (DateTime.Now.Month != i)
                {

                    RpItemSource_Month.Add("Tháng " + i);
                }
        }
        public void load_firstItem()
        {
            First_item_year = "Năm " + DateTime.Now.Year;
            RpItemSource_Year.Add(First_item_year);
            First_item_month = "Tháng " + DateTime.Now.Month;
            RpitemSource_Month.Add(First_item_month);

            ReportSales_LoadToView(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString());

        }
       
        public void Report_LoadToView(ReportWd p)
        {

            string[] tmp = p.Rpcb_SelectYear.SelectedValue.ToString().Split(' ');
            string selectedYear = tmp[1];
            string[] tmp1 = p.Rpcb_SelectMonth.SelectedValue.ToString().Split(' ');
            string selectedMonth = tmp1[1];

            ReportSales_LoadToView(selectedYear, selectedMonth);

        }

       

        public void ReportSales_LoadToView(string selectedYear, string selectedMonth)
        {
            GetModel getModel = new GetModel();
            ListSales = new ObservableCollection<ListSales>();

            int i = 1;

            TotalMoney = 0;
            var bill = getModel.GetListBillByTime(selectedYear, selectedMonth);
            if (bill != null)
            {
                foreach (var item in bill)
                {
                    TotalMoney += int.Parse(item.Total.ToString());
                }
            }



            var CatagoryRoom = getModel.getListCategoryRoom();

            foreach (var item in CatagoryRoom)
            {

                ListSales listSales = new ListSales();

                int totalMoney = 0;
                float rate = 0;

               
                totalMoney = int.Parse(bill.Where(x=>x.CategoryRoom==item.Name).ToList().Sum(x => x.Total).ToString());
                

                listSales.STT = i;
                listSales.CategoryRoom = item.Name;
                listSales.TotalMoney = totalMoney;
                listSales.Rate = rate;
                ListSales.Add(listSales);
                i++;

            }
            int Total = 0;
            foreach (var item in ListSales)
            {
                Total += item.TotalMoney;
            }
            foreach (var item in ListSales)
            {
                if (Total != 0)
                {
                    float x = (float)item.TotalMoney / Total;
                    item.Rate = (float)Math.Round(x, 2);
                }
            }
        }



        //Đóng wd
        public void CloseWd(ReportWd p)
        {
            p.Close();
        }

      
        public void Report_Sales(ReportWd p)
        {
            AddModel addModel = new AddModel();
            GetModel getModel = new GetModel();
            if (MessageBox.Show("Bạn có chắc chắn muốn lập báo cáo Doanh số", "Thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                string[] tmp = p.Rpcb_SelectYear.SelectedValue.ToString().Split(' ');
                int selectedYear = Int32.Parse(tmp[1]);
                string[] tmp1 = p.Rpcb_SelectMonth.SelectedValue.ToString().Split(' ');
                int selectedMonth = Int32.Parse(tmp1[1]);


                DateTime date = new DateTime(selectedYear, selectedMonth, 1);

                addModel.AddSaleReport(new SALES_REPORT { SalesReport_Date = date, SalesReport_Revenue = TotalMoney, SalesReport_UserName = UserName, IdUser = IdUser });
                int i = 0;
                var salesReport = getModel.getListSaleReport();
                foreach (var item in salesReport)
                {
                    if (item.SalesReport_Id > i)
                        i = item.SalesReport_Id;
                }

                foreach (var item in ListSales)
                {
                    SALES_REPORT_DETAIL salesReportDetail = new SALES_REPORT_DETAIL();
                    salesReportDetail.IdSalesReport = i;
                    salesReportDetail.CategoryRoom = item.CategoryRoom;
                    salesReportDetail.TotalMoney = item.TotalMoney;
                    salesReportDetail.Rate = item.Rate;

                    addModel.AddSaleReportDetail(salesReportDetail);
                }

                MessageBox.Show("Lập báo cáo thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

            }


        }
      

        public bool check_Report(ReportWd p)
        {
            string[] tmp = p.Rpcb_SelectYear.SelectedValue.ToString().Split(' ');
            int selectedYear = Int32.Parse(tmp[1]);
            string[] tmp1 = p.Rpcb_SelectMonth.SelectedValue.ToString().Split(' ');
            int selectedMonth = Int32.Parse(tmp1[1]);

            var a = DataProvider.Ins.DB.SALES_REPORT.Where(x => x.SalesReport_Date.Value.Year == selectedYear && x.SalesReport_Date.Value.Month == selectedMonth);


            if (DateTime.Now.Year > selectedYear || DateTime.Now.Year == selectedYear && DateTime.Now.Month > selectedMonth)
            {
                if (a.Count() == 0)
                    return true;
            }



            return false;
        }
        public void VisButtonReport(ReportWd p)
        {
            if (check_Report(p))
            {
                VisReport = true;
            }
            else
            {
                VisReport = false;
            }
        }

        public bool check_Print(ReportWd p)
        {
            string[] tmp = p.Rpcb_SelectYear.SelectedValue.ToString().Split(' ');
            int selectedYear = Int32.Parse(tmp[1]);
            string[] tmp1 = p.Rpcb_SelectMonth.SelectedValue.ToString().Split(' ');
            int selectedMonth = Int32.Parse(tmp1[1]);

            var a = DataProvider.Ins.DB.SALES_REPORT.Where(x => x.SalesReport_Date.Value.Year == selectedYear && x.SalesReport_Date.Value.Month == selectedMonth);


            if (a.Count() != 0)
                return true;


            return false;
        }

        public void VisButtonPrint(ReportWd p)
        {
            if (check_Print(p))
            {
                VisPrint = true;
                VisViewReport = true;
            }
            else
            {
                VisPrint = false;
                VisViewReport = false;
            }
        }


        public void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn đóng cửa sổ này", "Thông báo",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                e.Cancel = false;
            }
            else e.Cancel = true;
        }
    }
}
