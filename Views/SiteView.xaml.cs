using GalaSoft.MvvmLight.Messaging;
using Scheduler.Models;
using Scheduler.ViewModel;
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

namespace Scheduler.Views
{
    /// <summary>
    /// Interaction logic for SiteView.xaml
    /// </summary>
    public partial class SiteView : UserControl
    {
        private SiteViewModel ViewModel { get; set; } 
        public SiteView()
        {
            InitializeComponent();
            ViewModel = this.DataContext as SiteViewModel;
            ViewModel.OnShowPickList += ViewModel_OnShowPickList;
            ViewModel.OnHidePickList += ViewModel_OnHidePickList;
        }

        void ViewModel_OnHidePickList(object sender, EventArgs e)
        {
            employeePL.Visibility = Visibility.Collapsed;
            tiEdit.Focus();

        }

        void ViewModel_OnShowPickList(object sender, EventArgs e)
        {
            if (sender == null) return;
            employeePL.Visibility = Visibility.Visible;
            employeePL.Focus();
        }


        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (User item in e.RemovedItems)
            {
                ViewModel.SelectedEmployees.Remove(item);
            }

            foreach (User item in e.AddedItems)
            {
                ViewModel.SelectedEmployees.Add(item);
                
            }
        }
    }
}
