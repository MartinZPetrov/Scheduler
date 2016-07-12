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

namespace Scheduler.Controls
{
    /// <summary>
    /// Interaction logic for FavouriteWeekControl.xaml
    /// </summary>
    public partial class FavouriteWeekControl : UserControl
    {
        public ScheduleViewModel ViewModel { get; set; }
        public FavouriteWeekControl()
        {
            InitializeComponent();
        }

        private void Select_Week(object sender, RoutedEventArgs e)
        {
            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toBindedList = (Scheduledetail)item.SelectedCells[0].Item;

            ViewModel.CopyAllPerWeek(toBindedList);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
