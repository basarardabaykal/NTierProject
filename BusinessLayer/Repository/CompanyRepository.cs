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
        private readonly DataLayer.DbContext _dbContext;
        public CompanyRepository(DataLayer.DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDataResult<Company>> Get(string id)
        {
            var result = await _dbContext.companies.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return new SuccessDataResult<Company>(result, "Kullanıcı başarıyla bulundu.");

        }

        public async Task Add(Company company)
        {

            await _dbContext.companies.AddAsync(company);
            await _dbContext.SaveChangesAsync();
        }
    }
}
