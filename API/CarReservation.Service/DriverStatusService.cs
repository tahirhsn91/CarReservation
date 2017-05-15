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
            IEnumerable<Driver> result = await this.UnitOfWork.DriverRepository.GetByUserId(this.requestInfo.UserId);

            return (result != null && result.Count() > 0);
        }

        public async Task<DriverDTO> ToggleAvailable()
        {
            Driver driver = (await this.UnitOfWork.DriverRepository.GetByUserId(this.requestInfo.UserId)).FirstOrDefault();
            if (driver != null)
            {
                DriverStatus status = null;
                if (driver.Status == null || driver.Status.Name == Core.Constant.DriverStatus.UnAvailable)
                {
                    status = await this.UnitOfWork.DriverStatusRepository.GetByCode(Core.Constant.DriverStatus.Available);
                }
                else
                {
                    status = await this.UnitOfWork.DriverStatusRepository.GetByCode(Core.Constant.DriverStatus.UnAvailable);
                }

                if (status != null)
                {
                    driver.StatusId = status.Id;
                    await this.UnitOfWork.DriverRepository.Update(driver);
                    await this.UnitOfWork.SaveAsync();
                }

                return new DriverDTO(driver);
            }
            else
            {
                return null;
            }
        }
    }
}
