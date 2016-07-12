using GalaSoft.MvvmLight.CommandWpf;
using Scheduler.Base;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel;
using System.Windows.Data;
using sw = System.Windows;
using System.Collections;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Windows.Forms;
using Scheduler.Support;
using System.Globalization;
using xcd = Xceed.Wpf.Toolkit;

namespace Scheduler.ViewModel
{
    public class ScheduleViewModel : CrudVMBase<Schedule>
    {
        private Dictionary<int, Tuple<DateTime, DateTime>> WeeksHolder;
        private bool _myColumnVisibility;
        private ObservableCollection<Scheduledetail> _scheduleDetailsFav;
        private ObservableCollection<User> _selectedEmployeesCollection;
        private object _plSelectedItem;
        private ObservableCollection<Scheduledetail> _scheduleDetails;
        private ObservableCollection<Group> _scheduleGroups;
        private Schedule _selectedSchedule;
        private CollectionViewSource _scheduleDetailsViewSourceJan;
        private CollectionViewSource _scheduleDetailsViewSourceFeb;
        private CollectionViewSource _scheduleDetailsViewSourceMar;
        private CollectionViewSource _scheduleDetailsViewSourceApr;
        private CollectionViewSource _scheduleDetailsViewSourceMay;
        private CollectionViewSource _scheduleDetailsViewSourceJun;
        private CollectionViewSource _scheduleDetailsViewSourceJul;
        private CollectionViewSource _scheduleDetailsViewSourceAug;
        private CollectionViewSource _scheduleDetailsViewSourceSep;
        private CollectionViewSource _scheduleDetailsViewSourceOct;
        private CollectionViewSource _scheduleDetailsViewSourceNov;
        private CollectionViewSource _scheduleDetailsViewSourceDec;
        private CollectionViewSource _scheduleDetailsViewSourceFav;

        private Scheduledetail _dgSelectedScheduleDetail;
        private bool _isExpandetAll;
        private ObservableCollection<bool> _acceptedSchedules;
        private string _copyText;
        private string _pasteText;
        private ObservableCollection<Scheduledetail> _selectedItemsToCopy;
        private ObservableCollection<string> _endTimeText;
        private ObservableCollection<string> _startTimeText;
        private ObservableCollection<Scheduledetail> _selectedItemsToCopyPerDay;
        private ObservableCollection<Scheduledetail> _selectedItemsToCopyPerWeek;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string FullName { get { return "WeekStart" + " " + "WeekEnd"; } }

        public string PDFFileName { get; set; }
        public string PasteText
        {
            get
            {
                return _pasteText;
            }
            set
            {
                if (_pasteText == value) return;
                _pasteText = value;
                RaisePropertyChanged(() => PasteText);
            }
        }
        public int ScheduleClicked { get; set; }
        public string CopyText
        {
            get
            {
                return _copyText;
            }
            set
            {
                if (_copyText == value) return;
                _copyText = value;
                RaisePropertyChanged(() => CopyText);
            }
        }
        public int CurrentSelectedYear { get; set; }
        public Schedule SelectedSchedule
        {
            get
            {
                return _selectedSchedule;
            }
            set
            {
                if (_selectedSchedule == value) return;
                _selectedSchedule = value;
                RaisePropertyChanged(() => SelectedSchedule);
                WorkAliasCollection.View.MoveCurrentTo(SelectedSchedule);
            }
        }
        public ObservableCollection<Group> ScheduleGroups
        {
            get
            {
                return _scheduleGroups;
            }
            set
            {
                if (_scheduleGroups == value) return;
                _scheduleGroups = value;
                RaisePropertyChanged(() => ScheduleGroups);
            }
        }


        public ObservableCollection<Group> ScheduleGroupsFav
        {
            get
            {
                return _scheduleGroupsFav;
            }
            set
            {
                if (_scheduleGroupsFav == value) return;
                _scheduleGroupsFav = value;
                RaisePropertyChanged(() => ScheduleGroupsFav);
            }
        }


        public bool MyColumnVisibility
        {
            get
            {
                return _myColumnVisibility;
            }
            set
            {
                if (_myColumnVisibility == value) return;
                _myColumnVisibility = value;
                RaisePropertyChanged(() => MyColumnVisibility);
            }
        }
        
        public ObservableCollection<Scheduledetail> SelectedItemsToCopy
        {
            get
            {
                return _selectedItemsToCopy;
            }
            set
            {
                if (_selectedItemsToCopy == value) return;
                _selectedItemsToCopy = value;
                RaisePropertyChanged(() => ScheduleGroups);
            }
        }

        public ObservableCollection<Scheduledetail> SelectedItemsToCopyPerDay
        {
            get
            {
                return _selectedItemsToCopyPerDay;
            }
            set
            {
                if (_selectedItemsToCopyPerDay == value) return;
                _selectedItemsToCopyPerDay = value;
                RaisePropertyChanged(() => SelectedItemsToCopyPerDay);
            }
        }


        public ObservableCollection<Scheduledetail> SelectedItemsToCopyPerWeek
        {
            get
            {
                return _selectedItemsToCopyPerWeek;
            }
            set
            {
                if (_selectedItemsToCopyPerWeek == value) return;
                _selectedItemsToCopyPerWeek = value;
                RaisePropertyChanged(() => SelectedItemsToCopyPerWeek);
            }
        }
        public ObservableCollection<bool> AcceptedSchedules
        {
            get
            {
                return _acceptedSchedules;
            }
            set
            {
                if (_acceptedSchedules == value) return;
                _acceptedSchedules = value;
                RaisePropertyChanged(() => AcceptedSchedules);
            }
        }

        public ObservableCollection<string> StartTimeText
        {
            get
            {
                return _startTimeText;
            }
            set
            {
                if (_startTimeText == value) return;
                _startTimeText = value;
                RaisePropertyChanged(() => StartTimeText);
            }
        }
 
        public ObservableCollection<string> EndTimeText
        {
            get
            {
                return _endTimeText;
            }
            set
            {
                if (_endTimeText == value) return;
                _endTimeText = value;
                RaisePropertyChanged(() => EndTimeText);
            }
        }



        public ObservableCollection<Scheduledetail> ScheduleDetails
        {
            get
            {
                return _scheduleDetails;
            }
            set
            {
                if (_scheduleDetails == value) return;
                _scheduleDetails = value;
                RaisePropertyChanged(() => ScheduleDetails);
            }
        }


        public ObservableCollection<Scheduledetail> ScheduleDetailsFav
        {
            get
            {
                return _scheduleDetailsFav;
            }
            set
            {
                if (_scheduleDetailsFav == value) return;
                _scheduleDetailsFav = value;
                RaisePropertyChanged(() => ScheduleDetailsFav);
            }
        }

        public bool IsExpandedAll
        {
            get
            {
                return _isExpandetAll;
            }
            set
            {
                if (_isExpandetAll == value) return;
                _isExpandetAll = value;
                RaisePropertyChanged(() => IsExpandedAll);
                if (OnExpandDatagrid != null)
                {
                    OnExpandDatagrid(this, new EventArgs());
                }

            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceFav
        {
            get
            {
                return _scheduleDetailsViewSourceFav;
            }
            set
            {
                if (_scheduleDetailsViewSourceFav == value) return;
                _scheduleDetailsViewSourceFav = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceFav);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceJan
        {
            get
            {
                return _scheduleDetailsViewSourceJan;
            }
            set
            {
                if (_scheduleDetailsViewSourceJan == value) return;
                _scheduleDetailsViewSourceJan = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceJan);
            }
        }
        public CollectionViewSource ScheduleDetailsViewSourceFeb
        {
            get
            {
                return _scheduleDetailsViewSourceFeb;
            }
            set
            {
                if (_scheduleDetailsViewSourceFeb == value) return;
                _scheduleDetailsViewSourceFeb = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceFeb);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceMar
        {
            get
            {
                return _scheduleDetailsViewSourceMar;
            }
            set
            {
                if (_scheduleDetailsViewSourceMar == value) return;
                _scheduleDetailsViewSourceMar = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceMar);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceApr
        {
            get
            {
                return _scheduleDetailsViewSourceApr;
            }
            set
            {
                if (_scheduleDetailsViewSourceApr == value) return;
                _scheduleDetailsViewSourceApr = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceApr);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceMay
        {
            get
            {
                return _scheduleDetailsViewSourceMay;
            }
            set
            {
                if (_scheduleDetailsViewSourceMay == value) return;
                _scheduleDetailsViewSourceMay = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceMay);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceJun
        {
            get
            {
                return _scheduleDetailsViewSourceJun;
            }
            set
            {
                if (_scheduleDetailsViewSourceJun == value) return;
                _scheduleDetailsViewSourceJun = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceJun);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceJul
        {
            get
            {
                return _scheduleDetailsViewSourceJul;
            }
            set
            {
                if (_scheduleDetailsViewSourceJul == value) return;
                _scheduleDetailsViewSourceJul = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceJul);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceAug
        {
            get
            {
                return _scheduleDetailsViewSourceAug;
            }
            set
            {
                if (_scheduleDetailsViewSourceAug == value) return;
                _scheduleDetailsViewSourceAug = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceAug);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceSep
        {
            get
            {
                return _scheduleDetailsViewSourceSep;
            }
            set
            {
                if (_scheduleDetailsViewSourceSep == value) return;
                _scheduleDetailsViewSourceSep = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceSep);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceOct
        {
            get
            {
                return _scheduleDetailsViewSourceOct;
            }
            set
            {
                if (_scheduleDetailsViewSourceOct == value) return;
                _scheduleDetailsViewSourceOct = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceOct);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceNov
        {
            get
            {
                return _scheduleDetailsViewSourceNov;
            }
            set
            {
                if (_scheduleDetailsViewSourceNov == value) return;
                _scheduleDetailsViewSourceNov = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceNov);
            }
        }

        public CollectionViewSource ScheduleDetailsViewSourceDec
        {
            get
            {
                return _scheduleDetailsViewSourceDec;
            }
            set
            {
                if (_scheduleDetailsViewSourceDec == value) return;
                _scheduleDetailsViewSourceDec = value;
                RaisePropertyChanged(() => ScheduleDetailsViewSourceDec);
            }
        }



        public Scheduledetail DgSelectedScheduleDetail
        {
            get
            {
                return _dgSelectedScheduleDetail;
            }
            set
            {
                if (_dgSelectedScheduleDetail == value) return;
                _dgSelectedScheduleDetail = value;
                //RaisePropertyChanged(() => DgSelectedScheduleDetail);
                SetCopyAndPasteText(DgSelectedScheduleDetail);
              

            }
        }

        public object PlSelectedItem
        {
            get
            {
                return _plSelectedItem;
            }
            set
            {
                _plSelectedItem = value;
                if (_plSelectedItem == null) return;
                RaisePropertyChanged(() => PlSelectedItem);
                SetDataGridItem();
                
            }
        }


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


        public RelayCommand ProceedToScheduleDetails { get; private set; }
        public RelayCommand CreateSheduleJan { get; private set; }
        public RelayCommand CreateSheduleFeb { get; private set; }
        public RelayCommand CreateSheduleMar { get; private set; }
        public RelayCommand CreateSheduleApr { get; private set; }
        public RelayCommand CreateSheduleMay { get; private set; }
        public RelayCommand CreateSheduleJun { get; private set; }
        public RelayCommand CreateSheduleJul { get; private set; }
        public RelayCommand CreateSheduleAug { get; private set; }
        public RelayCommand CreateSheduleSep { get; private set; }
        public RelayCommand CreateSheduleOct { get; private set; }
        public RelayCommand CreateSheduleNov { get; private set; }
        public RelayCommand CreateSheduleDec { get; private set; }
        public RelayCommand AcceptSchedule { get; private set; }
        public RelayCommand EmployeePickList { get; private set; }

        public event CurrentEntityChangedEventHandler OnCreateScheduleDetails;
        public event EventHandler OnGetDataGridItemsHandler;
        public event EventHandler OnExpandDatagrid;
        public event EventHandler OnShowEmployeePickList;
        public event EventHandler OnSetDataGridData;
        private ObservableCollection<Group> _scheduleGroupsFav;
       
               
        public ScheduleViewModel()
        {
            ScheduleDetails = new ObservableCollection<Scheduledetail>();
            ScheduleGroups = new ObservableCollection<Group>();
            CreateSheduleJan = new RelayCommand(CreateShedulesJan);
            CreateSheduleFeb = new RelayCommand(CreateShedulesFeb);
            CreateSheduleMar = new RelayCommand(CreateShedulesMar);
            CreateSheduleApr = new RelayCommand(CreateShedulesApr);
            CreateSheduleMay = new RelayCommand(CreateShedulesMay);
            CreateSheduleJun = new RelayCommand(CreateShedulesJun);
            CreateSheduleJul = new RelayCommand(CreateShedulesJul);
            CreateSheduleAug = new RelayCommand(CreateShedulesAug);
            CreateSheduleSep = new RelayCommand(CreateShedulesSep);
            CreateSheduleOct = new RelayCommand(CreateShedulesOct);
            CreateSheduleNov = new RelayCommand(CreateShedulesNov);
            CreateSheduleDec = new RelayCommand(CreateShedulesDec);
            AcceptSchedule = new RelayCommand(AcceptCreatedSchedule);
            SelectedItemsToCopy = new ObservableCollection<Scheduledetail>();
            AcceptedSchedules = new ObservableCollection<bool>();
            SelectedItemsToCopyPerWeek = new ObservableCollection<Scheduledetail>();
            EndTimeText = new ObservableCollection<string>();
            SelectedItemsToCopyPerDay = new ObservableCollection<Scheduledetail>();
            ScheduleDetailsViewSourceJan = new CollectionViewSource();
            ScheduleDetailsViewSourceFeb = new CollectionViewSource();
            ScheduleDetailsViewSourceMar = new CollectionViewSource();
            ScheduleDetailsViewSourceApr = new CollectionViewSource();
            ScheduleDetailsViewSourceMay = new CollectionViewSource();
            ScheduleDetailsViewSourceJun = new CollectionViewSource();
            ScheduleDetailsViewSourceJul = new CollectionViewSource();
            ScheduleDetailsViewSourceAug = new CollectionViewSource();
            ScheduleDetailsViewSourceSep = new CollectionViewSource();
            ScheduleDetailsViewSourceNov = new CollectionViewSource();
            ScheduleDetailsViewSourceOct = new CollectionViewSource();
            ScheduleDetailsViewSourceDec = new CollectionViewSource();
            CurrentSelectedYear = DateTime.Now.Year;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            IsExpandedAll = true;
            ScheduleClicked = 0;
            AcceptedSchedules = new ObservableCollection<bool>(new[] { false, false, false, false, false, false, false, false, false, false, false, false });
            StartTimeText = new ObservableCollection<string>(new[] { "", "", "", "", "", "", "", "", "", "", "", "" });
            EndTimeText = new ObservableCollection<string>(new[] { "", "", "", "", "", "", "", "", "", "", "", "" });
            EmployeePickList = new RelayCommand(CallEmployeePickList);
            SelectedEmployeesCollection = new ObservableCollection<User>();
            WeeksHolder = new Dictionary<int, Tuple<DateTime, DateTime>>();
            ScheduleDetailsViewSourceFav = new CollectionViewSource();
            MyColumnVisibility = true;
        }

        public void GetEmployeesPerSiteAndGroup(Scheduledetail dtl)
        {
            if(db.SiteMembers.Count() == 0 || db.GroupMembers.Count() == 0)
            {
                MessageBox.Show("Please first define groups and site members before creating a schedule");
            }

            var list = db.Users.SqlQuery(@"select *
                                        from [User]
                                 join SiteMembers on [SiteMembers].User_Ref = [USER].User_ref
                                 join [GroupMembers] on [GroupMembers].User_Ref = [USER].User_ref
                                 where SiteMembers.Site_Ref = " + AppSettings.Instance.SiteRef + " and [GroupMembers].Group_Ref = " + dtl.Group_Ref +
                                 " ORDER BY [User].User_ref").ToList();
            
            SelectedEmployeesCollection.Clear();
            Helper.SelectedEmployeesCollection = new ObservableCollection<User>(list);
            foreach (var item in list)
            {
                SelectedEmployeesCollection.Add(item);
            }

        }

        private void CallEmployeePickList()
        {
            if(OnShowEmployeePickList != null)
            {
                OnShowEmployeePickList(this, new EventArgs());
            }
        }


        private void CreateShedulesDec()
        {
            ScheduleClicked = 12;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 12);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 12, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 12, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }
        }

        private void CreateShedulesNov()
        {
            ScheduleClicked = 11;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 11);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 11, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 11, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }
        }

        private void CreateShedulesOct()
        {
            ScheduleClicked = 10;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 10);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 10, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 10, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }
        }

        private void CreateShedulesSep()
        {
            ScheduleClicked = 9;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 9);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 9, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 9, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }

        }

        private void CreateShedulesAug()
        {
            ScheduleClicked = 8;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 8);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 8, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 8, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }
        }

        private void CreateShedulesJul()
        {
            ScheduleClicked = 7;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 7);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 7, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 7, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }
        }

        private void CreateShedulesJun()
        {
            ScheduleClicked = 6;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 6);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 6, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 6, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }

        }

        private void CreateShedulesMay()
        {
            ScheduleClicked = 5;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 5);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 5, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 5, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }

        }

        private void CreateShedulesApr()
        {
            ScheduleClicked = 4;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 4);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 4, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 4, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }
        }

        private void CreateShedulesMar()
        {
            ScheduleClicked = 3;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 3);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 3, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 3, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }
        }

        private void CreateShedulesFeb()
        {
            ScheduleClicked = 2;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;

            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 2);
            DateTime monthFirst = new DateTime(CurrentSelectedYear, 2, 1);
            DateTime monthLast = new DateTime(CurrentSelectedYear, 2, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == monthFirst && e.ToDate == monthLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = monthFirst, ToDate = monthLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }
        }

        private void CreateShedulesJan()
        {
            ScheduleClicked = 1;
            int startHour = StartTime.Hour;
            int endHour = EndTime.Hour;
            var lastDayOfMonth = DateTime.DaysInMonth(CurrentSelectedYear, 1);
            DateTime janFirst = new DateTime(CurrentSelectedYear, 1, 1);
            DateTime janLast = new DateTime(CurrentSelectedYear, 1, lastDayOfMonth);
            var schedules = db.Schedules.ToList();
            var scheduleFound = schedules.FirstOrDefault(e => e.FromDate == janFirst && e.ToDate == janLast);
            if (scheduleFound == null)
            {
                var newSchedule = db.Schedules.Add(new Schedule { FromDate = janFirst, ToDate = janLast, StartTime = startHour, EndTime = endHour, Site_Ref = AppSettings.Instance.SiteRef });
                db.SaveChanges();
                GetScheduleDetails(newSchedule);
            }
            else
            {
                db.Entry(scheduleFound).Entity.StartTime = startHour;
                db.Entry(scheduleFound).Entity.EndTime = endHour;
                if (db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
                GetScheduleDetails(scheduleFound);
            }

        }

        private void GetScheduleDetails(Schedule schedule)
        {

            int shedule_ref = schedule.Schedule_Ref;
            TimeSpan? t = schedule.ToDate - schedule.FromDate;
            int totalDays = t.Value.Days;

            var jan1 = new DateTime(schedule.FromDate.Value.Year, 1, 1);
            //beware different cultures, see other answers
            var startOfFirstWeek = jan1.AddDays(1 - (int)(jan1.DayOfWeek));

            // get weeks per current year
            var weeks =
            Enumerable
             .Range(0, 54)
             .Select(i => new { weekStart = startOfFirstWeek.AddDays(i * 7) })
             .TakeWhile(x => x.weekStart.Year <= jan1.Year)
             .Select(x => new
             {
                 x.weekStart,
                 weekFinish = x.weekStart.AddDays(6)
             })
             .SkipWhile(x => x.weekFinish < jan1.AddDays(1))
             .Select((x, i) => new
             {
                 x.weekStart,
                 x.weekFinish,
                 weekNum = i + 1

             });

            WeeksHolder.Clear();
            foreach (var item in weeks)
            {
                WeeksHolder.Add(item.weekNum, new Tuple<DateTime, DateTime>(item.weekStart, item.weekFinish));
            }

            for (int i = 0; i <= totalDays; i++)
            {
                if (i == 0)
                {
                    DateTime date = schedule.FromDate.Value.Date;
                    var item = db.Scheduledetails.Where(e => e.Day == date && e.Schedule_Ref == shedule_ref);
                   
                    if (item.Count() == 0)
                    {
                        db.Scheduledetails.Add(new Scheduledetail { Schedule_Ref = shedule_ref, Day = schedule.FromDate, Group_Ref = 1 });
                    }
                }
                else
                {
                    DateTime nextDate = schedule.FromDate.Value.AddDays(i).Date;
                    var item = db.Scheduledetails.Where(e => e.Day == nextDate && e.Schedule_Ref == shedule_ref);
                    if (item.Count() == 0)
                    {
                        db.Scheduledetails.Add(new Scheduledetail { Schedule_Ref = shedule_ref, Day = nextDate, Group_Ref = 1 });
                    }
                }
            }

           if(db.ChangeTracker.HasChanges())
           {
               db.SaveChanges();
           }

            var list = db.Scheduledetails.Where(e => e.Schedule_Ref == shedule_ref).OrderBy(e => e.Day);

            var query = db.Groups.ToList();
            var listGroups = query.ToList();

            ScheduleDetails = new ObservableCollection<Scheduledetail>(list);
            ScheduleGroups = new ObservableCollection<Group>(listGroups);

            CollectionViewSource scheduleDetailsViewSource = GetViewSourceForMonth();
            scheduleDetailsViewSource.GroupDescriptions.Clear();
            scheduleDetailsViewSource.Source = ScheduleDetails;
            scheduleDetailsViewSource.GroupDescriptions.Add(new PropertyGroupDescription("Day"));

            if (OnCreateScheduleDetails != null)
            {
                OnCreateScheduleDetails(this, new CurrentEntityChangedEventArgs(schedule));
            }
        }



        public void DeleteScheduleDetails(List<Scheduledetail> items)
        {
            if (items.Count == 1)
            {
                sw.MessageBoxResult result = sw.MessageBox.Show("Do you want to delete this record?", "Attention", sw.MessageBoxButton.YesNo,
                                                     sw.MessageBoxImage.Question);
                if (result == sw.MessageBoxResult.Yes)
                {
                    this.ScheduleDetails.Remove(items[0]);
                    db.Scheduledetails.Remove(items[0]);
                }
            }
            else
            {
                sw.MessageBoxResult result = sw.MessageBox.Show("Do you want to delete these records?", "Attention", sw.MessageBoxButton.YesNo,
                                                    sw.MessageBoxImage.Question);

                if (result == sw.MessageBoxResult.Yes)
                {
                    foreach (var item in items)
                    {
                        this.ScheduleDetails.Remove(item);
                        db.Scheduledetails.Remove(item);
                    }
                }
            }
            db.SaveChanges();

            var scheduleDetailsViewSource = GetViewSourceForMonth();
            scheduleDetailsViewSource.Source = ScheduleDetails;
        }

        public void AddScheduleDetails(Scheduledetail obj)
        {
            var newEntity = new Scheduledetail { Group_Ref = obj.Group_Ref, Day = obj.Day, Schedule_Ref = obj.Schedule_Ref };
            db.Scheduledetails.Add(newEntity);
            ScheduleDetails.Add(newEntity);
            db.SaveChanges();

            var scheduleDetailsViewSource = GetViewSourceForMonth();
            scheduleDetailsViewSource.Source = ScheduleDetails;
        }

        public void PasteSheduleDetails(Scheduledetail selectedSchedule)
        {
            int schedulRef = selectedSchedule.Schedule_Ref;
            foreach (var item in SelectedItemsToCopy)
            {
                item.Day = selectedSchedule.Day;
                item.Schedule_Ref = schedulRef;
                db.Entry(item).State = EntityState.Added;
            }
            if (db.ChangeTracker.HasChanges())
            {
                db.SaveChanges();
            }

            var list = db.Scheduledetails.Where(e => e.Schedule_Ref == schedulRef).OrderBy(e => e.Day);
            ScheduleDetails = new ObservableCollection<Scheduledetail>(list);

            var scheduleDetailsViewSource = GetViewSourceForMonth();
            scheduleDetailsViewSource.Source = ScheduleDetails;
        }

        private void SetCopyAndPasteText(Scheduledetail DgSelectedScheduleDetail)
        {
            if (DgSelectedScheduleDetail == null)
            {
                return;
            }

            string day = DgSelectedScheduleDetail.Day.Value.DayOfWeek.ToString();
            CopyText = "Copy " + day;
            PasteText = "Paste To " + day + "s";
        }

        public void CopyAllPerDay(Scheduledetail sch)
        {
            var setOFDataForDay = ScheduleDetails.Where(e => e.Day == sch.Day);
            SelectedItemsToCopyPerDay = new ObservableCollection<Scheduledetail>(setOFDataForDay);
        }

        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        private void AcceptCreatedSchedule()
        {
            if(DgSelectedScheduleDetail == null)
            {
                return;
            }

            int shedule_ref = DgSelectedScheduleDetail.Schedule_Ref;
            var Schedule = db.Schedules.FirstOrDefault(e => e.Schedule_Ref == shedule_ref);

            var result = sw.MessageBox.Show("Do you want to accept the Schedule?", "Attention", sw.MessageBoxButton.YesNo, sw.MessageBoxImage.Exclamation);
            if (result == sw.MessageBoxResult.Yes)
            {
                db.Entry(Schedule).Entity.Accepted = true;
                db.SaveChanges();
                CheckAcceptedSchedule();
            }
        }

        public void CheckAcceptedSchedule()
        {
            var entities = db.Schedules.Where(e => e.FromDate.Value.Year == CurrentSelectedYear);
            foreach (var entity in entities)
            {
                if (entity.Accepted)
                {
                    int index = entity.FromDate.Value.Month;
                    AcceptedSchedules[index - 1] = true;
                    StartTimeText[index - 1] = entity.StartTime.ToString();
                    EndTimeText[index - 1] = entity.EndTime.ToString();
                }
            }
        }

        protected override void PrintPDF()
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName =  GetTimestamp(DateTime.Now);
            dlg.DefaultExt = ".pdf"; // Default file extension
            dlg.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension

            //// Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            string filename = string.Empty;
            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dlg.FileName;
                PDFFileName = filename;
            }


            if (OnGetDataGridItemsHandler != null)
            {
                OnGetDataGridItemsHandler(this, new EventArgs());
            }
        }


        public CollectionViewSource GetViewSourceForMonth()
        {
            switch (ScheduleClicked)
            {
                case 1:
                    return ScheduleDetailsViewSourceJan;
                case 2:
                    return ScheduleDetailsViewSourceFeb;
                case 3:
                    return ScheduleDetailsViewSourceMar;
                case 4:
                    return ScheduleDetailsViewSourceApr;
                case 5:
                    return ScheduleDetailsViewSourceMay;
                case 6:
                    return ScheduleDetailsViewSourceJun;
                case 7:
                    return ScheduleDetailsViewSourceJul;
                case 8:
                    return ScheduleDetailsViewSourceAug;
                case 9:
                    return ScheduleDetailsViewSourceSep;
                case 10:
                    return ScheduleDetailsViewSourceOct;
                case 11:
                    return ScheduleDetailsViewSourceNov;
                case 12:
                    return ScheduleDetailsViewSourceDec;
                default:
                    break;
            }
            return new CollectionViewSource();
        }

        public string GetMonth()
        {
            string month = string.Empty;
            switch (ScheduleClicked)
            {
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "February";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "Octomber";
                    break;
                case 11:
                    month = "November";
                    break;
                case 12:
                    month = "December";
                    break;
            }
            return month;
        }

        public void CopyAllPerWeek(Scheduledetail obj)
        {
            var date = obj.Day;
            int year = date.Value.Year;
            int day = date.Value.Day;
            int month = date.Value.Month;
            int dayOfWeek = (int) date.Value.DayOfWeek;
            
            if(dayOfWeek == 0)
            {
                dayOfWeek = 7; // sunday
            }

            DateTime startDayOfWeek = StartDateToCopy(year, month, day, dayOfWeek);
            DateTime endDateOfWeek = EndDateToCopy(year, month, day, dayOfWeek);
            var filteredRecs = db.Scheduledetails.Where(e => e.Day >= startDayOfWeek && e.Day <= endDateOfWeek);
            SelectedItemsToCopyPerWeek = new ObservableCollection<Scheduledetail>(filteredRecs);

        }

        

        private DateTime StartDateToCopy(int year, int month , int day, int dayOfWeek)
        {
            int startDayOfWeek = day;
            if (dayOfWeek == 1)
            {
                return new DateTime(year, month, day);
            }
            else
            {
                switch (dayOfWeek)
                {
                    case 2:
                        {
                            startDayOfWeek -= 1;
                            break;
                        }
                    case 3:
                        {
                            startDayOfWeek -= 2;
                            break;
                        }
                    case 4:
                        {
                            startDayOfWeek -= 3;
                            break;
                        }
                    case 5:
                        {
                            startDayOfWeek -= 4;
                            break;
                        }
                    case 6:
                        {
                            startDayOfWeek -= 5;
                            break;
                        }
                    case 7:
                        {
                            startDayOfWeek -= 6;
                            break;
                        }
                }
            }
            return new DateTime(year, month, startDayOfWeek);
        }

        private DateTime EndDateToCopy(int year, int month, int day, int dayOfWeek)
        {
            int startDayOfWeek = day;
            if (dayOfWeek == 7)
            {
                return new DateTime(year, month, day);
            }
            else
            {
                switch (dayOfWeek)
                {
                    case 1:
                        {
                            startDayOfWeek += 6;
                            break;
                        }
                    case 2:
                        {
                            startDayOfWeek += 5;
                            break;
                        }
                    case 3:
                        {
                            startDayOfWeek += 4;
                            break;
                        }
                    case 4:
                        {
                            startDayOfWeek += 3;
                            break;
                        }
                    case 5:
                        {
                            startDayOfWeek += 2;
                            break;
                        }
                    case 6:
                        {
                            startDayOfWeek += 1;
                            break;
                        }
                }
            }
            return new DateTime(year, month, startDayOfWeek);
        }

        public void PasteAllPerWeek(Scheduledetail obj)
        {
            int schedule_ref = DgSelectedScheduleDetail.Schedule_Ref;
            var date = obj.Day;
            int year = date.Value.Year;
            int day = date.Value.Day;
            int month = date.Value.Month;
            int dayOfWeek = (int)date.Value.DayOfWeek;

            if (dayOfWeek == 0)
            {
                dayOfWeek = 7; // sunday
            }

            DateTime startDayOfWeek = StartDateToCopy(year, month, day, dayOfWeek);
            DateTime endDateOfWeek = EndDateToCopy(year, month, day, dayOfWeek);

            if (SelectedItemsToCopyPerWeek.Count == 0)
            {
                return;
            }

            for (DateTime startDate = startDayOfWeek; startDate <= endDateOfWeek; startDate = startDate.AddDays(1))
            {
                DayOfWeek startDayToPaste = startDate.DayOfWeek;
                var records = SelectedItemsToCopyPerWeek.Where(e => e.Day.Value.DayOfWeek == startDayToPaste);
                foreach (var item in records)
                {
                    item.Day = startDate;
                    item.Schedule_Ref = schedule_ref;
                    db.Entry(item).State = EntityState.Added;
                    if (db.ChangeTracker.HasChanges())
                    {
                        db.SaveChanges();
                    }

                }
            }
            var list = db.Scheduledetails.Where(e => e.Schedule_Ref == schedule_ref).OrderBy(e => e.Day);
            ScheduleDetails = new ObservableCollection<Scheduledetail>(list);
            var scheduleDetailsViewSource = GetViewSourceForMonth();
            scheduleDetailsViewSource.Source = ScheduleDetails;

            SelectedItemsToCopyPerWeek.Clear();

        }
        public void PasteAllPerDay()
        {
            if (DgSelectedScheduleDetail == null)
            {
                return;
            }

            DateTime? currentSelectedDate = DgSelectedScheduleDetail.Day;
            int schedule_ref = DgSelectedScheduleDetail.Schedule_Ref;
            if (currentSelectedDate == null)
            {
                return;
            }
            if (SelectedItemsToCopyPerDay.Count == 0)
            {
                return;
            }

            DayOfWeek dayOfweek = currentSelectedDate.Value.DayOfWeek;
            var lastDayOfMonth = DateTime.DaysInMonth(currentSelectedDate.Value.Year, currentSelectedDate.Value.Month);
            DateTime monthFirst = new DateTime(currentSelectedDate.Value.Year, currentSelectedDate.Value.Month, 1);
            DateTime monthLast = new DateTime(currentSelectedDate.Value.Year, currentSelectedDate.Value.Month, lastDayOfMonth);

            foreach (DateTime day in EachDay(monthFirst, monthLast))
            {
                if (day == currentSelectedDate)
                {
                    continue;
                }
                if (day.DayOfWeek == dayOfweek)
                {
                    foreach (var item in SelectedItemsToCopyPerDay)
                    {
                        item.Day = day;
                        item.Schedule_Ref = schedule_ref;
                        db.Entry(item).State = EntityState.Added;
                        if (db.ChangeTracker.HasChanges())
                        {
                            db.SaveChanges();
                        }
                    }
                }
            }

            var list = db.Scheduledetails.Where(e => e.Schedule_Ref == schedule_ref).OrderBy(e => e.Day);
            ScheduleDetails = new ObservableCollection<Scheduledetail>(list);
            var scheduleDetailsViewSource = GetViewSourceForMonth();
            scheduleDetailsViewSource.Source = ScheduleDetails;
            SelectedItemsToCopyPerDay.Clear();
        }

        public void RefreshSheduleDetails()
        {
            if (DgSelectedScheduleDetail != null)
            {
                var list = db.Scheduledetails.Where(e => e.Schedule_Ref == DgSelectedScheduleDetail.Schedule_Ref).OrderBy(e => e.Day);
                ScheduleDetails = new ObservableCollection<Scheduledetail>(list);
            }
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyMMdd") + " SOC S Planning " + value.ToString("HHmm");
        }

        private void SetDataGridItem()
        {
            if( OnSetDataGridData != null)
            {
                OnSetDataGridData(this, new EventArgs());
            }
        }

        public CollectionViewSource SetFavouriteWeeksData()
        {
            var currentYear = DgSelectedScheduleDetail.Day.Value.Year;

            var list = db.Scheduledetails.SqlQuery(@"SELECT * FROM Scheduledetails
                                                    join Schedule on Schedule.Schedule_Ref = Scheduledetails.Schedule_Ref
                                                    WHERE Schedule.StartTime = "+ StartTime.Hour  + " AND  EndTime = " + EndTime.Hour+ "and Site_Ref = " + AppSettings.Instance.SiteRef +
                                                   " AND WeekStart IS NOT NULL AND WekkEnd IS NOT NULL");
            
            var query = db.Groups.ToList();
            var listGroups = query.ToList();

            ScheduleDetailsFav = new ObservableCollection<Scheduledetail>(list);
            ScheduleGroupsFav = new ObservableCollection<Group>(listGroups);
            ScheduleDetailsViewSourceFav.GroupDescriptions.Clear();
            ScheduleDetailsViewSourceFav.Source = ScheduleDetailsFav;
            ScheduleDetailsViewSourceFav.GroupDescriptions.Add(new PropertyGroupDescription("WeekStart"));
            return ScheduleDetailsViewSourceFav;
        }

        public override void SendUpdates()
        {
            if(DgSelectedScheduleDetail == null)
            {
                return;
            }

            var jan1 = new DateTime(DgSelectedScheduleDetail.Day.Value.Year, 1, 1);
            //beware different cultures, see other answers
            var startOfFirstWeek = jan1.AddDays(1 - (int)(jan1.DayOfWeek));

            // get weeks per current year
            var weeks =
            Enumerable 
             .Range(0, 54)
             .Select(i => new { weekStart = startOfFirstWeek.AddDays(i * 7)})
             .TakeWhile(x => x.weekStart.Year <= jan1.Year)
             .Select(x => new
             {
                 x.weekStart,
                 weekFinish = x.weekStart.AddDays(6)
             })
             .SkipWhile(x => x.weekFinish < jan1.AddDays(1))
             .Select((x, i) => new
             {
                 x.weekStart,
                 x.weekFinish,
                 weekNum = i + 1

             });

            WeeksHolder.Clear();
            foreach (var item in weeks)
            {
                WeeksHolder.Add(item.weekNum, new Tuple<DateTime, DateTime>(item.weekStart, item.weekFinish));
            }

            var source = GetViewSourceForMonth();
            var collection = source.Source as ObservableCollection<Scheduledetail>;

            foreach (var item in collection)
            {
                DateTime? day = item.Day;

                var result = WeeksHolder.FirstOrDefault(e => day >= e.Value.Item1 && day <= e.Value.Item2);
                if(result.Value != null)
                {
                    DateTime weekStart = result.Value.Item1;
                    if (weekStart < jan1)
                    {
                        weekStart = jan1;
                    }
                    item.WeekStart = weekStart;
                    item.WekkEnd = result.Value.Item2;
                    item.WeekNum = result.Key;
                }
            }
            base.SendUpdates();
        }

    }
}

