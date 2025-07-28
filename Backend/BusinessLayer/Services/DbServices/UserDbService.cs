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
    public class UserDbService : GenericDbService<UserDTO, AppUser>, IUserDbService
    {
        private readonly IUserRepository _repo;
        public UserDbService(IUserRepository repo, IMapper mapper)
        : base(repo, mapper)
        {
            _repo = repo;
        }

        public async Task<IDataResult<UserDTO>> UpdateCompanyId(UserDTO userDTO)
        {
            AppUser user = _mapper.Map<AppUser>(userDTO);
            var result = await _repo.UpdateCompanyId(user);
            return new SuccessDataResult<UserDTO>(result.Message);
        }
        public async Task<IDataResult<UserDTO>> UpdateBranchId(UserDTO userDTO)
        {
            AppUser user = _mapper.Map<AppUser>(userDTO);
            var result = await _repo.UpdateBranchId(user);
            return new SuccessDataResult<UserDTO>(result.Message);
        }
    }
}
