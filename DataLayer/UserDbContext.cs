using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using CoreLayer.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DataLayer
{
    public class UserDBContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> users { get; set; }

        public UserDBContext()
        {
        }

        public UserDBContext(DbContextOptions<UserDBContext> options)
        : base(options)
        {
        }
    }
}
