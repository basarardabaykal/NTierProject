using AutoMapper;
using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DbServices
{
    public class DbService<TDto, TEntity> : IDbService<TDto>
    {
        private readonly IRepository<TEntity> _repo;
        private readonly IMapper _mapper;

        public DbService(IRepository<TEntity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IDataResult<TDto>> Get(string id)
        {
            var item = await _repo.Get(id);
            if (item.Success != true) return new ErrorDataResult<TDto>(item.StatusCode, item.Message);

            var dto = _mapper.Map<TDto>(item.Data);
            return new SuccessDataResult<TDto>(dto, item.Message);

        }
        public async Task Add(TDto dto)
        {
            TEntity Item = _mapper.Map<TEntity>(dto);
            await _repo.Add(Item);
        }
    }
}
