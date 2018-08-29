using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();
    }
}
