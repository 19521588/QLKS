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

namespace QLKS.UserControlss
{
    /// <summary>
    /// Interaction logic for DialogCustoms.xaml
    /// </summary>
    public partial class DialogCustoms : Window
    {
        public DialogCustomsViewModel viewModel { get; set; }
        public DialogCustoms(string mess, string title, int mode)
        {
            InitializeComponent();
            this.DataContext = viewModel=new DialogCustomsViewModel(mess,title,mode);
        }
    }
}
