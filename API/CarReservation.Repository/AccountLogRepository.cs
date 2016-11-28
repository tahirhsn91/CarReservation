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
    public class AccountLogRepository : AuditableRepository<AccountLog, int>, IAccountLogRepository
    {
        public AccountLogRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<AccountLog> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Include(x => x.User).Include(x => x.CurrencyLog).Include(x => x.Account);
            }
        }
    }
}
