using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Data.Entity;

namespace CarReservation.Repository
{
    public class LocationLagLonRepository: AuditableRepository<LocationLagLon, int>, ILocationLagLonRepository
    {
        public LocationLagLonRepository(IRepositoryRequisites repositoryRequisite)
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
    }
}
