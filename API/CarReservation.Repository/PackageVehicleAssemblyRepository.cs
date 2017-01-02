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
    public class PackageVehicleAssemblyRepository : AuditableRepository<PackageVehicleAssembly, int>, IPackageVehicleAssemblyRepository
    {
        public PackageVehicleAssemblyRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<PackageVehicleAssembly> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Package)
                    .Include(x => x.VehicleAssembly);
            }
        }

        public async Task<IEnumerable<VehicleAssembly>> GetAsyncByEntity(Package entity)
        {
            return await this.GetAsyncByEntity(entity.Id);
        }

        public async Task<IEnumerable<VehicleAssembly>> GetAsyncByEntity(int id)
        {
            IList<PackageVehicleAssembly> entities = await this.DefaultSingleQuery.Where(x => x.PackageId.Equals(id)).ToListAsync();
            return entities.Select(x => x.VehicleAssembly);
        }

        public async Task<IList<PackageVehicleAssembly>> Create(IList<VehicleAssembly> models, Package package)
        {
            IList<PackageVehicleAssembly> entity = new List<PackageVehicleAssembly>();
            if (models != null && package != null)
            {
                foreach (VehicleAssembly model in models)
                {
                    entity.Add(new PackageVehicleAssembly()
                    {
                        VehicleAssemblyId = model.Id,
                        PackageId = package.Id
                    });
                }
            }

            return await this.Create(entity);
        }

        public async Task DeleteAsync(Package entity)
        {
            IQueryable<PackageVehicleAssembly> entities = this.DefaultListQuery.Where(x => x.PackageId.Equals(entity.Id));
            this.DeleteRange<IQueryable<PackageVehicleAssembly>>(entities);
        }
    }
}
