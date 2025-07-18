using BusinessLayer.Dto;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Services.ControllerServices
{
    public interface IUserControllerService : IGenericControllerService<UserDTO>
    {
        public Task<IDataResult<UserDTO>> UpdateCompanyId(UserDTO userDTO);
    }
}
