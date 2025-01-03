using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebA.Controllers.Interfaces.Security;
using Service.Interfaces.Security;
using Service.Implements.Security;

namespace WebA.Controllers.Implements.Security
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserService business;

        public UserController(IUserService business)
        {
            this.business = business;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<UserDto>>> Get(int id)
        {
            var result = await business.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("/password")]
        public async Task<ActionResult<ApiResponse<PasswordDto>>> GetByEmail([FromBody] RecoveryDto email)
        {
            if (email == null)
            {
                return BadRequest("Email is null");
            }
            var result = business.GetByEmail(email.email);
            return CreatedAtAction(nameof(GetByEmail), new { data = result });
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserDto>>>> GetAll()
        {
            var result = await business.GetAll();
            return Ok(result);
        }

        [HttpGet("byRole/{id}")]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserDto>>>> GetAllByRole(int id)
        {
            var result = await business.GetAllByRole(id);
            return Ok(result);
        }

        [HttpPost("/login")]
        public async Task<ActionResult> Login(AuthenticationDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Entity is null");
            }
            var result = await business.Login(dto);
            if (result.IsNullOrEmpty())
            {
                return BadRequest("User no registrado");
            }
            return CreatedAtAction(nameof(Login), new { menu = result });
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("Entity is null");
            }
            try
            {
                ValidateInput(user);
                var result = await business.Save(user);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("La entidad no puede ser nula.");
            }

            try
            {
                ValidateInput(user);
                await business.Update(user);
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

        /*[HttpPatch]
        public async Task<ActionResult> Patch([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest("Entity is null");
            }

            var existingUser = await business.GetById(user.Id);
            if (existingUser == null)
            {
                return NotFound();
            }
     
            if (!string.IsNullOrEmpty(user.Password))
            {
                existingUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }

            await business.Patch(existingUser);

            return NoContent();
        }*/

        [HttpPatch("ChangePassword")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordDto entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.CurrentPassword) || string.IsNullOrEmpty(entity.NewPassword))
            {
                return BadRequest("Los datos de la solicitud no son válidos.");
            }

            try
            {
                // Llama al servicio para cambiar la contraseña
                await business.ChangePassword(entity);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void ValidateInput(UserDto user)
        {
            // Validación del Username
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                throw new Exception("El username es obligatorio.");
            }

            if (user.Username.Length > 15)
            {
                throw new Exception("El username no puede superar los 15 caracteres.");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(user.Username, @"^[a-zA-Z0-9]+$"))
            {
                throw new Exception("El username solo puede contener letras y números.");
            }

            // Validación de Password
            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                if (user.Password.Length < 8 || user.Password.Length > 15)
                {
                    throw new Exception("La contraseña debe tener entre 8 y 15 caracteres.");
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(user.Password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$"))
                {
                    throw new Exception("La contraseña debe tener al menos una letra mayúscula, un número y un carácter especial.");
                }
            }
        }
    }
}
