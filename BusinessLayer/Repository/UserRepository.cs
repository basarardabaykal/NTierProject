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
    public class UserRepository : IUserRepository
    {

        private readonly UserDBContext _dbContext;

        public UserRepository(UserDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDataResult<User>> GetUser(int id) 
        {
            if(id < 0)
            {
                return new ErrorDataResult<User>("Id sıfırdan küçük olamaz.");
            }
            var result = await _dbContext.users.FirstOrDefaultAsync(x => x.id == id);
            if (result.id == 15) throw new Exception("dasdsadsadsa"); //global exception denemesi
            return new SuccessDataResult<User>(result, "Kullanıcı başarıyla bulundu.");
        }

        public async Task AddUser(User user)
        {

            await _dbContext.users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}

