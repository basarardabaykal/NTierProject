using BusinessLayer.Congrate.Repository;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IDataResult<AppUser>> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(email);
                if (user == null)
                {
                    throw new Exception("No user was found with this email.");
                }
                else
                {
                    return new SuccessDataResult<AppUser>(user, "User with this email has been found succesfully.");
                }
            }
            catch (Exception exception)
            {
                {
                    return new ErrorDataResult<AppUser>(500, exception.Message);
                }
            }
        }
        public async Task<IDataResult<bool>> CheckPassword(AppUser user, string password)
        {
            try
            {
                var hasMatchedPasswords = await _userManager.CheckPasswordAsync(user, password);
                if (hasMatchedPasswords)
                {
                    return new SuccessDataResult<bool>(hasMatchedPasswords, "Password is correct.");
                }
                else
                {
                    return new ErrorDataResult<bool>(hasMatchedPasswords, 500, "Password is not correct.");
                }
                
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<bool>(500, "An unexpected error has occured while checking the password.");
            }
            
            
        }
    }
}
