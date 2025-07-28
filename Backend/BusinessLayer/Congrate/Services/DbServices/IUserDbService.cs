using BusinessLayer.Dto;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Services.DbServices
{
    public interface IUserDbService : IGenericDbService<UserDTO>
    {
        public Task<IDataResult<UserDTO>> UpdateCompanyId(UserDTO userDTO);
        public Task<IDataResult<UserDTO>> UpdateBranchId(UserDTO userDTO);
    }
}
