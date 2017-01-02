using CarReservation.Core.DTO.Base;
using CarReservation.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CarReservation.Core.DTO
{
    public class VehicleDTO : BaseDTO<Vehicle, int>
    {
        public VehicleDTO()
            : base()
        {
        }

        public VehicleDTO(Vehicle vehicle)
            : base(vehicle)
        {

        }

        [Required]
        public string RegistrationNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public int PassengerCapacity { get; set; }

        [Required]
        public CountryDTO Country { get; set; }

        [Required]
        public StateDTO State { get; set; }

        [Required]
        public CityDTO City { get; set; }

        [Required]
        public ColorDTO Color { get; set; }

        [Required]
        public VehicleBodyTypeDTO VehicleBodyType { get; set; }

        [Required]
        public VehicleAssemblyDTO VehicleAssembly { get; set; }

        [Required]
        public VehicleTransmissionDTO VehicleTransmission { get; set; }

        [Required]
        public VehicleModelDTO VehicleModel { get; set; }

        public PackageDTO Package { get; set; }

        [IgnoreDataMember]
        public int CountryId { get; set; }

        [IgnoreDataMember]
        public int StateId { get; set; }

        [IgnoreDataMember]
        public int CityId { get; set; }

        [IgnoreDataMember]
        public int ColorId { get; set; }

        [IgnoreDataMember]
        public int BodyTypeId { get; set; }

        [IgnoreDataMember]
        public int AssemblyId { get; set; }

        [IgnoreDataMember]
        public int TransmissionId { get; set; }

        [IgnoreDataMember]
        public int ModelId { get; set; }

        [IgnoreDataMember]
        public int PackageID { get; set; }

        public List<VehicleFeatureDTO> VehicleFeature { get; set; }

        public override void ConvertFromEntity(Vehicle entity)
        {
            base.ConvertFromEntity(entity);
            this.RegistrationNumber = entity.RegistrationNumber;
            this.RegistrationDate = entity.RegistrationDate;
            this.PassengerCapacity = entity.PassengerCapacity;

            if (entity.Country != null)
            {
                this.CountryId = entity.Country.Id;
                this.Country = new CountryDTO(entity.Country);
            }
            if (entity.State != null)
            {
                this.StateId = entity.State.Id;
                this.State = new StateDTO(entity.State);
            }
            if (entity.City != null)
            {
                this.CityId = entity.City.Id;
                this.City = new CityDTO(entity.City);
            }

            if (entity.Color != null)
            {
                this.ColorId = entity.Color.Id;
                this.Color = new ColorDTO(entity.Color);
            }
            if (entity.BodyType != null)
            {
                this.BodyTypeId = entity.BodyType.Id;
                this.VehicleBodyType = new VehicleBodyTypeDTO(entity.BodyType);
            }
            if (entity.Assembly != null)
            {
                this.AssemblyId = entity.Assembly.Id;
                this.VehicleAssembly = new VehicleAssemblyDTO(entity.Assembly);
            }
            if (entity.Transmission != null)
            {
                this.TransmissionId = entity.Transmission.Id;
                this.VehicleTransmission = new VehicleTransmissionDTO(entity.Transmission);
            }

            if (entity.Model != null)
            {
                this.ModelId = entity.Model.Id;
                this.VehicleModel = new VehicleModelDTO(entity.Model);
            }
            if (entity.Package != null)
            {
                this.PackageID = entity.Package.Id;
                this.Package = new PackageDTO(entity.Package);
            }
        }

        public override Vehicle ConvertToEntity(Vehicle entity)
        {
            entity = base.ConvertToEntity(entity);
            entity.RegistrationNumber = this.RegistrationNumber;
            entity.RegistrationDate = this.RegistrationDate;
            entity.PassengerCapacity = this.PassengerCapacity;

            entity.CountryId = this.Country.Id;
            entity.StateId = this.State.Id;
            entity.CityId = this.City.Id;

            entity.ColorId = this.Color.Id;
            entity.BodyTypeId = this.VehicleBodyType.Id;
            entity.AssemblyId = this.VehicleAssembly.Id;
            entity.TransmissionId = this.VehicleTransmission.Id;

            entity.ModelId = this.VehicleModel.Id;

            if (this.Package != null)
            {
                entity.PackageID = this.Package.Id;
            }
            else
            {
                entity.PackageID = null;
            }

            return entity;
        }
    }
}
