using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStream_Homework
{
    class UserInterface
    {
        private bool _isShown = true;
        ProductManager pMan = new ProductManager();

        public void StartInterface()
        {
            

            while(_isShown == true)
            {
                ShowInterface();
            }
            Console.WriteLine("Goodbye");
        }

        public void ShowCollection()
        {
            Console.WriteLine("collection: ");
            Console.WriteLine("----------");
            if (pMan._collection.Count > 0)
            {
                for (int i = 0; i < pMan._collection.Count; i++)
                {
                    Console.WriteLine("----------");
                    Console.WriteLine("Id: " + pMan._collection[i].Id);
                    Console.WriteLine("Name: " + pMan._collection[i].Name);
                    Console.WriteLine("Price: " + pMan._collection[i].Price);
                    Console.WriteLine("----------");

                }
            }
            else
            {
                Console.WriteLine("No items were found!");
            }
        }

        public void ShowInterface()
        {
            Console.WriteLine("----------");
            Console.WriteLine("Please select an option: ");
            Console.WriteLine("1 - Add a product");
            Console.WriteLine("2 - Update a product");
            Console.WriteLine("3 - Remove a product");
            Console.WriteLine("4 - Show all products");
            Console.WriteLine("5 - Clear all products");
            Console.WriteLine("6 - Exit");

            string option = Console.ReadLine();

            if(option == "1") //Add
            {
                pMan.AddItem();
            }
            if (option == "2") //Update
            {
                Console.Write("Enter index: ");
                int index = int.Parse(Console.ReadLine());
                pMan.UpdateItem(index);
            }
            if (option == "3") //Remove
            {
                Console.Write("Enter index: ");
                int index = int.Parse(Console.ReadLine());
                pMan.RemoveItem(index);
            }
            if (option == "4") //Show
            {
                ShowCollection();
            }
            if(option == "5")
            {
                pMan.ClearCollection();
            }
            if (option == "6") //Exit
            {
                _isShown = false;
            }
        }
    }
}
