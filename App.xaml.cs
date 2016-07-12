using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Threading;
using Scheduler.Support;
using log4net;
using Scheduler.Helpers;

namespace Scheduler
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Log log = Log.GetInstance();
        static App()
        {
            DispatcherHelper.Initialize();
            
            // loger initialization 
            log4net.Config.XmlConfigurator.Configure();
        }

        public App()
        {
            Startup += App_Startup;
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            // To think shall I handle all exceptions
            //AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;  
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; 
            DispatcherUnhandledException += App_DispatcherUnhandledException; 
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException; 

        }

        // Unhandled Exception in the Current AppDomain
        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            log.ProcessError(e.Exception);
            e.Handled = true; // 
        }

        // Process Handled Exceptions
        void CurrentDomain_FirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            log.ProcessError(e.Exception);   // This could be used here to log ALL errors, even those caught by a Try/Catch block
        }

        // UnHandled exception from another AppDomain
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            if (e.IsTerminating)
            {
                //Now is a good time to write that critical error file!
                log.ProcessError(exception);
            }
        }

        // Handles Task Factory Exceptions
        void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            log.ProcessError(e.Exception);
            e.SetObserved();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            AppSettings.Instance.IsUserLogged = false;
            base.OnStartup(e);

            //// Creating a Global culture specific to our application.
            //System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("fr-FR");

            //// Creating the DateTime Information specific to our application.
            //System.Globalization.DateTimeFormatInfo dateTimeInfo = new System.Globalization.DateTimeFormatInfo();

            //// Defining various date and time formats.
            //dateTimeInfo.DateSeparator = "-";
      
            //// Setting application wide date time format.
            //cultureInfo.DateTimeFormat = dateTimeInfo;

            //// Assigning our custom Culture to the application.                        
            //System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;
            //System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

            //FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
            //new FrameworkPropertyMetadata(System.Windows.Markup.XmlLanguage.GetLanguage(System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag)));
        }
    }
}
