using DataLayer;
using NTierProject;
using Microsoft.AspNetCore.Mvc;
using CoreLayer;
using BusinessLayer.Dto;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Congrate.Services.ControllerServices;
using CoreLayer.Utilities.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;


namespace NTierProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

        private readonly IUserControllerService _controllerService;
        //or IHomeControllerService
        public HomeController(IUserControllerService controllerService)
        {
            _controllerService = controllerService;
        }

        [Authorize]
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            var id = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var result = await _controllerService.Get(id);
            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                await _controllerService.Add(userDTO);
                return Ok("Kayıt başarıyla tamamlandı.");
            }
            else
            {
                return Ok("Kayıt esnasında bir hatayla karşılaşıldı.");
            }
            
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            var result = await _controllerService.GetAll();
            return new ObjectResult(result)
            {
                StatusCode = 200
            };
        }
    }
}
