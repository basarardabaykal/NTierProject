using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;

namespace BusinessLayer.Congrate.Repository
{
    public interface IUserRepository
    {
        public Task<IDataResult<User>> GetUser(int id);

        public Task AddUser(User user);
    }
    
}