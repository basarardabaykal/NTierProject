using CoreLayer.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Repository
{
    public interface IAuthRepository
    {
        public Task<AppUser> GetUserByEmail(string email);
        public Task<bool> CheckPassword(AppUser user, string password);
    }
}
