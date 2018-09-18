using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetRepository _petRepository;

        public OwnerService(IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            _ownerRepository = ownerRepository;
            _petRepository = petRepository;
        }

        public Owner Create(Owner owner)
        {
            return _ownerRepository.Create(owner);
        }

        public void Delete(int id)
        {
            _ownerRepository.Delete(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.ReadOwners().ToList();
        }

        public Owner GetNewOwner()
        {
            return new Owner();
        }

        public Owner GetOwnerById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        public Owner GetOwnerByIdIncludePets(int id)
        {
            var owner = _ownerRepository.GetOwnerById(id);
            owner.Pets = _petRepository.ReadPets().Where(pet => pet.Owner.Id == owner.Id).ToList();
            return owner;
        }

        public Owner Update(Owner owner)
        {
            return _ownerRepository.Update(owner);
        }
    }
}
