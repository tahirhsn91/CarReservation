using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class VehicleFeatureService : SetupService<IVehicleFeatureRepository, VehicleFeature, VehicleFeatureDTO>, IVehicleFeatureService
    {
        public VehicleFeatureService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.VehicleFeatureRepository)
        {
        }
    }
}
