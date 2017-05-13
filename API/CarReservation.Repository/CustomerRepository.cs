using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CarReservation.Repository
{
    public class CustomerRepository : AuditableRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(IRepositoryRequisites repositoryRequisite)
            : base(repositoryRequisite)
        {
        }

        protected override DbContext DBContext
        {
            get
            {
                return RepositoryRequisite.RequestInfo.Context;
            }
        }

        public async Task<Customer> GetByUserId(string userId)
        {
            return await this.DefaultSingleQuery.Where(x => x.UserId == userId).SingleOrDefaultAsync();
        }
    }
}