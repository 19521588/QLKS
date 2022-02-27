using QLKS.Model;
using QLKS.Template;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using IStyle = Syncfusion.XlsIO.IStyle;
using Size = System.Windows.Size;
using Microsoft.Win32;

namespace QLKS.ViewModel
{
    public class PrintViewModel:BaseViewModel
    {
        public ICommand PrintReportCommand { get; set; }
        public ICommand PrintBillCommand { get; set; }
        public PrintViewModel()
        {
           
            PrintBillCommand = new RelayCommand<BillTemplate>((p) => true, (p) => PrintBill(p));
            PrintReportCommand = new RelayCommand<SalesReport>((p) => true, (p) => PrintSalesReport(p));

        }
        public void PrintBill(BillTemplate billTemplate)
        {

            billTemplate.Height = billTemplate.Height ;
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(billTemplate.All, "hoadon");
            }

        }
        public void StyleExcel_Sales(IWorkbook workbook, IWorksheet sheet)
        {


            IStyle pageHeader = workbook.Styles.Add("PageHeaderStyle");
            IStyle tableHeader = workbook.Styles.Add("TableHeaderStyle");


            
            pageHeader.Font.FontName = "Calibri";
            pageHeader.Font.Size = 18;
            pageHeader.Font.Bold = true;
            pageHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            pageHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;


            tableHeader.Font.Color = ExcelKnownColors.Black;
            tableHeader.Font.Bold = true;
            tableHeader.Font.Size = 12;
            tableHeader.Font.FontName = "Calibri";
            tableHeader.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            tableHeader.VerticalAlignment = ExcelVAlign.VAlignCenter;

            tableHeader.Borders[ExcelBordersIndex.EdgeLeft].LineStyle = ExcelLineStyle.Thin;
            tableHeader.Borders[ExcelBordersIndex.EdgeRight].LineStyle = ExcelLineStyle.Thin;
            tableHeader.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
            tableHeader.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;




            sheet["A1"].Text = "Báo cáo Doanh số";
            sheet["A1"].CellStyle = pageHeader;

            sheet["A2"].Text = "Mã báo cáo";
            sheet["A2"].CellStyle.Font.Bold = false;
            sheet["A2"].CellStyle.Font.Size = 12;

            sheet["A3"].Text = "Tháng";
            sheet["A3"].CellStyle.Font.Bold = false;
            sheet["A3"].CellStyle.Font.Size = 12;

            sheet["A4"].Text = "Nhân viên";
            sheet["A4"].CellStyle.Font.Bold = false;
            sheet["A4"].CellStyle.Font.Size = 12;



            sheet["A1:E1"].Merge();


            sheet["A5"].Text = "STT";
            sheet["B5"].Text = "Loại phòng";
           
            sheet["C5"].Text = "Thành tiền";
            sheet["D5"].Text = "Tỉ lệ";
            sheet["A5:D5"].CellStyle = tableHeader;


            sheet.AutofitColumn(1);
            sheet.UsedRange.AutofitColumns();

        }
        public void PrintSalesReport(SalesReport salesReport)
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];


                StyleExcel_Sales(workbook, worksheet);


                worksheet["B2"].Text = salesReport.IdReport.ToString();
                worksheet["B3"].Text = salesReport.ReportDate.ToString();
                worksheet["B4"].Text = salesReport.UserName;


                int i = 6;
                foreach (var item in salesReport.ListSales)
                {
                    Object[] list = new object[] { item.STT.ToString() , item.CategoryRoom, item.TotalMoney
                    , item.Rate};
                    worksheet.InsertRow(i, 1, ExcelInsertOptions.FormatDefault);
                    worksheet.ImportArray(list, i, 1, false);
                    i++;
                }
                worksheet["D" + (i + 1)].Text = "Tổng doanh thu: " + salesReport.TotalMoney;
                worksheet["C" + (i + 1) + ":" + "D" + (i + 1)].Merge();

                worksheet.Columns[1].ColumnWidth = 30;
                worksheet.Columns[2].ColumnWidth = 20;
                worksheet.Columns[3].ColumnWidth = 20;
               



                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.ShowDialog();
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                {
                    Stream excelStream;
                    application.Application.IgnoreSheetNameException = false;
                    if (File.Exists(Path.GetFullPath(saveFileDialog1.FileName)))
                    {
                        excelStream = File.Create(Path.GetFullPath(saveFileDialog1.FileName));
                    }
                    else
                        excelStream = File.Create(Path.GetFullPath(saveFileDialog1.FileName + ".xlsx"));
                    workbook.SaveAs(excelStream);
                    excelStream.Dispose();
                }
            }
        }
    }
}
