﻿using Entity.Dto.Operational;
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
    public class ActividadService : IActividadService
    {
        private readonly IActividadRepository data;

        public ActividadService(IActividadRepository data)
        {
            this.data = data;
        }

        public async Task<ActividadDto> GetById(int id)
        {
            Actividad actividad = await data.GetById(id);
            ActividadDto actividadDto = new ActividadDto();

            actividadDto.Id = actividad.Id;
            actividadDto.ProyectoId = actividad.ProyectoId;
            actividadDto.Actividad_proyecto = actividad.Actividad_proyecto;
            actividadDto.CompetenciaId = actividad.CompetenciaId;
            actividadDto.Result_aprendizaje = actividad.Result_aprendizaje;
            actividadDto.Fecha_inicio_Ac = actividad.Fecha_inicio_Ac;
            actividadDto.Fecha_fin_Ac = actividad.Fecha_fin_Ac;
            actividadDto.Estado_RAP = actividad.Estado_RAP;
            actividadDto.Num_semanas = actividad.Num_semanas;
            actividadDto.State = actividad.State;
            return actividadDto;
        }

        public async Task<IEnumerable<ActividadDto>> GetAll()
        {
            IEnumerable<ActividadDto> actividades = await data.GetAll();
            var actividadDtos = actividades.Select(actividad => new ActividadDto
            {
                Id = actividad.Id,
                ProyectoId = actividad.ProyectoId,
                Actividad_proyecto = actividad.Actividad_proyecto,
                CompetenciaId = actividad.CompetenciaId,
                Result_aprendizaje = actividad.Result_aprendizaje,
                Fecha_inicio_Ac = actividad.Fecha_inicio_Ac,
                Fecha_fin_Ac = actividad.Fecha_fin_Ac,
                Estado_RAP = actividad.Estado_RAP,
                Num_semanas = actividad.Num_semanas,
                State = actividad.State,
            });

            return actividadDtos;
        }

        public async Task<Actividad> Save(ActividadDto entity)
        {
            Actividad actividad = new Actividad();
            actividad = mapearDatos(actividad, entity);
            actividad.CreatedAt = DateTime.Now;
            actividad.State = true;
            actividad.DeletedAt = null;
            actividad.UpdatedAt = null;
            return await data.Save(actividad);
        }

        public async Task Update(ActividadDto entity)
        {
            Actividad actividad = await data.GetById(entity.Id);
            if (actividad == null)
            {
                throw new Exception("Registro no encontrado");
            }
            actividad = mapearDatos(actividad, entity);
            actividad.UpdatedAt = DateTime.Now;

            await data.Update(actividad);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public Actividad mapearDatos(Actividad actividad, ActividadDto entity)
        {
            actividad.Id = entity.Id;
            actividad.ProyectoId = entity.ProyectoId;
            actividad.Actividad_proyecto = entity.Actividad_proyecto;
            actividad.CompetenciaId = entity.CompetenciaId;
            actividad.Result_aprendizaje = entity.Result_aprendizaje;
            actividad.Fecha_inicio_Ac = entity.Fecha_inicio_Ac;
            actividad.Fecha_fin_Ac = entity.Fecha_fin_Ac;
            actividad.Estado_RAP = entity.Estado_RAP;
            actividad.Num_semanas = entity.Num_semanas;
            actividad.State = entity.State;
            return actividad;


        }

    }
}