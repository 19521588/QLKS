﻿using System;
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
using QLKS.ViewModel;

namespace QLKS.UserControlss
{
    /// <summary>
    /// Interaction logic for uc_DatPhong.xaml
    /// </summary>
    public partial class uc_DatPhong : UserControl
    {
        private ReservationViewMOdel reservationViewMOdel { get; set; }
        public uc_DatPhong()
        {
            InitializeComponent();
            this.DataContext = (reservationViewMOdel = new ReservationViewMOdel());
        }
    }
}
