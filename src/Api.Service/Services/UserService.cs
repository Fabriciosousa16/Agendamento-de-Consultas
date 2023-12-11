using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.User;

namespace Api.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<UserEntity> _repository;

        public UserService(IRepository<UserEntity> repository)
        {
            _repository = repository;
        }

        public async Task<UserEntity> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserEntity> PostAsync(UserEntity user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<UserEntity> PutAsync(UserEntity user)
        {
            await _repository.UpdateAsync(user);
            return user; // Retornando a entidade após a atualização
        }

        public async Task<UserEntity> DeleteAsync(int id)
        {
            var deletedUser = await _repository.DeleteAsync(id);
            return deletedUser; // Retornando a entidade excluída
        }
    }
}
