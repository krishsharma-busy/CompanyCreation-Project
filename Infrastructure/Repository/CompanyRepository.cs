using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entity;
using Domain.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public CompanyRepository()
        {
            _context = new AppDbContext();
        }

        public void Add(CompanyEntity company)
        {
            if (company.Id == 0)
            {
                _context.Companies.Add(company);
            }
            else
            {
                _context.Entry(company).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public async Task AddAsync(CompanyEntity company)
        {
            if (company.Id == 0)
            {
                _context.Companies.Add(company);
            }
            else
            {
                _context.Entry(company).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }

        public List<CompanyEntity> GetAll()
        {
            return _context.Companies.ToList();
        }

        public async Task<List<CompanyEntity>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public CompanyEntity GetById(int id)
        {
            return _context.Companies.FirstOrDefault(c => c.Id == id);
        }

        public async Task<CompanyEntity> GetByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public bool ExistsByGstin(string gstin)
        {
            return _context.Companies.Any(c => c.Gstin == gstin);
        }
    }
}
