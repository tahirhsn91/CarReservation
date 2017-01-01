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
    public class PackageVehicleBodyTypeRepository : AuditableRepository<PackageVehicleBodyType, int>, IPackageVehicleBodyTypeRepository
    {
        public PackageVehicleBodyTypeRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<PackageVehicleBodyType> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Package)
                    .Include(x => x.VehicleBodyType);
            }
        }

        public async Task<IEnumerable<VehicleBodyType>> GetAsyncByEntity(Package entity)
        {
            return await this.GetAsyncByEntity(entity.Id);
        }

        public async Task<IEnumerable<VehicleBodyType>> GetAsyncByEntity(int id)
        {
            IList<PackageVehicleBodyType> entities = await this.DefaultSingleQuery.Where(x => x.PackageId.Equals(id)).ToListAsync();
            return entities.Select(x => x.VehicleBodyType);
        }

        public async Task<IList<PackageVehicleBodyType>> Create(IList<VehicleBodyType> models, Package package)
        {
            IList<PackageVehicleBodyType> entity = new List<PackageVehicleBodyType>();
            if (models != null && package != null)
            {
                foreach (VehicleBodyType model in models)
                {
                    entity.Add(new PackageVehicleBodyType()
                    {
                        VehicleBodyTypeId = model.Id,
                        PackageId = package.Id
                    });
                }
            }

            return await this.Create(entity);
        }

        public async Task DeleteAsync(Package entity)
        {
            IQueryable<PackageVehicleBodyType> entities = this.DefaultListQuery.Where(x => x.PackageId.Equals(entity.Id));
            this.DeleteRange<IQueryable<PackageVehicleBodyType>>(entities);
        }
    }
}
