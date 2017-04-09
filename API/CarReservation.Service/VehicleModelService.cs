using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class VehicleModelService : SetupService<IVehicleModelRepository, VehicleModel, VehicleModelDTO>, IVehicleModelService
    {
        public VehicleModelService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.VehicleModelRepository)
        {
        }
    }
}
