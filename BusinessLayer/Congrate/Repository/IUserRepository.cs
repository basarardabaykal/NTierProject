using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Repository
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        public Task<IDataResult<List<AppUser>>> GetAll();
    }
}
