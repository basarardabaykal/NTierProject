using BusinessLayer.Dto;
using CoreLayer;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Services.DbServices
{
    public interface IUserDbService
    {
        Task<IDataResult<UserDTO>> GetUser(int id);


        public Task AddUser(UserDTO userDTO);
    }
}
