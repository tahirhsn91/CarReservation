using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CarReservation.Repository
{
    public class DriverStatusRepository : AuditableRepository<DriverStatus, int>, IDriverStatusRepository
    {
        public DriverStatusRepository(IRepositoryRequisites repositoryRequisite)
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

        public async Task<DriverStatus> GetByName(string name)
        {
            return await this.DefaultSingleQuery.Where(x => x.Name == name).SingleOrDefaultAsync();
        }

        public async Task<DriverStatus> GetByCode(string code)
        {
            return await this.DefaultSingleQuery.Where(x => x.Code == code).SingleOrDefaultAsync();
        }
    }
}
