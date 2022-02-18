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
    /// Interaction logic for wd_AddConvenient.xaml
    /// </summary>
    public partial class wd_AddConvenient : Window
    {
        private AddConvenientViewModel addConvenientViewModel { get; set; }
        public wd_AddConvenient()
        {
            InitializeComponent();
            this.DataContext = addConvenientViewModel  = new AddConvenientViewModel();
        }
    }
}
