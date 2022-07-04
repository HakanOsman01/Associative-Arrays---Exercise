using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> register = new Dictionary<string, string>();
            int numberOrders = int.Parse(Console.ReadLine());
            ProcessInput(register, numberOrders);
            PrintUserNames(register);

        }
        static void ProcessInput(Dictionary<string,string>register,int n)
        {
            for (int curOrder = 0; curOrder <n; curOrder++)
            {
                string[] registerCommands = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string type = registerCommands[0];
                
                if (type== "register")
                {
                    string name = registerCommands[1];
                    string registerNumber = registerCommands[2];
                    RegisterProcess(register, name, registerNumber);
                }
                else if(type== "unregister")
                {
                    string name = registerCommands[1];
                    UnRegisterProcess(register, name);
                }
            }
        }
        static void RegisterProcess(Dictionary<string,string>register,string name,
            string registerNumber)
        {
            if (register.ContainsKey(name))
            {
                Console.WriteLine($"ERROR: already registered with plate number " +
                    $"{registerNumber}");
                
            }
            else
            {
                register.Add(name, registerNumber);
                Console.WriteLine($"{name} registered {registerNumber} successfully");
            }
        }
        static void UnRegisterProcess(Dictionary<string, string> register, string name)
        {
            if (!register.ContainsKey(name))
            {
                Console.WriteLine($"ERROR: user {name} not found");
            }
            else
            {
                register.Remove(name);
                Console.WriteLine($"{name} unregistered successfully");
            }
        }
        static void PrintUserNames(Dictionary<string, string> register)
        {
            foreach(var kvp in register)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }
    }
}
