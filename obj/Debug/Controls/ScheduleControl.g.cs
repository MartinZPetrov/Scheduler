﻿#pragma checksum "..\..\..\Controls\ScheduleControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6C6649846EF021B2D42E7771AB41E553"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Scheduler;
using Scheduler.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Scheduler.Controls {
    
    
    /// <summary>
    /// ScheduleControl
    /// </summary>
    public partial class ScheduleControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 92 "..\..\..\Controls\ScheduleControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgSchedules;
        
        #line default
        #line hidden
        
        
        #line 640 "..\..\..\Controls\ScheduleControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Scheduler.Controls.PickList empPL;
        
        #line default
        #line hidden
        
        
        #line 641 "..\..\..\Controls\ScheduleControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Scheduler.Controls.FavouriteWeekControl favWeekControl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Scheduler;component/controls/schedulecontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\ScheduleControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 83 "..\..\..\Controls\ScheduleControl.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CLose_CLick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dgSchedules = ((System.Windows.Controls.DataGrid)(target));
            
            #line 100 "..\..\..\Controls\ScheduleControl.xaml"
            this.dgSchedules.MouseMove += new System.Windows.Input.MouseEventHandler(this.dgSchedules_MouseMove);
            
            #line default
            #line hidden
            
            #line 103 "..\..\..\Controls\ScheduleControl.xaml"
            this.dgSchedules.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.dgSchedules_SelectedCellsChanged);
            
            #line default
            #line hidden
            
            #line 104 "..\..\..\Controls\ScheduleControl.xaml"
            this.dgSchedules.CurrentCellChanged += new System.EventHandler<System.EventArgs>(this.dgSchedules_CurrentCellChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 602 "..\..\..\Controls\ScheduleControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Context_Delete);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 603 "..\..\..\Controls\ScheduleControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Context_Insert);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 604 "..\..\..\Controls\ScheduleControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Context_Copy);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 605 "..\..\..\Controls\ScheduleControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Context_Paste);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 606 "..\..\..\Controls\ScheduleControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CopyDay);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 607 "..\..\..\Controls\ScheduleControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.PasteDay);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 608 "..\..\..\Controls\ScheduleControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CopyWeek);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 609 "..\..\..\Controls\ScheduleControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.PasteWeek);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 610 "..\..\..\Controls\ScheduleControl.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Choose_Week);
            
            #line default
            #line hidden
            return;
            case 12:
            this.empPL = ((Scheduler.Controls.PickList)(target));
            return;
            case 13:
            this.favWeekControl = ((Scheduler.Controls.FavouriteWeekControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
