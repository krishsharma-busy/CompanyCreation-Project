using System.Collections.Generic;
using System.Linq;
using Domain.DTO;
using Domain.GlobalVar;
using Controller.Mappers;
using Infrastructure.Repository;
using Domain.Interfaces;

namespace Controller.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService()
        {
            _repository = new UserRepository();
        }

        public void Save(UserDTO dto)
        {
            dto.CompanyId = GlobalVar.CompanyId;
            var entity = UserMapper.ToEntity(dto);
            _repository.Save(entity);
        }

        public List<UserDTO> ListUsers()
        {
            var entities = _repository.GetByCompanyId(GlobalVar.CompanyId);
            return entities.Select(e => UserMapper.ToDTO(e)).ToList();
        }

        public bool CheckIfUserExists()
        {
            var users = _repository.GetByCompanyId(GlobalVar.CompanyId);
            return users.Count > 0;
        }

        public UserDTO Authenticate(string username, string password)
        {
            var entity = _repository.GetByCredentials(username, password, GlobalVar.CompanyId);
            if (entity != null)
            {
                GlobalVar.UserId = entity.Id;
                return UserMapper.ToDTO(entity);
            }
            return null;
        }
    }
}
