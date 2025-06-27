using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate
{
    internal interface IUserRepository
    {
        public Task<List<DBItem>> GetUsers(int id);

        public Task SetUser(DBItem user);
    }
    
}
