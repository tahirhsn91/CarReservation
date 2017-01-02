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
    public class VehicleModelDTO : SetupDTO<VehicleModel, int>
    {
        [IgnoreDataMember]
        public int VehicleMakerId { get; set; }

        [Required]
        public VehicleMakerDTO VehicleMaker { get; set; }

        public VehicleModelDTO()
            : base()
        {
        }

        public VehicleModelDTO(VehicleModel vehicleModel)
            : base(vehicleModel)
        {
        }

        public override VehicleModel ConvertToEntity(VehicleModel entity)
        {
            entity = base.ConvertToEntity(entity);
            if (this.VehicleMaker != null)
            {
                entity.VehicleMakerId = this.VehicleMaker.Id;
            }

            return entity;
        }

        public override void ConvertFromEntity(VehicleModel entity)
        {
            base.ConvertFromEntity(entity);

            if (entity.Maker != null)
            {
                this.VehicleMakerId = entity.Maker.Id;
                this.VehicleMaker = new VehicleMakerDTO(entity.Maker);
            }
        }
    }
}
