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
    public interface IRepository<T>
    {
        public Task<IDataResult<T>> Get(Guid id);
        
        public Task Add(T item);
    }
    
}