using System.ComponentModel.DataAnnotations;

namespace CarReservation.Core.Model.Base
{
    public interface IBase<TKey> : IBase
    {
        [Key]
        TKey Id { get; set; }
    }

    public interface IBase
    {

    }
}
