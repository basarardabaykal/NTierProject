using BusinessLayer.Congrate.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataLayer.DbContext _dbContext;

        public AuthRepository(DataLayer.DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Login()
        {
            //_dbContext.asfjasıgfagfa
            Console.WriteLine("ZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZZ");
        }
    }
}
