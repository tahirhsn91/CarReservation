using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Repository
{
    public class DistanceUnitRepository : AuditableRepository<DistanceUnit, int>, IDistanceUnitRepository
    {
        public DistanceUnitRepository(IRepositoryRequisites repositoryRequisite)
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

        public async Task<DistanceUnit> GetByName(string name)
        {
            return await this.DefaultSingleQuery.Where(x => x.Name == name).SingleOrDefaultAsync();
        }

        public async Task<DistanceUnit> GetByCode(string code)
        {
            return await this.DefaultSingleQuery.Where(x => x.Code == code).SingleOrDefaultAsync();
        }
    }
}
