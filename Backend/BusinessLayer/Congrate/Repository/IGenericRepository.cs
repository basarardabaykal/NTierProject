using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;

namespace BusinessLayer.Congrate.Repository
{
    public interface IGenericRepository<TEntity>
    {
        public Task<IDataResult<TEntity>> Get(Guid id);
        
        public Task Add(TEntity item);
    }
    
}