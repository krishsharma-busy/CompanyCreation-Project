using Domain.DTO;
using Domain.Entity;

namespace Controller.Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(UserDTO dto)
        {
            return new UserEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Password = dto.Password,
                CompanyId = dto.CompanyId
            };
        }

        public static UserDTO ToDTO(UserEntity entity)
        {
            return new UserDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Password = entity.Password,
                CompanyId = entity.CompanyId
            };
        }
    }
}
