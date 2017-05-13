using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class DistanceDTO : BaseDTO<Distance, int>
    {
        public double TotalDistance { get; set; }

        public int UnitId { get; set; }

        public DistanceUnitDTO Unit { get; set; }

        public DistanceDTO()
        {
        }

        public DistanceDTO(Distance entity)
            : base(entity)
        {
        }

        public override void ConvertFromEntity(Distance entity)
        {
            base.ConvertFromEntity(entity);

            this.TotalDistance = entity.TotalDistance;
            this.UnitId = entity.UnitId;

            if (entity.Unit != null)
            {
                this.Unit = new DistanceUnitDTO(entity.Unit);
            }
        }

        public override Distance ConvertToEntity(Distance entity)
        {
            entity = base.ConvertToEntity(entity);

            entity.TotalDistance = this.TotalDistance;
            entity.UnitId = this.UnitId;

            return entity;
        }
    }
}
