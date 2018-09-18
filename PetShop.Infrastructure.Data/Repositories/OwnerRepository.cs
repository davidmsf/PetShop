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
            throw new NotImplementedException();
        }

        public Owner GetOwnerById(int id)
        {
            return _ctx.Owners.FirstOrDefault(owner => owner.Id == id);
        }

        public IEnumerable<Owner> ReadOwners()
        {
            return _ctx.Owners;
        }

        public Owner Update(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
