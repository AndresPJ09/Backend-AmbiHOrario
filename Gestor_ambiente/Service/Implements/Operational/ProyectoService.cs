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
    public class ProyectoService : IProyectoService
    {
        private readonly IProyectoRepository data;

        public ProyectoService(IProyectoRepository data)
        {
            this.data = data;
        }

        public async Task<ProyectoDto> GetById(int id)
        {
            Proyecto instructorHorario = await data.GetById(id);
            ProyectoDto proyectoDto = new ProyectoDto();

            proyectoDto.Id = instructorHorario.Id;
            proyectoDto.Nombre = instructorHorario.Nombre;
            proyectoDto.ActividadId = instructorHorario.ActividadId;
            proyectoDto.Jornada_tecnica = instructorHorario.Jornada_tecnica;
            proyectoDto.Fase = instructorHorario.Fase;
            proyectoDto.State = instructorHorario.State;
            return proyectoDto;
        }

        public async Task<IEnumerable<ProyectoDto>> GetAll()
        {
            IEnumerable<ProyectoDto> proyectos = await data.GetAll();
            var proyectoDtos = proyectos.Select(proyecto => new ProyectoDto
            {
                Id = proyecto.Id,
                Nombre = proyecto.Nombre,
                ActividadId = proyecto.ActividadId,
                Jornada_tecnica = proyecto.Jornada_tecnica,
                Fase = proyecto.Fase,
                State = proyecto.State,
            });

            return proyectoDtos;
        }

        public async Task<Proyecto> Save(ProyectoDto entity)
        {
            Proyecto proyecto = new Proyecto();
            proyecto = mapearDatos(proyecto, entity);
            proyecto.CreatedAt = DateTime.Now;
            proyecto.State = true;
            proyecto.DeletedAt = null;
            proyecto.UpdatedAt = null;
            return await data.Save(proyecto);
        }

        public async Task Update(ProyectoDto entity)
        {
            Proyecto proyecto = await data.GetById(entity.Id);
            if (proyecto == null)
            {
                throw new Exception("Registro no encontrado");
            }
            proyecto = mapearDatos(proyecto, entity);
            proyecto.UpdatedAt = DateTime.Now;

            await data.Update(proyecto);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public Proyecto mapearDatos(Proyecto proyecto, ProyectoDto entity)
        {
            proyecto.Id = entity.Id;
            proyecto.Nombre = entity.Nombre;
            proyecto.ActividadId = entity.ActividadId;
            proyecto.Jornada_tecnica = entity.Jornada_tecnica;
            proyecto.Fase = entity.Fase;
            proyecto.State = entity.State;
            return proyecto;


        }

    }
}
