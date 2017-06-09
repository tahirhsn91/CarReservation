using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Repository
{
    public class DriverLocationRepository : AuditableRepository<DriverLocation>, IDriverLocationRepository
    {
        public DriverLocationRepository(IRepositoryRequisites repositoryRequisite)
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

        public async Task<DriverLocation> GetByUserId(string userId)
        {
            return await this.DefaultSingleQuery
                .Include(x => x.Driver)
                .Include(x => x.Location)
                .Include(x => x.Status)
                .Where(x => x.Driver.UserId == userId).SingleOrDefaultAsync();
        }

        public async Task<DriverLocation> GetByDriverId(int id)
        {
            return await this.DefaultSingleQuery
                .Include(x => x.Driver)
                .Include(x => x.Location)
                .Include(x => x.Status)
                .Where(x => x.DriverId == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<DriverLocation>> GetByDriverId(IList<int> driverIds)
        {
            return await this.DefaultListQuery
                .Include(x => x.Location)
                .Include(x => x.Driver)
                .Where(x => driverIds.Contains(x.DriverId))
                .ToListAsync();
        }

        public async Task<IEnumerable<DriverLocation>> GetAllDriverLocation()
        {
            return await this.DefaultListQuery
                .Include(x => x.Location)
                .Include(x => x.Driver.Status)
                .Include(x => x.Status)
                .Where(x => x.Driver.Status.Code == Core.Constant.DriverStatus.Available)
                .ToListAsync();
        }
    }
}
