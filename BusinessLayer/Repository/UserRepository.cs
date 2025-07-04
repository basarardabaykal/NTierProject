using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using DataLayer;
using BusinessLayer.Congrate.Repository;
using CoreLayer.Entity;



namespace BusinessLayer.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly UserDBContext _dbContext;

        public UserRepository(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetUser(int id)
        {
            return await _dbContext.users.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task AddUser(User user)
        {

            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}

