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

namespace QLKS
{
    /// <summary>
    /// Interaction logic for wd_AddService.xaml
    /// </summary>
    public partial class wd_AddService : Window
    {
        private AddServiceViewModel addServiceViewModel { get; set; }
        public wd_AddService()
        {
            InitializeComponent();
            this.DataContext = addServiceViewModel = new AddServiceViewModel();
        }
    }
}
