using Entity.Dto.Security;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Security
{
    public interface IUserService
    {
        Task<UserDto> GetById(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<User> Save(UserDto entity);
        Task Update(UserDto entity);
        Task Delete(int id);
        User mapearDatos(User user, UserDto entity);
        Task<PasswordDto> GetByEmail(string email);
        Task<IEnumerable<UserDto>> GetAllByRole(int id);
        Task<IEnumerable<MenuDto>> Login(AuthenticationDto dto);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
