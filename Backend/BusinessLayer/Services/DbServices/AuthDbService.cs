using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.DbServices;
using CoreLayer.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DbServices
{
    public class AuthDbService : IAuthDbService
    {
        private readonly IAuthRepository _authRepository;
        public AuthDbService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public async Task<AppUser> Login(string email, string password)
        {
            Console.WriteLine("YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY: " + email);
            var user = await _authRepository.GetUserByEmail(email);
            if (user == null)
            {
                Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            }
            if (await _authRepository.CheckPassword(user, password))
            {
                return user;    
            }
            else
            {
                return null;
            }
        }
    }
}
