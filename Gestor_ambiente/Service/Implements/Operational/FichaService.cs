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
    public class FichaService : IFichaService
    {
        private readonly IFichaRepository data;

        public FichaService(IFichaRepository data)
        {
            this.data = data;
        }

        public async Task<FichaDto> GetById(int id)
        {
            Ficha ficha = await data.GetById(id);
            FichaDto fichaDto = new FichaDto();

            fichaDto.Id = ficha.Id;
            fichaDto.Codigo = ficha.Codigo;
            fichaDto.GestorId = ficha.GestorId;
            fichaDto.ProgramaId = ficha.ProgramaId;
            fichaDto.AmbienteId = ficha.AmbienteId;
            fichaDto.ProyectoId = ficha.ProyectoId;
            fichaDto.Fecha_inicio = ficha.Fecha_inicio;
            fichaDto.Fecha_fin = ficha.Fecha_fin;
            fichaDto.Fin_lectiva = ficha.Fin_lectiva;
            fichaDto.Estado_ideal_evalu_rap = ficha.Estado_ideal_evalu_rap;
            fichaDto.Num_semanas = ficha.Num_semanas;
            fichaDto.State = ficha.State;
            return fichaDto;
        }

        public async Task<IEnumerable<FichaDto>> GetAll()
        {
            IEnumerable<FichaDto> fichas = await data.GetAll();
            var fichaDtos = fichas.Select(ficha => new FichaDto
            {
                Id = ficha.Id,
                Codigo = ficha.Codigo,
                GestorId = ficha.GestorId,
                ProgramaId = ficha.ProgramaId,
                AmbienteId = ficha.AmbienteId,
                ProyectoId = ficha.ProyectoId,
                Fecha_inicio = ficha.Fecha_inicio,
                Fecha_fin = ficha.Fecha_fin,
                Fin_lectiva = ficha.Fin_lectiva,
                Estado_ideal_evalu_rap = ficha.Estado_ideal_evalu_rap,
                Num_semanas = ficha.Num_semanas,
                State = ficha.State,
            });

            return fichaDtos;
        }

        public async Task<Ficha> Save(FichaDto entity)
        {
            Ficha ficha = new Ficha();
            ficha = mapearDatos(ficha, entity);
            ficha.CreatedAt = DateTime.Now;
            ficha.State = true;
            ficha.DeletedAt = null;
            ficha.UpdatedAt = null;
            return await data.Save(ficha);
        }

        public async Task Update(FichaDto entity)
        {
            Ficha ficha = await data.GetById(entity.Id);
            if (ficha == null)
            {
                throw new Exception("Registro no encontrado");
            }
            ficha = mapearDatos(ficha, entity);
            ficha.UpdatedAt = DateTime.Now;

            await data.Update(ficha);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public Ficha mapearDatos(Ficha ficha, FichaDto entity)
        {
            ficha.Id = entity.Id;
            ficha.Codigo = entity.Codigo;
            ficha.GestorId = entity.GestorId;
            ficha.ProgramaId = entity.ProgramaId;
            ficha.AmbienteId = entity.AmbienteId;
            ficha.ProyectoId = entity.ProyectoId;
            ficha.Fecha_inicio = entity.Fecha_inicio;
            ficha.Fecha_fin = entity.Fecha_fin;
            ficha.Fin_lectiva = entity.Fin_lectiva;
            ficha.Estado_ideal_evalu_rap = entity.Estado_ideal_evalu_rap;
            ficha.Num_semanas = entity.Num_semanas;
            ficha.State = entity.State;
            return ficha;


        }

    }
}
