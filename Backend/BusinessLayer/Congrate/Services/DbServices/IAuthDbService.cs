using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
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
        public Task<IDataResult<AppUser>> Login(string email, string password);
    }
}
