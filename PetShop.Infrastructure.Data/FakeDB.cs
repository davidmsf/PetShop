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
                Id = id++,
                Name = "Jazz",
                Type = "Cat",
                BirthDate = new DateTime(14/10/2008),
                SoldDate = new DateTime(15/12/2008),
                Color = "grey",
                PreviousOwner = "homeless/streetcat",
                Price = 5000
    };
            Pet dog = new Pet()
            {
                Id = id++,
                Name = "Sarri",
                Type = "Dog",
                BirthDate = new DateTime(14 / 10 / 2006),
                SoldDate = new DateTime(15 / 10 / 2007),
                Color = "Golden",
                PreviousOwner = "David Fabricius",
                Price = 50
            };
            pets = new List<Pet> { cat, dog };
        }

    }
}