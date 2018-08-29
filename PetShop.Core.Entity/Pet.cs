using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        private int id;
        private string name;
        private string type;
        private DateTime birthDate;
        private DateTime soldDate;
        private string color;
        private string previousOwner;
        private double price;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public DateTime SoldDate { get => soldDate; set => soldDate = value; }
        public string Color { get => color; set => color = value; }
        public string PreviousOwner { get => previousOwner; set => previousOwner = value; }
        public double Price { get => price; set => price = value; }
    }
}
