using CarReservation.Common.Helper;
using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
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
    public class ColorService : BaseService<IBaseRepository<Color, int>, Color, ColorDTO, int>, IColorService
    {
        public ColorService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.ColorRepository)
        {
            IRequestInfo requestInfo = new RequestInfo();
            IRepositoryRequisites repositoryRequisites = new RepositoryRequisites(requestInfo);
            IColorRepository ColorRepository = new ColorRepository(repositoryRequisites);
        }
    }
}
