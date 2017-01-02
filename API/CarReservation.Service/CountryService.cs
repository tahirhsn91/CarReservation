using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class CountryService : SetupService<IBaseRepository<Country, int>, Country, CountryDTO, int>, ICountryService
    {
        public CountryService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.CountryRepository)
        {
        }
    }
}
