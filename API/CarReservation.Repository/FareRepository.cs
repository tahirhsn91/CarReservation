using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Data.Entity;

namespace CarReservation.Repository
{
    public class FareRepository : AuditableRepository<Fare, int>, IFareRepository
    {
        public FareRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override System.Linq.IQueryable<Fare> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Currency);
            }
        }
    }
}
