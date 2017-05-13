using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure;
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
    public class RideService : BaseService<IRideRepository, Ride, RideDTO, int>, IRideService
    {
        private IRequestInfo requestInfo;

        public RideService(IUnitOfWork unitOfWork, IRequestInfo requestInfo)
            : base(unitOfWork, unitOfWork.RideRepository)
        {
            this.requestInfo = requestInfo;
        }

        public override async Task<RideDTO> CreateAsync(RideDTO dtoObject)
        {
            using (var trans = this.UnitOfWork.DBContext.Database.BeginTransaction())
            {
                LocationLagLon sourceEntity = null;
                LocationLagLon destinationEntity = null;
                if (dtoObject.Source != null)
                {
                    sourceEntity = await this.UnitOfWork.LocationLagLonRepository.Create(dtoObject.Source.ConvertToEntity());
                }

                if (dtoObject.Destination != null)
                {
                    destinationEntity = await this.UnitOfWork.LocationLagLonRepository.Create(dtoObject.Destination.ConvertToEntity());
                }

                Customer customer = await this.UnitOfWork.CustomerRepository.GetByUserId(this.requestInfo.UserId);
                if (customer == null)
                {
                    customer = await this.UnitOfWork.CustomerRepository.Create(new Customer()
                    {
                        UserId = this.requestInfo.UserId
                    });
                }

                await this.UnitOfWork.SaveAsync();
                dtoObject.SourceId = sourceEntity.Id;
                dtoObject.DestinationId = sourceEntity.Id;
                dtoObject.CustomerId = customer.Id;

                dtoObject = await base.CreateAsync(dtoObject);

                trans.Commit();

                return dtoObject;
            }
        }
    }
}
