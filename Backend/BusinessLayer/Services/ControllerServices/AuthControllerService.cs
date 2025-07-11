using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Services.DbServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.ControllerServices
{
    public class AuthControllerService : IAuthControllerService
    {
        private readonly IAuthDbService _authDbService;
        public AuthControllerService(IAuthDbService authDbService)
        {
            _authDbService = authDbService;
        }

        public async Task Login() 
        { 
            await _authDbService.Login();
        }
    }
}
