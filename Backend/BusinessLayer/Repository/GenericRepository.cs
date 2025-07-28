using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Congrate.Repository;
using DataLayer;

namespace BusinessLayer.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity :class,  IBaseEntity
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IDataResult<TEntity>> Get(Guid id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            return new SuccessDataResult<TEntity>(result, "Kullanıcı başarıyla bulundu.");

        }

        public async Task Add(TEntity item)
        {

            await _dbSet.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IDataResult<List<TEntity>>> GetAll()
        {
            var result = await _dbSet.ToListAsync();
            return new SuccessDataResult<List<TEntity>>(result, "Tüm kullanıcılar başarıyla bulundu.");
        }
    }
}
