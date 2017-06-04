using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface IVehicleService : IBaseService<VehicleDTO, int>
    {
        Task<IList<VehicleDTO>> GetVehicleWithPackageInfo();

        Task<VehicleDTO> GetVehicleWithPackageInfo(int id);

        Task<VehicleDTO> AssignVehicle(VehicleDTO vehicle);
    }
}
