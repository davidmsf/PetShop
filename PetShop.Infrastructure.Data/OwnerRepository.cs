﻿using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        public Owner Create(Owner owner)
        {
            owner.Id = FakeDB.ownerId++;
            var owners = FakeDB.owners.ToList();
            owners.Add(owner);
            FakeDB.owners = owners;
            return owner;
        }

        public void Delete(int id)
        {
            var owners = FakeDB.owners.ToList();
            var ownerToDelete = owners.FirstOrDefault(owner => owner.Id == id);
            owners.Remove(ownerToDelete);
            FakeDB.owners = owners;
        }

        public Owner GetOwnerById(int id)
        {
            var selectedOwner = FakeDB.owners.FirstOrDefault(owner => owner.Id == id);
            return selectedOwner;
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return FakeDB.owners;
        }

        public Owner Update(Owner updatedOwner)
        {
            var ownerFromDB = GetOwnerById(updatedOwner.Id);
            if (ownerFromDB == null)
            {
                return null;
            }
            else
            {
                ownerFromDB.FirstName = updatedOwner.FirstName;
                ownerFromDB.LastName = updatedOwner.LastName;
                ownerFromDB.Email = updatedOwner.Email;
                ownerFromDB.PhoneNumber = updatedOwner.PhoneNumber;
                ownerFromDB.Address = updatedOwner.Address;
                ownerFromDB.Pets = updatedOwner.Pets;
                return ownerFromDB;

            }
        }
    }
}
