using CarReservation.Core.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarReservation.Core.Model
{
    public class Vehicle : EntityBase
    {
        public string RegistrationNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int PassengerCapacity { get; set; }

        public Country Country { get; set; }

        public State State { get; set; }

        public City City { get; set; }

        public Color Color { get; set; }

        public VehicleBodyType BodyType { get; set; }

        public VehicleAssembly Assembly { get; set; }

        public VehicleTransmission Transmission { get; set; }

        public VehicleModel Model { get; set; }

        public Package Package { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        [ForeignKey("Color")]
        public int ColorId { get; set; }

        [ForeignKey("BodyType")]
        public int BodyTypeId { get; set; }

        [ForeignKey("Assembly")]
        public int AssemblyId { get; set; }

        [ForeignKey("Transmission")]
        public int TransmissionId { get; set; }

        [ForeignKey("Model")]
        public int ModelId { get; set; }

        [ForeignKey("Package")]
        public int? PackageID { get; set; }
    }
}
