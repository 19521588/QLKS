using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QLKS.Template
{
    /// <summary>
    /// Interaction logic for ReportTemplate.xaml
    /// </summary>
    public partial class ReportTemplate : Window
    {
        ReportTemplateViewModel viewModel { get; set; }
        public ReportTemplate(DateTime date)
        {
            InitializeComponent();
            this.DataContext = viewModel=new ReportTemplateViewModel(date);   
        }
    }
}
