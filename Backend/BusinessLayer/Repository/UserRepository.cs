using BusinessLayer.Congrate.Repository;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;



namespace BusinessLayer.Repository
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base (dbContext) { }
        public async Task<IDataResult<AppUser>> UpdateCompanyId(AppUser user)
        {
            var existingUser = await _dbSet.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (existingUser == null)
            {
                return new ErrorDataResult<AppUser>(404, "Kullanıcı bulunamadı.");
            }

            existingUser.CompanyId = user.CompanyId;
            _dbContext.Update(existingUser);
            await _dbContext.SaveChangesAsync();

            return new SuccessDataResult<AppUser>("Kullanıcı başarıyla güncellendi.");

        }
    }
}

