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
    /// Interaction logic for uc_RoomCategoryManage.xaml
    /// </summary>
    public partial class uc_RoomCategoryManage : UserControl
    {
        private RoomCategoryViewModel roomCategoryViewModel { get; set; }
        public uc_RoomCategoryManage()
        {
            InitializeComponent();
            this.DataContext = (roomCategoryViewModel = new RoomCategoryViewModel());
        }
    }
}
