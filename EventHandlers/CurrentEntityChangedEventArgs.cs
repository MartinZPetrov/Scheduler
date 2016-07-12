using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class CurrentEntityChangedEventArgs : EventArgs
    {
        public CurrentEntityChangedEventArgs()
            : base()
        { }

        public CurrentEntityChangedEventArgs(object newEntity)
            : base()
        {
            NewEntity = newEntity;
        }

        public object NewEntity { get; set; }
    }
}
