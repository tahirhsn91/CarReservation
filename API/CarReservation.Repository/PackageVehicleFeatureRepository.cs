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
    public class PackageVehicleFeatureRepository : AuditableRepository<PackageVehicleFeature, int>, IPackageVehicleFeatureRepository
    {
        public PackageVehicleFeatureRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<PackageVehicleFeature> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Package)
                    .Include(x => x.VehicleFeature);
            }
        }

        public async Task<IEnumerable<VehicleFeature>> GetAsyncByEntity(Package entity)
        {
            return await this.GetAsyncByEntity(entity.Id);
        }

        public async Task<IEnumerable<VehicleFeature>> GetAsyncByEntity(int id)
        {
            IList<PackageVehicleFeature> entities = await this.DefaultSingleQuery.Where(x => x.PackageId.Equals(id)).ToListAsync();
            return entities.Select(x => x.VehicleFeature);
        }

        public async Task<IList<PackageVehicleFeature>> Create(IList<VehicleFeature> models, Package package)
        {
            IList<PackageVehicleFeature> entity = new List<PackageVehicleFeature>();
            if (models != null && package != null)
            {
                foreach (VehicleFeature model in models)
                {
                    entity.Add(new PackageVehicleFeature()
                    {
                        VehicleFeatureId = model.Id,
                        PackageId = package.Id
                    });
                }
            }

            return await this.Create(entity);
        }

        public async Task DeleteAsync(Package entity)
        {
            IQueryable<PackageVehicleFeature> entities = this.DefaultListQuery.Where(x => x.PackageId.Equals(entity.Id));
            this.DeleteRange<IQueryable<PackageVehicleFeature>>(entities);
        }
    }
}
