using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class CurrencyService : LoggableService<
        ICurrencyRepository,
        ICurrencyLogRepository,
        Currency,
        CurrencyLog,
        CurrencyDTO,
        CurrencyLogDTO,
        int>,
        ICurrencyService
    {
        public CurrencyService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.CurrencyRepository, unitOfWork.CurrencyLogRepository)
        {
        }
    }
}
