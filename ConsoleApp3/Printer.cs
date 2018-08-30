using PetShop.Core.ApplicationService;
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

            int selection = -1;
            string[] menuItems = { "Show all pets", "Create", "Delete", "Exit" };

            while (selection != 4)
            {
                switch (selection)
                {
                    case 1:
                        ShowAllPets();
                        GoBack();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
                
                selection = ShowMainMenu(menuItems);
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
            while (true)
            {
                Console.WriteLine("Press 1 to go back");
                int selection = int.Parse(Console.ReadLine());
                if (selection == 1)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        private void ShowAllPets()
        {
            foreach(var pet in _petService.GetPets())
            {
                Console.WriteLine(pet.Name);
            }
        }
    }
}
