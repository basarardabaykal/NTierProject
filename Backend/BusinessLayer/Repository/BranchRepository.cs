using BusinessLayer.Congrate.Repository;
using CoreLayer.Entity;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class BranchRepository : GenericRepository<Branch>, IBranchRepository
    {
        public BranchRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}
