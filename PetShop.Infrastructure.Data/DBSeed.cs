using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public class DBSeed
    {
        public static void seed(PetShopAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var owner = ctx.Owners.Add(new Owner()
            {
                FirstName = "BOB",
                LastName = "Poulson",
                Address = "bobstreet",
                Email = "bob@bobs.com",
                PhoneNumber = "22334455",
            }).Entity;

            var pet = ctx.Pets.Add(new Pet() {
                Name = "Jazz",
                Type = "Cat",
                BirthDate = new DateTime(2008, 10, 14),
                SoldDate = new DateTime(2008, 12, 15),
                Color = "grey",
                PreviousOwner = "homeless/streetcat",
                Price = 5000,
                Owner = owner
            }).Entity;

            var pet1 = ctx.Pets.Add(new Pet()
            {
                Name = "Dog",
                Type = "dog",
                BirthDate = new DateTime(2008, 10, 14),
                SoldDate = new DateTime(2008, 12, 15),
                Color = "grey",
                PreviousOwner = "From the getto",
                Price = 5000,
                Owner = owner
            }).Entity;

            ctx.SaveChanges();
        }
    }
}
