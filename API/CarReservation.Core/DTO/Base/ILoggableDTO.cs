namespace CarReservation.Core.DTO.Base
{
    public interface ILoggableDTO<TEntity>
    {
        void ConvertFromLogEntity(TEntity entity);
    }
}
