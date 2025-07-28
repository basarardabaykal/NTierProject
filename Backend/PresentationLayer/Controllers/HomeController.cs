using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using CoreLayer;
using CoreLayer.Utilities.Interfaces;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NTierProject;
using Sprache;
using System.Security.Claims;


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

        [Authorize]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _controllerService.GetAll();
            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode,
            };
        }

        [Authorize(Roles ="Admin")]
        [HttpPatch("updatecompany")]
        public async Task<IActionResult> UpdateCompanyId([FromBody] UserDTO userDTO)
        {
            var result = await _controllerService.UpdateCompanyId(userDTO);
            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode,
            };     
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch("updatebranch")]
        public async Task<IActionResult> UpdateBranchId([FromBody] UserDTO userDTO)
        {
            var result = await _controllerService.UpdateBranchId(userDTO);
            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode,
            };
        }
    }
}
