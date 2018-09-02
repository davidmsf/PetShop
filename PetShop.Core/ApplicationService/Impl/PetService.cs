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

        /// <summary>
        /// Compares all the pets in the shop to the specific type chosen by the user, and returns all matches
        /// </summary>
        /// <param name="type"></param>
        /// <returns>returns all pets that matches the selected type</returns>
        public List<Pet> GetPetsByType(string type)
        {
            return _petRepository.ReadPets().Where(pet => pet.Type.Equals(type, StringComparison.InvariantCultureIgnoreCase)).ToList();
        }

        /// <summary>
        /// Returns the pets by price either ascending or descending 
        /// </summary>
        /// <param name="ascending"></param>
        /// <returns>Returns the pets by price either ascending or descending</returns>
        public List<Pet> GetsPetsByPrice(bool ascending)
        {
            if (ascending)
            {
                return _petRepository.ReadPets().OrderBy(pet => pet.Price).ToList();
            }
            else
            {
                return _petRepository.ReadPets().OrderByDescending(pet => pet.Price).ToList();
            }
        }

        /// <summary>
        /// Returns the distinct types of pets in the petshop
        /// </summary>
        /// <returns>Available types of pets in the inventory</returns>
        public List<string> GetTypesOfPets()
        {
            return _petRepository.ReadPets().Select(pet => pet.Type).Distinct().ToList();
        }

        public List<Pet> Show5CheapestPets()
        {
            return _petRepository.ReadPets().OrderBy(pet => pet.Price).Take(5).ToList();
        }

        public Pet UpdatePet(Pet pet, string property)
        {
            return _petRepository.UpdatePet(pet, property);
        }
    }
}
