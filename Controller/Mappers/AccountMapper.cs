using Domain.DTO;
using Domain.Entity;

namespace Controller.Mappers
{
    public static class AccountMapper
    {
        public static AccountEntity ToEntity(AccountDTO dto)
        {
            return new AccountEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Group = dto.Group,
                Balance = dto.Balance,
                UserId = dto.UserId,
                CompanyId = dto.CompanyId
            };
        }

        public static AccountDTO ToDTO(AccountEntity entity)
        {
            return new AccountDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Group = entity.Group,
                Balance = entity.Balance,
                UserId = entity.UserId,
                CompanyId = entity.CompanyId
            };
        }
    }
}
