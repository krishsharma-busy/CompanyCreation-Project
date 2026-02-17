using System.Collections.Generic;
using System.Linq;
using Domain.DTO;
using Domain.GlobalVar;
using Controller.Mappers;
using Infrastructure.Repository;
using Domain.Interfaces;

namespace Controller.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _repository;

        public CompanyService()
        {
            _repository = new CompanyRepository();
        }

        public void Save(CompanyDTO dto)
        {
            var entity = CompanyMapper.ToEntity(dto);
            _repository.Add(entity);
        }

        public List<CompanyDTO> ListCompanies()
        {
            var entities = _repository.GetAll();
            return entities.Select(e => CompanyMapper.ToDTO(e)).ToList();
        }

        public bool IsGstinUnique(string gstin)
        {
            return !_repository.ExistsByGstin(gstin);
        }

        public void Close()
        {
            GlobalVar.CompanyId = 0;
            GlobalVar.UserId = 0;
        }
    }
}
