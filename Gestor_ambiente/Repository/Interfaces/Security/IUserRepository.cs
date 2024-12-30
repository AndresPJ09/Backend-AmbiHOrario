using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;


namespace Repository.Interfaces.Security
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<User> Save(User entity);
        Task Update(User entity);
        Task Delete(int id);
        Task<IEnumerable<UserDto>> GetAllByRole(int id);
        Task<User> GetByEmail(string email);
        Task<UserDto> GetByIdAndRoles(int id);
        Task<User> GetByUsername(string username);
        Task<User> GetByPassword(string password);
        Task<IEnumerable<LoginDto>> Login(string username);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
