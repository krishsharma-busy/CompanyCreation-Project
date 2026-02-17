using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        void Save(UserEntity user);
        Task SaveAsync(UserEntity user);
        List<UserEntity> GetByCompanyId(int companyId);
        Task<List<UserEntity>> GetByCompanyIdAsync(int companyId);
        UserEntity GetByCredentials(string username, string password, int companyId);
        Task<UserEntity> GetByCredentialsAsync(string username, string password, int companyId);
    }
}
