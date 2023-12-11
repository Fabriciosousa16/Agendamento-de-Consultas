using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.User
{
    public interface IUserService
    {
        Task<UserEntity> GetAsync(int id);
        Task<IEnumerable<UserEntity>> GetAllAsync();
        Task<UserEntity> PostAsync(UserEntity user);
        Task<UserEntity> PutAsync(UserEntity user);
        Task<UserEntity> DeleteAsync(int id);
    }
}
