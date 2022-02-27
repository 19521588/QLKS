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
using QLKS.ViewModel;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for wd_AddNewReservation.xaml
    /// </summary>
    public partial class wd_AddNewReservation : Window
    {
        private AddReservationViewModel addReservationViewModel { get; set; }
        public wd_AddNewReservation(bool isReservation)
        {
            InitializeComponent();
            this.DataContext = (addReservationViewModel = new AddReservationViewModel(isReservation));
        }
    }
}
