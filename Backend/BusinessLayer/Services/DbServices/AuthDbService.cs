using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.DbServices;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
    }
}
