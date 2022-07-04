using System;
using System.Linq;
using System.Collections.Generic;


namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> company = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command
                .Split("->", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
                string companyName = cmdArgs[0];
                string idEmployee = cmdArgs[1];
                if (!company.ContainsKey(companyName))
                {
                    List<string> currentId = new List<string>();
                    currentId.Add(idEmployee);
                    company.Add(companyName, currentId);
                }else if (company.ContainsKey(companyName))
                {
                    
                    if (company[companyName].Contains(idEmployee))
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        company[companyName].Add(idEmployee);
                    }
                }
                command = Console.ReadLine();
            }

            PrintEmployees(company);
        }
        static void PrintEmployees(Dictionary<string, List<string>> company)
        {
            foreach(var kvp in company)
            {
                string companyName = kvp.Key;
                List<string> idsEmployees = kvp.Value;
                Console.WriteLine($"{companyName}");
                foreach(string id in idsEmployees)
                {
                    Console.WriteLine($"--{id}");
                }
            }
        }


    }
}
