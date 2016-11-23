using System.Data.Entity;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;

namespace CarReservation.Repository
{
    public class CreditCardRepository : AuditableRepository<CreditCard, int>, ICreditCardRepository
    {
        public CreditCardRepository(IRepositoryRequisites repositoryRequisite)
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
