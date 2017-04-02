using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface IDriverRepository : IBaseRepository<Driver>
    {
        Task<IEnumerable<Driver>> GetByUserId(string userId);
    }
}
