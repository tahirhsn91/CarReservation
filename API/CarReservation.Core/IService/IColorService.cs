using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Core.Model;

namespace CarReservation.Core.IService
{
    public interface IColorService : ISetupService<IBaseRepository<Color, int>, Color, ColorDTO, int>
    {
    }
}