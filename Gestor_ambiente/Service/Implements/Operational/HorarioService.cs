﻿using Entity.Dto.Operational;
using Entity.Model.Operational;
using Repository.Interfaces.Operational;
using Service.Interfaces.Operational;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements.Operational
{
    public class HorarioService : IHorarioService
    {
        private readonly IHorarioRepository data;

        public HorarioService(IHorarioRepository data)
        {
            this.data = data;
        }

        public async Task<HorarioDto> GetById(int id)
        {
            Horario horario = await data.GetById(id);
            HorarioDto horarioDto = new HorarioDto();

            horarioDto.Id = horario.Id;
            horarioDto.UserId = horario.UserId;
            horarioDto.FichaId = horario.FichaId;
            horarioDto.AmbienteId = horario.AmbienteId;
            horarioDto.PeriodoId = horario.PeriodoId;
            horarioDto.Jornada_programa = horario.Jornada_programa;
            horarioDto.Fecha_inicio = horario.Fecha_inicio;
            horarioDto.Hora_ingreso = horario.Hora_ingreso;
            horarioDto.Hora_egreso = horario.Hora_egreso;
            horarioDto.Horas = horario.Horas;
            horarioDto.Validación = horario.Validación;
            horarioDto.Observaciones = horario.Observaciones;
            horarioDto.State = horario.State;
            return horarioDto;
        }

        public async Task<IEnumerable<HorarioDto>> GetAll()
        {
            IEnumerable<HorarioDto> horarios = await data.GetAll();
            var horarioDtos = horarios.Select(horario => new HorarioDto
            {
                Id = horario.Id,
                UserId = horario.UserId,
                FichaId = horario.FichaId,
                AmbienteId = horario.AmbienteId,
                PeriodoId = horario.PeriodoId,
                Jornada_programa = horario.Jornada_programa,
                Fecha_inicio = horario.Fecha_inicio,
                Hora_ingreso = horario.Hora_ingreso,
                Hora_egreso = horario.Hora_egreso,
                Horas = horario.Horas,
                Validación = horario.Validación,
                Observaciones = horario.Observaciones,
                State = horario.State,
            });

            return horarioDtos;
        }

        public async Task<Horario> Save(HorarioDto entity)
        {
            // Obtener la ficha relacionada
            var ambiente = await data.GetAmbientesById(entity.AmbienteId);
            if (ambiente == null)
            {
                throw new ValidationException("Ficha no encontrada.");
            }
            if (!ambiente.State)
            {
                throw new ValidationException("El ambiente no existe o está inactivo.");
            }


            Horario horario = new Horario();
            horario = mapearDatos(horario, entity);
            horario.CreatedAt = DateTime.Now;
            horario.State = true;
            horario.DeletedAt = null;
            horario.UpdatedAt = null;
            return await data.Save(horario);
        }

        public async Task Update(HorarioDto entity)
        {
            Horario horario = await data.GetById(entity.Id);
            if (horario == null)
            {
                throw new Exception("Registro no encontrado");
            }
            horario = mapearDatos(horario, entity);
            horario.UpdatedAt = DateTime.Now;

            await data.Update(horario);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public Horario mapearDatos(Horario horario, HorarioDto entity)
        {
            horario.Id = entity.Id;
            horario.UserId = entity.UserId;
            horario.FichaId = entity.FichaId;
            horario.AmbienteId = entity.AmbienteId;
            horario.PeriodoId = entity.PeriodoId;
            horario.Jornada_programa = entity.Jornada_programa;
            horario.Validación = entity.Validación;
            horario.Horas = entity.Horas;
            horario.Hora_ingreso = entity.Hora_ingreso;
            horario.Hora_egreso = entity.Hora_egreso;
            horario.Observaciones = entity.Observaciones;
            horario.State = entity.State;
            return horario;


        }

    }
}
