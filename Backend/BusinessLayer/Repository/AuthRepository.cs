using BusinessLayer.Congrate.Repository;
using CoreLayer.Entity;
using Microsoft.AspNetCore.Identity;
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
        public async Task<AppUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByNameAsync(email);
        }   

        public async Task<bool> CheckPassword(AppUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);      
        }
    }
}
