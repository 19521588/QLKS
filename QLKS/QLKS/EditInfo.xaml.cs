using QLKS.Model;
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
    /// Interaction logic for EditInfo.xaml
    /// </summary>
    public partial class EditInfo : Window
    {
        EditInfoViewModel viewModel { get; set; }
        public EditInfo()
        {
            InitializeComponent();
            
        }
        public EditInfo(EMPLOYEE e)
        {
            InitializeComponent();
            this.DataContext = viewModel = new EditInfoViewModel(e);
        }
    }
}
