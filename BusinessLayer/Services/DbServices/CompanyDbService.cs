using BusinessLayer.Congrate.Repository;
using BusinessLayer.Dto;
using CoreLayer.Entity;
using BusinessLayer.Congrate.Services.DbServices;
using AutoMapper;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DbServices
{
    public class CompanyDbService : IDbService<CompanyDTO>
    {
        private readonly IRepository<Company> _repo;
        private readonly IMapper _mapper;

        public CompanyDbService(IRepository<Company> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<IDataResult<CompanyDTO>> Get(string id)
        {
            var item = await _repo.Get(id);
            if (item.Success != true) return new ErrorDataResult<CompanyDTO>(item.StatusCode, item.Message);

            var dto = _mapper.Map<CompanyDTO>(item.Data);
            return new SuccessDataResult<CompanyDTO>(dto, item.Message);
        }
        public async Task Add(CompanyDTO dto)
        {
            Company Item = _mapper.Map<Company>(dto);
            await _repo.Add(Item);
        }
    }
}
