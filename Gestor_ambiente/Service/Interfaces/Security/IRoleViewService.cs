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
    public interface IRoleViewService
    {
        Task<RoleViewDto> GetById(int id);
        Task<IEnumerable<RoleViewDto>> GetAll();
        Task<RoleView> Save(RoleViewDto entity);
        Task Update(RoleViewDto entity);
        Task Delete(int id);
        Task DeleteViews(int id);
        RoleView mapearDatos(RoleView roleView, RoleViewDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
