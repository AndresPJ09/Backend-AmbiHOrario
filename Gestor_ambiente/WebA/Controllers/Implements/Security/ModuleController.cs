using Entity.Dto;
using Entity.Dto.Security;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Security;
using WebA.Controllers.Interfaces.Security;

namespace WebA.Controllers.Implements.Security
{
    [Route("api/Module")]
    [ApiController]
    public class ModuleController : ControllerBase, IModuloController
    {
        protected readonly IModuleService business;

        public ModuleController(IModuleService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ModuleDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ModuleDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ModuleDto modulo)
        {
            // Validar los datos de entrada
            if (modulo == null)
            {
                return BadRequest("La entidad no puede ser nula.");
            }

            try
            {
                ValidateInput(modulo); // Validar los datos antes de enviarlos al servicio
                var result = await business.Save(modulo);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ModuleDto modulo)
        {
            if (modulo == null)
            {
                return BadRequest();
            }

            try
            {
                ValidateInput(modulo);
            await business.Update(modulo);
            return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await business.Delete(id);
            return NoContent();
        }

        [HttpGet("AllSelect")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect()
        {
            var result = await business.GetAllSelect();
            return Ok(result);
        }

        // Método para validar datos de entrada
        private void ValidateInput(ModuleDto entity)
        {
            // Validar el nombre
            if (string.IsNullOrWhiteSpace(entity.Name))
            {
                throw new Exception("El nombre del módulo es obligatorio.");
            }

            if (entity.Name.Length > 50)
            {
                throw new Exception("El nombre del módulo no puede superar los 50 caracteres.");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(entity.Name, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new Exception("El nombre del módulo solo puede contener letras y espacios.");
            }

            // Validar la descripción
            if (string.IsNullOrWhiteSpace(entity.Description))
            {
                throw new Exception("La descripción del módulo es obligatoria.");
            }

            if (entity.Description.Length > 100)
            {
                throw new Exception("La descripción del módulo no puede superar los 100 caracteres.");
            }

            // Validar la posición
            if (entity.Position <= 0)
            {
                throw new Exception("La posición del módulo debe ser mayor a 0.");
            }

            if (entity.Position > 5)
            {
                throw new Exception("La posición del módulo no puede ser mayor a 5.");
            }
        }
    }
}