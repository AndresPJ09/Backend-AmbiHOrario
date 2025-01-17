using Entity.Dto.Operational;
using Entity.Dto;
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
    public class ConsolidadoAmbienteService : IConsolidadoAmbienteService
    {
        private readonly IConsolidadoAmbienteRepository data;

        public ConsolidadoAmbienteService(IConsolidadoAmbienteRepository data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<ConsolidadoAmbienteDto>> GetAll()
        {
            IEnumerable<ConsolidadoAmbienteDto> ConsolidadoAmbientes = await data.GetAll();
            var consolidadoAmbienteDtos = ConsolidadoAmbientes.Select(ConsolidadoAmbiente => new ConsolidadoAmbienteDto
            {
                Id = ConsolidadoAmbiente.Id,
                FichaID = ConsolidadoAmbiente.FichaID,
                InstructorId = ConsolidadoAmbiente.InstructorId,
                Observaciones = ConsolidadoAmbiente.Observaciones,
                State = ConsolidadoAmbiente.State
            });

            return consolidadoAmbienteDtos;
        }

        public async Task<ConsolidadoAmbienteDto> GetById(int id)
        {
            ConsolidadoAmbiente consolidadoAmbiente = await data.GetById(id);
            ConsolidadoAmbienteDto consolidadoAmbienteDto = new ConsolidadoAmbienteDto();

            consolidadoAmbienteDto.Id = consolidadoAmbiente.Id;
            consolidadoAmbienteDto.FichaID = consolidadoAmbiente.FichaID;
            consolidadoAmbienteDto.InstructorId = consolidadoAmbiente.InstructorId;
            consolidadoAmbienteDto.Observaciones = consolidadoAmbiente.Observaciones;
            consolidadoAmbienteDto.State = consolidadoAmbiente.State;
            return consolidadoAmbienteDto;
        }

        public async Task<ConsolidadoAmbiente> Save(ConsolidadoAmbienteDto entity)
        {
            ConsolidadoAmbiente consolidadoAmbiente = new ConsolidadoAmbiente();
            consolidadoAmbiente = mapearDatos(consolidadoAmbiente, entity);
            consolidadoAmbiente.CreatedAt = DateTime.Now;
            consolidadoAmbiente.State = true;
            consolidadoAmbiente.DeletedAt = null;
            consolidadoAmbiente.UpdatedAt = null;
            return await data.Save(consolidadoAmbiente);
        }

        public async Task Update(ConsolidadoAmbienteDto entity)
        {
            ConsolidadoAmbiente consolidadoHorario = await data.GetById(entity.Id);
            if (consolidadoHorario == null)
            {
                throw new Exception("Registro no encontrado");
            }
            consolidadoHorario = mapearDatos(consolidadoHorario, entity);
            consolidadoHorario.UpdatedAt = DateTime.Now;

            await data.Update(consolidadoHorario);
        }

        public ConsolidadoAmbiente mapearDatos(ConsolidadoAmbiente consolidadoAmbiente, ConsolidadoAmbienteDto entity)
        {
            consolidadoAmbiente.Id = entity.Id;
            consolidadoAmbiente.FichaID = entity.FichaID;
            consolidadoAmbiente.InstructorId = entity.InstructorId;
            consolidadoAmbiente.Observaciones = entity.Observaciones;
            consolidadoAmbiente.State = entity.State;
            return consolidadoAmbiente;
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }
    }
}
