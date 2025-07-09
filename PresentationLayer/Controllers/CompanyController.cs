using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using CoreLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Runtime.InteropServices;

namespace NTierProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private readonly IControllerService<CompanyDTO> _controllerService;
        public CompanyController(IControllerService<CompanyDTO> controllerService)
        {
            _controllerService = controllerService;
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCompany(Guid id)
        {
            var result = await _controllerService.Get(id);
            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }

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

    }
}
