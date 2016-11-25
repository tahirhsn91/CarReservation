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
    public class CurrencyLogRepository : AuditableRepository<CurrencyLog, int>, ICurrencyLogRepository
    {
        public CurrencyLogRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override System.Linq.IQueryable<CurrencyLog> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Include(x => x.Currency);
            }
        }
    }
}
