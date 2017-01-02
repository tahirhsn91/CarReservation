using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;

namespace CarReservation.Core.IService
{
    public interface IVehicleService : IBaseService<VehicleDTO, int>
    {
    }
}
