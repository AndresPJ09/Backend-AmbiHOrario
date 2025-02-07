using Service.Implements.Additional;
using Service.Interfaces.Additional;
using Entity.Model.Security;
using Entity.Dto;
using Entity.Dto.Security;
using Repository.Interfaces.Security;
using Service.Interfaces.Security;
using System;
using Microsoft.Identity.Client;
using System.Text.Json;
using static Dapper.SqlMapper;
using Microsoft.EntityFrameworkCore;

namespace Service.Implements.Security
{
    public class UserService: IUserService
    {
        private readonly IUserRepository data;
        private readonly IUserRoleService userRoleService;
        private readonly IPersonService personService;
        private readonly IEmailService emailService;

        public UserService(IUserRepository data, IUserRoleService userRoleService, IEmailService emailService, IPersonService personService)
        {
            this.data = data;
            this.userRoleService = userRoleService;
            this.emailService = emailService;
            this.personService = personService;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<UserDto> GetById(int id)
        {
            UserDto user = await data.GetByIdAndRoles(id);
            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.PhotoBase64 = user.Photo != null ? Convert.ToBase64String(user.Photo) : null;
            userDto.Username = user.Username;
            userDto.Password = user.Password;
            userDto.PersonId = user.PersonId;
            userDto.State = user.State;
            if (user.roleString != null)
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                userDto.Roles = JsonSerializer.Deserialize<List<DataSelectDto>>(user.roleString, options);
            }

            return userDto;
        }

        public async Task<PasswordDto> GetByEmail(string email)
        {
            User user = await data.GetByEmail(email);
            PasswordDto passwordDto = new PasswordDto();
            Random random = new Random();

            if (user == null)
            {
                throw new Exception("Correo no registrado");
            }
            int codigoAleatorio = random.Next(1000, 10000);

            passwordDto.Id = user.Id;
            passwordDto.PersonId = user.PersonId;
            passwordDto.Code = codigoAleatorio.ToString();

            PersonDto person = await personService.GetById(passwordDto.PersonId);

            EmailDto emailDto = new EmailDto

            {
                Para = email,
                Asunto = "Código de verificación para restablecer contraseña",
                Contenido = $@"
<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Código de Verificación</title>
    <style>
        body {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }}
        .container {{
            width: 100%;
            padding: 20px;
        }}
        .card {{
            max-width: 500px;
            margin: 0 auto;
            background-color: #ffffff;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            overflow: hidden;
        }}
        .header {{
            background-color: #5EB319;
            color: white;
            text-align: center;
            font-size: 20px;
            font-weight: bold;
            padding: 15px;
        }}
        .logo {{
            text-align: center;
            padding: 20px 0;
        }}
        .logo img {{
            max-width: 150px;
        }}
        .content {{
            padding: 20px;
            color: #333;
            font-size: 16px;
        }}
        .code {{
            font-size: 22px;
            font-weight: bold;
            text-align: center;
            background-color: #5EB319;
            padding: 15px;
            margin: 10px 0;
            border: 2px dashed #ECF0F5;
            border-radius: 5px;
            color: #F7F7F7;
        }}
        .footer {{
            text-align: center;
            font-size: 12px;
            color: #777;
            padding: 15px;
            background-color: #f8f9fa;
        }}
    </style>
</head>
<body>
    <div class=""container"">
        <div class=""card"">
            <div class=""header"">
                Código de Verificación
            </div>
            <div class=""logo"">
                <img src=""https://oficinavirtualderadicacion.sena.edu.co/oficinavirtual/Resources/logoSenaNaranja.png"" alt=""Logo AmbiHorario"">
            </div>
            <div class=""content"">
                <p>Estimado/a <strong>{user.Username}</strong>,</p>
                <p>Hemos recibido una solicitud para restablecer su contraseña. Su código de verificación es:</p>
                <div class=""code"">
                    {codigoAleatorio}
                </div>
                <p>Por favor, use este código para completar el proceso de cambio de contraseña.</p>
                <p>Si no solicitó este cambio, ignore este mensaje.</p>
                <p>Saludos,<br>El equipo de soporte de <strong>AmbiHorario</strong></p>
            </div>
            <div class=""footer"">
                <p>*Este correo se ha generado automáticamente, por favor no responda.*</p>
            </div>
        </div>
    </div>
</body>
</html>
"
            };

            bool emailEnviado = await emailService.SendEmail(emailDto);

            if (!emailEnviado)
            {
                throw new Exception("Error al enviar el correo");
            }

            return passwordDto;
        }

        public async Task<User> Save(UserDto entity)
        {
            var users = await data.GetAll();

            // Validar que el username sea único
            if (users.Any(u => u.Username == entity.Username))
            {
                throw new Exception("El username ya existe.");
            }
            User user = new User();

            // Encripta la contraseña si se proporciona en el DTO
            if (!string.IsNullOrEmpty(entity.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
            }
            else
            {
                throw new Exception("La contraseña no puede estar vacía para un nuevo usuario.");
            }

            var existingUser = users.FirstOrDefault(u => u.PersonId == entity.PersonId && u.Id != entity.Id);
            if (existingUser != null)
            {
                throw new Exception("Esta persona ya está asociada a otro usuario.");
            }

            user = mapearDatos(user, entity);
            user.CreatedAt = DateTime.Now;
            user.State = true;
            user.DeletedAt = null;
            user.UpdatedAt = null;

            User save = await data.Save(user);

            if (entity.Roles != null && entity.Roles.Count > 0)
            {
                foreach (var role in entity.Roles)
                {
                    UserRoleDto userole = new UserRoleDto();
                    userole.UserId = save.Id;
                    userole.RoleId = role.Id;
                    userole.State = true;
                    await userRoleService.Save(userole);
                }
            }

            PersonDto person = await personService.GetById(save.PersonId);

            EmailDto emailDto = new EmailDto
            {
                Para = person.Email,
                Asunto = "¡Bienvenido a AmbiHorario!",
                Contenido = $@"
<!DOCTYPE html>
<html lang=""es"">
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Bienvenido a AmbiHorario</title>
</head>
<body style=""font-family: Arial, sans-serif; margin: 0; padding: 0; text-align: center; background-color: #ffffff; color: #333;"">
    <div style=""width: 100%; padding: 20px;"">
        <div style=""max-width: 500px; margin: 0 auto; border-radius: 10px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); padding: 20px; background-color: #ffffff; border: 1px solid #e0e0e0;"">
            <div style=""text-align: center;"">
                <img src=""https://oficinavirtualderadicacion.sena.edu.co/oficinavirtual/Resources/logoSenaNaranja.png"" alt=""Logo AmbiHorario"" style=""max-width: 150px; margin-bottom: 15px;"">
                <h1 style=""font-size: 24px; font-weight: bold; color: #5EB319; margin: 0;"">¡Bienvenido a AmbiHorario!</h1>
            </div>
            <div style=""font-size: 16px; line-height: 1.6; padding: 20px 0;"">
                <h2 style=""color: #333;"">Hola, {save.Username} 👋</h2>
                <p>
                    Nos complace darte la bienvenida a <span style=""color: #5EB319; font-weight: bold;"">AmbiHorario</span>, 
                    la plataforma que transformará la manera en que gestionas los ambientes y horarios para los instructores.
                </p>
                <p>
                   Ahora puedes acceder a tu cuenta y comenzar a gestionar los ambientes y horarios 
                    de manera más rápida, eficiente y segura. Explora todas nuestras funcionalidades y comienza a 
                    optimizar tus procesos hoy mismo.
                </p>
                <a href=""#iniciar-sesion"" style=""display: inline-block; padding: 12px 20px; margin-top: 15px; text-decoration: none; font-size: 16px; font-weight: bold; border-radius: 5px; background-color: #5EB319; color: #ffffff; text-align: center;"">Iniciar Sesión</a>
            </div>
            <div style=""font-size: 12px; padding-top: 15px; color: #777;"">
                <p>&copy; 2024 AmbiHorario | Todos los derechos reservados</p>
            </div>
        </div>
    </div>  
</body>
</html>"
            };

            bool emailEnviado = await emailService.SendEmail(emailDto);

            if (!emailEnviado)
            {
                throw new Exception("Error al enviar el correo");
            }

            return save;

        }

        public async Task Update(UserDto entity)
        {
            User user = await data.GetById(entity.Id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }

            var users = await data.GetAll();

            // Validar que el username sea único (excluyendo al usuario actual)
            if (users.Any(u => u.Username == entity.Username && u.Id != entity.Id))
            {
                throw new Exception("El username ya existe.");
            }

            user = mapearDatos(user, entity);
            user.UpdatedAt = DateTime.Now;

            await userRoleService.DeleteRoles(user.Id);

            if (entity.Roles != null && entity.Roles.Count > 0)
            {
                foreach (var role in entity.Roles)
                {
                    UserRoleDto userole = new UserRoleDto();
                    userole.UserId = user.Id;
                    userole.RoleId = role.Id;
                    userole.State = true;
                    await userRoleService.Save(userole);
                }
            }

            await data.Update(user);
        }


        public async Task<IEnumerable<UserDto>> GetAll()
        {
            IEnumerable<UserDto> users = await data.GetAll();
            List<UserDto> userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                UserDto userDto = new UserDto();
                userDto.Id = user.Id;
                userDto.Username = user.Username;
                userDto.Password = user.Password;
                userDto.PhotoBase64 = user.Photo != null ? Convert.ToBase64String(user.Photo) : null;
                userDto.PersonId = user.PersonId;
                userDto.State = user.State;
                if (user.roleString != null)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    userDto.Roles = JsonSerializer.Deserialize<List<DataSelectDto>>(user.roleString, options);
                }
                userDtos.Add(userDto);
            }
            return userDtos;
        }

        public async Task<IEnumerable<UserDto>> GetAllByRole(int id)
        {
            IEnumerable<UserDto> users = await data.GetAllByRole(id);
            List<UserDto> userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                UserDto userDto = new UserDto();
                userDto.Id = user.Id;
                userDto.Username = user.Username;
                userDto.Password = user.Password;
                userDto.PhotoBase64 = user.Photo != null ? Convert.ToBase64String(user.Photo) : null;
                userDto.PersonId = user.PersonId;
                userDto.State = user.State;
                if (user.roleString != null)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    userDto.Roles = JsonSerializer.Deserialize<List<DataSelectDto>>(user.roleString, options);
                }
                userDtos.Add(userDto);
            }
            return userDtos;
        }

        public User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            if (!string.IsNullOrEmpty(entity.PhotoBase64))
            {
                user.Photo = Convert.FromBase64String(entity.PhotoBase64);
            }
            else
            {
                user.Photo = null;
            }
            if (!string.IsNullOrEmpty(entity.Username))
            {
                // Si se pasa un nuevo username, lo asignamos
                user.Username = entity.Username;
            }

            // Mantener el password actual si no se envía uno nuevo
            if (!string.IsNullOrEmpty(entity.Password))
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);
            }
            // Si la contraseña no se envía, no se cambia


            user.PersonId = entity.PersonId;
            user.State = entity.State;
            return user;
        }

        public async Task<IEnumerable<MenuDto>> Login(AuthenticationDto dto)
        {
            var login = await data.Login(dto.username);

            var user = login.First();

            if (login == null || !BCrypt.Net.BCrypt.Verify(dto.password, user.password))
            {
                throw new Exception("Usuario o contraseña incorrectos.");
            }

            List<MenuDto> menuDtos = new List<MenuDto>();

            foreach (var loginDto in login)
            {
                MenuDto menu = new MenuDto();
                menu.userID = loginDto.userID;
                menu.roleID = loginDto.roleID;
                menu.role = loginDto.role;
                if (loginDto.ListView != null)
                {
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    menu.ListView = JsonSerializer.Deserialize<List<moduleDao>>(loginDto.ListView, options);
                }

                menuDtos.Add(menu);
            }

            return menuDtos;
        }

        /*public async Task Patch(UserDto entity)
        {
            User user = await data.GetById(entity.Id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }
            user = cambioContraseña(user, entity);
            user.UpdatedAt = DateTime.Now;

            await userRoleService.DeleteRoles(user.Id);

            if (entity.Roles != null && entity.Roles.Count > 0)
            {
                foreach (var role in entity.Roles)
                {
                    UserRoleDto userole = new UserRoleDto();
                    userole.UserId = user.Id;
                    userole.RoleId = role.Id;
                    userole.State = true;
                    await userRoleService.Save(userole);
                }
            }

            await data.Update(user);
        }*/

        public async Task ChangePassword(ChangePasswordDto entity)
        {
            // Verifica si el usuario existe
            User user = await data.GetById(entity.UserId);
            if (user == null)
            {
                throw new Exception("El usuario no existe.");
            }

            // Valida la contraseña actual
            if (!BCrypt.Net.BCrypt.Verify(entity.CurrentPassword, user.Password))
            {
                throw new Exception("La contraseña actual es incorrecta.");
            }

            // Actualiza la contraseña con la nueva
            user.Password = BCrypt.Net.BCrypt.HashPassword(entity.NewPassword);
            user.UpdatedAt = DateTime.Now;

            // Guarda los cambios
            await data.Update(user);
        }


    }
}
