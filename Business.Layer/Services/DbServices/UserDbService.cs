using Microsoft.Identity.Client;
using BusinessLayer.Congrate.Repository;
using CoreLayer;
using DataLayer;

namespace BusinessLayer.Services.DbServices
{
    public class UserDbService
    {
        private readonly IUserRepository _repo;
        public string Name { get; set; }
        public string TCNumber { get; set; }

        public UserDbService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task LoadData(int id)
        {
            var db = await _repo.GetUsers(id);

            var item = db.FirstOrDefault(x => x.id == id);
            if (item == null)
            {
                Console.WriteLine("Bu ID'ye sahip bir kullanıcı bulunamadı.");
                return;
            }

            Name = item.name;
            TCNumber = item.tcnumber;
        }


        public async Task SendData(UserDTO dto)
        {
            DBItem Item = new DBItem(dto.name, dto.tcnumber);
            await _repo.SetUser(Item);
        }

    }
}
