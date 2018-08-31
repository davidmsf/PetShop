using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Impl
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.CreatePet(pet);
        }

        public void Delete(int id)
        {
            _petRepository.Delete(id);
        }

        public Pet GetNewPet()
        {
            return new Pet();
        }

        public Pet GetPetById(int id)
        {
            return _petRepository.GetPetById(id);
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> GetPetsByType(string type)
        {
            return _petRepository.ReadPets().Where(pet => pet.Type.Equals(type)).ToList();
        }

        public List<string> GetTypesOfPets()
        {
            return _petRepository.ReadPets().Select(pet => pet.Type).Distinct().ToList();
        }

        public Pet UpdatePet(Pet pet, string property)
        {
            return _petRepository.UpdatePet(pet, property);
        }
    }
}
