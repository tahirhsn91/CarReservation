using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.Model
{
    public class TimeTracker : EntityBase
    {
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan TotalTime
        {
            get
            {
                return EndTime.Subtract(StartTime);
            }
        }

        public double TotalDays
        {
            get
            {
                return TotalTime.TotalDays;
            }
        }

        public double TotalHours
        {
            get
            {
                return TotalTime.TotalHours;
            }
        }

        public double TotalMinutes
        {
            get
            {
                return TotalTime.TotalSeconds;
            }
        }

        public double TotalMilliseconds
        {
            get
            {
                return TotalTime.TotalMilliseconds;
            }
        }
    }
}
