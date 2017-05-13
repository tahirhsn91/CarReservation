using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;

namespace CarReservation.Core.DTO
{
    public class TimeTrackerDTO : BaseDTO<TimeTracker, int>
    {
        public TimeTrackerDTO()
        {
        }

        public TimeTrackerDTO(TimeTracker entity)
            : base(entity)
        {
        }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan TotalTime { get; set; }

        public double TotalDays { get; set; }

        public double TotalHours { get; set; }

        public double TotalMinutes { get; set; }

        public double TotalMilliseconds { get; set; }

        public override void ConvertFromEntity(TimeTracker entity)
        {
            base.ConvertFromEntity(entity);

            this.StartTime = entity.StartTime;
            this.EndTime = entity.EndTime;
            this.TotalTime = entity.TotalTime;
            this.TotalDays = entity.TotalDays;
            this.TotalHours = entity.TotalHours;
            this.TotalMinutes = entity.TotalMinutes;
            this.TotalMilliseconds = entity.TotalMilliseconds;
        }

        public override TimeTracker ConvertToEntity(TimeTracker entity)
        {
            entity = base.ConvertToEntity(entity);

            entity.StartTime = this.StartTime;
            entity.EndTime = this.EndTime;

            return entity;
        }
    }
}
