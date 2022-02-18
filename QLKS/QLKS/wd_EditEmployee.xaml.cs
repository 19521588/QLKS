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
using QLKS.Model;

namespace QLKS
{
    /// <summary>
    /// Interaction logic for wd_EditEmployee.xaml
    /// </summary>
    public partial class wd_EditEmployee : Window
    {
        private EditEmployeeViewModel editEmployeeViewModel { get; set; }

        public wd_EditEmployee(EMPLOYEE  employee)
        {
            InitializeComponent();
            this.DataContext = (editEmployeeViewModel = new EditEmployeeViewModel(employee));
        }
    }
}
