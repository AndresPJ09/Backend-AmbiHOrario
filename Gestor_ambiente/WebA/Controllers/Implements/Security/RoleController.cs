using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces.Security;
using WebA.Controllers.Interfaces.Security;
using System.Text.RegularExpressions;

namespace WebA.Controllers.Implements.Security
{
    [Route("api/Role")]
    [ApiController]
    public class RoleController : ControllerBase, IRoleController
    {
        protected readonly IRoleService business;

        public RoleController(IRoleService business)
        {
            this.business = business;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await business.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<RoleDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<RoleDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpGet("AllSelect")]
        public async Task<ActionResult<ApiResponse<IEnumerable<DataSelectDto>>>> GetAllSelect()
        {
            var result = business.GetAllSelect();
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RoleDto role)
        {
            if (role == null)
            {
                return BadRequest("Entity is null.");
            }

            try
            {
                ValidateRole(role);

                var result = await business.Save(role);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RoleDto role)
        {
            if (role == null)
            {
                return BadRequest();
            }

            try
            {
                ValidateRole(role);

                await business.Update(role);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        private void ValidateRole(RoleDto role)
        {
            // Validar Name: máximo 15 caracteres y solo letras
            if (string.IsNullOrWhiteSpace(role.Name) || role.Name.Length > 15)
            {
                throw new Exception("El nombre no puede estar vacío y no debe superar los 15 caracteres.");
            }

            if (!Regex.IsMatch(role.Name, @"^[a-zA-Z]+$"))
            {
                throw new Exception("El nombre solo puede contener letras.");
            }

            // Validar Description: máximo 100 caracteres y solo letras
            if (string.IsNullOrWhiteSpace(role.Description) || role.Description.Length > 100)
            {
                throw new Exception("La descripción no puede estar vacía y no debe superar los 100 caracteres.");
            }

            if (!Regex.IsMatch(role.Description, @"^[a-zA-Z\s]+$"))
            {
                throw new Exception("La descripción solo puede contener letras y espacios.");
            }
        }

    }
}
