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
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using CoreLayer.Utilities.Interfaces;
using BusinessLayer.Services.DbServices;
using CoreLayer.Utilities.Results;

namespace BusinessLayer.Services.ControllerServices
{
    public class UserControllerService : GenericControllerService<UserDTO>, IUserControllerService
    {
        private readonly IUserDbService _dbService;
        public UserControllerService(IUserDbService dbService) : base (dbService) 
        {
            _dbService = dbService;
        }
        public async Task<IDataResult<UserDTO>> UpdateCompanyId(UserDTO userDTO)
        {
            var result = await _dbService.UpdateCompanyId(userDTO);
            return new SuccessDataResult<UserDTO>(result.Message);
        }
        public async Task<IDataResult<UserDTO>> UpdateBranchId(UserDTO userDTO)
        {
            var result = await _dbService.UpdateBranchId(userDTO);
            return new SuccessDataResult<UserDTO>(result.Message);
        }
    }
}
