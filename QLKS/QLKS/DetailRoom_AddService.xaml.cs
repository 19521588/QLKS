using QLKS.Model;
using QLKS.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for DetailRoom_AddService.xaml
    /// </summary>
    public partial class DetailRoom_AddService : Window
    {
        AddServiceDRViewModel viewModel { get; set; }

        public DetailRoom_AddService(ObservableCollection<ListService> list)
        {
            InitializeComponent();
            this.DataContext=viewModel=new AddServiceDRViewModel(list);
        }
    }
}
