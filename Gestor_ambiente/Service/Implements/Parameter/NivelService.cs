using Entity.Dto.Parameter;
using Entity.Dto;
using Entity.Model.Parameter;
using Repository.Interfaces.Parameter;
using Service.Interfaces.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implements.Parameter
{
    public class NivelService : INivelService
    {
        private readonly INivelRepositoy data;

        public NivelService(INivelRepositoy data)
        {
            this.data = data;
        }

        public async Task<NivelDto> GetById(int id)
        {
            Nivel nivel = await data.GetById(id);
            NivelDto nivelDto = new NivelDto();

            nivel.Id = nivel.Id;
            nivelDto.Nombre = nivel.Nombre;
            nivelDto.Codigo = nivel.Codigo;
            nivelDto.Duracion = nivel.Duracion;
            nivelDto.State = nivel.State;
            return nivelDto;
        }

        public async Task<IEnumerable<NivelDto>> GetAll()
        {
            IEnumerable<NivelDto> niveles = await data.GetAll();
            var nivelDtos = niveles.Select(nivel => new NivelDto
            {
                Id = nivel.Id,
                Nombre = nivel.Nombre,
                Codigo = nivel.Codigo,
                Duracion = nivel.Duracion,
                State = nivel.State,
            });

            return nivelDtos;
        }

        public async Task<Nivel> Save(NivelDto entity)
        {
            Nivel nivel = new Nivel();
            nivel = mapearDatos(nivel, entity);
            nivel.CreatedAt = DateTime.Now;
            nivel.State = true;
            nivel.DeletedAt = null;
            nivel.UpdatedAt = null;
            return await data.Save(nivel);
        }

        public async Task Update(NivelDto entity)
        {
            Nivel nivel = await data.GetById(entity.Id);
            if (nivel == null)
            {
                throw new Exception("Registro no encontrado");
            }
            nivel = mapearDatos(nivel, entity);
            nivel.UpdatedAt = DateTime.Now;

            await data.Update(nivel);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public Nivel mapearDatos(Nivel nivel, NivelDto entity)
        {
            nivel.Id = entity.Id;
            nivel.Nombre = entity.Nombre;
            nivel.Codigo = entity.Codigo;
            nivel.Duracion = entity.Duracion;
            nivel.State = entity.State;
            return nivel;


        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }
    }
}
