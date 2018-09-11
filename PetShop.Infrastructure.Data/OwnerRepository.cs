using PetShop.Core.DomainService;
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
            var owners = FakeDB.owners.ToList();
            var ownerToUpdate = owners.FirstOrDefault(owner => owner.Id == updatedOwner.Id);
            ownerToUpdate = updatedOwner;
            return ownerToUpdate;
        }
    }
}
