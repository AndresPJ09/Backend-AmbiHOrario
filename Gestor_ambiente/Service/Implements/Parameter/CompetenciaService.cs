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
    public class CompetenciaService : ICompetenciaService
    {
        private readonly ICompetenciaRepositoy data;

        public CompetenciaService(ICompetenciaRepositoy data)
        {
            this.data = data;
        }

        public async Task<CompetenciaDto> GetById(int id)
        {
            Competencia competencia = await data.GetById(id);
            CompetenciaDto competenciaDto = new CompetenciaDto();

            competenciaDto.Id = competencia.Id;
            competenciaDto.Codigo = competencia.Codigo;
            competenciaDto.Nombre = competencia.Nombre;
            competenciaDto.State = competencia.State;
            return competenciaDto;
        }

        public async Task<IEnumerable<CompetenciaDto>> GetAll()
        {
            IEnumerable<CompetenciaDto> competencias = await data.GetAll();
            var competenciaDtos = competencias.Select(competencia => new CompetenciaDto
            {
                Id = competencia.Id,
                Codigo = competencia.Codigo,
                Nombre = competencia.Nombre,
                State = competencia.State,
            });

            return competenciaDtos;
        }

        public async Task<Competencia> Save(CompetenciaDto entity)
        {
            Competencia competencia = new Competencia();
            competencia = mapearDatos(competencia, entity);
            competencia.CreatedAt = DateTime.Now;
            competencia.State = true;
            competencia.DeletedAt = null;
            competencia.UpdatedAt = null;
            return await data.Save(competencia);
        }

        public async Task Update(CompetenciaDto entity)
        {
            Competencia competencia = await data.GetById(entity.Id);
            if (competencia == null)
            {
                throw new Exception("Registro no encontrado");
            }
            competencia = mapearDatos(competencia, entity);
            competencia.UpdatedAt = DateTime.Now;

            await data.Update(competencia);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public Competencia mapearDatos(Competencia competencia, CompetenciaDto entity)
        {
            competencia.Id = entity.Id;
            competencia.Codigo = entity.Codigo;
            competencia.Nombre = entity.Nombre;
            competencia.State = entity.State;
            return competencia;


        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }
    }
}
