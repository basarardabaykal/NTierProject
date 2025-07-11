using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.DbServices;
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
        public async Task Login()
        {
            _authRepository.Login();
        }
    }
}
