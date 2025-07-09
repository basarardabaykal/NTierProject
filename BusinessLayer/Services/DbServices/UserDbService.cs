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
    public class UserDbService : DbService<UserDTO, AppUser>, IUserDbService
    {
        private readonly IUserRepository _userRepository;
        public UserDbService(IUserRepository userRepository, IMapper mapper) : base(userRepository, mapper) 
        {
            _userRepository = userRepository;
        }

        public async Task<IDataResult<List<AppUser>>> GetAll()
        {
            return await _userRepository.GetAll(); 
        }
    }
}
