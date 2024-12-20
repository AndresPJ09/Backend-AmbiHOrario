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
    public interface IUserRoleService
    {
        Task<UserRoleDto> GetById(int id);
        Task<IEnumerable<UserRoleDto>> GetAll();
        Task<UserRole> Save(UserRoleDto entity);
        Task Update(UserRoleDto entity);
        Task Delete(int id);
        Task DeleteRoles(int id);
        UserRole mapearDatos(UserRole userRole, UserRoleDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
