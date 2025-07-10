using BusinessLayer.Dto;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Services.ControllerServices
{
    public interface IGenericControllerService<T>
    {
      
        Task<IDataResult<T>> Get(Guid id);

        public Task Add(T dto); 

    }
}
