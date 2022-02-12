﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLKS.ViewModel
{
    public class ControlBar2ViewModel : BaseViewModel
    {
        #region
        public ICommand CloseWindowCommand { get; set; }

        public ICommand MinimizeWindowCommand { get; set; }
      
        #endregion
        public ControlBar2ViewModel()
        {
            CloseWindowCommand = new RelayCommand<UserControl>(
                (p) =>
                { return p == null ? false : true; },
                (p) =>
                {
                    FrameworkElement window = getWindow(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.Close();
                    }
                }
            );

            

            MinimizeWindowCommand = new RelayCommand<UserControl>(
               (p) =>
               { return p == null ? false : true; },
               (p) =>
               {
                   FrameworkElement window = getWindow(p);
                   var w = window as Window;
                   if (w != null)
                   {
                       if (w.WindowState != WindowState.Minimized)
                       {
                           w.WindowState = WindowState.Minimized;
                       }
                       else
                       {
                           w.WindowState = WindowState.Maximized;
                       }
                   }
               }
           );
          

        }

        FrameworkElement getWindow(UserControl p)
        {
            FrameworkElement parent = p;

            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }
    }
}
