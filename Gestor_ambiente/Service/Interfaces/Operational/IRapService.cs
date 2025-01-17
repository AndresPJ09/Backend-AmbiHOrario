using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dto.Operational;
using Entity.Model.Operational;

namespace Service.Interfaces.Operational
{
    public interface IRapService
    {
        Task<RapDto> GetById(int id);
        Task<IEnumerable<RapDto>> GetAll();
        Task<Rap> Save(RapDto entity);
        Task Update(RapDto entity);
        Task Delete(int id);
        Rap mapearDatos(Rap rap, RapDto entity);
    }
}
