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
    public class ViewService: IViewService
    {
        protected readonly IViewRepository data;

        public ViewService(IViewRepository data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await data.Delete(id);
        }

        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            IEnumerable<View> views = await data.GetAll();
            var viewDtos = views.Select(view => new ViewDto
            {
                Id = view.Id,
                Name = view.Name,
                Description = view.Description,
                Route = view.Route,
                ModuleId = view.ModuleId,
                State = view.State
            });

            return viewDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await data.GetAllSelect();
        }

        public async Task<ViewDto> GetById(int id)
        {
            View view = await data.GetById(id);
            ViewDto viewDto = new ViewDto();

            viewDto.Id = view.Id;
            viewDto.Name = view.Name;
            viewDto.Description = view.Description;
            viewDto.Route = view.Route;
            viewDto.ModuleId = view.ModuleId;
            viewDto.State = view.State;
            return viewDto;
        }

        public View mapearDatos(View view, ViewDto entity)
        {
            view.Id = entity.Id;
            view.Name = entity.Name;
            view.Description = entity.Description;
            view.Route = entity.Route;
            view.ModuleId = entity.ModuleId;
            view.State = entity.State;
            return view;
        }

        public async Task<View> Save(ViewDto entity)
        {
            var views = await data.GetAll();
            if (views.Any(v => v.Name == entity.Name))
            {
                throw new Exception("El nombre de vista ya existe.");
            }
            if (views.Any(v => v.Route == entity.Route))
            {
                throw new Exception("La ruta de vista ya existe.");
            }
            View view = new View();
            view = mapearDatos(view, entity);
            view.CreatedAt = DateTime.Now;
            view.State = true;
            view.UpdatedAt = null;
            view.DeletedAt = null;


            return await data.Save(view);
        }

        public async Task Update(ViewDto entity)
        {
            View view = await data.GetById(entity.Id);
            if (view == null)
            {
                throw new Exception("Registro no encontrado");
            }
            var views = await data.GetAll();
            if (views.Any(v => v.Name == entity.Name && v.Id != entity.Id))
            {
                throw new Exception("El nombre de rol ya existe.");
            }
            if (views.Any(v => v.Route == entity.Route && v.Id != entity.Id))
            {
                throw new Exception("la ruta de rol ya existe.");
            }
            view = mapearDatos(view, entity);
            view.UpdatedAt = DateTime.Now;

            await data.Update(view);
        }
    }
}
