using SmartERPBackend.Models;
using SmartERPBackend.Repositories;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SmartERPBackend.Services
{
    public class CompanyService:ICompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }

        public async Task<Companies> CreateCompanyAsync(CreateCompanyDto dto)
        {
            
            var company = new Companies
            {
                CompanyName = dto.CompanyName,
                Address = dto.Address,
                GSTNumber = dto.GstNumber,
                FinancialYear = dto.FinancialYear,
                State = dto.State,
                ContactNo = dto.ContactNo,
                UserId = dto.UserId
            };
            return await _repository.CreateCompanyAsync(company);
        }
        public async Task<List<Companies>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task<Companies> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
    }
}
