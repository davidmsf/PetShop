using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace Petshop.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: api/Owner
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return _ownerService.GetAllOwners();
        }

        // GET: api/Owner/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            if (id > 0)
            {
                return _ownerService.GetOwnerById(id);
            }
            else
            {
                return BadRequest("id is below 1");
            }
        }

        // POST: api/Owner
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (string.IsNullOrEmpty(owner.FirstName))
            {
                return BadRequest("The firstname is Required for creating a new owner");
            }

            if (string.IsNullOrEmpty(owner.LastName))
            {
                return BadRequest("The lastname is Required for creating a new owner");
            }

            return _ownerService.Create(owner);
        }

        // PUT: api/Owner/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id == owner.Id)
            {
                return _ownerService.Update(owner);
            }
            else
            {
                return BadRequest("The GET id does not match the object you are trying to update");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ownerService.Delete(id);
        }
    }
}
