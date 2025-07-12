using CoreLayer.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Services.DbServices
{
    public interface IAuthDbService
    {
        public Task<AppUser> Login(string email, string password);
    }
}
