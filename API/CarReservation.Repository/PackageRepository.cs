using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Data.Entity;

namespace CarReservation.Repository
{
    public class PackageRepository : AuditableRepository<Package, int>, IPackageRepository
    {
        public PackageRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override System.Linq.IQueryable<Package> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.StartFare);
            }
        }
    }
}
