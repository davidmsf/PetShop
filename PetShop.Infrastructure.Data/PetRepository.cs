using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class PetRepository : IPetRepository
    {
        public Pet CreatePet(Pet pet)
        {
            pet.Id = FakeDB.petId++;
            var pets = FakeDB.pets.ToList();
            pets.Add(pet);
            FakeDB.pets = pets;
            return pet;
        }

        public void Delete(int id)
        {
            var pets = FakeDB.pets.ToList();
            var petToDelete = pets.FirstOrDefault(pet => pet.Id == id);
            pets.Remove(petToDelete);
            FakeDB.pets = pets;
        }

        public Pet GetPetById(int id)
        {
            var selectedPet = FakeDB.pets.FirstOrDefault(pet => pet.Id == id);
            return selectedPet;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.pets;
        }

        public Pet UpdatePet(Pet updatedPet)
        {
            var pets = FakeDB.pets.ToList();
            var petToUpdate = pets.FirstOrDefault(pet => pet.Id == updatedPet.Id);
            petToUpdate = updatedPet;
            return petToUpdate;
        }
    }
}
