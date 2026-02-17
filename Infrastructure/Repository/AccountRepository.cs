using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public AccountRepository()
        {
            _context = new AppDbContext();
        }

        public void Save(AccountEntity account)
        {
            if (account.Id == 0)
            {
                _context.Accounts.Add(account);
            }
            else
            {
                _context.Entry(account).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public async Task SaveAsync(AccountEntity account)
        {
            if (account.Id == 0)
            {
                _context.Accounts.Add(account);
            }
            else
            {
                _context.Entry(account).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        public List<AccountEntity> GetByCompanyId(int companyId)
        {
            return _context.Accounts.Where(a => a.CompanyId == companyId).ToList();
        }

        public async Task<List<AccountEntity>> GetByCompanyIdAsync(int companyId)
        {
            return await _context.Accounts.Where(a => a.CompanyId == companyId).ToListAsync();
        }

        public List<AccountEntity> GetByUserAndCompany(int userId, int companyId)
        {
            return _context.Accounts.Where(a => a.UserId == userId && a.CompanyId == companyId).ToList();
        }

        public async Task<List<AccountEntity>> GetByUserAndCompanyAsync(int userId, int companyId)
        {
            return await _context.Accounts.Where(a => a.UserId == userId && a.CompanyId == companyId).ToListAsync();
        }

        public bool ExistsByNameAndCompany(string name, int companyId)
        {
            return _context.Accounts.Any(a => a.Name == name && a.CompanyId == companyId);
        }
    }
}
