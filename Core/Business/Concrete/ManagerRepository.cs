using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;

namespace Core.Business.Concrete
{
    public class ManagerRepository<TEntity> : IBaseService<TEntity>
        where  TEntity :class, IEntity, new()
    {
        public IEntityRepository<TEntity> _dal;
        public ManagerRepository(IEntityRepository<TEntity> dataService)
        {
            _dal = dataService;
        }
        public IResult Add(TEntity entity)
        {
            _dal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(TEntity entity)
        {
            _dal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<TEntity>> GetAll()
        {
            return new SuccessDataResult<List<TEntity>>(_dal.GetAll());
        }

        public virtual IDataResult<TEntity> GetById(int id)
        {
            return new SuccessDataResult<TEntity>();
        }

        public IResult Update(TEntity rental)
        {
            _dal.Update(rental);
            return new SuccessResult();
        }
    }
}
