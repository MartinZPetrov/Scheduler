using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Scheduler.Models;
using Scheduler.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;
using System.ComponentModel;
using Scheduler.Messages;
using GalaSoft.MvvmLight.Messaging;

namespace Scheduler.ViewModel
{
    public class LoginViewModel : ViewModelBase, IDataErrorInfo
    {
        protected SchedulerContext db;
        private ObservableCollection<User> _employeesCollection;
        private ObservableCollection<string> siteCollection;
        private string userName;
        private string currentSite;
        private string userPassword;
        private string sitePassword;

        public int CurrentStep { get; set; }
        public RelayCommand ProceedToNext { get; private set; }

        public bool UserLoggedIn { get; set; }
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


        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if (userName == value) return;
                userName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public string CurrentSite
        {
            get
            {
                return currentSite;
            }
            set
            {
                if (currentSite == value) return;
                currentSite = value;
                RaisePropertyChanged(() => CurrentSite);
            }
        }

        public string UserPassword
        {
            get
            {
                return userPassword;
            }
            set
            {
                if (userPassword == value) return;
                userPassword = value;
                RaisePropertyChanged(() => UserPassword);
            }
        }

        public string SitePassword
        {
            get
            {
                return sitePassword;
            }
            set
            {
                if (sitePassword == value) return;
                sitePassword = value;
                RaisePropertyChanged(() => SitePassword);
            }
        }

        public ObservableCollection<String> SiteCollection
        {
            get
            {
                return siteCollection;
            }
            set
            {
                if (siteCollection == value) return;
                siteCollection = value;
                RaisePropertyChanged(() => SiteCollection);
            }
        }

        public RelayCommand ProceedToLogin { get; private set; }
        public LoginViewModel()
        {
            db = new SchedulerContext();
            EmployeesCollection = new ObservableCollection<User>();
            SiteCollection = new ObservableCollection<String>();
            CurrentStep = 0;
            LoadData();
            ProceedToLogin = new RelayCommand(HandleUserLogin, () => CanProceed);
        }

        private void LoadData()
        {
            var employeeData = db.Users.ToList();
            var siteData = db.Sites.Select(x => x.Name).ToList();
            EmployeesCollection = new ObservableCollection<User>(employeeData);
            SiteCollection = new ObservableCollection<String>(siteData);

        }

        private void HandleLogins()
        {
            if (CurrentStep == 0)
            {

            }
        }

        public void HandleUserLogin()
        {
            var userFound = EmployeesCollection.FirstOrDefault(e => e.FirstName.Trim() == userName.Trim());
            var siteFound = db.Sites.First(e => e.Name == CurrentSite);
            string userNotFoundText = string.Empty;
            string siteFoundText = string.Empty;
            string userDoesnotExistInSite = string.Empty;
            string passWordNotMatchText = string.Empty;

            if (siteFound == null)
            {
                siteFoundText = "Site does not exist";
                goto finish;
            }

            if (userFound == null)
            {
                userNotFoundText = "User does not exist!";
                goto finish;
            }
            else
            {
                if (db.SiteMembers.Count() == 0)
                {
                    return;
                }
                var query = db.SiteMembers.Include(e => e.User);
                var result = query.Where(e => e.Site_Ref == siteFound.Site_Ref && e.User_Ref == userFound.User_ref).ToList();
                if (result.Count == 0)
                {
                    userDoesnotExistInSite = "User does not exist in site";
                }

            }

            string uncryptedPassword = DataProtectionExtensions.Unprotect(userFound.Password);
            bool passWordFound = uncryptedPassword == UserPassword;
            
            if (!passWordFound)
            {
                passWordNotMatchText = "Password does not match!";
            }

            finish:
            if (!string.IsNullOrEmpty(userNotFoundText) || !string.IsNullOrEmpty(passWordNotMatchText)
                    || !string.IsNullOrEmpty(userDoesnotExistInSite) || !string.IsNullOrEmpty(siteFoundText))
            {
                MessageBox.Show(!string.IsNullOrEmpty(userNotFoundText) ? userNotFoundText + "\n " : string.Empty +
                                  (!string.IsNullOrEmpty(passWordNotMatchText) ? passWordNotMatchText + "\n " : string.Empty) +
                                  (!string.IsNullOrEmpty(siteFoundText) ? siteFoundText + "\n " : string.Empty) +
                                 (!string.IsNullOrEmpty(userDoesnotExistInSite) ? userDoesnotExistInSite + "\n " : string.Empty), "Scheduler",
                               MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                AppSettings.Instance.IsUserLogged = true;
                AppSettings.Instance.SiteRef = siteFound.Site_Ref;
                AppSettings.Instance.UserRef = userFound.User_ref;
                var msg = new FormModeMessage() { Message = CurrentSite };
                var msgEnable = new EnableRibbonMessage() { Enabled = true };
                Messenger.Default.Send<EnableRibbonMessage>(msgEnable);
                Messenger.Default.Send<FormModeMessage>(msg);
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "UserName")
                {
                    if (string.IsNullOrEmpty(UserName))
                        result = "Please enter a First Name";
                }

                if (columnName == "UserPassword")
                {
                    if (string.IsNullOrEmpty(UserPassword))
                        result = "Please enter a Password";
                }
                
                if (columnName == "CurrentSite")
                {
                    if (string.IsNullOrEmpty(CurrentSite))
                        result = "Please Select a Site";
                }
                
                return result;
            }
        }

        static readonly string[] ValidatedProperties =
        {
            "UserName",
            "UserPassword",
            "CurrentSite"
        };
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                {

                    if (GetValidationError(property) != null) // there is an error
                        return false;
                }

                return true;
            }
        }

        public bool CanProceed
        {
            get
            {
                return IsValid;
            }
        }

        private string GetValidationError(string propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "UserName":
                    {
                        if (string.IsNullOrEmpty(UserName))
                        {
                            error = "Please enter a First Name";
                        }
                        break;
                    }
                case "UserPassword":
                    {
                        if (string.IsNullOrEmpty(UserPassword))
                        {
                            error = "Please enter a Password";
                        }
                        break;
                    }
                case "CurrentSite":
                    if (string.IsNullOrEmpty(CurrentSite))
                    {
                        error = "Please enter a Password";
                    }
                    break;

                default:
                    error = null;
                    throw new Exception("Unexpected property being validated on Service");
            }

            return error;
        }
    }
}
