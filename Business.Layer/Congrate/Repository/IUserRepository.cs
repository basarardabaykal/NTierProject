using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entity;

namespace BusinessLayer.Congrate.Repository
{
    public interface IUserRepository
    {
        public Task<DBItem> GetUser(int id);

        public Task SetUser(DBItem user);
    }
    
}