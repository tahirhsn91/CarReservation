using CarReservation.Core.Model.Base;

namespace CarReservation.Core.DTO
{
    public class SupervisorDashboardDTO : IBase
    {
        public int Package { get; set; }
        public int Vehicle { get; set; }
        public int Driver { get; set; }
    }
}
