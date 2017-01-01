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
    public class PackageTravelUnitRepository : AuditableRepository<PackageTravelUnit, int>, IPackageTravelUnitRepository
    {
        public PackageTravelUnitRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<PackageTravelUnit> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Package)
                    .Include(x => x.TravelUnit);
            }
        }

        public async Task<IEnumerable<TravelUnit>> GetAsyncByEntity(Package entity)
        {
            return await this.GetAsyncByEntity(entity.Id);
        }

        public async Task<IEnumerable<TravelUnit>> GetAsyncByEntity(int id)
        {
            IList<PackageTravelUnit> entities = await this.DefaultSingleQuery.Where(x => x.PackageId.Equals(id)).ToListAsync();
            return entities.Select(x => x.TravelUnit);
        }

        public async Task<IList<PackageTravelUnit>> Create(IList<TravelUnit> models, Package package)
        {
            IList<PackageTravelUnit> entity = new List<PackageTravelUnit>();
            if (models != null && package != null)
            {
                foreach (TravelUnit model in models)
                {
                    entity.Add(new PackageTravelUnit()
                    {
                        TravelUnitId = model.Id,
                        PackageId = package.Id
                    });
                }
            }

            return await this.Create(entity);
        }

        public async Task DeleteAsync(Package entity)
        {
            IQueryable<PackageTravelUnit> entities = this.DefaultListQuery.Where(x => x.PackageId.Equals(entity.Id));
            this.DeleteRange<IQueryable<PackageTravelUnit>>(entities);
        }
    }
}
