using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using CoreLayer.Entity;

namespace DataLayer
{
    public class UserDBContext : DbContext
    {
        public DbSet<User> users { get; set; }

        public UserDBContext()
        {
        }

        public UserDBContext(DbContextOptions<UserDBContext> options)
        : base(options)
        {
        }
    }
}
