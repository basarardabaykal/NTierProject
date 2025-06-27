using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using DataLayer;


namespace BusinessLayer.Congrate
{
    public class UserRepository : IUserRepository
    {

        private readonly UserDBContext _dbContext;

        public UserRepository(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DBItem>> GetUsers(int id)
        {
            var users = await _dbContext.users.ToListAsync();
            return users;
        }

        public async Task SetUser(DBItem user)
        {
            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}

