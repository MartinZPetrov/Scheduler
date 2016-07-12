using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Scheduler.Support;
namespace Scheduler.EntityWrappers
{
    public class EntityWrapper : ViewModelBase
    {
        private INotifyPropertyChanged _entity;
        public INotifyPropertyChanged Entity
        {
            get
            {
                return _entity;
            }
            set
            {
                _entity = value;
                _entity.PropertyChanged += EntityPropertyChanged;
                RaisePropertyChanged(() => _entity);
            }
        }
        private ObservableDictionary<string, CollectionViewSource> _parentEntities;

        private IDictionary<string, string> _messageDictionary;
        public IDictionary<string, string> MessageDictionary
        {
            get
            {
                return _messageDictionary;
            }
            set
            {
                _messageDictionary = value;
                RaisePropertyChanged(() => _messageDictionary);
            }
        }

        private ObservableDictionary<string, CollectionViewSource> _childEntities;
        public ObservableDictionary<string, CollectionViewSource> ChildEntities
        {
            get
            {
                return _childEntities;
            }
            set
            {
                _childEntities = value;
                RaisePropertyChanged(() => _childEntities);
            }
        }

        private CollectionViewSource _childCollection;
        public CollectionViewSource ChildCollection
        {
            get
            {
                return _childCollection;
            }
            set
            {
                _childCollection = value;
                RaisePropertyChanged(() => _childCollection);
            }
        }

        public ObservableDictionary<string, CollectionViewSource> ParentEntities
        {
            get
            {
                return _parentEntities;
            }
            set
            {
                _parentEntities = value;
                RaisePropertyChanged(() => _parentEntities);
            }
        }


        private EntityStates _entityState;
        public EntityStates State
        {
            get
            {
                return _entityState;
            }
            set
            {
                _entityState = value;
                RaisePropertyChanged(() =>_entityState);
            }
        }

        public EntityWrapper()
        {
            ChildEntities = new ObservableDictionary<string, CollectionViewSource>();
            ChildCollection = new CollectionViewSource();
        }

        protected void OnUndelyningEntityPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.UnderlyingEntityPropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler UnderlyingEntityPropertyChanged;

        protected void EntityPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnUndelyningEntityPropertyChanged(e.PropertyName);
        }

        public bool IsNew { get; set; }
    }
}
