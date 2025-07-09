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

namespace BusinessLayer.Services.ControllerServices
{
    public class UserControllerService : ControllerService<UserDTO>, IUserControllerService
    {
        private readonly IUserDbService _userDbService; 
        public UserControllerService(IUserDbService dbService) : base (dbService) 
        {
            _userDbService = dbService;
        }

        public async Task<IDataResult<List<AppUser>>> GetAll()
        {
            return await _userDbService.GetAll();
        }
    }
}
