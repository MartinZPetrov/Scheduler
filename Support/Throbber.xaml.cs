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
using System.Windows.Threading;

namespace Scheduler
{
    /// <summary>
    /// Interaction logic for Throbber.xaml
    /// </summary>
    public partial class Throbber : UserControl
    {
        public Throbber()
        {
             InitializeComponent();
             this.IsVisibleChanged += new DependencyPropertyChangedEventHandler(VisibleChanged);
        }


        void VisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                Dispatcher.BeginInvoke(
                DispatcherPriority.ContextIdle,
                new Action(delegate()
                {
                    this.ArcContainer.Focus();
                }));
            }
        }
    }
}
