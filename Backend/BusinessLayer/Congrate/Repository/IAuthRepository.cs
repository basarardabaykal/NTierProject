using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
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
        public Task<IDataResult<AppUser>> GetUserByEmail(string email);
        public Task<IDataResult<bool>> CheckPassword(AppUser user, string password);
        public Task<IDataResult<AppUser>> CreateUser(AppUser user, string password);
    }
}
