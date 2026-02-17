using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IAccountRepository
    {
        void Save(AccountEntity account);
        Task SaveAsync(AccountEntity account);
        List<AccountEntity> GetByCompanyId(int companyId);
        Task<List<AccountEntity>> GetByCompanyIdAsync(int companyId);
        List<AccountEntity> GetByUserAndCompany(int userId, int companyId);
        Task<List<AccountEntity>> GetByUserAndCompanyAsync(int userId, int companyId);
        bool ExistsByNameAndCompany(string name, int companyId);
    }
}
