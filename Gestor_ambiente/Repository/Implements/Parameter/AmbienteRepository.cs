﻿using Entity.Context;
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
    public class AmbienteRepository: IAmbienteRepositoy
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public AmbienteRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.Ambientes.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Name, ' - ', Last_name) AS TextoMostrar 
                    FROM 
                        Ambientes
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Ambiente> GetById(int id)
        {
            var sql = @"SELECT * FROM Ambientes WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Ambiente>(sql, new { Id = id });
        }

        public async Task<Ambiente> Save(Ambiente entity)
        {
            context.Ambientes.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Ambiente entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AmbienteDto>> GetAll()
        {
            var sql = @"SELECT * FROM Ambientes Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<AmbienteDto>(sql);
        }
    }
}
