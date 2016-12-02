using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Data.Entity;


namespace CarReservation.Repository
{
    public class CurrencyRepository : AuditableRepository<Currency, int>, ICurrencyRepository
    {
        public CurrencyRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override System.Linq.IQueryable<Currency> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Include(x => x.Country);
            }
        }
    }
}
