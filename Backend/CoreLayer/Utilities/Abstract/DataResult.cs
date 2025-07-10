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
        public int StatusCode { get; }
        public DataResult(T data, bool success, int statusCode, string message)
        {
            Data = data;
            Success = success;
            Message = message;
            StatusCode = statusCode;
        }
        public DataResult(T data, bool success, int statusCode)
        {
            Data = data;
            Success = success;
            StatusCode = statusCode;
        }

        public DataResult(T data, bool success, string message)
        {
            Data = data;
            Success = success;
            Message = message;
            StatusCode = 200;
        }

        public DataResult(T data, bool success)
        {
            Data = data;
            Success = success;
            StatusCode = 200;
        }

    }
}
