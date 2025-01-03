using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using Repository.Interfaces.Operational;
using Service.Interfaces.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Implements.Operational
{
    public class ConsolidadoHorarioService : IConsolidadoHorarioService
    {
        private readonly IConsolidadoHorarioRepository data;

        public ConsolidadoHorarioService(IConsolidadoHorarioRepository data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<ConsolidadoHorarioDto>> GetAll()
        {
            IEnumerable<ConsolidadoHorarioDto> ConsolidadoHorarios = await data.GetAll();
            var consolidadoHorarioDtos = ConsolidadoHorarios.Select(ConsolidadoHorario => new ConsolidadoHorarioDto
            {
                Id = ConsolidadoHorario.Id,
                FichaID = ConsolidadoHorario.FichaID,
                InstructorId = ConsolidadoHorario.InstructorId,
                Observaciones = ConsolidadoHorario.Observaciones,
                State = ConsolidadoHorario.State
            });

            return consolidadoHorarioDtos;
        }

        public async Task<ConsolidadoHorarioDto> GetById(int id)
        {
            ConsolidadoHorario consolidadoHorario = await data.GetById(id);
            ConsolidadoHorarioDto consolidadoHorarioDto = new ConsolidadoHorarioDto();

            consolidadoHorarioDto.Id = consolidadoHorario.Id;
            consolidadoHorarioDto.FichaID = consolidadoHorario.FichaID;
            consolidadoHorarioDto.InstructorId = consolidadoHorario.InstructorId;
            consolidadoHorarioDto.Observaciones = consolidadoHorario.Observaciones;
            consolidadoHorarioDto.State = consolidadoHorario.State;
            return consolidadoHorarioDto;
        }

        public async Task<ConsolidadoHorario> Save(ConsolidadoHorarioDto entity)
        {
            ConsolidadoHorario consolidadoHorario = new ConsolidadoHorario();
            consolidadoHorario = mapearDatos(consolidadoHorario, entity);
            consolidadoHorario.CreatedAt = DateTime.Now;
            consolidadoHorario.State = true;
            consolidadoHorario.DeletedAt = null;
            consolidadoHorario.UpdatedAt = null;
            return await data.Save(consolidadoHorario);
        }

        public async Task Update(ConsolidadoHorarioDto entity)
        {
            ConsolidadoHorario consolidadoHorario = await data.GetById(entity.Id);
            if (consolidadoHorario == null)
            {
                throw new Exception("Registro no encontrado");
            }
            consolidadoHorario = mapearDatos(consolidadoHorario, entity);
            consolidadoHorario.UpdatedAt = DateTime.Now;

            await data.Update(consolidadoHorario);
        }

        public ConsolidadoHorario mapearDatos(ConsolidadoHorario consolidadoHorario, ConsolidadoHorarioDto entity)
        {
            consolidadoHorario.Id = entity.Id;
            consolidadoHorario.FichaID = entity.FichaID;
            consolidadoHorario.InstructorId = entity.InstructorId;
            consolidadoHorario.Observaciones = entity.Observaciones;
            consolidadoHorario.State = entity.State;
            return consolidadoHorario;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }
    }
}
