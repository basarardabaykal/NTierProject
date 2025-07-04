using Microsoft.Identity.Client;
using BusinessLayer.Congrate.Repository;
using BusinessLayer.Dto;
using CoreLayer.Entity;
using BusinessLayer.Congrate.Services.DbServices;

namespace BusinessLayer.Services.DbServices
{
    public class UserDbService : IUserDbService
    {
        private readonly IUserRepository _repo;
   

        public UserDbService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var item = await _repo.GetUser(id);
            if (item == null)
            {
                Console.WriteLine("Bu ID'ye sahip bir kullanıcı bulunamadı.");
                return new UserDTO() { };
            }
            var dto = new UserDTO()
            {
                name = item.name,
                tcnumber = item.tcnumber // Bu kısımda mapper kullanılacak.
            };
            return dto;

        }


        public async Task AddUser(UserDTO dto)
        {
            User Item = new User(dto.name, dto.tcnumber);
            await _repo.AddUser(Item);
        }

    }
}
