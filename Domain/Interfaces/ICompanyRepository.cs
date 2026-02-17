using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface ICompanyRepository
    {
        void Add(CompanyEntity company);
        Task AddAsync(CompanyEntity company);
        List<CompanyEntity> GetAll();
        Task<List<CompanyEntity>> GetAllAsync();
        CompanyEntity GetById(int id);
        Task<CompanyEntity> GetByIdAsync(int id);
        bool ExistsByGstin(string gstin);
    }
}
