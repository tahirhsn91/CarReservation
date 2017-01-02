using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class VehicleBodyTypeService : SetupService<IBaseRepository<VehicleBodyType, int>, VehicleBodyType, VehicleBodyTypeDTO, int>, IVehicleBodyTypeService
    {
        public VehicleBodyTypeService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.VehicleBodyTypeRepository)
        {
        }
    }
}
