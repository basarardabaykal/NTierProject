using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using CoreLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

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

        public async Task<IActionResult> GetCompany(string id)
        {
            var result = await _controllerService.Get(id);
            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        } 

    }
}
