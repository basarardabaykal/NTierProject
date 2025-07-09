using BusinessLayer.Congrate.Services.ControllerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Utilities.Interfaces;
using BusinessLayer.Congrate.Services.DbServices;

namespace BusinessLayer.Services.ControllerServices
{
    public class ControllerService<T> : IGenericControllerService<T>
    {
        protected readonly IGenericDbService<T> _dbService;
        public ControllerService(IGenericDbService<T> dbService) 
        {
            _dbService = dbService;
        }

        public async Task<IDataResult<T>> Get(Guid id)
        {
            return await _dbService.Get(id);
        }
        
        public async Task Add(T dto)
        {
            await _dbService.Add(dto);
        }
    }
}
