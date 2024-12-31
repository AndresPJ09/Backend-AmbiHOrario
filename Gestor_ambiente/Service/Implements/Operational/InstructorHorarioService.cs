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
    public class InstructorHorarioService : IInstructorHorarioService
    {
        private readonly IInstructoHorarioRepository data;

        public InstructorHorarioService(IInstructoHorarioRepository data)
        {
            this.data = data;
        }

        public async Task<InstructorHorarioDto> GetById(int id)
        {
            InstructorHorario instructorHorario = await data.GetById(id);
            InstructorHorarioDto instructorHorarioDto = new InstructorHorarioDto();

            instructorHorarioDto.Id = instructorHorario.Id;
            instructorHorarioDto.InstructorId = instructorHorario.InstructorId;
            instructorHorarioDto.HorarioId = instructorHorario.HorarioId;
            instructorHorarioDto.Observaciones = instructorHorario.Observaciones;
            instructorHorarioDto.State = instructorHorario.State;
            return instructorHorarioDto;
        }

        public async Task<IEnumerable<InstructorHorarioDto>> GetAll()
        {
            IEnumerable<InstructorHorarioDto> instructorHorarios = await data.GetAll();
            var instructorHorarioDtos = instructorHorarios.Select(instructorHorario => new InstructorHorarioDto
            {
                Id = instructorHorario.Id,
                InstructorId = instructorHorario.InstructorId,
                HorarioId = instructorHorario.HorarioId,
                Observaciones = instructorHorario.Observaciones,
                State = instructorHorario.State,
            });

            return instructorHorarioDtos;
        }

        public async Task<InstructorHorario> Save(InstructorHorarioDto entity)
        {
            InstructorHorario instructorHorario = new InstructorHorario();
            instructorHorario = mapearDatos(instructorHorario, entity);
            instructorHorario.CreatedAt = DateTime.Now;
            instructorHorario.State = true;
            instructorHorario.DeletedAt = null;
            instructorHorario.UpdatedAt = null;
            return await data.Save(instructorHorario);
        }

        public async Task Update(InstructorHorarioDto entity)
        {
            InstructorHorario instructorHorario = await data.GetById(entity.Id);
            if (instructorHorario == null)
            {
                throw new Exception("Registro no encontrado");
            }
            instructorHorario = mapearDatos(instructorHorario, entity);
            instructorHorario.UpdatedAt = DateTime.Now;

            await data.Update(instructorHorario);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public InstructorHorario mapearDatos(InstructorHorario instructorHorario, InstructorHorarioDto entity)
        {
            instructorHorario.Id = entity.Id;
            instructorHorario.InstructorId = entity.InstructorId;
            instructorHorario.HorarioId = entity.HorarioId;
            instructorHorario.Observaciones = entity.Observaciones;
            instructorHorario.State = entity.State;
            return instructorHorario;


        }
    }
}
