using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetShopAppContext _ctx;

        public OwnerRepository(PetShopAppContext ctx)
        {
            _ctx = ctx;
        }

        public Owner Create(Owner owner)
        {
            var savedOwner = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return savedOwner;
        }

        public void Delete(int id)
        {
            var owner = GetOwnerById(id);
            _ctx.Owners.Remove(owner);
            _ctx.SaveChanges();
        }

        public Owner GetOwnerById(int id)
        {
            return _ctx.Owners.FirstOrDefault(owner => owner.Id == id);
        }

        public Owner GetOwnerByIdIncludePets(int id)
        {
            return _ctx.Owners.Include(owner => owner.Pets).FirstOrDefault(owner => owner.Id == id);
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner Update(Owner owner)
        {
            var updatedOwner = _ctx.Owners.Update(owner).Entity;
            _ctx.SaveChanges();
            return updatedOwner;
        }
    }
}
