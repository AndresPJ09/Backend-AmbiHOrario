using Entity.Dto.Operational;
using Entity.Model.Operational;
using Repository.Interfaces.Operational;
using Service.Interfaces.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements.Operational
{
    public class RapService : IRapService
    {
        private readonly IRapRepository data;

        public RapService(IRapRepository data)
        {
            this.data = data;
        }

        public async Task<RapDto> GetById(int id)
        {
            Rap rap = await data.GetById(id);
            if (rap == null)
            {
                throw new Exception("El módulo no existe.");
            }
            RapDto rapdto = new RapDto();

            rapdto.Id = rap.Id;
            rapdto.Descripción = rap.Descripcion;
            rapdto.CompetenciaId = rap.CompetenciaId;
            rapdto.estado_ideal_evaluacion_rap = rap.estado_ideal_evaluacion_rap;
            rapdto.State = rap.State;
            return rapdto;
        }

        public async Task<IEnumerable<RapDto>> GetAll()
        {
            IEnumerable<RapDto> raps = await data.GetAll();
            var rapDtos = raps.Select(rap => new RapDto
            {
                Id = rap.Id,
                Descripción = rap.Descripción,
                CompetenciaId = rap.CompetenciaId,
                estado_ideal_evaluacion_rap = rap.estado_ideal_evaluacion_rap,
                State = rap.State
            });

            return rapDtos;
        }

        public async Task<Rap> Save(RapDto entity)
        {

            Rap rap = new Rap();
            rap = mapearDatos(rap, entity);
            rap.CreatedAt = DateTime.Now;
            rap.State = true;
            rap.DeletedAt = null;
            rap.UpdatedAt = null;
            return await data.Save(rap);
        }

        public async Task Update(RapDto entity)
        {
            Rap rap = await data.GetById(entity.Id);
            if (rap == null)
            {
                throw new Exception("Registro no encontrado");
            }
            rap = mapearDatos(rap, entity);
            rap.UpdatedAt = DateTime.Now;

            await data.Update(rap);
        }

        public async Task Delete(int id)
        {
            Rap rap = await data.GetById(id);
            if (rap == null)
            {
                throw new Exception("El módulo no existe.");
            }
            await data.Delete(id);
        }

        public Rap mapearDatos(Rap rap, RapDto entity)
        {
            rap.Id = entity.Id;
            rap.Descripcion = entity.Descripción;
            rap.CompetenciaId = entity.CompetenciaId;
            rap.estado_ideal_evaluacion_rap = entity.estado_ideal_evaluacion_rap;
            rap.State = entity.State;
            return rap;


        }
    }
}
