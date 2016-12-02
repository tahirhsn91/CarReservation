using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using CarReservation.Common.Helper;

namespace CarReservation.Repository
{
    public class FavouriteLocationRepository : AuditableRepository<FavouriteLocation, int>, IFavouriteLocationRepository
    {
        public FavouriteLocationRepository(IRepositoryRequisites repositoryRequisite)
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

        protected override IQueryable<FavouriteLocation> DefaultSingleQuery
        {
            get
            {
                return base.DefaultSingleQuery.Include(x => x.Location).Include(x => x.User);
            }
        }

        protected override IQueryable<FavouriteLocation> DefaultListQuery
        {
            get
            {
                return base.DefaultListQuery.Include(x => x.Location).Include(x => x.User);
            }
        }

        public override async Task<IEnumerable<FavouriteLocation>> GetAll()
        {
            return await DefaultListQuery.Where(x => x.User.Id == RepositoryRequisite.RequestInfo.UserId).ToListAsync();
        }

        protected override IQueryable<FavouriteLocation> GetAllQueryable(JsonApiRequest request)
        {
            return base.GetAllQueryable(request).Where(x => x.User.Id == RepositoryRequisite.RequestInfo.UserId);
        }

        public override async Task<FavouriteLocation> GetAsync(int id)
        {
            return await this.DefaultSingleQuery.SingleOrDefaultAsync(x => x.Id == id && x.User.Id == RepositoryRequisite.RequestInfo.UserId);
        }
    }
}
