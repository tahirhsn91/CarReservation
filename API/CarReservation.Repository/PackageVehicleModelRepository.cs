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
    public class PackageVehicleModelRepository : AuditableRepository<PackageVehicleModel, int>, IPackageVehicleModelRepository
    {
        public PackageVehicleModelRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<PackageVehicleModel> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Package)
                    .Include(x => x.VehicleModel);
            }
        }

        public async Task<IEnumerable<VehicleModel>> GetAsyncByEntity(Package entity)
        {
            return await this.GetAsyncByEntity(entity.Id);
        }

        public async Task<IEnumerable<VehicleModel>> GetAsyncByEntity(int id)
        {
            IList<PackageVehicleModel> entities = await this.DefaultSingleQuery.Where(x => x.PackageId.Equals(id)).ToListAsync();
            return entities.Select(x => x.VehicleModel);
        }

        public async Task<IList<PackageVehicleModel>> Create(IList<VehicleModel> models, Package package)
        {
            IList<PackageVehicleModel> entity = new List<PackageVehicleModel>();
            if (models != null && package != null)
            {
                foreach (VehicleModel model in models)
                {
                    entity.Add(new PackageVehicleModel()
                    {
                        VehicleModelId = model.Id,
                        PackageId = package.Id
                    });
                }
            }

            return await this.Create(entity);
        }

        public async Task DeleteAsync(Package entity)
        {
            IQueryable<PackageVehicleModel> entities = this.DefaultListQuery.Where(x => x.PackageId.Equals(entity.Id));
            this.DeleteRange<IQueryable<PackageVehicleModel>>(entities);
        }
    }
}
