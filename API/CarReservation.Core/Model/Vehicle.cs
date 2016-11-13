using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<VehicleFeature> Features { get; set; }

        public Package Package { get; set; }
    }
}
