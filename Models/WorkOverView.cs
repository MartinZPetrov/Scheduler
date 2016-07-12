using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Models
{
    public class WorkOverView
    {
        public DateTime WorkDay { get; set; }
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }
        public decimal HoursToWork { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal FirstBreak { get; set; }
        public decimal SecondBreak { get; set; }
        public decimal ThirdBreak { get; set; }
        public decimal OverLappedHours { get; set; }
        public decimal UnderLappedHours { get; set; }
    }
}
