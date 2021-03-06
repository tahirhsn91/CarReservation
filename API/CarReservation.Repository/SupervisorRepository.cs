﻿using CarReservation.Core.Infrastructure.Base;
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
    public class SupervisorRepository : AuditableRepository<Supervisor, int>, ISupervisorRepository
    {
        public SupervisorRepository(IRepositoryRequisites repositoryRequisite)
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

        public async Task<Supervisor> GetByUserId(string userId)
        {
            return await this.DefaultSingleQuery.Where(x => x.UserId == userId).SingleOrDefaultAsync();
        }
    }
}
