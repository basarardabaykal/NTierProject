using BusinessLayer.Congrate.Services;
using BusinessLayer.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class BranchController : Controller
    {
        private readonly IBranchControllerService _controllerService;
        public BranchController(IBranchControllerService controllerService)
        {
            _controllerService = controllerService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetBranch(Guid id)
        {
            var result = await _controllerService.Get(id);
            return new ObjectResult(result)
            {
                StatusCode = result.StatusCode
            };
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddBranch([FromBody] BranchDTO branchDTO)
        {
            if (ModelState.IsValid)
            {
                await _controllerService.Add(branchDTO);
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
