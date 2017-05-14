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
    public class RideRepository : AuditableRepository<Ride, int>, IRideRepository
    {
        public RideRepository(IRepositoryRequisites repositoryRequisite)
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

        public async Task<IEnumerable<Ride>> GetByCustomerId(int customerId)
        {
            return await this.DefaultListQuery
                .Include(x => x.Source)
                .Include(x => x.Destination)
                .Include(x => x.RideDistance)
                .Include(x => x.TimeTaken)
                .Include(x => x.TotalFare)
                .Include(x => x.ApproximateFare)
                .Include(x => x.Customer)
                .Include(x => x.Driver)
                .Include(x => x.Package)
                .Include(x => x.RideStatus)
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ride>> GetActiveRideByDriverId(int driverId)
        {
            return await this.DefaultListQuery
                .Include(x => x.Source)
                .Include(x => x.Destination)
                .Include(x => x.RideDistance)
                .Include(x => x.TimeTaken)
                .Include(x => x.TotalFare)
                .Include(x => x.ApproximateFare)
                .Include(x => x.Customer)
                .Include(x => x.Driver)
                .Include(x => x.Package)
                .Include(x => x.RideStatus)
                .Where(x => x.DriverId == driverId && x.IsActive)
                .ToListAsync();
        }

    }
}
