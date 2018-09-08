using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        List<Owner> GetAllOwners();

        void Delete(int id);

        Owner GetOwnerById(int id);

        Owner GetNewOwner();

        Owner Create(Owner owner);

        Owner Update(Owner owner);
    }
}
