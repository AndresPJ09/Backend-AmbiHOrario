﻿using Entity.Context;
using Entity.Dto.Operational;
using Entity.Dto;
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
    public class ConsolidadoAmbienteRepository : IConsolidadoAmbienteRepository
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ConsolidadoAmbienteRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.ConsolidadoAmbientes.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<ConsolidadoAmbiente> GetById(int id)
        {
            var sql = @"SELECT * FROM ConsolidadoAmbientes WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<ConsolidadoAmbiente>(sql, new { Id = id });
        }

        public async Task<ConsolidadoAmbiente> Save(ConsolidadoAmbiente entity)
        {
            context.ConsolidadoAmbientes.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(ConsolidadoAmbiente entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ConsolidadoAmbienteDto>> GetAll()
        {
            var sql = @"SELECT * FROM ConsolidadoAmbientes Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<ConsolidadoAmbienteDto>(sql);
        }
        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        Observacion AS TextoMostrar 
                    FROM 
                        ConsolidadoAmbientes
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }
    }
}
