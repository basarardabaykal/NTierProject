using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using CoreLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Authorization;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly ICompanyControllerService _controllerService;
        public CompanyController(ICompanyControllerService controllerService)
        {
            _controllerService = controllerService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var result = await _controllerService.Get(id);
            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddCompany([FromBody] CompanyDTO companyDTO)
        {
            if (ModelState.IsValid)
            {
                await _controllerService.Add(companyDTO);
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
                StatusCode = 200
            };
        }

    }
}
