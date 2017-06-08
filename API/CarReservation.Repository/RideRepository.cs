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

        public override async Task<Ride> GetAsync(int id)
        {
            return await this.DefaultListQuery
                .Include(x => x.Source)
                .Include(x => x.Destination)
                .Include(x => x.RideDistance)
                .Include(x => x.TimeTaken)
                .Include(x => x.TotalFare.Currency)
                .Include(x => x.ApproximateFare)
                .Include(x => x.Customer.User)
                .Include(x => x.Driver.User)
                .Include(x => x.Vehicle.Model)
                .Include(x => x.Package.StartFare)
                .Include(x => x.RideStatus)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
        }


        public async Task<IEnumerable<Ride>> GetRideBySupervisorUserId(string userId)
        {
            return await this.DefaultListQuery
                .Include(x => x.Source)
                .Include(x => x.Destination)
                .Include(x => x.RideDistance)
                .Include(x => x.TimeTaken)
                .Include(x => x.TotalFare.Currency)
                .Include(x => x.ApproximateFare)
                .Include(x => x.Customer.User)
                .Include(x => x.Driver.User)
                .Include(x => x.Driver.Supervisor)
                .Include(x => x.Vehicle.Model)
                .Include(x => x.Package.StartFare)
                .Include(x => x.RideStatus)
                .Where(x => x.Driver.Supervisor.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ride>> GetCustomerByUserId(string userId)
        {
            return await this.DefaultListQuery
                .Include(x => x.Source)
                .Include(x => x.Destination)
                .Include(x => x.RideDistance)
                .Include(x => x.TimeTaken)
                .Include(x => x.TotalFare.Currency)
                .Include(x => x.ApproximateFare)
                .Include(x => x.Customer.User)
                .Include(x => x.Driver.User)
                .Include(x => x.Vehicle.Model)
                .Include(x => x.Package.StartFare)
                .Include(x => x.RideStatus)
                .Where(x => x.Customer.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ride>> GetByCustomerId(int customerId)
        {
            return await this.DefaultListQuery
                .Include(x => x.Source)
                .Include(x => x.Destination)
                .Include(x => x.RideDistance)
                .Include(x => x.TimeTaken)
                .Include(x => x.TotalFare.Currency)
                .Include(x => x.ApproximateFare)
                .Include(x => x.Customer.User)
                .Include(x => x.Driver.User)
                .Include(x => x.Vehicle.Model)
                .Include(x => x.Package.StartFare)
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
                .Include(x => x.TotalFare.Currency)
                .Include(x => x.ApproximateFare)
                .Include(x => x.Customer.User)
                .Include(x => x.Driver.User)
                .Include(x => x.Vehicle.Model)
                .Include(x => x.Package.StartFare)
                .Include(x => x.RideStatus)
                .Where(x => x.DriverId == driverId && x.IsActive)
                .ToListAsync();
        }
    }
}
