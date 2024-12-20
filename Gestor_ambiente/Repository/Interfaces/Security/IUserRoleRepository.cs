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
    public interface IUserRoleRepository
    {
        Task<UserRole> GetById(int id);
        Task<IEnumerable<UserRole>> GetAll();
        Task<UserRole> Save(UserRole entity);
        Task Update(UserRole entity);
        Task Delete(int id);
        Task DeleteRoles(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
