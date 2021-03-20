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
        IResult Update(T rental);
        IResult Add(T rental);
        IResult Delete(T rental);
    }
}
