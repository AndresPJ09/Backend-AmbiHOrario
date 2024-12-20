using Entity.Dto;
using Entity.Dto.Security;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces.Security
{
    public interface IRoleRepository
    {
        Task<Role> GetById(int id);
        Task<IEnumerable<RoleDto>> GetAll();
        Task<Role> Save(Role entity);
        Task Update(Role entity);
        Task Delete(int id);
        Task<RoleDto> GetByIdAndViews(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
