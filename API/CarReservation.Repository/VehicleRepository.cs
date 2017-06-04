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
    public class VehicleRepository : AuditableRepository<Vehicle, int>, IVehicleRepository
    {
        public VehicleRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override System.Linq.IQueryable<Vehicle> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery
                    .Include(x => x.Country)
                    .Include(x => x.State)
                    .Include(x => x.City)
                    .Include(x => x.Color)
                    .Include(x => x.BodyType)
                    .Include(x => x.Assembly)
                    .Include(x => x.Transmission)
                    .Include(x => x.Model)
                    .Include(x => x.Package);
            }
        }

        public override async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await this.DefaultListQuery.Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId)).ToListAsync();
        }

        public override async Task<IEnumerable<Vehicle>> GetAll(Common.Helper.JsonApiRequest request)
        {
            return await this.GetAllQueryable(request).Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId)).ToListAsync();
        }

        public override async Task<Vehicle> GetAsync(int id)
        {
            return await this.DefaultSingleQuery.SingleOrDefaultAsync(x => x.Id.Equals(id) && x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId));
        }

        public override async Task<int> GetCount()
        {
            IList<Vehicle> obj = await this.DefaultListQuery.Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId)).ToListAsync();

            if (obj == null || obj.Count > 0)
            {
                return obj.Count;
            }
            else
            {
                return 0;
            }
        }

        public async Task<IList<Vehicle>> GetVehicleWithPackageInfo()
        {
            return await this.DefaultListQuery
                .Include(x => x.Package)
                .Include(x => x.Driver)
                .Include(x => x.Driver.User)
                .Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId)).ToListAsync();
        }

        public async Task<Vehicle> GetVehicleWithPackageInfo(int id)
        {
            return await this.DefaultListQuery
                .Include(x => x.City)
                .Include(x => x.Color)
                .Include(x => x.Country)
                .Include(x => x.Package)
                .Include(x => x.Driver)
                .Include(x => x.Driver.User)
                .Include(x => x.State)
                .Include(x => x.Assembly)
                .Include(x => x.BodyType)
                .Include(x => x.Model)
                .Include(x => x.Transmission)
                .Where(x => x.CreatedBy.Equals(RepositoryRequisite.RequestInfo.UserId) && x.Id == id).SingleOrDefaultAsync();
        }
    }
}
