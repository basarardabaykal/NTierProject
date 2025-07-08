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
    public class HomeControllerService : IControllerService<UserDTO>
    {
        private readonly IDbService<UserDTO> _dbService;

        public HomeControllerService(IDbService<UserDTO> userDbService)
        {
            _dbService = userDbService;
        }


        public async Task<IDataResult<UserDTO>> Get(string id)

        {
            return await _dbService.Get(id);
            

        }


        public async Task Add(UserDTO dto)
        {
            await _dbService.Add(dto);
        }

      
    }
}
