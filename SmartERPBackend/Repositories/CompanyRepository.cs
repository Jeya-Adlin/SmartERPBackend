using Microsoft.EntityFrameworkCore;
using SmartERPBackend.Data;
using SmartERPBackend.Models;

namespace SmartERPBackend.Repositories
{
    public class CompanyRepository: ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Companies>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }
        public async Task<Companies> GetByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }
        public async Task<Companies> CreateCompanyAsync(Companies companies)
        {
            _context.Companies.Add(companies);
            await _context.SaveChangesAsync();
            return companies;
        }
    }
}
