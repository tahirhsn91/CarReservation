using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class DriverStatusService : SetupService<IDriverStatusRepository, DriverStatus, DriverStatusDTO, int>, IDriverStatusService
    {
        private IRequestInfo requestInfo;

        public DriverStatusService(IUnitOfWork unitOfWork, IRequestInfo requestInfo)
            : base(unitOfWork, unitOfWork.DriverStatusRepository)
        {
            this.requestInfo = requestInfo;
        }

        public async Task<bool> GetDriverAssociation()
        {
            IEnumerable<Driver> result = await this._unitOfWork.DriverRepository.GetByUserId(this.requestInfo.UserId);

            return (result != null && result.Count() > 0);
        }
    }
}
