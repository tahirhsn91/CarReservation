using CarReservation.Core.Infrastructure;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CarReservation.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRequestInfo _requestInfo;

        private readonly IColorRepository _colorRepository;
        private readonly IRideStatusRepository _rideStatusRepository;


        public ApplicationDbContext DBContext
        {
            get { return this._requestInfo.Context; }
        }
        public IRequestInfo RequestInfo
        {
            get { return this._requestInfo; }
        }

        public IColorRepository ColorRepository
        {
            get { return this._colorRepository; }
        }
        public IRideStatusRepository RideStatusRepository
        {
            get { return this._rideStatusRepository; }
        }

        public UnitOfWork(
            IRequestInfo requestInfo,
            IColorRepository colorRepository,
            IRideStatusRepository rideStatusRepository
            )
        {
            this._requestInfo = requestInfo;

            this._colorRepository = colorRepository;
            this._rideStatusRepository = rideStatusRepository;
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await DBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Save()
        {
            try
            {
                return DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Data.Entity.DbContextTransaction BeginTransaction()
        {
            return DBContext.Database.BeginTransaction();
        }
    }
}
