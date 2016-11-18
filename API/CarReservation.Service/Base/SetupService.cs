using CarReservation.Core.DTO.Base;
using CarReservation.Core.IRepository.Base;
using CarReservation.Core.IService.Base;
using CarReservation.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReservation.Service.Base
{
    //public abstract class SetupService<TEntity, TKey> : BaseService<TEntity, TKey> where TEntity : SetupDTO<TEntity, TKey>
    //{
    //    private IBaseRepository<TEntity, TKey> _repository;

    //    public SetupService()
    //    {
    //    }

    //    public SetupService(IBaseRepository repository)
    //    {
    //        this._repository = repository;
    //    }

    //    public override Task<TEntity> CreateAsync(TEntity dtoObject)
    //    {
    //        TEntity entity = dtoObject.ConvertToEntity();
    //        var result = await _repository.Create(entity);
    //        await _unitOfWork.SaveAsync();

    //        dtoObject.ConvertFromEntity(result);
    //        return dtoObject;
    //    }

    //    public override Task DeleteAsync(TKey id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override Task<IList<TEntity>> GetAllAsync()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override Task<IList<TEntity>> GetAllAsync(Common.Helper.JsonApiRequest request)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override Task<TEntity> GetAsync(TKey id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public override Task<TEntity> UpdateAsync(TEntity dtoObject)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
