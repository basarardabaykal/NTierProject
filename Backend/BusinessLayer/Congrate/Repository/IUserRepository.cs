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
        public Task<IDataResult<AppUser>> UpdateCompanyId(AppUser user);
        public Task<IDataResult<AppUser>> UpdateBranchId(AppUser user);
    }
}
