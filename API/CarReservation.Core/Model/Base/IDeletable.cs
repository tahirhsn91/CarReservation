namespace CarReservation.Core.Model.Base
{
    public interface IDeletable<TKey> : IDeletable, IBase<TKey>
    {

    }
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
