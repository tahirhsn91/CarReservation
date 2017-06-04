using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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

        protected override IQueryable<Package> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.StartFare)
                    .Include(x => x.StartFare.Currency);
            }
        }

        public override async Task<IEnumerable<Package>> GetAll()
        {
            return await this.DefaultListQuery.Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId)).ToListAsync();
        }

        public override async Task<IEnumerable<Package>> GetAll(Common.Helper.JsonApiRequest request)
        {
            return await this.GetAllQueryable(request).Include(x => x.StartFare).Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId)).ToListAsync();
        }

        public override async Task<Package> GetAsync(int id)
        {
            return await this.DefaultSingleQuery.SingleOrDefaultAsync(x => x.Id.Equals(id) && x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId));
        }

        public override async Task<int> GetCount()
        {
            IList<Package> obj = await this.DefaultListQuery.Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId)).ToListAsync();

            if (obj == null || obj.Count > 0)
            {
                return obj.Count;
            }
            else
            {
                return 0;
            }
        }
    }
}
