using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static IEnumerable<Pet> pets;
        public static IEnumerable<Owner> owners;
        public static IEnumerable<Order> orders;
        public static IEnumerable<Customer> customers;

        public static int petId = 1;
        public static int ownerId = 1;
        public static int orderId = 1;
        public static int customerId = 1;

        public static void InitData()
        {
            //PETS------------------------------------------------
            Pet cat = new Pet()
            {
                Id = petId++,
                Name = "Jazz",
                Type = "Cat",
                BirthDate = new DateTime(2008, 10, 14),
                SoldDate = new DateTime(2008, 12, 15),
                Color = "grey",
                PreviousOwner = "homeless/streetcat",
                Price = 5000
    };
            Pet dog = new Pet()
            {
                Id = petId++,
                Name = "Sarri",
                Type = "Dog",
                BirthDate = new DateTime(2006, 10, 14),
                SoldDate = new DateTime(2007, 10, 15),
                Color = "Golden",
                PreviousOwner = "David Fabricius",
                Price = 50
            };

            Pet turtle = new Pet()
            {
                Id = petId++,
                Name = "Leonardo",
                Type = "Turtle",
                BirthDate = new DateTime(2016, 10, 14),
                SoldDate = new DateTime(2017, 10, 15),
                Color = "Green",
                PreviousOwner = "Splinter",
                Price = 200
            };

            Pet Lobster = new Pet()
            {
                Id = petId++,
                Name = "Rock lobster",
                Type = "Lobster",
                BirthDate = new DateTime(2014, 10, 14),
                SoldDate = new DateTime(2017, 10, 15),
                Color = "Brown",
                PreviousOwner = "The ocean",
                Price = 400
            };

            Pet Dog = new Pet()
            {
                Id = petId++,
                Name = "SomeDog",
                Type = "Dog",
                BirthDate = new DateTime(2015, 10, 11),
                SoldDate = new DateTime(2017, 01, 15),
                Color = "Brown",
                PreviousOwner = "SomeBody",
                Price = 450
            };

            Pet Cat = new Pet()
            {
                Id = petId++,
                Name = "SomeCat",
                Type = "Cat",
                BirthDate = new DateTime(2016, 11, 04),
                SoldDate = new DateTime(2017, 01, 15),
                Color = "Black",
                PreviousOwner = "SomeBody",
                Price = 600
            };

            pets = new List<Pet> { cat, dog, turtle, Lobster, Dog, Cat };

            //OWNERS-------------------------------------------------

            Owner owner = new Owner()
            {
                Id = ownerId++,
                FirstName = "BOB",
                LastName = "Poulson",
                Address = "bobstreet",
                Email = "bob@bobs.com",
                PhoneNumber = "22334455"
            };

            Owner owner2 = new Owner()
            {
                Id = ownerId++,
                FirstName = "Paul",
                LastName = "Poulson",
                Address = "paulstreet",
                Email = "paul@bobs.com",
                PhoneNumber = "22334455"
            };

            owners = new List<Owner> { owner, owner2 };

            //ORDERS----------------------------------------------

            Order order = new Order()
            {
                Id = orderId++,
                Customer = new Customer(){ Id = 1 },
                Pets = new List<Pet> { new Pet() { Id = 3 }, new Pet() { Id = 4 } },
                OrderDate =  new DateTime(2008, 10, 14),
                DeliveryDate = new DateTime(2014, 11, 11)
            };

            Order order2 = new Order()
            {
                Id = orderId++,
                Customer = new Customer() { Id = 2 },
                Pets = new List<Pet> { new Pet() { Id = 1 }, new Pet() { Id = 2 } },
                OrderDate = new DateTime(2008, 10, 14),
                DeliveryDate = new DateTime(2014, 11, 11)
            };

            orders = new List<Order> { order, order2 };

            //CUSTOMERS---------------------------------------------

            Customer customer = new Customer()
            {
                Id = customerId++,
                FirstName = "Cust",
                LastName = "tomer",
                Address = "TomerCustStreet",
            };

            Customer customer2 = new Customer()
            {
                Id = customerId++,
                FirstName = "yoyoy",
                LastName = "jdsnd",
                Address = "bobstreet"
            };

            customers = new List<Customer> { customer, customer2 };
        }

    }
}