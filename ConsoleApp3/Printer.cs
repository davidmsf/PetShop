using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

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
            string[] menuItems = { "Show all pets", "Add", "Update", "Delete", "Search by type", "Exit" };

            while (selection != 6)
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
                        List<string> typesOfPets = GetTypes();
                        PrintTypes(typesOfPets);
                        SearchPetsByType(typesOfPets);
                        GoBack();
                        break;
                    default:
                        break;
                }

                selection = ShowMainMenu(menuItems);
            }
        }

        private void UpdatePet(Pet pet)
        {
            Console.WriteLine("1. Name - "+pet.Name
                            +"2. Type - "+pet.Type
                            +"3. Previous Owner - "+pet.PreviousOwner
                            +"4. Price - "+pet.Price
                            );
        }

        private void SearchPetsByType(List<string> typesOfPets)
        {
            Console.WriteLine("Select the type you want to search");
            int.TryParse(Console.ReadLine(), out int typeNr);
            if(typeNr < typesOfPets.Count && typeNr >= 0)
            {
                List<Pet> pets = _petService.GetPetsByType(typesOfPets[typeNr]);
                foreach (var pet in pets)
                {
                    Console.WriteLine(pet.Name);
                }
            }
        }

        private static void PrintTypes(List<string> typesOfPets)
        {
            for(int i = 0; i < typesOfPets.Count; i++)
            {
                Console.WriteLine(i+" - "+ typesOfPets[i]);
            }
        }

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

            int selection = int.Parse(Console.ReadLine());
            Console.Clear();
            return selection;
        }

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
                Console.WriteLine(pet.Id+" - "+pet.Name);
            }
        }

        private Pet GetPetById()
        {
            Console.WriteLine("Please select the pet by its id:");
            int id = int.Parse(Console.ReadLine());
            var pet = _petService.GetPetById(id);
            return pet;
        }

        private void Delete()
        {
            Console.WriteLine("Please select the pet to delete by its id:");
            int id = int.Parse(Console.ReadLine());
            _petService.Delete(id);
        }
    }
}
