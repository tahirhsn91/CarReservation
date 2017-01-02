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
    public class PackageVehicleTransmissionRepository : AuditableRepository<PackageVehicleTransmission, int>, IPackageVehicleTransmissionRepository
    {
        public PackageVehicleTransmissionRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<PackageVehicleTransmission> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Package)
                    .Include(x => x.VehicleTransmission);
            }
        }

        public async Task<IEnumerable<VehicleTransmission>> GetAsyncByEntity(Package entity)
        {
            return await this.GetAsyncByEntity(entity.Id);
        }

        public async Task<IEnumerable<VehicleTransmission>> GetAsyncByEntity(int id)
        {
            IList<PackageVehicleTransmission> entities = await this.DefaultSingleQuery.Where(x => x.PackageId.Equals(id)).ToListAsync();
            return entities.Select(x => x.VehicleTransmission);
        }

        public async Task<IList<PackageVehicleTransmission>> Create(IList<VehicleTransmission> transmissions, Package package)
        {
            IList<PackageVehicleTransmission> entity = new List<PackageVehicleTransmission>();
            if (transmissions != null && package != null)
            {
                foreach (VehicleTransmission transmission in transmissions)
                {
                    entity.Add(new PackageVehicleTransmission()
                    {
                        VehicleTransmissionId = transmission.Id,
                        PackageId = package.Id
                    });
                }
            }

            return await this.Create(entity);
        }

        public async Task DeleteAsync(Package entity)
        {
            IQueryable<PackageVehicleTransmission> entities = this.DefaultListQuery.Where(x => x.PackageId.Equals(entity.Id));
            this.DeleteRange<IQueryable<PackageVehicleTransmission>>(entities);
        }
    }
}
