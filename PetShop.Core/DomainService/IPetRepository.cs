using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();

        void Delete(int id);

        Pet GetPetById(int id);

        Pet CreatePet(Pet pet);
    }
}
