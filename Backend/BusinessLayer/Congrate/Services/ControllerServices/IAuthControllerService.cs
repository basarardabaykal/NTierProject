﻿using BusinessLayer.Dto;
using BusinessLayer.Dto.Auth;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Services.ControllerServices
{
    public interface IAuthControllerService
    {
        public Task<IDataResult<LoginResponseDTO>> Login(LoginRequestDTO loginDTO);
        public Task<IDataResult<RegisterResponseDTO>> Register(RegisterRequestDTO registerDTO);
        public Task<IDataResult<UserDTO>> GetUser(string token);
    }
}
