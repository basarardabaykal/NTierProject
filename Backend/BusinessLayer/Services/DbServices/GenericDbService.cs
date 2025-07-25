﻿using AutoMapper;
using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using BusinessLayer.Repository;
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
    public class GenericDbService<TDto, TEntity> : IGenericDbService<TDto>
    {
        private readonly IGenericRepository<TEntity> _repo;
        protected readonly IMapper _mapper;

        public GenericDbService(IGenericRepository<TEntity> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IDataResult<TDto>> Get(Guid id)
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
        public async Task<IDataResult<List<TDto>>> GetAll()
        {
            var Item = await _repo.GetAll();
            if (Item.Success != true)
            {
                return new ErrorDataResult<List<TDto>>(Item.StatusCode, Item.Message);
            }
            var dto = _mapper.Map<List<TDto>>(Item.Data);
            return new SuccessDataResult<List<TDto>>(dto, Item.Message);
        }
    }
}
