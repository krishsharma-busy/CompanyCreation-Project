using System.Collections.Generic;
using System.Linq;
using Domain.DTO;
using Domain.GlobalVar;
using Controller.Mappers;
using Infrastructure.Repository;
using Domain.Interfaces;

namespace Controller.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService()
        {
            _repository = new AccountRepository();
        }

        public void Save(AccountDTO dto)
        {
            dto.CompanyId = GlobalVar.CompanyId;
            dto.UserId = GlobalVar.UserId;
            var entity = AccountMapper.ToEntity(dto);
            _repository.Save(entity);
        }

        public List<AccountDTO> ListAccounts()
        {
            var entities = _repository.GetByUserAndCompany(GlobalVar.UserId, GlobalVar.CompanyId);
            return entities.Select(e => AccountMapper.ToDTO(e)).ToList();
        }

        public List<AccountDTO> ListAllAccounts()
        {
            var entities = _repository.GetByCompanyId(GlobalVar.CompanyId);
            return entities.Select(e => AccountMapper.ToDTO(e)).ToList();
        }

        public bool IsAccountNameUnique(string name)
        {
            return !_repository.ExistsByNameAndCompany(name, GlobalVar.CompanyId);
        }
    }
}
