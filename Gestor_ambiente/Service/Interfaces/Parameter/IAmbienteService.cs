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
    public interface IAmbienteService
    {
        Task<AmbienteDto> GetById(int id);
        Task<IEnumerable<AmbienteDto>> GetAll();
        Task<Ambiente> Save(AmbienteDto entity);
        Task Update(AmbienteDto entity);
        Task Delete(int id);
        Ambiente mapearDatos(Ambiente ambiente, AmbienteDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
