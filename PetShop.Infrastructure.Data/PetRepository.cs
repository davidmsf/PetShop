using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.pets;
        }
    }
}
