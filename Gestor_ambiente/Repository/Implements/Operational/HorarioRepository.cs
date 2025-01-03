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
    public class HorarioRepository : IHorarioRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public HorarioRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.Horarios.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<Horario> GetById(int id)
        {
            var sql = @"SELECT * FROM Horarios WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Horario>(sql, new { Id = id });
        }

        public async Task<Horario> Save(Horario entity)
        {
            context.Horarios.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Horario entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HorarioDto>> GetAll()
        {
            var sql = @"SELECT * FROM Horarios Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<HorarioDto>(sql);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Observaciones AS TextoMostrar 
                    FROM 
                        ConsolidadoHorarios
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
    }
}
