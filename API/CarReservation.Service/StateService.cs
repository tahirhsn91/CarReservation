using CarReservation.Core.DTO;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class StateService : SetupService<IStateRepository, State, StateDTO, int>, IStateService
    {
        public StateService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.StateRepository)
        {
        }
    }
}
