using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class CityService : SetupService<ICityRepository, City, CityDTO, int>, ICityService
    {
        public CityService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.CityRepository)
        {
        }
    }
}
