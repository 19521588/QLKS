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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel mainViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = (mainViewModel = new MainViewModel());
           
        }
        private void lisviewMenu_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
                btnCloseLVMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            
        }


    }
}
