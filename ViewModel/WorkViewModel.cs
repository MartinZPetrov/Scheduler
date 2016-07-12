using Scheduler.Base;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using Scheduler.Support;

namespace Scheduler.ViewModel
{
    public class WorkViewModel : CrudVMBase<Work>
    {
        public bool IsPicStartTaken { get; set; }
        public bool IsPicEndTaken { get; set; }
        private byte[] _pictureStartTaken;
        private byte[] _pictureEndTaken;
        private ObservableCollection<WorkImage> _workStartImages;
        private ObservableCollection<WorkImage> _workEndImages;
        private ObservableCollection<Work> _workStart;
        private ObservableCollection<Work> _workEnd;
        private DateTime _workDay;

        public byte[] PictureStartTaken
        {
            get
            {
                return _pictureStartTaken;
            }
            set
            {
                if (_pictureStartTaken == value) return;
                _pictureStartTaken = value;
                RaisePropertyChanged(() => PictureStartTaken);
            }
        }

        public byte[] PictureEndTaken
        {
            get
            {
                return _pictureEndTaken;
            }
            set
            {
                if (_pictureEndTaken == value) return;
                _pictureEndTaken = value;
                RaisePropertyChanged(() => PictureEndTaken);
            }
        }

        public ObservableCollection<WorkImage> WorkStartImages
        {
            get
            {
                return _workStartImages;
            }
            set
            {
                if (_workStartImages == value) return;
                _workStartImages = value;
                RaisePropertyChanged(() => WorkStartImages);
            }
        }

        public ObservableCollection<WorkImage> WorkEndImages
        {
            get
            {
                return _workEndImages;
            }
            set
            {
                if (_workEndImages == value) return;
                _workEndImages = value;
                RaisePropertyChanged(() => WorkEndImages);
            }
        }

        public ObservableCollection<Work> WorkStart
        {
            get
            {
                return _workStart;
            }
            set
            {
                if (_workStart == value) return;
                _workStart = value;
                RaisePropertyChanged(() => WorkStart);
            }
        }

        public ObservableCollection<Work> WorkEnd
        {
            get
            {
                return _workEnd;
            }
            set
            {
                if (_workEnd == value) return;
                _workEnd = value;
                RaisePropertyChanged(() => WorkEnd);
            }
        }



        public DateTime WorkDay
        {
            get
            {
                return _workDay;
            }
            set
            {
                if (_workDay == value) return;
                _workDay = value;
                RaisePropertyChanged(() => WorkDay);
                LoadWork(WorkDay);
            }
        }

        public WorkViewModel()
        {
            WorkStart = new ObservableCollection<Work>();
            WorkEnd = new ObservableCollection<Work>();
            WorkStartImages = new ObservableCollection<WorkImage>();
            WorkEndImages = new ObservableCollection<WorkImage>();
            WorkDay = DateTime.Now;
            this.MainEntityLoad += WorkViewModel_MainEntityLoad;
        }

        void WorkViewModel_MainEntityLoad(object sender, EventArgs e)
        {
            LoadWork(DateTime.Now);
        }

        private void LoadWork(DateTime time)
        {
            var workRecordsPerEmployee = db.Works.Where(e => e.WorkDay == time.Date && e.Site_Ref == AppSettings.Instance.SiteRef && e.User_Ref == AppSettings.Instance.UserRef);
            WorkStart = new ObservableCollection<Work>(workRecordsPerEmployee);
            WorkEnd = new ObservableCollection<Work>(workRecordsPerEmployee);

            if (WorkStart.Count > 0)
            {
                int workRef = WorkStart[0].Work_Ref;
                var workStartImages = db.WorkImages.Where(e => e.IsWorkStart == true && e.Work_Ref == workRef);
                var workEndImages = db.WorkImages.Where(e => e.IsWorkStart == false && e.Work_Ref == workRef);

                WorkStartImages = new ObservableCollection<WorkImage>(workStartImages);
                WorkEndImages = new ObservableCollection<WorkImage>(workEndImages);
            }
            else
            {
                WorkStartImages.Clear();
                WorkEndImages.Clear();
            }
        }


        public override void MoveNext()
        {
         
        }

        public override void MovePrev()
        {
            
        }

        public override void MoveToTop()
        {
            
        }

        public override void MoveToBottom()
        {
            
        }

        public override void SendUpdates()
        {
            DateTime time = DateTime.Now;

            if(IsPicStartTaken)
            {
                db.Works.Add(new Work() { Site_Ref = 4, User_Ref = 9, WorkDay = time, WorkStart = time, WorkEnd = null });
            }
            else 
            {
                Work workEntry = db.Works.FirstOrDefault(e => e.Site_Ref == AppSettings.Instance.SiteRef && e.User_Ref == AppSettings.Instance.UserRef && WorkDay == time.Date 
                                                    && e.WorkEnd == null);
                if (workEntry != null)
                {
                    db.Entry(workEntry).Entity.WorkEnd = time;
                    db.Entry(workEntry).State = EntityState.Modified;
                }
            }
            base.SendUpdates();

            var work = db.Works.Where(e => e.Site_Ref == AppSettings.Instance.SiteRef && e.User_Ref == AppSettings.Instance.UserRef && e.WorkDay == time.Date).FirstOrDefault();
            if(work != null)
            {
                db.WorkImages.Add(new WorkImage { Work_Ref = work.Work_Ref, Image = IsPicStartTaken ? PictureStartTaken : PictureEndTaken, IsWorkStart = IsPicStartTaken });
                if(db.ChangeTracker.HasChanges())
                {
                    db.SaveChanges();
                }
            }

            LoadWork(time);
        }
    }
}

