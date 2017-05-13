using CarReservation.Core.IRepository.Base;
using CarReservation.Core.Model;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<Customer> GetByUserId(string userId);
    }
}