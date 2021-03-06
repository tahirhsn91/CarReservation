﻿using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.Model;
using CarReservation.Repository.Base;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CarReservation.Repository
{
    public class CountryRepository : AuditableRepository<Country, int>, ICountryRepository
    {
        public CountryRepository(IRepositoryRequisites repositoryRequisite)
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
    }
}
