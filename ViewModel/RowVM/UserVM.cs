using Scheduler.Base;
using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.ViewModel
{
    public class UserVM : VMBase
    {

        public User TheUser { get; set; }
        public UserVM()
        {
            TheUser = new User();
        }
    }
}
