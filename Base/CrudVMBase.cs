using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Scheduler.Messages;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;
using Scheduler.EntityWrappers;
using System.Reflection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq.Expressions;
using Scheduler.DataAccessLayer;
using System.Data.Entity.Infrastructure;
using System.Collections.Specialized;

namespace Scheduler.Base
{

    public class CrudVMBase<T> : ViewModelBase, IGenericDataRepository<T> where T : class, new()
    {

        private CollectionViewSource _workAliasCollection;
        private Visibility throbberVisible = Visibility.Visible;
        private ObservableCollection<T> _internalObservable;
        private string errorMessage;
        protected bool isCurrentView = false;
        protected Dictionary<string, Type> ParentEntitiesToBind { get; set; }
        protected Dictionary<string, Type> ParentEntitiesToLoad { get; set; }
        protected Dictionary<string, Type> ChildEntitiesToLoad { get; set; }

        public SchedulerContext db;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                RaisePropertyChanged(() => errorMessage);
            }
        }

        public Visibility ThrobberVisible
        {
            get { return throbberVisible; }
            set
            {
                throbberVisible = value;
                RaisePropertyChanged(() => throbberVisible);
            }
        }

        public CollectionViewSource WorkAliasCollection
        {
            get
            {
                return _workAliasCollection;
            }
            private set
            {
                if (_workAliasCollection != value)
                {
                    _workAliasCollection = value;
                    RaisePropertyChanged(() => _workAliasCollection);
                }
            }
        }


        public T CurrentEntity
        {
            get
            {
                T entity = null;
                if (WorkAliasCollection.View != null &&
                    WorkAliasCollection.View.CurrentItem != null)
                {
                    entity = (T)WorkAliasCollection.View.CurrentItem;
                }
                return entity;
            }
            set
            {
                WorkAliasCollection.View.MoveCurrentTo(value);
                RaisePropertyChanged(() => CurrentEntity);
            }
        }

        public ObservableCollection<T> InternalObservable
        {
            get
            {
                return _internalObservable;
            }
            set
            {
                _internalObservable = value;
                RaisePropertyChanged(() => _internalObservable);
            }
        }

        public event EventHandler MainEntityLoad;

        public CrudVMBase()
        {
            db = new SchedulerContext();
            this.WorkAliasCollection = new CollectionViewSource();
            this.InternalObservable = new ObservableCollection<T>();
            Messenger.Default.Register<CommandMessage>(this, (action) => HandleCommand(action));
            Messenger.Default.Register<NavigateMessage>(this, (action) => CurrentUserControl(action));
            Reload();
        }

        public virtual void Reload(bool presistCurrent = false)
        {
            LoadMainEntity(presistCurrent);
        }


        protected virtual void LoadMainEntity(bool presistCurrent = false)
        {
            var entities = GetAll();
            int currentPossition = -1;
            if (presistCurrent)
            {
                if (WorkAliasCollection.View != null)
                {
                    currentPossition = WorkAliasCollection.View.CurrentPosition;
                }
            }
            
            this.InternalObservable.Clear();
            foreach (var entity in entities)
            {
                this.InternalObservable.Add(entity);
            }
            
           
            WorkAliasCollection.Source = this.InternalObservable;
            this.InternalObservable.CollectionChanged += InternalObservable_CollectionChanged;
            WorkAliasCollection.View.CurrentChanged += View_CurrentChanged;

            
            if (!WorkAliasCollection.View.MoveCurrentToPosition(currentPossition))
            {
                WorkAliasCollection.View.MoveCurrentToFirst();
            }

        }

        void InternalObservable_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }

        private void View_CurrentChanged(object sender, object e)
        {
            if (WorkAliasCollection.View.CurrentItem != null)
            {
                RaisePropertyChanged("CurrentEntity");
            }
        }


        public virtual void MoveNext()
        {
            if (!WorkAliasCollection.View.MoveCurrentToNext())
            {
                WorkAliasCollection.View.MoveCurrentToLast();
            }
        }

        public virtual void MovePrev()
        {
            if (!WorkAliasCollection.View.MoveCurrentToPrevious())
            {
                WorkAliasCollection.View.MoveCurrentToFirst();
            }
        }

        public virtual void MoveToTop()
        {
            WorkAliasCollection.View.MoveCurrentToFirst();
        }

        public virtual void MoveToBottom()
        {
            WorkAliasCollection.View.MoveCurrentToLast();
        }


        private void Edit()
        {
            var msg = new FormModeMessage() { Message = "Edit" };
            Messenger.Default.Send<FormModeMessage>(msg);
        }

        protected virtual void UndoChanges()
        {
            var msg = new FormModeMessage() { Message = "" };
            Messenger.Default.Send<FormModeMessage>(msg);
            LoadMainEntity(true);
        }


        protected virtual void RefreshData()
        {
            Reload();
        }


        private void CurrentUserControl(NavigateMessage nm)
        {
            if (this.GetType() == nm.ViewModelType)
            {
                isCurrentView = true;
            }
            else
            {
                isCurrentView = false;
            }

            OnMainEntityLoaded();

        }

        private void OnMainEntityLoaded()
        {
            if (MainEntityLoad != null)
            {
                MainEntityLoad(this, new EventArgs());
            }
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;

            IQueryable<T> dbQuery = db.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .ToList<T>();

            return list;
        }

        public virtual IList<T> GetList(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;

            IQueryable<T> dbQuery = db.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            list = dbQuery
                .Where(where)
                .ToList<T>();

            return list;
        }

        public virtual T GetSingle(Func<T, bool> where,
             params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            IQueryable<T> dbQuery = db.Set<T>();

            //Apply eager loading
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            item = dbQuery
                .FirstOrDefault(where); //Apply where clause

            return item;
        }

        public virtual void Add()
        {
            var msg = new FormModeMessage() { Message = "Add" };
            Messenger.Default.Send<FormModeMessage>(msg);
            var entity = new T();
            DbSet<T> dbSet = db.Set<T>();
            dbSet.Add(entity);
            db.Entry(entity).State = EntityState.Added;

            this.InternalObservable.Add(entity);
            WorkAliasCollection.View.MoveCurrentTo(entity);

        }

        public virtual void SendUpdates()
        {
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

        public virtual void Remove()
        {
            var entity = CurrentEntity;
            MessageBoxResult result = MessageBox.Show("Do you want to delete this record?", "Attention", MessageBoxButton.YesNo,
                                                   MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.InternalObservable.Remove(entity);
                db.Entry(entity).State = EntityState.Deleted;
                db.Set<T>().Remove(entity);
                SendUpdates();
            }

        }
        protected void HandleCommand(CommandMessage action)
        {
            if (isCurrentView)
            {
                switch (action.Command)
                {
                    case CommandType.Insert:
                        Add();
                        break;
                    case CommandType.Edit:
                        Edit();
                        break;
                    case CommandType.Delete:
                        Remove();
                        break;
                    case CommandType.Commit:
                        SendUpdates(); ;
                        break;
                    case CommandType.Refresh:
                        RefreshData();
                        break;
                    case CommandType.Undo:
                        UndoChanges();
                        break;
                    case CommandType.Top:
                        MoveToTop();
                        break;
                    case CommandType.Previous:
                        MovePrev();
                        break;
                    case CommandType.Next:
                        MoveNext();
                        break;
                    case CommandType.Bottom:
                        MoveToBottom();
                        break;
                    case CommandType.InsertChild:
                        InsertChild();
                        break;
                    case CommandType.DeleteChild:
                        DeleteChild();
                        break;
                    case CommandType.PrintPDF:
                        PrintPDF();
                        break;
                    default:
                        break;
                }
            }
        }

        protected virtual void  PrintPDF()
        {
         
        }

        protected virtual void DeleteChild()
        {
            
        }

        protected virtual void InsertChild()
        {
            
        }
    }
}
