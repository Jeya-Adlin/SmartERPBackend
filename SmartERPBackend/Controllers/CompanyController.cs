using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartERPBackend.Models;
using SmartERPBackend.Services;
using System.Data.Common;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SmartERPBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _service;
        public CompanyController(ICompanyService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] CreateCompanyDto dto)
        {
            try
            {
                var createdCompany = await _service.CreateCompanyAsync(dto);
                return CreatedAtAction(
               nameof(GetCompanyById),
               new { id = createdCompany.Id },
               createdCompany);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest("Database constraint violation (invalid reference data)");
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var companies = await _service.GetAllAsync();
            return Ok(companies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var company = await _service.GetByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }
    }
}
