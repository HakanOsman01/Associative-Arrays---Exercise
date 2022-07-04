using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> minerColection = new Dictionary<string, int>();
            string command = Console.ReadLine();
            while (command != "stop")
            {
                string resource = command;
                int quantity = int.Parse(Console.ReadLine());
                if (minerColection.ContainsKey(resource))
                {
                    minerColection[resource] += quantity;
                }
                else
                {
                    minerColection.Add(resource, quantity);
                }
                command = Console.ReadLine();
            }
            foreach(var item in minerColection)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
