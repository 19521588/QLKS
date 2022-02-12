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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLKS.UserControlss
{
    /// <summary>
    /// Interaction logic for ControlBar2.xaml
    /// </summary>
    public partial class ControlBar2 : UserControl
    {
        public ControlBar2ViewModel Viewmodel { get; set; }
        public ControlBar2()
        {
            InitializeComponent();
            this.DataContext = Viewmodel = new ControlBar2ViewModel();
        }
    }
}
