using BusinessLayer.Dto;
using CoreLayer;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Services.DbServices
{
    public interface IGenericDbService<TDto>
    {
        public Task<IDataResult<TDto>> Get(Guid id);


        public Task Add(TDto dto);
    }
}
