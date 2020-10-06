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
    public class VehicleTypesController : ControllerBase
    {
        private readonly IVehicleTypesService _service;
        private readonly IMapper _mapper;

        public VehicleTypesController(IVehicleTypesService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/VehicleTypes
        [HttpGet]
        public async Task<ActionResult<List<VehicleTypeViewResource>>> Get()
        {
            var vehicleTypes = new List<VehicleTypeViewResource>();
            try
            {
                vehicleTypes = _mapper.Map<List<VehicleTypeViewResource>>(await _service.GetAllAsync());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("VehicleTypes", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vehicleTypes);
        }

        // GET: api/VehicleTypes/5
        [HttpGet("{id}")]
        public async ValueTask<ActionResult<VehicleTypeViewResource>> Get(Guid id)
        {
            VehicleTypeViewResource vehicleType = null;
            try
            {
                vehicleType = _mapper.Map<VehicleTypeViewResource>(await _service.GetAsync(id));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("VehicleTypes", ex.Message);
            }

            if (vehicleType is null)
                return NotFound(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vehicleType);
        }

        // POST: api/VehicleTypes
        [HttpPost]
        public async ValueTask<ActionResult<VehicleTypeViewResource>> Post([FromBody] AddVehicleTypeResource vehicleType)
        {
            VehicleTypeViewResource addedVehicleType = null;
            try
            {
                addedVehicleType = _mapper.Map<VehicleTypeViewResource>(await _service.AddAsync(_mapper.Map<VehicleTypeDTO>(vehicleType)));
            }
            catch (ValidationException vEx)
            {
                ModelState.AddModelError("VehicleTypes", vEx.Message);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("VehicleTypes", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(addedVehicleType);
        }

        // PUT: api/VehicleTypes
        [HttpPut]
        public async ValueTask<ActionResult<VehicleTypeViewResource>> Put([FromBody] UpdateVehicleTypeResource vehicleType)
        {
            VehicleTypeViewResource updatedVehicleType = null;
            try
            {
                updatedVehicleType = _mapper.Map<VehicleTypeViewResource>(await _service.UpdateAsync(_mapper.Map<VehicleTypeDTO>(vehicleType)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("VehicleTypes", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(updatedVehicleType);
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
                ModelState.AddModelError("VehicleTypes", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }
    }
}
