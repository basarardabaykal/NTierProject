using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Utilities.Abstract
{
    public abstract class DataResult<T> : IDataResult<T>
    {
        public T Data { get; }
        public bool Success { get; }
        public string Message { get; }
        public DataResult(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
        }
        public DataResult(T data, bool success)
        {
            Data = data;
            Success = success;
        }
    }
}
