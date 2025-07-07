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

namespace BusinessLayer.Services.ControllerServices
{
    public class HomeControllerService : IControllerService
    {
        private readonly IUserDbService _userDbService;

        public HomeControllerService(IUserDbService userDbService)
        {
            _userDbService = userDbService;
        }


        public async Task<IDataResult<UserDTO>> GetUser(string id)

        {
            return await _userDbService.GetUser(id);
            

        }


        public async Task AddUser(UserDTO dto)
        {
            await _userDbService.AddUser(dto);
        }

      
    }
}
