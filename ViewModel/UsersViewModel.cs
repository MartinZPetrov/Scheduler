using Scheduler.Base;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Scheduler.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace Scheduler.ViewModel
{
    public class UsersViewModel : CrudVMBase
    {
        public UserVM SelectedUser { get; set; }

        public ObservableCollection<UserVM> Users { get; set; }
        public UsersViewModel()
            : base()
        {
        }
        protected override void CommitUpdates()
        {
            UserMessage msg = new UserMessage();
            var inserted = (from c in Users
                            where c.IsNew
                            select c).ToList();
            if (db.ChangeTracker.HasChanges() || inserted.Count > 0)
            {
                foreach (UserVM c in inserted)
                {
                    db.Users.Add(c.TheUser);
                }
                try
                {
                    db.SaveChanges();
                    msg.Message = "Database Updated";
                }
                catch (Exception e)
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        ErrorMessage = e.InnerException.GetBaseException().ToString();
                    }
                    msg.Message = "There was a problem updating the database";
                }
            }
            else
            {
                msg.Message = "No changes to save";
            }
            Messenger.Default.Send<UserMessage>(msg);
        }


        protected async override void GetData()
        {
            ObservableCollection<UserVM> _users = new ObservableCollection<UserVM>();
            var users = await(from p in db.Users
                                 orderby p.FirstName
                                 select p).ToListAsync();
            foreach (User user in users)
            {
                _users.Add(new UserVM { IsNew = false, TheUser = user });
            }
            Users = _users;
            RaisePropertyChanged("Users");
        }


        protected override void DeleteCurrent()
        {
            UserMessage msg = new UserMessage();
            if (SelectedUser != null)
            {
                int NumOrders = NumberOfOrders();
                if (NumOrders > 0)
                {
                    msg.Message = string.Format("Cannot delete - there are {0} Orders for this Customer", NumOrders);
                }
                else
                {
                    db.Users.Remove(SelectedUser.TheUser);
                    Users.Remove(SelectedUser);
                    RaisePropertyChanged("Users");
                    msg.Message = "Deleted";
                }
            }
            else
            {
                msg.Message = "No Customer selected to delete";
            }
            Messenger.Default.Send<UserMessage>(msg);
        }

        private int NumberOfOrders()
        {
            var cust = db.Users.Find(SelectedUser.TheUser.User_ref);
            // Count how many Order Lines the Product has
            int ordersCount = db.Users.Count();
            return ordersCount;
        }
    }
}
