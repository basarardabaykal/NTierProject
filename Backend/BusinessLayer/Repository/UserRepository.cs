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
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(DataLayer.DbContext dbContext) : base (dbContext) { }

    }
}

