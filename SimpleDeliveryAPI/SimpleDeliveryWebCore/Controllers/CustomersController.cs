using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleDelivery.BLL.Dtos;
using SimpleDelivery.BLL.Infrastructure.Exceptions;
using SimpleDelivery.BLL.Interfaces;
using SimpleDelivery.DAL.Interfaces;
using SimpleDelivery.DAL.Models;
using SimpleDeliveryWebCore.Resources;

namespace SimpleDeliveryWebCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<List<CustomerViewResource>>> Get()
        {
            var customers = new List<CustomerViewResource>();
            try
            {
                customers = _mapper.Map<List<CustomerViewResource>>(await _service.GetAllAsync());
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Customers", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customers);

        }

        // GET: api/Customers/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<CustomerViewResource>> Get(Guid id)
        {
            CustomerViewResource customer = null;
            try
            {
                customer = _mapper.Map<CustomerViewResource>(await _service.GetAsync(id));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Customers", ex.Message);
            }

            if (customer is null)
                return NotFound(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(customer);
        }

        // POST: api/Customers
        [HttpPost]
        public async ValueTask<ActionResult<CustomerViewResource>> Post([FromBody] AddCustomerResource customer)
        {
            CustomerViewResource addedCustomer = null;
            try
            {
                addedCustomer = _mapper.Map<CustomerViewResource>(await _service.AddAsync(_mapper.Map<CustomerDTO>(customer)));
            }
            catch(ValidationException vEx)
            {
                ModelState.AddModelError("Customers", vEx.Message);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Customers", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(addedCustomer);
        }

        // PUT: api/Customers
        [HttpPut]
        public async Task<ActionResult<CustomerViewResource>> Put([FromBody] CustomerViewResource customer)
        {
            CustomerViewResource updatedCustomer = null;
            try
            {
                updatedCustomer = _mapper.Map<CustomerViewResource>(await _service.UpdateAsync(_mapper.Map<CustomerDTO>(customer)));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Customers", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(updatedCustomer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _service.RemoveAsync(id);
            }
            catch(ArgumentNullException)
            {
                return NotFound(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Customers", ex.Message);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }
    }
}
