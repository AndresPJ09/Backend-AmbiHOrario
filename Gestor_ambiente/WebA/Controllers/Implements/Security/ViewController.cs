using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Security;
using Service.Interfaces.Security;
using System.Text.RegularExpressions;

namespace WebA.Controllers.Implements.Security
{
    [Route("api/View")]
    [ApiController]
    public class ViewController : ControllerBase, IViewController
    {
        protected readonly IViewService business;

        public ViewController(IViewService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ViewDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ViewDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ViewDto view)
        {
            if (view == null)
            {
                return BadRequest("Entity is null");
            }
            try
            {
                ValidateView(view);

                var result = await business.Save(view);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ViewDto view)
        {
            if (view == null)
            {
                return BadRequest();
            }
            try
            {
                ValidateView(view);

                await business.Update(view);
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

        private void ValidateView(ViewDto view)
        {
            // Validar Name: máximo 15 caracteres y solo letras
            if (string.IsNullOrWhiteSpace(view.Name) || view.Name.Length > 25)
            {
                throw new Exception("El nombre no puede estar vacío y no debe superar los 15 caracteres.");
            }

            if (!Regex.IsMatch(view.Name, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                throw new Exception("El nombre solo puede contener letras y espacios.");
            }

            // Validar Description: máximo 100 caracteres y solo letras y signos comunes
            if (string.IsNullOrWhiteSpace(view.Description) || view.Description.Length > 100)
            {
                throw new Exception("La descripción no puede estar vacía y no debe superar los 100 caracteres.");
            }

            if (!Regex.IsMatch(view.Description, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s.,;!?]+$"))
            {
                throw new Exception("La descripción solo puede contener letras, espacios y signos comunes.");
            }

            // Validar Route: debe comenzar con "/" y solo permitir letras
            if (string.IsNullOrWhiteSpace(view.Route) || !view.Route.StartsWith("/"))
            {
                throw new Exception("La ruta debe comenzar con '/'.");
            }

            if (!Regex.IsMatch(view.Route.Substring(1), @"^[a-zA-Z]+$"))
            {
                throw new Exception("La ruta solo puede contener letras después de '/'. No se permiten números.");
            }
        }

    }
}
