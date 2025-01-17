using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model.Parameter;
using Entity.Dto.Parameter;

namespace Service.Interfaces.Parameter
{
    public interface IPeriodoService
    {
        Task<PeriodoDto> GetById(int id);
        Task<IEnumerable<PeriodoDto>> GetAll();
        Task<Periodo> Save(PeriodoDto entity);
        Task Update(PeriodoDto entity);
        Task Delete(int id);
        Periodo mapearDatos(Periodo periodo, PeriodoDto entity);
    }
}
