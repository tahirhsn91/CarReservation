using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class DriverLocationDTO : BaseDTO<DriverLocation, int>
    {
        public DriverLocationDTO()
        {
        }

        public DriverLocationDTO(DriverLocation entity)
            : base(entity)
        {
        }

        public int DriverId { get; set; }

        public int LocationId { get; set; }

        public int? StatusId { get; set; }

        public DriverDTO Driver { get; set; }

        public LocationLagLonDTO Location { get; set; }

        public DriverStatusDTO Status { get; set; }

        public override void ConvertFromEntity(DriverLocation entity)
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

        public override DriverLocation ConvertToEntity(DriverLocation entity)
        {
            entity = base.ConvertToEntity(entity);

            entity.DriverId = this.DriverId;
            entity.LocationId = this.LocationId;
            entity.StatusId = this.StatusId;

            if (this.Driver != null)
            {
                entity.DriverId = this.Driver.Id;
            }

            if (this.Location != null)
            {
                entity.LocationId = this.Location.Id;
            }

            if (this.Status != null)
            {
                entity.StatusId = this.Status.Id;
            }

            return entity;
        }
    }
}
