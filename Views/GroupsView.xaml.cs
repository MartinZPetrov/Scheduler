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
    /// Interaction logic for GroupsView.xaml
    /// </summary>
    public partial class GroupsView : UserControl
    {
        private GroupsViewModel ViewModel { get; set; } 
        public GroupsView()
        {
            InitializeComponent();
            ViewModel = this.DataContext as GroupsViewModel;
            ViewModel.OnShowPickList += ViewModel_OnShowPickList;
            ViewModel.OnHidePickList += ViewModel_OnHidePickList;
            ViewModel.OnSetColor += ViewModel_OnSetColor;
        }

        void ViewModel_OnSetColor(object sender, EventArgs e)
        {
            var snd = sender as GroupsViewModel;
            if(snd == null) return;
            if (((Group)snd.WorkAliasCollection.View.CurrentItem == null)) return;

            string colorValue = ((Group)snd.WorkAliasCollection.View.CurrentItem).Color;
            if (string.IsNullOrEmpty(colorValue))
            {
                ClrPcker_Background.SelectedColor = null;
            }
            else
            {
                Color color = (Color)ColorConverter.ConvertFromString(colorValue);
                ClrPcker_Background.SelectedColor = color;
            }
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

        private void ClrPcker_Background_SelectedColorChanged_1(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {

            if(ClrPcker_Background.SelectedColor == null) return;
            var rgbString = string.Format("#{0:X2}{1:X2}{2:X2}",
                    (int)(ClrPcker_Background.SelectedColor.Value.R ),
                    (int)(ClrPcker_Background.SelectedColor.Value.G ),
                    (int)(ClrPcker_Background.SelectedColor.Value.B ));

            ((Group)ViewModel.WorkAliasCollection.View.CurrentItem).Color = rgbString;
        }


    }
}
