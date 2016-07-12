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
using System.Security.Cryptography;
using Scheduler.Support;
using System.Windows.Media;

namespace Scheduler.ViewModel
{
    public class UsersViewModel : CrudVMBase<User>
    {
        private User _selectedUser;
        
        private string _password;
        private ImageSource _userImage;
        private UserImage _userImageSelection;

        private bool IsAdding { get; set; }
        public string PicFilePath { get; set; }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password == value) return;
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public User SelectedUser
        {
            get 
            {
                return _selectedUser; 
            }
            set 
            {
                if (_selectedUser == value) return;
                _selectedUser = value;
                RaisePropertyChanged(() => SelectedUser);
                NavigateToCurrentUser(SelectedUser);
            }
        }

        
        public UserImage UserImageSelection
        {
            get
            {
                return _userImageSelection;
            }
            set
            {
                if (_userImageSelection == value) return;
                _userImageSelection = value;
                RaisePropertyChanged(() => UserImageSelection);
            }
        }


        public UsersViewModel()
        {
            GetChildren();
            
        }
        public override void SendUpdates()
        {
            string ecntyptedPassowrd = DataProtectionExtensions.Protect(Password);
            string unprotec = DataProtectionExtensions.Unprotect(ecntyptedPassowrd);
            ((User)WorkAliasCollection.View.CurrentItem).Password = ecntyptedPassowrd;
            if (UserImageSelection != null && UserImageSelection.User_Ref != 0)
            {
                UserImage usrimg = db.UserImages.FirstOrDefault(e => e.User_Ref == UserImageSelection.User_Ref);
                db.Entry(usrimg).Entity.Image = UserImageSelection.Image;
                db.Entry(usrimg).State = EntityState.Modified;
            }
            base.SendUpdates();
            if(IsAdding)
            {
                IsAdding = false;
                var query = db.UserImages.Include(e => e.User);
                if (CurrentEntity == null) return;
                if (UserImageSelection == null) return;

                //UserImage usrImg = query.AsNoTracking()
                //                .Where(e => e.User_Ref == CurrentEntity.User_ref).FirstOrDefault();

                UserImage usrImg = db.UserImages.FirstOrDefault(e => e.User_Ref == CurrentEntity.User_ref);
                db.Entry(usrImg).Entity.Image = UserImageSelection.Image;
                db.Entry(usrImg).State = EntityState.Modified;
                UserImageSelection = usrImg;
                base.SendUpdates();
            }
        }

        private void GetChildren()
        {
            var query = db.UserImages.Include(e => e.User);
            if (CurrentEntity == null) return;

            UserImage usrImg = query.AsNoTracking()
                            .Where(e => e.User_Ref == CurrentEntity.User_ref).FirstOrDefault() ;
            UserImageSelection = usrImg;

        }

        protected override void LoadMainEntity(bool presistCurrent = false)
        {
            base.LoadMainEntity(presistCurrent);
            string password = ((User)WorkAliasCollection.View.CurrentItem).Password;
            if (!string.IsNullOrEmpty(password))
            {
                string decryptedPassowrd = DataProtectionExtensions.Unprotect(password);
                Password = decryptedPassowrd;
            }
            else
            {
                Password = string.Empty;
            }
        }

        public override void MoveNext()
        {
            base.MoveNext();
            string password = ((User)WorkAliasCollection.View.CurrentItem).Password;
            if (!string.IsNullOrEmpty(password))
            {
                Password = DataProtectionExtensions.Unprotect(password);
            }
            else
            {
                Password = string.Empty;
            }
            GetChildren();
        }

        public override void MovePrev()
        {
            base.MovePrev();
            string password = ((User)WorkAliasCollection.View.CurrentItem).Password;
            if (!string.IsNullOrEmpty(password))
            {
                Password = DataProtectionExtensions.Unprotect(password);
            }
            else
            {
                Password = string.Empty;
            }
            GetChildren();
        }

        public override void MoveToBottom()
        {
            base.MoveToBottom();
            GetChildren();
        }

        public override void MoveToTop()
        {
            base.MoveToTop();
            GetChildren();
        }

        private void NavigateToCurrentUser(User SelectedUser)
        {
            WorkAliasCollection.View.MoveCurrentTo(SelectedUser);
        }


        public override void Add()
        {
            base.Add();
            Password = string.Empty;
            IsAdding = true;
            var entity = new UserImage();
            DbSet<UserImage> dbSet = db.Set<UserImage>();
            dbSet.Add(entity);
            //db.UserImages.Add(entity);
            db.Entry(entity).State = EntityState.Added;
            UserImageSelection = entity;
            
        }

        public override void Remove()
        {
            base.Remove();
        }
    }
}

