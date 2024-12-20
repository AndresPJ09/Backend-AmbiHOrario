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
    public interface IViewService
    {
        Task<ViewDto> GetById(int id);
        Task<IEnumerable<ViewDto>> GetAll();
        Task<View> Save(ViewDto entity);
        Task Update(ViewDto entity);
        Task Delete(int id);
        View mapearDatos(View view, ViewDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
