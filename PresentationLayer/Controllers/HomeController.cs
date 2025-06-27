using DataLayer;
using NTierProject;
using Microsoft.AspNetCore.Mvc;
using CoreLayer;
using BusinessLayer.Services.DbServices;

namespace NTierProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

        private readonly IUserDbService _userDbService;
        public HomeController(IUserDbService userDA)
        {
            _userDbService = userDA;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            await _userDbService.LoadData(id);
            return Ok(_userDbService);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            await _userDbService.SendData(userDTO);
            return Ok("Kayıt başarıyla tamamlandı.");
        }

    }
}
