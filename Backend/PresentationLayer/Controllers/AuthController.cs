using BusinessLayer.Congrate.Services.ControllerServices;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Dto;


namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthControllerService _controllerService;

        public AuthController(IAuthControllerService controllerService)
        {
            _controllerService = controllerService;
        }

        [HttpPost("login")]
        public async Task Login([FromBody] LoginDTO loginDTO)
        {
            _controllerService.Login();
        }
    }
}
