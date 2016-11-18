using CarReservation.Core.Infrastructure;
using CarReservation.Core.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Core.IRepository.Base
{
    public interface IUnitOfWork
    {
        ApplicationDbContext DBContext { get; }
        IRequestInfo RequestInfo { get; }
        IColorRepository ColorRepository { get; }

        Task<int> SaveAsync();
        int Save();
        DbContextTransaction BeginTransaction();
    }
}
