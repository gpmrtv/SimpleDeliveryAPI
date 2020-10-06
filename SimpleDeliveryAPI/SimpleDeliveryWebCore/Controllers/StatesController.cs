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
    public class StatesController : ControllerBase
    {
        private readonly IStatesService _service;
        private readonly IMapper _mapper;

        public StatesController(IStatesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/States
        [HttpGet]
        public async Task<ActionResult<List<StateViewResource>>> Get()
        {
            var states = new List<StateViewResource>();
            try
            {
                states = _mapper.Map<List<StateViewResource>>(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("States", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(states);

        }

        // GET: api/States/5
        [HttpGet("{id}")]
        public async ValueTask<ActionResult<StateViewResource>> Get(Guid id)
        {
            StateViewResource state = null;
            try
            {
                state = _mapper.Map<StateViewResource>(await _service.GetAsync(id));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("States", ex.Message);
            }

            if (state is null)
                return NotFound(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(state);
        }

        // POST: api/States
        [HttpPost]
        public async ValueTask<ActionResult<StateViewResource>> Post([FromBody] AddVehicleResource state)
        {
            StateViewResource addedState = null;
            try
            {
                addedState = _mapper.Map<StateViewResource>(await _service.AddAsync(_mapper.Map<StateDTO>(state)));
            }
            catch (ValidationException vEx)
            {
                ModelState.AddModelError("States", vEx.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("States", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(addedState);
        }

        // PUT: api/States
        [HttpPut]
        public async ValueTask<ActionResult<StateViewResource>> Put([FromBody] UpdateStateResource state)
        {
            StateViewResource updatedState = null;
            try
            {
                updatedState = _mapper.Map<StateViewResource>(await _service.UpdateAsync(_mapper.Map<StateDTO>(state)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("States", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(updatedState);
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
                ModelState.AddModelError("States", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }
    }
}
