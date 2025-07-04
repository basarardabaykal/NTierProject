using BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Services.ControllerServices
{
    public interface IControllerService
    {
        public Task<UserDTO> GetUser(int id);
        public Task AddUser(UserDTO dto); 

    }
}
