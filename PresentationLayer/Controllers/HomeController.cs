using DataLayer;
using NTierProject;
using Microsoft.AspNetCore.Mvc;

namespace NTierProject.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {

        private readonly UserDA _userDA;
        public HomeController(UserDA userDA)
        {
            _userDA = userDA;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            await _userDA.LoadData(id);
            return Ok(_userDA);
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] UserDTO userDTO)
        {
            await _userDA.SendData(userDTO);
            return Ok("Kayıt başarıyla tamamlandı.");
        }

    }
}
