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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        private LoginViewModel ViewModel { get; set; }
        
        public LoginView()
        {
            InitializeComponent();
            ViewModel = this.DataContext as LoginViewModel;
        }

        void ViewModel_OnShowControls(object sender, EventArgs e)
        {
            ViewModel.HandleUserLogin();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            string connectionStr = string.Empty;
            Helper.TryGetDataConnectionStringFromUser(out connectionStr);
        }
    }
}
