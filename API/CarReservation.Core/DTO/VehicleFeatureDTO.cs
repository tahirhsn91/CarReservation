using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace CarReservation.Core.DTO
{
    public class VehicleFeatureDTO : SetupDTO<VehicleFeature, int>
    {
        [MaxLength(250)]
        public string Description { get; set; }

        public VehicleFeatureDTO()
            : base()
        {
        }

        public VehicleFeatureDTO(VehicleFeature vehicleFeature)
            : base(vehicleFeature)
        {
        }

        public override void ConvertFromEntity(VehicleFeature entity)
        {
            base.ConvertFromEntity(entity);
            this.Description = entity.Description;
        }

        public override VehicleFeature ConvertToEntity(VehicleFeature entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Description = this.Description;

            return entity;
        }
    }
}
