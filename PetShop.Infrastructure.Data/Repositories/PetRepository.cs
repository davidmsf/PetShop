using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetShopAppContext _ctx;

        public PetRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Pet CreatePet(Pet pet)
        {
            if(pet.Owner != null)
            { 
                _ctx.Attach(pet.Owner);
            }
            var savedPet = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return savedPet;
        }

        public void Delete(int id)
        {
            var pet = GetPetById(id);
            _ctx.Pets.Remove(pet);
            _ctx.SaveChanges();
        }

        public Pet GetPetById(int id)
        {
            return _ctx.Pets.FirstOrDefault(pet => pet.Id == id);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet UpdatePet(Pet pet)
        {
            var updatedPet = _ctx.Pets.Update(pet).Entity;
            _ctx.SaveChanges();
            return updatedPet;
        }
    }
}
