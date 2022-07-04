using System;
using System.Linq;
using System.Collections.Generic;


namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, double> products = new Dictionary<string, double>();
            Dictionary<string, int> quantityProducts = new Dictionary<string, int>();
            string input = Console.ReadLine();
            ProcessInput(products, quantityProducts, input);
            PrintProducts(products, quantityProducts);
           
        }
        static void ProcessInput(Dictionary<string, double> products, 
            Dictionary<string, int> quantityProducts,string input)
        {
            while (input != "buy")
            {
                string[] cmdArgs = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string nameProduct = cmdArgs[0];
                double priceProduct = double.Parse(cmdArgs[1]);
                int quantityProduct = int.Parse(cmdArgs[2]);
                CheckProducts(products, quantityProducts, nameProduct, priceProduct, quantityProduct);
                input = Console.ReadLine();
            }
        }
        static void CheckProducts(Dictionary<string, double> products, 
            Dictionary<string, int> quantityProducts, string nameProduct, double priceProduct, 
            int quantityProduct)
        {
            if (!products.ContainsKey(nameProduct))
            {
                products.Add(nameProduct, priceProduct);
                quantityProducts.Add(nameProduct, quantityProduct);
            }
            else if (products.ContainsKey(nameProduct))
            {
                products.Remove(nameProduct);
                products.Add(nameProduct, priceProduct);
                quantityProducts[nameProduct] += quantityProduct;
            }
        }
        static void PrintProducts(Dictionary<string, double> products, Dictionary<string, int> quantities)
        {
            foreach(var product in products)
            {
                foreach(var quantity in quantities)
                {
                    if (product.Key == quantity.Key)
                    {
                        Console.WriteLine($"{product.Key} -> {product.Value*quantity.Value:f2}");
                    }
                }
            }
        }
          
    }
   
}
