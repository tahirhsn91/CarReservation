using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IDriverService : IBaseService<DriverDTO, int>
    {
        Task<DriverDTO> GetCurrentDriver();
    }
}
