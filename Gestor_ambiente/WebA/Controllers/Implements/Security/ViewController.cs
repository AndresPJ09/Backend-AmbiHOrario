﻿using Entity.Dto.Security;
using Entity.Dto;
using Microsoft.AspNetCore.Mvc;
using WebA.Controllers.Interfaces.Security;
using Service.Interfaces.Security;

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
            var result = await business.Save(view);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ViewDto view)
        {
            if (view == null)
            {
                return BadRequest();
            }
            await business.Update(view);
            return NoContent();
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
    }
}