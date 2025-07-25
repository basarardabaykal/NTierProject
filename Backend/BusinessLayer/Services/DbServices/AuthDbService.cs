﻿using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DbServices
{
    public class AuthDbService : IAuthDbService
    {
        private readonly IAuthRepository _authRepository;
        public AuthDbService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<IDataResult<AppUser>> Login(string email, string password)
        {
            var result = await _authRepository.GetUserByEmail(email);
            var user = result.Data;
            if (!result.Success)
            {
                return result;
            }

            else {
                var passwordResult = await _authRepository.CheckPassword(user, password);
                if (!passwordResult.Success)
                {
                    return new ErrorDataResult<AppUser>(500, "Passwords is not correct.");
                }
                else
                {
                    return new SuccessDataResult<AppUser>(user, "User has been authenticated.");
                }
                    
            }
        }
        public async Task<IDataResult<AppUser>> Register(string email, string password, string firstName, string lastName, string tcNumber, string userName, string role)
        {
            var existingUserResult = await _authRepository.GetUserByEmail(email);
            if (existingUserResult.Success)
            {
                return new ErrorDataResult<AppUser>(400, "User with this email already exists.");
            }

            var newUser = new AppUser
            {
                Email = email,
                Firstname = firstName,
                Lastname = lastName,
                Tcnumber = tcNumber,
                UserName = userName
            };
            
            var result = await _authRepository.CreateUser(newUser, password);
            if (result.Success)
            {
                await _authRepository.AssignRole(newUser, role);
            }
            return result;
        }

        public async Task<IDataResult<List<string>>> GetUserRoles(string email)
        {
            return await _authRepository.GetUserRoles(email);
        }
        public async Task<IDataResult<UserDTO>> GetUser(string email)
        {
            var result = await _authRepository.GetUserByEmail(email);
            var user = result.Data;

            var rolesResult = await GetUserRoles(email);
            var roles = rolesResult.Data;

            var userDTO = new UserDTO
            {
                Id = user.Id,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Tcnumber = user.Tcnumber,
                Email = user.Email,
                CompanyId = user.CompanyId,
                Roles = roles,
            };

            return new SuccessDataResult<UserDTO>(userDTO);
        }
    }
}
