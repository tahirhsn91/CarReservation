using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;

namespace CarReservation.Core.IService
{
    public interface IVehicleBodyTypeService : ISetupService<IBaseRepository<VehicleBodyType>, VehicleBodyType, VehicleBodyTypeDTO, int>
    {
    }
}
