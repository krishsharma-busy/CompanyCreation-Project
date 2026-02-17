using Domain.DTO;
using Domain.Entity;

namespace Controller.Mappers
{
    public static class CompanyMapper
    {
        public static CompanyEntity ToEntity(CompanyDTO dto)
        {
            return new CompanyEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Gstin = dto.Gstin,
                Country = dto.Country,
                State = dto.State
            };
        }

        public static CompanyDTO ToDTO(CompanyEntity entity)
        {
            return new CompanyDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Gstin = entity.Gstin,
                Country = entity.Country,
                State = entity.State
            };
        }
    }
}
