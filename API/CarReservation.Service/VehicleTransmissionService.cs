using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class VehicleTransmissionService : SetupService<IBaseRepository<VehicleTransmission, int>, VehicleTransmission, VehicleTransmissionDTO, int>, IVehicleTransmissionService
    {
        public VehicleTransmissionService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.VehicleTransmissionRepository)
        {
        }
    }
}
