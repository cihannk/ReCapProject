using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(bool succes, string message, T data):base(succes, message)
        {
            Data = data;
        }
        public DataResult(bool success, T data):base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
