﻿using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;


namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();
        void Delete(int id);
        Pet GetPetById(int id);
        Pet GetNewPet();
        Pet CreatePet(Pet pet);
        List<string> GetTypesOfPets();
        List<Pet> GetPetsByType(string type);
        Pet UpdatePet(Pet pet, string property);
        List<Pet> GetsPetsByPrice(bool ascending);
        List<Pet> Show5CheapestPets();
    }
}
