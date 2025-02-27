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
    public class NivelRepository: INivelRepositoy
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public NivelRepository(ApplicationDBContext context, IConfiguration configuration)
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
            context.Niveles.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Name, ' - ', Last_name) AS TextoMostrar 
                    FROM 
                        Niveles
                    WHERE DeletedAt IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Nivel> GetById(int id)
        {
            var sql = @"SELECT * FROM Niveles WHERE Id = @Id ORDER BY Id ASC";
            return await context.QueryFirstOrDefaultAsync<Nivel>(sql, new { Id = id });
        }

        public async Task<Nivel> Save(Nivel entity)
        {
            context.Niveles.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Nivel entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NivelDto>> GetAll()
        {
            var sql = @"SELECT * FROM Niveles Where DeletedAt is null ORDER BY Id ASC";
            return await context.QueryAsync<NivelDto>(sql);
        }
    }
}
