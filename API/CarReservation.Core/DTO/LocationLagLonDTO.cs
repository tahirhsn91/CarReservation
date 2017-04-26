using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class    LocationLagLonDTO : BaseDTO<LocationLagLon, int>
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        public LocationLagLonDTO()
            : base()
        {
        }

        public LocationLagLonDTO(LocationLagLon location)
            : base(location)
        {
        }

        public override LocationLagLon ConvertToEntity(LocationLagLon entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Latitude = this.Latitude;
            entity.Longitude = this.Longitude;

            return entity;
        }

        public override void ConvertFromEntity(LocationLagLon entity)
        {
            base.ConvertFromEntity(entity);
            this.Latitude = entity.Latitude;
            this.Longitude = entity.Longitude;
        }
    }
}
