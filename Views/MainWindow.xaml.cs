using GalaSoft.MvvmLight.Messaging;
using Scheduler.Messages;
using Scheduler.Support;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Scheduler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
            Messenger.Default.Register<NavigateMessage>(this, (action) => ShowUserControl(action));
            Messenger.Default.Register<UserMessage>(this, (action) => ReceiveUserMessage(action));
            Messenger.Default.Register<FormModeMessage>(this, (action) => SetFormCaption(action));
            Messenger.Default.Register<EnableRibbonMessage>(this, (action) => EnableRibbon(action));
            ViewModel = this.DataContext as MainWindowViewModel;

            if (!AppSettings.Instance.IsUserLogged)
            {
                ribbonBar.IsEnabled = false;
                ViewModel.Views[4].NavigateExecute();
            }
            
            AppSettings.Instance.SiteRef = 4;
        }

        private void EnableRibbon(EnableRibbonMessage msg)
        {
            ribbonBar.IsEnabled = msg.Enabled;
            ViewModel.Views[3].NavigateExecute();
        }

        private void SetFormCaption(FormModeMessage msg)
        {
            if (string.IsNullOrEmpty(msg.Message))
            {
                this.Title = "Scheduler";
            }
            else
            {
                this.Title = "Scheduler" + " -  " + msg.Message;
            }
        }

        private void ReceiveUserMessage(UserMessage msg)
        {
            UIMessage.Opacity = 1;
            UIMessage.Text = msg.Message;
            Storyboard sb = (Storyboard)this.FindResource("FadeUIMessage");
            sb.Begin();
        }
        private void ShowUserControl(NavigateMessage nm)
        {
            nm.View.Visibility = Visibility.Visible;
            EditFrame.Content = nm.View;
        }

        private void EditFrame_Navigated(object sender, NavigationEventArgs e)
        {
            ((Frame)sender).NavigationService.RemoveBackEntry();
        }
    }
}
