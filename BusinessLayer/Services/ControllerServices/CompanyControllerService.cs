using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using BusinessLayer.Congrate.Services.ControllerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Utilities.Interfaces;
using AutoMapper;


namespace BusinessLayer.Services.ControllerServices
{
    public class CompanyControllerService : IControllerService<CompanyDTO>
    {
        private readonly IDbService<CompanyDTO> _dbService;
        public CompanyControllerService(IDbService<CompanyDTO> dbService) 
        {
            _dbService = dbService;
        }

        public async Task<IDataResult<CompanyDTO>> Get(string id)
        {
            return await _dbService.Get(id);
        }
        
        public async Task Add(CompanyDTO dto)
        {
            await _dbService.Add(dto);
        }

    }
}
