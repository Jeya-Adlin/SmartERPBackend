using SmartERPBackend.Models;

namespace SmartERPBackend.Repositories
{
    public interface ICompanyRepository
    {
       Task<List<Companies>> GetAllAsync();
       Task<Companies> GetByIdAsync(int id);
       Task<Companies> CreateCompanyAsync(Companies companies);

    }
}
