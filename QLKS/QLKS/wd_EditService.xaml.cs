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
    /// Interaction logic for wd_EditService.xaml
    /// </summary>
    public partial class wd_EditService : Window
    {
        private EditServiceViewModel editServiceViewModel { get; set; }
        public wd_EditService()
        {
            InitializeComponent();
            this.DataContext = editServiceViewModel = new EditServiceViewModel();
        }
    }
}
