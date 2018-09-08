using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);

        IEnumerable<Owner> ReadOwners();

        void Delete(int id);

        Owner GetOwnerById(int id);

        Owner Update(Owner owner);
    }
}
