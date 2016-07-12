using GalaSoft.MvvmLight;
using Scheduler.Base;
using Scheduler.Messages;
using Scheduler.ViewModel;
using Scheduler.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Scheduler.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<CommandVM> Commands { get; set; }
        public ObservableCollection<ViewVM> Views { get; set; }
        public string Message { get; set; }

        public MainWindowViewModel()
        {
            ObservableCollection<ViewVM> views = new ObservableCollection<ViewVM>
            {
                new ViewVM{ViewDisplay="Users",  ViewType = typeof(UsersView), ViewModelType = typeof(UsersViewModel)},
                new ViewVM{ViewDisplay="Sites", ViewType = typeof(SiteView), ViewModelType=typeof(SiteViewModel)},
                new ViewVM{ViewDisplay="Groups", ViewType = typeof(GroupsView), ViewModelType=typeof(GroupsViewModel)},
                new ViewVM{ViewDisplay="Schedule", ViewType = typeof(ScheduleView), ViewModelType=typeof(ScheduleViewModel)},
                new ViewVM{ViewDisplay="Login", ViewType=typeof(LoginView), ViewModelType=typeof(LoginViewModel)},
                //new ViewVM{ViewDisplay="Test", ViewType = typeof(TestView), ViewModelType=typeof(TestViewModel)},
                new ViewVM{ViewDisplay="Work", ViewType = typeof(WorkView), ViewModelType = typeof(WorkViewModel)}
            };
         
            Views = views;
           
            RaisePropertyChanged(() => Views);

            ObservableCollection<CommandVM> commands = new ObservableCollection<CommandVM>
            {
                new CommandVM{ CommandDisplay="Insert", Icon=Application.Current.Resources["InsertIcon"] as BitmapImage  , Message=new CommandMessage{ Command =CommandType.Insert}},
                new CommandVM{ CommandDisplay="Delete", Icon=Application.Current.Resources["DeleteIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.Delete}},
                new CommandVM{ CommandDisplay="Commit", Icon=Application.Current.Resources["SaveIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.Commit}},
                new CommandVM{ CommandDisplay="Refresh", Icon=Application.Current.Resources["RefreshIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.Refresh}},
                new CommandVM{ CommandDisplay="Undo", Icon=Application.Current.Resources["UndoIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.Undo}},
                new CommandVM{ CommandDisplay="Top", Icon=Application.Current.Resources["TopIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.Top}},
                new CommandVM{ CommandDisplay="Previous", Icon=Application.Current.Resources["PreviousIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.Previous}},
                new CommandVM{ CommandDisplay="Next", Icon=Application.Current.Resources["NextIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.Next}},
                new CommandVM{ CommandDisplay="Bottom", Icon=Application.Current.Resources["BottomIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.Bottom}},
                new CommandVM{ CommandDisplay="PDF", Icon=Application.Current.Resources["PDFIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.PrintPDF}},
            };
            Commands = commands;
            RaisePropertyChanged(() => Commands);
        }
    }
}
