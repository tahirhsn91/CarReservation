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
    public class PackageTravelUnitDTO : BaseDTO<PackageTravelUnit, int>
    {
        [Required]
        public double Rate { get; set; }

        [Required]
        public CurrencyDTO Currency { get; set; }

        [Required]
        public PackageDTO Package { get; set; }

        [Required]
        public TravelUnitDTO TravelUnit { get; set; }

        [IgnoreDataMember]
        public int CurrencyId { get; set; }

        [IgnoreDataMember]
        public int PackageId { get; set; }

        [IgnoreDataMember]
        public int TravelUnitId { get; set; }

        public PackageTravelUnitDTO()
            : base()
        {
        }

        public PackageTravelUnitDTO(PackageTravelUnit packageTravelUnit)
            : base(packageTravelUnit)
        {
        }

        public override void ConvertFromEntity(PackageTravelUnit entity)
        {
            base.ConvertFromEntity(entity);

            this.Rate = entity.Rate;
            if (entity.Currency != null)
            {
                this.CurrencyId = entity.Currency.Id;
                this.Currency = new CurrencyDTO(entity.Currency);
            }

            if (entity.Package != null)
            {
                this.PackageId = entity.Package.Id;
                this.Package = new PackageDTO(entity.Package);
            }

            if (entity.TravelUnit != null)
            {
                this.TravelUnitId = entity.TravelUnit.Id;
                this.TravelUnit = new TravelUnitDTO(entity.TravelUnit);
            }
        }

        public override PackageTravelUnit ConvertToEntity(PackageTravelUnit entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.Rate = this.Rate;
            entity.CurrencyId = this.Currency.Id;
            entity.TravelUnitId= this.TravelUnit.Id;
            if (this.Package != null)
            {
                entity.PackageId = this.Package.Id;
            }

            return entity;
        }
    }
}
