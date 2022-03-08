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
    public class ControlBarViewModel : BaseViewModel
    {
        #region
        public ICommand CloseWindowCommand { get; set; }
        public ICommand MaximizeWindowCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        #endregion
        public ControlBarViewModel()
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

            MaximizeWindowCommand = new RelayCommand<UserControl>(
               (p) =>
               { return p == null ? false : true; },
               (p) =>
               {
                   FrameworkElement window = getWindow(p);
                   var w = window as Window;
                   if (w != null)
                   {
                       if (w.WindowState != WindowState.Maximized)
                       {
                           w.WindowState = WindowState.Maximized;
                           (w.DataContext as MainViewModel).Rect = new Rect(0, 0, SystemParameters.MaximizedPrimaryScreenWidth, SystemParameters.MaximizedPrimaryScreenHeight); ;
                       }
                       else
                       {
                           w.WindowState = WindowState.Normal;
                           (w.DataContext as MainViewModel).Rect = new Rect(0, 0, 1300, 700);

                       }
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
            MouseMoveWindowCommand = new RelayCommand<UserControl>(
              (p) =>
              { return p == null ? false : true; },
              (p) =>
              {
                  FrameworkElement window = getWindow(p);
                  var w = window as Window;
                  if (w != null)
                  {
                      w.DragMove();
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
