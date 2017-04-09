using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Data.Entity;
using System.Linq;

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
                    .Include(x => x.StartFare)
                    .Include(x => x.StartFare.Currency);
            }
        }

        public override async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Package>> GetAll()
        {
            return await this.DefaultListQuery.Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId)).ToListAsync();
        }

        public override async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Package>> GetAll(Common.Helper.JsonApiRequest request)
        {
            return await this.GetAllQueryable(request).Include(x => x.StartFare).Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId)).ToListAsync();
        }

        public override async System.Threading.Tasks.Task<Package> GetAsync(int id)
        {
            return await this.DefaultSingleQuery.SingleOrDefaultAsync(x => x.Id.Equals(id) && x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId));
        }

        public override async System.Threading.Tasks.Task<int> GetCount()
        {
            return await this.DefaultListQuery.Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId)).CountAsync();
        }
    }
}
