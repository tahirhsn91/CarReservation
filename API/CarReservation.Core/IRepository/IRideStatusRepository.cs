using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IRideStatusRepository : IBaseRepository<RideStatus>
    {
        Task<RideStatus> GetByName(string name);

        Task<RideStatus> GetByCode(string code);
    }
}
