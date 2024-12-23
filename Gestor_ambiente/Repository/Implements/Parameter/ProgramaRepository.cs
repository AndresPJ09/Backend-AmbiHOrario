using Entity.Context;
using Entity.Dto.Parameter;
using Entity.Dto;
using Entity.Model.Parameter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Interfaces.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implements.Parameter
{
    public class ProgramaRepository: IProgramaRepositoy
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ProgramaRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.Programas.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Name, ' - ', Last_name) AS TextoMostrar 
                    FROM 
                        Programas
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Programa> GetById(int id)
        {
            var sql = @"SELECT * FROM Programas WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Programa>(sql, new { Id = id });
        }

        public async Task<Programa> Save(Programa entity)
        {
            context.Programas.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Programa entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProgramaDto>> GetAll()
        {
            var sql = @"SELECT * FROM Programas Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<ProgramaDto>(sql);
        }
    }
}
