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

        private readonly IControllerService<UserDTO> _controllerService;
        //or IHomeControllerService
        public HomeController(IControllerService<UserDTO> controllerService)
        {
            _controllerService = controllerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
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

    }
}
