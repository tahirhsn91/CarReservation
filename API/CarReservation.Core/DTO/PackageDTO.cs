﻿using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.DTO
{
    public class PackageDTO : SetupDTO<Package, int>
    {
        public FareDTO StartFare { get; set; }

        [IgnoreDataMember]
        public int StartFareId { get; set; }

        public List<PackageTravelUnitDTO> TravelUnit { get; set; }
        
        public List<VehicleAssemblyDTO> VehicleAssembly { get; set; }
        
        public List<VehicleBodyTypeDTO> VehicleBodyType { get; set; }
        
        public List<VehicleFeatureDTO> VehicleFeature { get; set; }
        
        public List<VehicleModelDTO> VehicleModel { get; set; }
        
        public List<VehicleTransmissionDTO> VehicleTransmission{ get; set; }

        public PackageDTO()
            : base()
        {
        }

        public PackageDTO(Package package)
            : base(package)
        {

        }

        public override void ConvertFromEntity(Package entity)
        {
            base.ConvertFromEntity(entity);
            if (entity.StartFare != null)
            {
                this.StartFareId = entity.StartFare.Id;
                this.StartFare = new FareDTO(entity.StartFare);
            }
        }

        public override Package ConvertToEntity(Package entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.StartFareId = this.StartFare.Id;

            return entity;
        }
    }
}
