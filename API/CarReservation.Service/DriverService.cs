using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class DriverService : BaseService<IDriverRepository, Driver, DriverDTO, int>, IDriverService
    {
        private IRequestInfo requestInfo;

        public DriverService(IUnitOfWork unitOfWork, IRequestInfo requestInfo)
            : base(unitOfWork, unitOfWork.DriverRepository)
        {
            this.requestInfo = requestInfo;
        }

        public async Task<DriverDTO> GetCurrentDriver()
        {
            IEnumerable<Driver> driverEntity = await this.Repository.GetByUserId(this.requestInfo.UserId);
            if (driverEntity != null && driverEntity.Count() > 0)
            {
                return new DriverDTO(driverEntity.First());
            }
            else
            {
                return null;
            }
        }
    }
}
