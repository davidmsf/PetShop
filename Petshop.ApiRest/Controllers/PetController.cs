﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

namespace Petshop.ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pet
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetPets();
        }

        // GET api/pet/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            if (id > 0)
            {
                return _petService.GetPetById(id);
            }
            else
            {
                return BadRequest("The ID is not above 0");
            }
        }

        // POST api/pet
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("The pet name is Required for creating a pet");
            }

            if (string.IsNullOrEmpty(pet.Type))
            {
                return BadRequest("Type is Required for creating a pet");
            }

            return _petService.CreatePet(pet);
        }

        // PUT api/pet/5
        [HttpPut("{id}")]
        public ActionResult<Pet> Put(int id, [FromBody] Pet pet)
        {
            if (id == pet.Id)
            {
                return _petService.UpdatePet(pet);
            }
            else
            {
                return BadRequest("The GET id does not match the object you are trying to update");
            }
            

        }

        // DELETE api/pet/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.Delete(id);
        }
    }
}
