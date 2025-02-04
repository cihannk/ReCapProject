﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data) : base(false, data)
        {

        }
        public ErrorDataResult(T data, string message) : base(false, message, data)
        {

        }
        public ErrorDataResult(string message) : base(false, message, default)
        {

        }
        public ErrorDataResult() : base(false, default)
        {

        }
    }
}
