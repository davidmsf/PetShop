﻿using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Printer
    {
        private readonly IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;

            MainMenu();
        }
        

        private void MainMenu()
        {
            int selection = -1;
            string[] menuItems = { "Show all pets",
                                    "Add",
                                    "Update",
                                    "Delete",
                                    "Search by type",
                                    "Sort pets by price",
                                    "Show 5 cheapest available Pets",
                                    "Exit" };

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        ShowAllPets();
                        GoBack();
                        break;
                    case 2:
                        CreatePet();
                        GoBack();
                        break;
                    case 3:
                        ShowAllPets();
                        var pet = GetPetById();
                        UpdatePet(pet);
                        GoBack();
                        break;
                    case 4:
                        ShowAllPets();
                        Delete();
                        GoBack();
                        break;
                    case 5:
                        SearchPetsByType();
                        GoBack();
                        break;
                    case 6:
                        SortByPrice();
                        GoBack();
                        break;
                    case 7:
                        Show5CheapestPets();
                        GoBack();
                        break;
                    default:
                        break;
                }

                selection = ShowMainMenu(menuItems);
            }
        }


        private void Show5CheapestPets()
        {
            List<Pet> cheapestPets = _petService.Show5CheapestPets();

            foreach (var pet in cheapestPets)
            {
                PrintPetByPrice(pet);
            }
        }

        /// <summary>
        /// Is used in Show5CheapestPets() and SortByPrice() methods for printing the pets with the price first
        /// </summary>
        /// <param name="pet"></param>
        private static void PrintPetByPrice(Pet pet)
        {
            Console.WriteLine("Price: " + pet.Price
                                        + " - " + pet.Id
                                        + " - "
                                        + pet.Name
                                        + " - "
                                        + pet.Type
                                        + " - "
                                        + pet.Color
                                        + " - "
                                        +"Previous owner: "+pet.PreviousOwner
                                        + " - "
                                        +"Birth date: "+pet.BirthDate.ToString("dd/MM/yyyy")
                                        + " - "
                                        +"Sold date: "+pet.SoldDate.ToString("dd/MM/yyyy"));
        }


        private void SortByPrice()
        {
            Console.WriteLine("1. Order by ascending");
            Console.WriteLine("2. Order by descending");
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) 
                   || selection != 1 && selection != 2)
            {
                Console.WriteLine("Select a number:");
            }

            Boolean ascending;
            if (selection == 1)
            {
                ascending = true;
            }
            else
            {
                ascending = false;
            }
            List<Pet> sortedPets = _petService.GetsPetsByPrice(ascending);

            foreach (var pet in sortedPets)
            {
                PrintPetByPrice(pet);
            } 

        }

        /// <summary>
        /// Method for updating a single property of a pet.
        /// The Updated pet and the name of the parameter is passed along as parametes to the core and then the infrastructure  
        /// </summary>
        /// <param name="pet"></param>
        private void UpdatePet(Pet pet)
        {

            Console.WriteLine("1. Name - " + pet.Name);
            Console.WriteLine("2. Type - " + pet.Type);
            Console.WriteLine("3. Previous owner - " + pet.PreviousOwner);
            Console.WriteLine("4. Price - " + pet.Price);
            Console.WriteLine("5. Sold date - " + pet.SoldDate);
            Console.WriteLine("6. Bith date - " + pet.BirthDate);
            Console.WriteLine("7. Color - " + pet.Color);

            int selection;
            Console.WriteLine("Select the specific pet info you wish to edit by entering the associated number:");
            while (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Select a number:");
            }
            
            string property = "";
            switch (selection)
            {
                case 1:
                    Console.WriteLine("Write the name of the pet:");
                    pet.Name = Console.ReadLine();
                    property = "Name";
                    break;
                case 2:
                    Console.WriteLine("Write the type of the pet:");
                    pet.Type = Console.ReadLine();
                    property = "Type";
                    break;
                case 3:
                    Console.WriteLine("Write the previous owner of the pet:");
                    pet.PreviousOwner = Console.ReadLine();
                    property = "PreviousOwner";
                    break;
                case 4:
                    double price;
                    Console.WriteLine("Write the price of the pet:");
                    while (!double.TryParse(Console.ReadLine(), out price))
                    {
                        Console.WriteLine("Write the price of the pet:");
                    }
                    pet.Price = price;
                    property = "Price";
                    break;
                case 5:
                    Console.WriteLine("Write the sold date of the pet(dd/mm/yyyy):");
                    WriteSoldDate(pet);
                    property = "SoldDate";
                    break;
                case 6:
                    Console.WriteLine("Write the birth date of the pet(dd/mm/yyyy):");
                    WriteBirthDate(pet);
                    property = "BirthDate";
                    break;
                case 7:
                    Console.WriteLine("Write the color of the pet:");
                    pet.Color = Console.ReadLine();
                    property = "Color";
                    break;
            }

            var updatedPet = _petService.UpdatePet(pet, property);
            if (updatedPet.Id > 0)
            {
                Console.WriteLine("The pet has been updated");
            }
        }
        /// <summary>
        /// Since this piece of code, which sets the solddate of the given pet by user input,
        /// is used several times, it is placed in a separate method
        /// </summary>
        /// <param name="pet"></param>
        private static void WriteSoldDate(Pet pet)
        {
            DateTime soldDate;
            while (!DateTime.TryParseExact(Console.ReadLine(),
                "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out soldDate))
            {
                Console.WriteLine("Write the sold date of the pet(dd/mm/yyyy):");
            }

            pet.SoldDate = soldDate;
        }

        /// <summary>
        /// Since this piece of code, which sets the birthdate of the given pet by user input,
        /// is used several times, it is placed in a separate method
        /// </summary>
        /// <param name="pet"></param>
        private static void WriteBirthDate(Pet pet)
        {
            DateTime birthDate;
            while (!DateTime.TryParseExact(Console.ReadLine(),
                "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out birthDate))
            {
                Console.WriteLine("Write the birth date of the pet(dd/mm/yyyy):");
            }

            pet.BirthDate = birthDate;
        }

        /// <summary>
        /// The user can select the type of pet they wish to look up, and get a list of all the pets of the choosen type,
        /// by using either a menu or writing the type themselves 
        /// </summary>
        private void SearchPetsByType()
        {
            Console.WriteLine("Press 1 if you want to select the type through a menu");
            Console.WriteLine("Or press 2 if you want to select the type through a search");
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection != 1 && selection != 2)
            {
                Console.WriteLine("Select a number:");
            }

            List<Pet> pets;
            if (selection == 1)
            {
                List<string> typesOfPets = GetTypes();
                PrintTypes(typesOfPets);
                pets = TypeSearchThroughMenu(typesOfPets);
            }
            else
            {
                Console.WriteLine("Write the type you want to search:");
                string searchWord = Console.ReadLine();
                pets = _petService.GetPetsByType(searchWord);
            }

            foreach (var pet in pets)
            {
                PrintPet(pet);
            }
        
        }

        /// <summary>
        /// Since pets are printed several places in the program it is isolated in a method,
        /// so it takes the specific pet and prints all its properties 
        /// </summary>
        /// <param name="pet"></param>
        private static void PrintPet(Pet pet)
        {
            Console.WriteLine("Id:"+pet.Id
                              + " - "
                              +pet.Name
                              + " - "
                              +pet.Type
                              + " - "
                              +pet.Color
                              + " - "
                              +"Previous owner:"+pet.PreviousOwner
                              + " - "
                              +"Birthdate:"+pet.BirthDate.ToString("dd/MM/yyyy")
                              + " - "
                              +"Solddate:"+pet.SoldDate.ToString("dd/MM/yyyy")
                              + " - "
                              +"Price:"+pet.Price);
            Console.WriteLine();
        }

        /// <summary>
        /// This method is used in the SearchPetsByType() method,
        /// and takes the users input for which type of animal they wish to see an inventory of
        /// </summary>
        /// <param name="typesOfPets"></param>
        /// <returns></returns>
        private List<Pet> TypeSearchThroughMenu(List<string> typesOfPets)
        {
            List<Pet> pets;
            int typeNr;
            Console.WriteLine("Select the type you want to search:");

            while (!int.TryParse(Console.ReadLine(), out typeNr)
                   || typeNr >= typesOfPets.Count
                   || typeNr < 0)
            {
                Console.WriteLine("Select the type you want to search:");
            }

            pets = _petService.GetPetsByType(typesOfPets[typeNr]);
            return pets;
        }

        /// <summary>
        /// This method is used in the SearchPetsByType() method,
        /// it prints the types of animals in the petshop
        /// </summary>
        /// <param name="typesOfPets"></param>
        private static void PrintTypes(List<string> typesOfPets)
        {

            for(int i = 0; i < typesOfPets.Count; i++)
            {
                Console.WriteLine(i+" - "+ typesOfPets[i]);
            }
        }

        /// <summary>
        /// This method is used in the SearchPetsByType() method,
        /// it fetches the different types of animals available in the petshop
        /// </summary>
        /// <returns></returns>
        private List<String> GetTypes()
        {
            List<string> types = _petService.GetTypesOfPets();
            return types;
        }


        private void CreatePet()
        {
            var pet = _petService.GetNewPet();
            Console.WriteLine("Write the name of the pet:");
            pet.Name = Console.ReadLine();

            Console.WriteLine("Write the color of the pet:");
            pet.Color = Console.ReadLine();

            Console.WriteLine("Write the name of the previous owner:");
            pet.PreviousOwner = Console.ReadLine();

            Console.WriteLine("Write the type of the pet:");
            pet.Type = Console.ReadLine();

            double price;
            Console.WriteLine("Write the price of the pet:");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Write the price of the pet:");
            }
            pet.Price = price;

            Console.WriteLine("Write the sold date of the pet(dd/mm/yyyy):");
            WriteSoldDate(pet);

            Console.WriteLine("Write the birth date of the pet(dd/mm/yyyy):");
            WriteBirthDate(pet);
            
            var newPet = _petService.CreatePet(pet);
            if (newPet.Id > 0)
            {
                Console.WriteLine("The pet has been added");
            }
        }

        private int ShowMainMenu(string[] menuItems)
        {
            for(int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i+1)+". "+ menuItems[i]);
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection))
            {
                Console.WriteLine("Select a number:");
            }
            Console.Clear();
            return selection;
        }

        /// <summary>
        /// This code is used throughout this class, in order for the user to decide when to return to the main menu 
        /// </summary>
        private void GoBack()
        {

            Console.WriteLine("Press Enter to go back");
            Console.ReadLine();
            Console.Clear();
             
        }

        private void ShowAllPets()
        {
            foreach(var pet in _petService.GetPets())
            {
                PrintPet(pet);
            }
        }

        private Pet GetPetById()
        {
            Console.WriteLine("Please select the pet by its id:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Select a number:");
            }
            var pet = _petService.GetPetById(id);
            return pet;
        }

        private void Delete()
        {
            Console.WriteLine("Please select the pet to delete by its id:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Select a number:");
            }
            _petService.Delete(id);
            var pet = _petService.GetPetById(id);
            if (pet == null)
            {
                Console.WriteLine("The pet was deleted from the system");
            }
           
        }
    }
}
