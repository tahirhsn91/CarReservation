using CarReservation.Core.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Repository.Base
{
    //public abstract class TernaryRepository<TEntity, TSingleEntity, TManyEntity, TKey> : AuditableRepository<TEntity, TKey>
    //    where TEntity : class, IAuditModel<TKey>
    //    where TSingleEntity : class, IAuditModel<TKey>
    //    where TManyEntity : class, IAuditModel<TKey>
    //    where TKey : IEquatable<TKey>
    //{
    //    public async Task<IEnumerable<TManyEntity>> GetAsyncByEntity(TSingleEntity entity)
    //    {
    //        return await this.GetAsyncByEntity(entity.Id);
    //    }

    //    public async Task<IEnumerable<TManyEntity>> GetAsyncByEntity(int id)
    //    {
    //        IList<VehicleVehicleFeature> entities = await this.DefaultSingleQuery.Where(x => x.id == vehicleId).ToListAsync();
    //        return entities.Select(x => x.VehicleFeature);
    //    }

    //    public async Task<IList<VehicleVehicleFeature>> Create(IList<VehicleFeature> features, Vehicle vehicle)
    //    {
    //        IList<VehicleVehicleFeature> entity = new List<VehicleVehicleFeature>();
    //        if (features != null && vehicle != null)
    //        {
    //            foreach (VehicleFeature feature in features)
    //            {
    //                entity.Add(new VehicleVehicleFeature()
    //                {
    //                    VehicleFeatureId = feature.Id,
    //                    VehicleId = vehicle.Id
    //                });
    //            }
    //        }

    //        return await this.Create(entity);
    //    }

    //    public async Task DeleteAsync(Vehicle vehicle)
    //    {
    //        IQueryable<VehicleVehicleFeature> entities = this.DefaultListQuery.Where(x => x.VehicleId == vehicle.Id);
    //        this.DeleteRange<IQueryable<VehicleVehicleFeature>>(entities);
    //    }
    //}
}
