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
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;


namespace BusinessLayer.Repository
{
    public class UserRepository : IRepository<AppUser>
    {

        private readonly UserDBContext _dbContext;

        public UserRepository(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDataResult<AppUser>> Get(string id) 
        {
            var result = await _dbContext.users.FirstOrDefaultAsync(x => x.Id == id);
            return new SuccessDataResult<AppUser>(result, "Kullanıcı başarıyla bulundu.");

        }

        public async Task Add(AppUser user)
        {

            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}

