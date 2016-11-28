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
    public class AccountRepository : AuditableRepository<Account, int>, IAccountRepository
    {
        public AccountRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<Account> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Include(x => x.Currency).Include(x => x.User);
            }
        }

        public async Task<Account> GetAccountByUserId(string userId)
        {
            return await this.DefaultSingleQuery.FirstAsync(x => x.UserId == userId);
        }
    }
}
