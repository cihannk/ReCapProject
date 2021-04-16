using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Business
{
    public interface IBaseService<T>
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> GetById(int id);
        IResult Update(T item);
        IResult Add(T item);
        IResult Delete(T item);
    }
}
