using Entity.Dto.Parameter;
using Entity.Dto;
using Entity.Model.Parameter;
using Repository.Interfaces.Parameter;
using Service.Interfaces.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements.Parameter
{
    public class ProgramaService : IProgramaService
    {
        private readonly IProgramaRepositoy data;

        public ProgramaService(IProgramaRepositoy data)
        {
            this.data = data;
        }

        public async Task<ProgramaDto> GetById(int id)
        {
            Programa programa = await data.GetById(id);
            ProgramaDto programaDto = new ProgramaDto();

            programaDto.Id = programa.Id;
            programaDto.Nombre = programa.Nombre;
            programaDto.NivelId = programa.NivelId;
            programaDto.State = programa.State;
            return programaDto;
        }

        public async Task<IEnumerable<ProgramaDto>> GetAll()
        {
            IEnumerable<ProgramaDto> programas = await data.GetAll();
            var programaDtos = programas.Select(programa => new ProgramaDto
            {
                Id = programa.Id,
                Nombre = programa.Nombre,
                NivelId = programa.NivelId,
                State = programa.State,
            });

            return programaDtos;
        }

        public async Task<Programa> Save(ProgramaDto entity)
        {
            Programa programa = new Programa();
            programa = mapearDatos(programa, entity);
            programa.CreatedAt = DateTime.Now;
            programa.State = true;
            programa.DeletedAt = null;
            programa.UpdatedAt = null;
            return await data.Save(programa);
        }

        public async Task Update(ProgramaDto entity)
        {
            Programa programa = await data.GetById(entity.Id);
            if (programa == null)
            {
                throw new Exception("Registro no encontrado");
            }
            programa = mapearDatos(programa, entity);
            programa.UpdatedAt = DateTime.Now;

            await data.Update(programa);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public Programa mapearDatos(Programa programa, ProgramaDto entity)
        {
            programa.Id = entity.Id;
            programa.Nombre = entity.Nombre;
            programa.NivelId = entity.NivelId;
            programa.State = entity.State;
            return programa;


        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }
    }
}
