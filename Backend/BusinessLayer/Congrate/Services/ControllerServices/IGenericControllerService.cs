using BusinessLayer.Dto;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Services.ControllerServices
{
    public interface IGenericControllerService<TDto>
    {
      
        Task<IDataResult<TDto>> Get(Guid id);

        public Task Add(TDto dto);
        public Task<IDataResult<List<TDto>>> GetAll();

    }
}
