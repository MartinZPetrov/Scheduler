using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Support
{
    public sealed class AppSettings
    {
        private static AppSettings instance = null;
        private bool _isUserLogged;
        private int _siteRef;
        private static object padlock = new object();
        private int _userRef;

        private AppSettings()
        {
            
        }

        public static AppSettings Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AppSettings();
                    }
                    return instance;
                }
            }
        }


        public bool IsUserLogged
        {
            get
            {
                return _isUserLogged;
            }
            set
            {
                _isUserLogged = value;
            }
        }


        public int SiteRef 
        {
            get
            {
                return _siteRef;
            }
            set
            {
                _siteRef = value;
            }
        }

        public int UserRef
        {
            get
            {
                return _userRef;
            }
            set
            {
                _userRef = value;
            }
        }
    }
}
