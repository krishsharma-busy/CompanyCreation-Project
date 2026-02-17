using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public UserRepository()
        {
            _context = new AppDbContext();
        }

        public void Save(UserEntity user)
        {
            if (user.Id == 0)
            {
                _context.Users.Add(user);
            }
            else
            {
                _context.Entry(user).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public async Task SaveAsync(UserEntity user)
        {
            if (user.Id == 0)
            {
                _context.Users.Add(user);
            }
            else
            {
                _context.Entry(user).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        public List<UserEntity> GetByCompanyId(int companyId)
        {
            return _context.Users.Where(u => u.CompanyId == companyId).ToList();
        }

        public async Task<List<UserEntity>> GetByCompanyIdAsync(int companyId)
        {
            return await _context.Users.Where(u => u.CompanyId == companyId).ToListAsync();
        }

        public UserEntity GetByCredentials(string username, string password, int companyId)
        {
            return _context.Users.FirstOrDefault(u =>
                u.Name == username &&
                u.Password == password &&
                u.CompanyId == companyId);
        }

        public async Task<UserEntity> GetByCredentialsAsync(string username, string password, int companyId)
        {
            return await _context.Users.FirstOrDefaultAsync(u =>
                u.Name == username &&
                u.Password == password &&
                u.CompanyId == companyId);
        }
    }
}
