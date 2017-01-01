using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IVehicleService : IBaseService<VehicleDTO, int>
    {
    }
}
