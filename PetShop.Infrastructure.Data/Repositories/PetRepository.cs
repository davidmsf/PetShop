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
            var savedPet = _ctx.Pets.Add(pet).Entity;
            _ctx.SaveChanges();
            return savedPet;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Pet GetPetById(int id)
        {
            return _ctx.Pets.FirstOrDefault(owner => owner.Id == id);
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets;
        }

        public Pet UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
