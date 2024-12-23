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
    public class AmbienteService : IAmbienteService
    {
        private readonly IAmbienteRepositoy data;

        public AmbienteService(IAmbienteRepositoy data)
        {
            this.data = data;
        }

        public async Task<AmbienteDto> GetById(int id)
        {
            Ambiente ambiente = await data.GetById(id);
            AmbienteDto ambienteDto = new AmbienteDto();

            ambienteDto.Id = ambiente.Id;
            ambienteDto.Nombre = ambiente.Nombre;
            ambienteDto.Codigo = ambiente.Codigo;
            ambienteDto.Cupo = ambiente.Cupo;
            ambienteDto.State = ambiente.State;
            return ambienteDto;
        }

        public async Task<IEnumerable<AmbienteDto>> GetAll()
        {
            IEnumerable<AmbienteDto> ambientes = await data.GetAll();
            var ambienteDtos = ambientes.Select(ambiente => new AmbienteDto
            {
                Id = ambiente.Id,
                Nombre = ambiente.Nombre,
                Codigo = ambiente.Codigo,
                Cupo = ambiente.Cupo,
                State = ambiente.State,
            });

            return ambienteDtos;
        }

        public async Task<Ambiente> Save(AmbienteDto entity)
        {
            Ambiente ambiente = new Ambiente();
            ambiente = mapearDatos(ambiente, entity);
            ambiente.CreatedAt = DateTime.Now;
            ambiente.State = true;
            ambiente.DeletedAt = null;
            ambiente.UpdatedAt = null;
            return await data.Save(ambiente);
        }

        public async Task Update(AmbienteDto entity)
        {
            Ambiente ambiente = await data.GetById(entity.Id);
            if (ambiente == null)
            {
                throw new Exception("Registro no encontrado");
            }
            ambiente = mapearDatos(ambiente, entity);
            ambiente.UpdatedAt = DateTime.Now;

            await data.Update(ambiente);
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public Ambiente mapearDatos(Ambiente ambiente, AmbienteDto entity)
        {
            ambiente.Id = entity.Id;
            ambiente.Nombre = entity.Nombre;
            ambiente.Codigo = entity.Codigo;
            ambiente.Cupo = entity.Cupo;
            ambiente.State = entity.State;
            return ambiente;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }
    }
}
