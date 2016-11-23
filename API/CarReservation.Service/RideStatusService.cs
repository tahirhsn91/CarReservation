using CarReservation.Core.DTO;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Repository;
using CarReservation.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class RideStatusService : BaseService<IBaseRepository<RideStatus, int>, RideStatus, RideStatusDTO, int>, IRideStatusService
    {
        public RideStatusService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.RideStatusRepository)
        {
        }
    }
}
