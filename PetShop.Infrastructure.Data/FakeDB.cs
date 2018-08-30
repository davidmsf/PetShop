using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static IEnumerable<Pet> pets;

        public static void InitData()
        {
            Pet cat = new Pet()
            {
                Name = "Jazz",
                Id = 1,
                Type = "Cat"

            };
            pets = new List<Pet> { cat };
        }

    }
}