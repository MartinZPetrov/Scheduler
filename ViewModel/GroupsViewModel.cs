using Scheduler.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scheduler.Models;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Media.Imaging;
using Scheduler.Messages;
using System.Data.Entity;
using GalaSoft.MvvmLight.Messaging;

namespace Scheduler.ViewModel
{
    public class GroupsViewModel : CrudVMBase<Group>
    {
        private ObservableCollection<User> _selectedEmployeesCollection;
        private Group _selectedGroup;
        private ObservableCollection<User> _employeesCollection;
        private User _dgSelectedEmployee;
        public bool IsInsertingChild { get; set; }

        public Group SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }
            set
            {
                if (_selectedGroup == value) return;
                _selectedGroup = value;
                RaisePropertyChanged(() => SelectedGroup);
                NavigateToCurrentGroup(SelectedGroup);
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
        private void NavigateToCurrentGroup(Group SelectedGroup)
        {
            WorkAliasCollection.View.MoveCurrentTo(SelectedGroup);
            GetChildren();
            SetColorFromRGB();
        }


        public List<User> SelectedEmployees;
        public RelayCommand SelectedEmployeesCommand { get; private set; }

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
        public ObservableCollection<CommandVM> Commands { get; set; }
        public event EventHandler<EventArgs> OnShowPickList;
        public event EventHandler<EventArgs> OnHidePickList;
        public event EventHandler OnSetColor;

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

        public GroupsViewModel()
        {
            SelectedEmployeesCollection = new ObservableCollection<User>();
            SelectedEmployees = new List<User>();
            SelectedEmployeesCommand = new RelayCommand(SaveEmployeesForGroup);
            var commands = new ObservableCollection<CommandVM>
            {
                new CommandVM{ CommandDisplay="Insert Employee", Icon=Application.Current.Resources["InsertIcon"] as BitmapImage  , Message=new CommandMessage{ Command =CommandType.InsertChild}},
                new CommandVM{ CommandDisplay="Delete Employee", Icon=Application.Current.Resources["DeleteIcon"] as BitmapImage , Message=new CommandMessage{ Command = CommandType.DeleteChild}},
            };

            Commands = commands;
            RaisePropertyChanged(() => Commands);
            GetChildren();
            this.MainEntityLoad += GroupsViewModel_MainEntityLoad;
        }

        void GroupsViewModel_MainEntityLoad(object sender, EventArgs e)
        {
            SetColorFromRGB();
        }

        private void SaveEmployeesForGroup()
        {
            var result = MessageBox.Show("Do you want to save this record?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                // check if already exist 
                foreach (User item  in SelectedEmployeesCollection)
                {
                    if (SelectedEmployees.Any(e => e.User_ref == item.User_ref))
                    {
                        MessageBox.Show(item.FirstName + " already exists in this group", "Scheduler", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        User itemToRemove = SelectedEmployees.FirstOrDefault(e => e.User_ref == item.User_ref);
                        SelectedEmployees.Remove(itemToRemove);
                    }
                }
                
                // add records
                foreach (var item in SelectedEmployees)
                {
                    SelectedEmployeesCollection.Add(item);
                    int usr_Ref = item.User_ref;
                    int group_ref = CurrentEntity.Group_Ref;
                    db.GroupMembers.Add(new GroupMember { Group_Ref = group_ref, User_Ref = usr_Ref });
                }
            
                var msg = new FormModeMessage() { Message = "" };
                var usrmsg = new UserMessage() { Message = string.Empty };
                Messenger.Default.Send<FormModeMessage>(msg);
                if (db.ChangeTracker.HasChanges())
                {
                    try
                    {
                        db.SaveChanges();

                    }
                    catch (Exception)
                    {
                        usrmsg.Message = "Could not save record.";
                    }
                    if (string.IsNullOrEmpty(usrmsg.Message))
                    {
                        usrmsg.Message = "Record Saved!";
                        Messenger.Default.Send<UserMessage>(usrmsg);
                    }
                }

            }
            if (OnHidePickList != null)
            {
                OnHidePickList(this, EventArgs.Empty);
            }
        }


        public override void SendUpdates()
        {
            string color = ((Group) this.WorkAliasCollection.View.CurrentItem).Color;
            // Check if a group has already this color
            var colorFound = db.Groups.Where(e => e.Color == color).ToList();
            if (colorFound.Count() >= 1)
            {
                MessageBox.Show("There is a group already with this color!\nPlease select another color", "Scheduler", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
        
            base.SendUpdates();
        }

        public override void MoveNext()
        {
            base.MoveNext();
            GetChildren();
            SetColorFromRGB();
        }

        public override void MovePrev()
        {
            base.MovePrev();
            GetChildren();
            SetColorFromRGB();
        }

        public override void MoveToTop()
        {
            base.MoveToTop();
            GetChildren();
            SetColorFromRGB();
        }

        public override void MoveToBottom()
        {
            base.MoveToBottom();
            GetChildren();
            SetColorFromRGB();
        }

          protected override void InsertChild()
        {
            IsInsertingChild = true;
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


        protected override void DeleteChild()
        {
            MessageBoxResult result = MessageBox.Show("Delete Record", "Scheduleren", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (DgSelectedEmployee != null)
                {
                    int user_ref = DgSelectedEmployee.User_ref;
                    var groupMember = (from st in db.GroupMembers
                                       where st.Group_Ref == CurrentEntity.Group_Ref && st.User_Ref == DgSelectedEmployee.User_ref
                                       select st
                                          ).FirstOrDefault<GroupMember>();

                    db.Entry(groupMember).State = EntityState.Deleted;
                    SelectedEmployeesCollection.Remove(DgSelectedEmployee);
                    db.SaveChanges();
                }
            }
        }


        private void GetChildren()
        {
            var query = db.GroupMembers.Include(e => e.User);
            if (CurrentEntity == null) return;

            var list = query.AsNoTracking()
                            .Where(e => e.Group_Ref == CurrentEntity.Group_Ref).ToList(); ;
            SelectedEmployeesCollection.Clear();
            foreach (var item in list)
            {
                SelectedEmployeesCollection.Add(item.User);
            }

        }
        
        private void SetColorFromRGB()
        {
            if(OnSetColor != null)
            {
                OnSetColor(this, new EventArgs());
            }

        }
    }
}
