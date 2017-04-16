using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Service
{
    public class SupervisorService : BaseService<ISupervisorRepository, Supervisor, SupervisorDTO, int>, ISupervisorService
    {
        private IRequestInfo requestInfo;
        private IUserService userService;

        public SupervisorService(IUnitOfWork unitOfWork, IUserService userService, IRequestInfo requestInfo)
            : base(unitOfWork, unitOfWork.SupervisorRepository)
        {
            this.requestInfo = requestInfo;
            this.userService = userService;
        }

        public async Task AddDriver(DriverDTO driver)
        {
            using (var trans = this.UnitOfWork.DBContext.Database.BeginTransaction())
            {
                UserDTO user = await this.userService.GetByUserName(driver.User.Email);
                Driver driverEntity = (await this.UnitOfWork.DriverRepository.GetByUserName(driver.User.Email)).FirstOrDefault();

                Supervisor supervisorEntity = await this.UnitOfWork.SupervisorRepository.GetByUserId(this.requestInfo.UserId);
                if (supervisorEntity == null)
                {
                    supervisorEntity = await this.UnitOfWork.SupervisorRepository.Create(new Supervisor()
                    {
                        UserId = this.requestInfo.UserId
                    });
                    await this.UnitOfWork.SaveAsync();
                }

                driver.SupervisorId = supervisorEntity.Id;

                if (user != null)
                {
                    driver.UserId = user.UserId;
                }

                if (driverEntity == null)
                {
                    driverEntity = await this.UnitOfWork.DriverRepository.Create(driver.ConvertToEntity());
                }
                else
                {
                    driverEntity = await this.UnitOfWork.DriverRepository.Update(driver.ConvertToEntity(driverEntity));
                }

                await this.UnitOfWork.SaveAsync();
                trans.Commit();
            }
        }

        public async Task<IList<DriverDTO>> GetDrivers()
        {
            return DriverDTO.ConvertEntityListToDTOList<DriverDTO>(await this.UnitOfWork.DriverRepository.GetBySupervisorId(this.requestInfo.UserId));
        }

        public async Task<bool> CheckDriver(string driverUserName)
        {
            return await this.UnitOfWork.DriverRepository.CheckByUserName(driverUserName);
        }
    }
}
