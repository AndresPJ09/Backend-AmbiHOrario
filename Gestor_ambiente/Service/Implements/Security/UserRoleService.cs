using Entity.Dto.Security;
using Entity.Dto;
using Entity.Model.Security;
using Service.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces.Security;

namespace Service.Implements.Security
{
    public class UserRoleService: IUserRoleService
    {
        protected readonly IUserRoleRepository data;

        public UserRoleService(IUserRoleRepository data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }
        public async Task DeleteRoles(int id)
        {
            await data.DeleteRoles(id);
        }

        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            IEnumerable<UserRole> userRoles = await data.GetAll();
            var userRoleDtos = userRoles.Select(userRole => new UserRoleDto
            {
                Id = userRole.Id,
                RoleId = userRole.RoleId,
                UserId = userRole.UserId,
                State = userRole.State
            });

            return userRoleDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<UserRoleDto> GetById(int id)
        {
            UserRole userRole = await data.GetById(id);
            UserRoleDto userRoleDto = new UserRoleDto();

            userRoleDto.Id = userRole.Id;
            userRoleDto.RoleId = userRole.RoleId;
            userRoleDto.UserId = userRole.UserId;
            userRoleDto.State = userRole.State;
            return userRoleDto;
        }

        public UserRole mapearDatos(UserRole userRole, UserRoleDto entity)
        {
            userRole.Id = entity.Id;
            userRole.UserId = entity.UserId;
            userRole.RoleId = entity.RoleId;
            userRole.State = entity.State;
            return userRole;
        }

        public async Task<UserRole> Save(UserRoleDto entity)
        {
            UserRole userRole = new UserRole();
            userRole = mapearDatos(userRole, entity);
            userRole.CreatedAt = DateTime.Now;
            userRole.State = true;
            userRole.UpdatedAt = null;
            userRole.DeletedAt = null;

            return await data.Save(userRole);
        }

        public async Task Update(UserRoleDto entity)
        {
            UserRole userRole = await data.GetById(entity.Id);
            if (userRole == null)
            {
                throw new Exception("Registro no encontrado");
            }
            userRole = mapearDatos(userRole, entity);
            userRole.UpdatedAt = DateTime.Now;

            await data.Update(userRole);
        }
    }
}
