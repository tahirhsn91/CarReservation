using CarReservation.Core.DTO;
using CarReservation.Core.Infrastructure;
using CarReservation.Core.Infrastructure.Base;
using CarReservation.Core.IRepository;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService;
using CarReservation.Core.Model;
using CarReservation.Repository;
using CarReservation.Service.Base;

namespace CarReservation.Service
{
    public class ColorService : SetupService<IBaseRepository<Color, int>, Color, ColorDTO, int>, IColorService
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
