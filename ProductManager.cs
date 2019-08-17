using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FileStream_Homework
{
    class ProductManager
    {
        public List<Product> _collection;
        private string path;
        public ProductManager()
        {
            path = @"C:\Users\user\Desktop\MyJson.Json";
            LoadCollection();
            //_collection = new List<Product>();

        }
        //Private Methods
        private void LoadCollection()
        {
            Stream readingStream = new FileStream(path, FileMode.OpenOrCreate);
            try
            {
                byte[] temp = new byte[100];
                int len = 0;
                string jSon = "";

                while ((len = readingStream.Read(temp, 0, temp.Length)) > 0)
                {
                    jSon += Encoding.UTF8.GetString(temp, 0, len);
                }
                _collection = JsonConvert.DeserializeObject<List<Product>>(jSon);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                readingStream.Close();
            }
        }

        private void SaveCollection()
        {
            Stream writingStream = new FileStream(path, FileMode.Create);
            try
            {
                string jSon = JsonConvert.SerializeObject(_collection);
                byte[] bytes = Encoding.ASCII.GetBytes(jSon);

                writingStream.Write(bytes, 0, bytes.Length);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                writingStream.Close();
            }
        }

        //Public Methods
        public void AddItem()
        {
            Product newItem = new Product();
            Console.Write("Id: ");
            newItem.Id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            newItem.Name = Console.ReadLine();
            Console.Write("Price: ");
            newItem.Price = Console.ReadLine();
            _collection.Add(newItem);
            SaveCollection();
            Console.WriteLine("Item added!");
        }

        public void RemoveItem(int index)
        {
            if(index < _collection.Count)
            {
                _collection.RemoveAt(index);
                SaveCollection();
                Console.WriteLine("Item removed!");
            }
            else
            {
                Console.WriteLine("NO ITEM FOUND");
            }
        }

        public void UpdateItem(int index)
        {
            if (index < _collection.Count)
            {
                Console.Write("Id: ");
                _collection[index].Id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                _collection[index].Name = Console.ReadLine();
                Console.Write("Price: ");
                _collection[index].Price = Console.ReadLine();
                SaveCollection();
                Console.WriteLine("Item updated!");
            }
            else
            {
                Console.WriteLine("NO ITEM FOUND");
            }
        }

        public void ClearCollection()
        {
            for(int i = 0;i < _collection.Count; i++)
            {
                _collection.RemoveAt(0);
                i--;
            }
            SaveCollection();
            Console.WriteLine("Items Cleared!");
        }
    }
}
