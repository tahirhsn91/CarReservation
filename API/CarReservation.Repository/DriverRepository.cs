using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CarReservation.Repository
{
    public class DriverRepository : AuditableRepository<Driver, int>, IDriverRepository
    {
        public DriverRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<Driver> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Supervisor)
                    .Include(x => x.User)
                    .Include(x => x.Status);
            }
        }

        public async Task<int> GetCount(int supervisorId)
        {
            return await this.DefaultListQuery.Where(x => x.SupervisorId == supervisorId).CountAsync();
        }

        public async Task<IEnumerable<Driver>> GetByUserId(string userId)
        {
            return await this.DefaultListQuery
                .Include(x => x.Supervisor)
                .Include(x => x.User)
                .Include(x => x.Status)
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Driver>> GetByUserName(string userName)
        {
            return await this.DefaultListQuery.Include(x => x.User).Where(x => x.User.UserName == userName).ToListAsync();
        }

        public async Task<IEnumerable<Driver>> GetBySupervisorId(string supervisorId)
        {
            return await this.DefaultListQuery
                .Include(x => x.User)
                .Include(x => x.Status)
                .Include(x => x.Supervisor)
                .Where(x => x.Supervisor.UserId == supervisorId)
                .ToListAsync();
        }

        public async Task<bool> CheckByUserName(string userName)
        {
            var driver = (await this.DefaultSingleQuery.Include(x => x.User).Where(x => x.User != null && x.User.UserName == userName).SingleOrDefaultAsync());

            return (driver == null || (driver.SupervisorId == null || driver.SupervisorId == 0));
        }
    }
}
