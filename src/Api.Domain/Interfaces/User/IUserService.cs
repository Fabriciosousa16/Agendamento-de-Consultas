using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;

namespace Api.Domain.Interfaces.User
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDtoCreateResult> PostAsync(UserDtoCreate user);
        Task<UserDtoUpdateResult> PutAsync(UserDtoUpdate user);
        Task<UserDto> DeleteAsync(int id);
    }
}
