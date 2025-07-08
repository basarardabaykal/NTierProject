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
    public class CompanyRepository : IRepository<Company>
    {
        private readonly DbContext _dbContext;
        public CompanyRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDataResult<Company>> Get(string id)
        {
            var result = await _dbContext.users.FirstOrDefaultAsync(x => x.Id == id);
            return new SuccessDataResult<AppUser>(result, "Kullanıcı başarıyla bulundu.");

        }

        public async Task Add(Company company)
        {

            await _dbContext.users.AddAsync(company);
            await _dbContext.SaveChangesAsync();
        }
    }
}
