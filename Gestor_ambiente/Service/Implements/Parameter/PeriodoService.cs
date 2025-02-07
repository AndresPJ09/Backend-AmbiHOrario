using Entity.Dto.Operational;
using Entity.Dto.Parameter;
using Entity.Model.Operational;
using Entity.Model.Parameter;
using Repository.Interfaces.Parameter;
using Service.Interfaces.Operational;
using Service.Interfaces.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements.Parameter
{
    public class PeriodoService : IPeriodoService
    {
        private readonly IPeriodoRepository data;

        public PeriodoService(IPeriodoRepository data)
        {
            this.data = data;
        }

        public async Task<PeriodoDto> GetById(int id)
        {
            Periodo periodo = await data.GetById(id);
            if (periodo == null)
            {
                throw new Exception("El módulo no existe.");
            }
            PeriodoDto periododto = new PeriodoDto();

            periododto.Id = periodo.Id;
            periododto.nombre = periodo.nombre;
            periododto.fecha_inicio = periodo.fecha_inicio;
            periododto.fecha_fin = periodo.fecha_fin;
            periododto.ano = periodo.ano;
            periododto.State = periodo.State;
            return periododto;
        }

        public async Task<IEnumerable<PeriodoDto>> GetAll()
        {
            IEnumerable<PeriodoDto> periodos = await data.GetAll();
            var periodoDtos = periodos.Select(periodo => new PeriodoDto
            {
                Id = periodo.Id,
                nombre = periodo.nombre,
                fecha_inicio = periodo.fecha_inicio,
                fecha_fin = periodo.fecha_fin,
                ano = periodo.ano,
                State = periodo.State
            });

            return periodoDtos;
        }
        public async Task<Periodo> Save(PeriodoDto entity)
        {
            // Validaciones de fechas
            if (entity.fecha_inicio.Year != entity.ano)
            {
                throw new Exception("El año de la fecha de inicio debe coincidir con el año indicado.");
            }

            if (entity.fecha_fin < entity.fecha_inicio)
            {
                throw new Exception("La fecha de fin no puede ser anterior a la fecha de inicio.");
            }

            if (entity.fecha_inicio.Year != entity.fecha_fin.Year)
            {
                throw new Exception("La fecha de inicio y la fecha de fin deben ser del mismo año.");
            }

            Periodo periodo = new Periodo();
            periodo = mapearDatos(periodo, entity);
            periodo.CreatedAt = DateTime.Now;
            periodo.State = true;
            periodo.DeletedAt = null;
            periodo.UpdatedAt = null;

            return await data.Save(periodo);
        }

        public async Task Update(PeriodoDto entity)
        {
            Periodo periodo = await data.GetById(entity.Id);
            if (periodo == null)
            {
                throw new Exception("Registro no encontrado");
            }

            // Validaciones de fechas
            if (entity.fecha_inicio.Year != entity.ano)
            {
                throw new Exception("El año de la fecha de inicio debe coincidir con el año indicado.");
            }

            if (entity.fecha_fin < entity.fecha_inicio)
            {
                throw new Exception("La fecha de fin no puede ser anterior a la fecha de inicio.");
            }

            if (entity.fecha_inicio.Year != entity.fecha_fin.Year)
            {
                throw new Exception("La fecha de inicio y la fecha de fin deben ser del mismo año.");
            }

            periodo = mapearDatos(periodo, entity);
            periodo.UpdatedAt = DateTime.Now;

            await data.Update(periodo);
        }

        public async Task Delete(int id)
        {
            Periodo periodo = await data.GetById(id);
            if (periodo == null)
            {
                throw new Exception("El módulo no existe.");
            }
            await data.Delete(id);
        }

        public Periodo mapearDatos(Periodo periodo, PeriodoDto entity)
        {
            periodo.Id = entity.Id;
            periodo.nombre = entity.nombre;
            periodo.fecha_inicio = entity.fecha_inicio;
            periodo.fecha_fin = entity.fecha_fin;
            periodo.ano = entity.ano;
            periodo.State = entity.State;
            return periodo;


        }
    }
}
