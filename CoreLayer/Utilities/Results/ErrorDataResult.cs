using CoreLayer.Utilities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, bool success, int statusCode, string message) : base(data, false, statusCode, message)
        {

        }
        public ErrorDataResult(T data, int statusCode, string message) : base(data, false, statusCode, message)
        {

        }

        public ErrorDataResult(T data, int statusCode) : base(data, false, statusCode)
        {

        }

        public ErrorDataResult(int statusCode, string message) : base(default, false, statusCode, message)
        {

        }

        public ErrorDataResult(int statusCode) : base(default, false, statusCode)
        {

        }
    }
}
