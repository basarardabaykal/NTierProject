using BusinessLayer.Congrate.Services.ControllerServices;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Dto.Auth;


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
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDTO)
        {
            var result = await _controllerService.Login(loginDTO);

            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode,
            };
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerDTO)
        {
            var result = await _controllerService.Register(registerDTO);
            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode,
            };
        }
    }
}
