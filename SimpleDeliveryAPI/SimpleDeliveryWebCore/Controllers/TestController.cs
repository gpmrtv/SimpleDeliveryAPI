using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleDelivery.DAL.Interfaces;
using SimpleDelivery.DAL.Models;

namespace SimpleDeliveryWebCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public TestController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        // GET: api/Test
        [HttpGet]
        public async ValueTask<CustomerEntity> Get()
        {
            var repo = await _uow.GetRepository<CustomerEntity>();
            var findestEntities = await repo.GetAllAsync(x => x.Orders);
            var entityForUpdate = findestEntities.FirstOrDefault();
            entityForUpdate.Email = "change@gmail.com";
            var result = await repo.UpdateAsync(entityForUpdate);
            return result;
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
