using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CarReservation.Core.DTO
{
    public class CityDTO : SetupDTO<City, int>
    {
        [IgnoreDataMember]
        public int StateId { get; set; }

        [Required]
        public StateDTO State { get; set; }

        public CityDTO()
            : base()
        {
        }

        public CityDTO(City city)
            : base(city)
        {
        }

        public override void ConvertFromEntity(City entity)
        {
            base.ConvertFromEntity(entity);

            this.StateId = entity.State == null ? 0 : entity.State.Id;
            if (entity.State != null)
            {
                this.State = new StateDTO(entity.State);
            }
        }

        public override City ConvertToEntity(City entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.StateId = this.State.Id;

            return entity;
        }
    }
}
