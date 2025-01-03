using Entity.Context;
using Entity.Dto;
using Entity.Dto.Operational;
using Entity.Model.Operational;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces.Operational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements.Operational
{
    public class ConsolidadoHorarioRepository : IConsolidadoHorarioRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ConsolidadoHorarioRepository(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.DeletedAt = DateTime.Parse(DateTime.Today.ToString());
            entity.State = false;
            context.ConsolidadoHorarios.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<ConsolidadoHorario> GetById(int id)
        {
            var sql = @"SELECT * FROM ConsolidadoHorarios WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<ConsolidadoHorario>(sql, new { Id = id });
        }

        public async Task<ConsolidadoHorario> Save(ConsolidadoHorario entity)
        {
            context.ConsolidadoHorarios.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(ConsolidadoHorario entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ConsolidadoHorarioDto>> GetAll()
        {
            var sql = @"SELECT * FROM ConsolidadoHorarios Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<ConsolidadoHorarioDto>(sql);
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Observacion AS TextoMostrar 
                    FROM 
                        ConsolidadoHorarios
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
    }
}
