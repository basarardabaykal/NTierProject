using Microsoft.Identity.Client;
using BusinessLayer.Congrate.Repository;
using BusinessLayer.Dto;
using CoreLayer.Entity;
using BusinessLayer.Congrate.Services.DbServices;
using AutoMapper;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;

namespace BusinessLayer.Services.DbServices
{
    public class UserDbService : IUserDbService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
   

        public UserDbService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IDataResult<UserDTO>> GetUser(int id)
        {
            var item = await _repo.GetUser(id);
            if (item.Success != true) return new ErrorDataResult<UserDTO>(item.StatusCode, item.Message);
          
            var dto = _mapper.Map<UserDTO>(item.Data);
            return new SuccessDataResult<UserDTO>(dto, item.Message);

        }


        public async Task AddUser(UserDTO dto)
        {
            User Item = _mapper.Map<User>(dto);
            await _repo.AddUser(Item);
        }

    }
}
