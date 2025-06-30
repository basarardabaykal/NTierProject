using CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Dto;

namespace BusinessLayer.Congrate.Services.DbServices
{
    public interface IUserDbService
    {
        public Task<UserDTO> LoadData(int id);

        public Task SendData(UserDTO userDTO);
    }
}
