using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleDelivery.BLL.Dtos;
using SimpleDelivery.BLL.Infrastructure.Exceptions;
using SimpleDelivery.BLL.Interfaces;
using SimpleDeliveryWebCore.Resources;

namespace SimpleDeliveryWebCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerformersController : ControllerBase
    {
        private readonly IPerformersService _service;
        private readonly IMapper _mapper;

        public PerformersController(IPerformersService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Performers
        [HttpGet]
        public async Task<ActionResult<List<PerformerViewResource>>> Get()
        {
            var performers = new List<PerformerViewResource>();
            try
            {
                performers = _mapper.Map<List<PerformerViewResource>>(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Performers", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(performers);

        }

        // GET: api/Performers/5
        [HttpGet("{id}")]
        public async ValueTask<ActionResult<PerformerViewResource>> Get(Guid id)
        {
            PerformerViewResource performer = null;
            try
            {
                performer = _mapper.Map<PerformerViewResource>(await _service.GetAsync(id));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Performers", ex.Message);
            }

            if (performer is null)
                return NotFound(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(performer);
        }

        // POST: api/Performers
        [HttpPost]
        public async ValueTask<ActionResult<PerformerViewResource>> Post([FromBody] AddPerformerResource performer)
        {
            PerformerViewResource addedPerformer = null;
            try
            {
                addedPerformer = _mapper.Map<PerformerViewResource>(await _service.AddAsync(_mapper.Map<PerformerDTO>(performer)));
            }
            catch (ValidationException vEx)
            {
                ModelState.AddModelError("Performers", vEx.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Performers", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(addedPerformer);
        }

        // PUT: api/Performers
        [HttpPut]
        public async ValueTask<ActionResult<PerformerViewResource>> Put([FromBody] UpdatePerformerResource performer)
        {
            PerformerViewResource updatedPerformer = null;
            try
            {
                updatedPerformer = _mapper.Map<PerformerViewResource>(await _service.UpdateAsync(_mapper.Map<PerformerDTO>(performer)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Performers", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(updatedPerformer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _service.RemoveAsync(id);
            }
            catch (ArgumentNullException)
            {
                return NotFound(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Performers", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }
    }
}
