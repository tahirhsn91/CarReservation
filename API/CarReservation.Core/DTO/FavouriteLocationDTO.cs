using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class FavouriteLocationDTO : BaseDTO<FavouriteLocation, int>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public LocationLagLonDTO Location { get; set; }

        [IgnoreDataMember]
        public UserDTO User { get; set; }

        [IgnoreDataMember]
        public string UserId { get; set; }

        [IgnoreDataMember]
        public int LocationId { get; set; }

        public FavouriteLocationDTO()
            : base()
        {
        }

        public FavouriteLocationDTO(FavouriteLocation driverStatus)
            : base(driverStatus)
        {
        }

        public override FavouriteLocation ConvertToEntity(FavouriteLocation entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Name = this.Name;
            entity.Description = this.Description;
            entity.LocationId = this.Location.Id;
            entity.UserId = this.User.UserId;

            return entity;
        }

        public override void ConvertFromEntity(FavouriteLocation entity)
        {
            base.ConvertFromEntity(entity);
            this.Name = entity.Name;
            this.Description = entity.Description;

            this.LocationId = entity.Location == null ? 0 : entity.Location.Id;
            if (entity.Location != null)
            {
                this.Location = new LocationLagLonDTO(entity.Location);
            }

            this.UserId = entity.User == null ? string.Empty : entity.User.Id;
            if (entity.User != null)
            {
                this.User = new UserDTO(entity.User);
            }
        }
    }
}
