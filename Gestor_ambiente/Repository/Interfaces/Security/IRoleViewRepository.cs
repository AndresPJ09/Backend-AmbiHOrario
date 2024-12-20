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
    public interface IRoleViewRepository
    {
        Task<RoleView> GetById(int id);
        Task<IEnumerable<RoleView>> GetAll();
        Task<RoleView> Save(RoleView entity);
        Task Update(RoleView entity);
        Task Delete(int id);
        Task DeleteViews(int id);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
