using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    class Owner
    {
        private int id;
        private string firstName;
        private string lastName;
        private string address;
        private string phoneNumber;
        private string email;

        public int Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Address { get => address; set => address = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }
    }
}
