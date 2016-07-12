using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Scheduler.Base;
using Scheduler.Messages;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using xcd = Xceed.Wpf.Toolkit;
using System.Data.Entity.Infrastructure;
using System.Collections.Specialized;
using System.Data.Entity;
using Scheduler.Support;

namespace Scheduler.ViewModel
{
    public class SiteViewModel : CrudVMBase<Site>
    {
        private ObservableCollection<User> _employeesCollection;
        private ObservableCollection<User> _selectedEmployeesCollection;
        private User _dgSelectedEmployee;
        private Site _selectedSite;

        public ObservableCollection<CommandVM> Commands { get; set; }

        public ObservableCollection<User> SelectedEmployeesCollection 
        {
            get
            {
                return _selectedEmployeesCollection;
            }
            set
            {
                if (_selectedEmployeesCollection == value) return;
                _selectedEmployeesCollection = value;
                RaisePropertyChanged(() => SelectedEmployeesCollection);
            }
        }

        public ObservableCollection<User> EmployeesCollection
        {
            get
            {
                return _employeesCollection;
            }
            set
            {
                if (_employeesCollection == value) return;
                _employeesCollection = value;
                RaisePropertyChanged(() => EmployeesCollection);
            }
        }

        public Site SelectedSite
        {
            get
            {
                return _selectedSite;
            }
            set
            {
                if (_selectedSite == value) return;
                _selectedSite = value;
                RaisePropertyChanged(() => SelectedSite);
                NavigateToCurrentUser(SelectedSite);
            }
        }


	    public User DgSelectedEmployee
	    {
		    get 
            {
                return _dgSelectedEmployee;
            }
		    set 
            {
                if (_dgSelectedEmployee == value) return;
                _dgSelectedEmployee = value;
                RaisePropertyChanged(() => DgSelectedEmployee);
            }
	    }
	


        public List<User> SelectedEmployees;
        public RelayCommand SelectedEmployeesCommand { get; private set; }
        public event EventHandler<EventArgs> OnShowPickList;
        public event EventHandler<EventArgs> OnHidePickList;
        public SiteViewModel()
        {
            SelectedEmployeesCollection = new ObservableCollection<User>();
            SelectedEmployeesCommand = new RelayCommand(SaveEmployeesForSite);
            SelectedEmployees = new List<User>();
            var commands = new ObservableCollection<CommandVM>
            {
                new CommandVM{ CommandDisplay="Insert Employee", Icon=Application.Current.Resources["InsertIcon"] as BitmapImage  , Message=new CommandMessage{ Command =CommandType.InsertChild}},
                new CommandVM{ CommandDisplay="Delete Employee", Icon=Application.Current.Resources["DeleteIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.DeleteChild}},
            };
            Commands = commands;
            RaisePropertyChanged(() => Commands);
            GetChildren();

        }

        private void GetChildren()
        {
            if(db.SiteMembers.Count() == 0)
            {
                return;
            }
            var query = db.SiteMembers.Include(e => e.User);
            var list = query.AsNoTracking()
                            .Where(e => e.Site_Ref == CurrentEntity.Site_Ref).ToList();
            SelectedEmployeesCollection.Clear();
            foreach (var item in list)
            {
                SelectedEmployeesCollection.Add(item.User);
            }

        }

        private void NavigateToCurrentUser(Site SelectedUser)
        {
            WorkAliasCollection.View.MoveCurrentTo(SelectedUser);
            GetChildren();
        }

        public override void MoveNext()
        {
            base.MoveNext();
            GetChildren();
        }

        public override void MovePrev()
        {
            base.MovePrev();
            GetChildren();
        }

        public override void MoveToTop()
        {
            base.MoveToTop();
            GetChildren();
        }

        public override void MoveToBottom()
        {
            base.MoveToBottom();
            GetChildren();
        }

        private void SaveEmployeesForSite()
        {
            var result = xcd.MessageBox.Show("Do you want to save this record?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if(result == MessageBoxResult.Yes)
            {
                // check if already exist 
                foreach (User item in SelectedEmployeesCollection)
                {
                    if (SelectedEmployees.Any(e => e.User_ref == item.User_ref))
                    {
                        MessageBox.Show(item.FirstName + " already exists in this site", "Scheduler", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        User itemToRemove = SelectedEmployees.FirstOrDefault(e => e.User_ref == item.User_ref);
                        SelectedEmployees.Remove(itemToRemove);
                    }
                }

                // add records
                foreach (var item in SelectedEmployees)
                {
                    SelectedEmployeesCollection.Add(item);
                    int usr_Ref = item.User_ref;
                    int site_ref = CurrentEntity.Site_Ref;
                    db.SiteMembers.Add(new SiteMember { Site_Ref = site_ref, User_Ref = usr_Ref });
                }
            

                SendUpdates();
            }
            if (OnHidePickList != null)
            {
                OnHidePickList(this, EventArgs.Empty);
            }
           
        }

        public override void SendUpdates()
        {
            base.SendUpdates();
        }


        protected override void DeleteChild()
        {
            if (DgSelectedEmployee != null)
            {
                int user_ref = DgSelectedEmployee.User_ref;
                var sitemember = (from st in db.SiteMembers
                                  where st.Site_Ref == CurrentEntity.Site_Ref && st.User_Ref == DgSelectedEmployee.User_ref
                                  select st
                                      ).FirstOrDefault<SiteMember>();

                db.Entry(sitemember).State = EntityState.Deleted;
                SelectedEmployeesCollection.Remove(DgSelectedEmployee);
              
                
            }
        }
        protected override void InsertChild()
        {
            var employees = (from c in db.Users
                             orderby c.FirstName
                             select c).ToList();

            EmployeesCollection = new ObservableCollection<User>(employees);

            if (OnShowPickList != null)
            {
                OnShowPickList(this, new EventArgs());
            }    
        }

        protected override void UndoChanges()
        {
            base.UndoChanges();
            if (OnHidePickList != null)
            {
                OnHidePickList(this, EventArgs.Empty);
            }
        }
    }
}
