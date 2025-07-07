using Microsoft.Identity.Client;
using BusinessLayer.Congrate.Repository;
using BusinessLayer.Dto;
using CoreLayer.Entity;
using BusinessLayer.Congrate.Services.DbServices;
using AutoMapper;

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

        public async Task<UserDTO> GetUser(string id)
        {
            var item = await _repo.GetUser(id);
            if (item == null)
            {
                Console.WriteLine("Bu ID'ye sahip bir kullanıcı bulunamadı.");
                return new UserDTO() { };
            }
            var dto = _mapper.Map<UserDTO>(item.Data);
            return dto;

        }


        public async Task AddUser(UserDTO dto)
        {
            AppUser Item = _mapper.Map<AppUser>(dto);
            await _repo.AddUser(Item);
        }

    }
}
