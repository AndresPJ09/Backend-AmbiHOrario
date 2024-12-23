using Entity.Dto;
using Entity.Dto.Parameter;
using Entity.Model.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces.Parameter
{
    public interface INivelService
    {
        Task<NivelDto> GetById(int id);
        Task<IEnumerable<NivelDto>> GetAll();
        Task<Nivel> Save(NivelDto entity);
        Task Update(NivelDto entity);
        Task Delete(int id);
        Nivel mapearDatos(Nivel nivel, NivelDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
