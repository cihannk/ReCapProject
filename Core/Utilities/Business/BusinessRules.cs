using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] functions)
        {
            foreach (var func in functions)
            {
                if(!func.Success)
                {
                    return func;
                }
            }
            return null;
        }
    }
}
