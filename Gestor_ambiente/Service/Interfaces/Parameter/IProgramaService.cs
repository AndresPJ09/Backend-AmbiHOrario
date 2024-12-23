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
    public interface IProgramaService
    {
        Task<ProgramaDto> GetById(int id);
        Task<IEnumerable<ProgramaDto>> GetAll();
        Task<Programa> Save(ProgramaDto entity);
        Task Update(ProgramaDto entity);
        Task Delete(int id);
        Programa mapearDatos(Programa programa, ProgramaDto entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
