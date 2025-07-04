using DataLayer;
using NTierProject;
using Microsoft.AspNetCore.Mvc;
using CoreLayer;
using BusinessLayer.Dto;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Congrate.Services.ControllerServices;


namespace NTierProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

        private readonly IControllerService _controllerService;
        public HomeController(IControllerService controllerService)
        {
            _controllerService = controllerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var userDto = await _controllerService.GetUser(id);
            return Ok(userDto);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                await _controllerService.AddUser(userDTO);
                return Ok("Kayıt başarıyla tamamlandı.");
            }
            else
            {
                return Ok("Kayıt esnasında bir hatayla karşılaşıldı.");
            }
            
        }

    }
}
