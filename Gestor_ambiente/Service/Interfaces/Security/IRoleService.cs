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
    public interface IRoleService
    {
        Task<RoleDto> GetById(int id);
        Task<IEnumerable<RoleDto>> GetAll();
        Task<Role> Save(RoleDto entity);
        Task Update(RoleDto entity);
        Task Delete(int id);
        Role mapearDatos(Role role, RoleDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();

    }
}
