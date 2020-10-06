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
    public class VehiclesController : ControllerBase
    {
        private readonly IVehiclesService _service;
        private readonly IMapper _mapper;

        public VehiclesController(IVehiclesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Vehicles
        [HttpGet]
        public async Task<ActionResult<List<VehicleViewResource>>> Get()
        {
            var vehicles = new List<VehicleViewResource>();
            try
            {
                vehicles = _mapper.Map<List<VehicleViewResource>>(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Vehicles", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vehicles);

        }

        // GET: api/Vehicles/5
        [HttpGet("{id}")]
        public async ValueTask<ActionResult<VehicleViewResource>> Get(Guid id)
        {
            VehicleViewResource vehicle = null;
            try
            {
                vehicle = _mapper.Map<VehicleViewResource>(await _service.GetAsync(id));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Vehicles", ex.Message);
            }

            if (vehicle is null)
                return NotFound(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vehicle);
        }

        // POST: api/Vehicles
        [HttpPost]
        public async ValueTask<ActionResult<VehicleViewResource>> Post([FromBody] AddVehicleResource vehicle)
        {
            VehicleViewResource addedVehicle = null;
            try
            {
                addedVehicle = _mapper.Map<VehicleViewResource>(await _service.AddAsync(_mapper.Map<VehicleDTO>(vehicle)));
            }
            catch (ValidationException vEx)
            {
                ModelState.AddModelError("Vehicles", vEx.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Vehicles", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(addedVehicle);
        }

        // PUT: api/Vehicles
        [HttpPut]
        public async ValueTask<ActionResult<VehicleViewResource>> Put([FromBody] UpdateVehicleResource vehicle)
        {
            VehicleViewResource updatedVehicle = null;
            try
            {
                updatedVehicle = _mapper.Map<VehicleViewResource>(await _service.UpdateAsync(_mapper.Map<VehicleDTO>(vehicle)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Vehicles", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(updatedVehicle);
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
                ModelState.AddModelError("Vehicles", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }
    }
}
