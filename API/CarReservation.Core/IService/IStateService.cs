using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;

namespace CarReservation.Core.IService
{
    public interface IStateService : ISetupService<IBaseRepository<State, int>, State, StateDTO, int>
    {
    }
}
