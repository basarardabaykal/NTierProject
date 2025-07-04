using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using CoreLayer.Entity;
using BusinessLayer.Congrate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.ControllerServices
{
    public class HomeControllerService : IControllerService
    {
        private readonly IUserDbService _userDbService;

        public HomeControllerService(IUserDbService userDbService)
        {
            _userDbService = userDbService;
        }

        public async Task<UserDTO> GetUser(int id)
        {
            var dto = await _userDbService.GetUser(id);
            return dto;

        }


        public async Task AddUser(UserDTO dto)
        {
            await _userDbService.AddUser(dto);
        }
    }
}
