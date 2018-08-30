using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static IEnumerable<Pet> pets;
        public static int id = 1;
        public static void InitData()
        {
            Pet cat = new Pet()
            {
                Name = "Jazz",
                Id = id++,
                Type = "Cat"

            };
            Pet dog = new Pet()
            {
                Name = "Something",
                Id = id++,
                Type = "dog"

            };
            pets = new List<Pet> { cat, dog };
        }

    }
}