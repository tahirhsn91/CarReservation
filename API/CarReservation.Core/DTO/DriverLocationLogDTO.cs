using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class DriverLocationLogDTO : BaseDTO<DriverLocationLog, int>, ILoggableDTO<DriverLocation>
    {
        public DriverLocationLogDTO()
        {
        }

        public DriverLocationLogDTO(DriverLocationLog entity)
            : base(entity)
        {
        }

        public int DriverId { get; set; }

        public int LocationId { get; set; }

        public int StatusId { get; set; }

        public DriverDTO Driver { get; set; }

        public LocationLagLonDTO Location { get; set; }

        public DriverStatusDTO Status { get; set; }

        public override void ConvertFromEntity(DriverLocationLog entity)
        {
            base.ConvertFromEntity(entity);

            this.DriverId = entity.DriverId;
            this.LocationId = entity.LocationId;
            this.StatusId = entity.StatusId;

            if (entity.Driver != null)
            {
                this.Driver = new DriverDTO(entity.Driver);
            }

            if (entity.Location != null)
            {
                this.Location = new LocationLagLonDTO(entity.Location);
            }

            if (entity.Status != null)
            {
                this.Status = new DriverStatusDTO(entity.Status);
            }
        }

        public override DriverLocationLog ConvertToEntity(DriverLocationLog entity)
        {
            entity = base.ConvertToEntity(entity);

            entity.DriverId = this.DriverId;
            entity.LocationId = this.LocationId;
            entity.StatusId = this.StatusId;

            if (this.Driver != null)
            {
                this.DriverId = entity.Driver.Id;
            }

            if (this.Location != null)
            {
                this.LocationId = entity.Location.Id;
            }

            if (this.Status != null)
            {
                this.StatusId = entity.Status.Id;
            }

            return entity;
        }

        public void ConvertFromLogEntity(DriverLocation entity)
        {
            this.DriverId = entity.DriverId;
            this.LocationId = entity.LocationId;
            this.StatusId = entity.StatusId;

            if (entity.Driver != null)
            {
                this.Driver = new DriverDTO(entity.Driver);
            }

            if (entity.Location != null)
            {
                this.Location = new LocationLagLonDTO(entity.Location);
            }

            if (entity.Status != null)
            {
                this.Status = new DriverStatusDTO(entity.Status);
            }
        }
    }
}
