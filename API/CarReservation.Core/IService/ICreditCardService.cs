using CarReservation.Core.DTO;
using CarReservation.Core.IService.Base;
using System.Threading.Tasks;

namespace CarReservation.Core.IService
{
    public interface ICreditCardService : IBaseService<CreditCardDTO, int>
    {
        Task<CreditCardDTO> Topup(int amount, CreditCardDTO dtoObject, CurrencyDTO currencyDto, UserDTO user);
    }
}
