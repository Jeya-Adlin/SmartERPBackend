using SmartERPBackend.Models;

namespace SmartERPBackend.Services
{
    public interface ICompanyService
    {
        Task<Companies> CreateCompanyAsync(CreateCompanyDto companies);
        Task<List<Companies>> GetAllAsync();
        Task<Companies> GetByIdAsync(int id);
    }
}
