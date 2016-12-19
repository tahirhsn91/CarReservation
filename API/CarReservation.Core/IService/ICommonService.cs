using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface ICommonService : IBaseService
    {
        Task<DashboardDTO> GetDashboard();
    }
}
