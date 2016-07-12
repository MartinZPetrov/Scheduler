using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.DataAccessLayer
{
    public interface IEntity
    {
        EntityStates EntityState { get; set; }
    }
}
