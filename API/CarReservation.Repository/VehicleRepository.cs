using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace CarReservation.Repository
{
    public class VehicleRepository : AuditableRepository<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override System.Linq.IQueryable<Vehicle> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Country)
                    .Include(x => x.State)
                    .Include(x => x.City)
                    .Include(x => x.Color)
                    .Include(x => x.BodyType)
                    .Include(x => x.Assembly)
                    .Include(x => x.Transmission)
                    .Include(x => x.Model)
                    .Include(x => x.Package);
            }
        }
    }
}
