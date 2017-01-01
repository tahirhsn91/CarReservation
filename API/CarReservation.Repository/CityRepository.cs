using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Data.Entity;
using System.Linq;

namespace CarReservation.Repository
{
    public class CityRepository : AuditableRepository<City, int>, ICityRepository
    {
        public CityRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<City> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Include(x => x.State);
            }
        }
    }
}
