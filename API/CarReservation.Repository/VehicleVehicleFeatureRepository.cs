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
    public class VehicleVehicleFeatureRepository : AuditableRepository<VehicleVehicleFeature, int>, IVehicleVehicleFeatureRepository
    {
        public VehicleVehicleFeatureRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<VehicleVehicleFeature> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Vehicle)
                    .Include(x => x.VehicleFeature);
            }
        }

        public async Task<IEnumerable<VehicleFeature>> GetAsyncByEntity(Vehicle vehicle)
        {
            return await this.GetAsyncByEntity(vehicle.Id);
        }

        public async Task<IEnumerable<VehicleFeature>> GetAsyncByEntity(int vehicleId)
        {
            IList<VehicleVehicleFeature> entities = await this.DefaultSingleQuery.Where(x => x.VehicleId.Equals(vehicleId)).ToListAsync();
            return entities.Select(x => x.VehicleFeature);
        }

        public async Task<IList<VehicleVehicleFeature>> Create(IList<VehicleFeature> features, Vehicle vehicle)
        {
            IList<VehicleVehicleFeature> entity = new List<VehicleVehicleFeature>();
            if (features != null && vehicle != null)
            {
                foreach (VehicleFeature feature in features)
                {
                    entity.Add(new VehicleVehicleFeature()
                    {
                        VehicleFeatureId = feature.Id,
                        VehicleId = vehicle.Id
                    });
                }
            }

            return await this.Create(entity);
        }

        public async Task DeleteAsync(Vehicle vehicle)
        {
            IQueryable<VehicleVehicleFeature> entities = this.DefaultListQuery.Where(x => x.VehicleId == vehicle.Id);
            this.DeleteRange<IQueryable<VehicleVehicleFeature>>(entities);
        }
    }
}
