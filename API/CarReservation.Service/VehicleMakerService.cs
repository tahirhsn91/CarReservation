using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class VehicleMakerService : SetupService<IBaseRepository<VehicleMaker, int>, VehicleMaker, VehicleMakerDTO, int>, IVehicleMakerService
    {
        public VehicleMakerService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.VehicleMakerRepository)
        {
        }
    }
}
