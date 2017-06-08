using CarReservation.Core.Model.Base;

namespace CarReservation.Core.Model
{
    public class LocationLagLon : EntityBase
    {
        public string Address { get; set; }
        
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
