using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] keyMaterialsNames = new string[] { "shards", "fragments", "motes" };

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
            {
                {"shards",0},
                {"motes",0 },
                {"fragments",0 }
            };

            Dictionary<string, int> junk = new Dictionary<string, int>();
            string itemObtained = string.Empty;
            while (String.IsNullOrEmpty(itemObtained))
            {
                string materialLine = Console.ReadLine().ToLower();
                string[] materialArr = materialLine.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                ProcessInputLine(keyMaterials, junk, materialArr, ref itemObtained);
            }
            PrintOutput(keyMaterials, junk, itemObtained);

        }

        static void ProcessInputLine(Dictionary<string, int> keyMaterials,
            Dictionary<string, int> junk,
            string[] materialsArr, ref string itemObtained)
        {
            Dictionary<string, string> craftTable = new Dictionary<string, string>
            {
                {"shards","Shadowmourne"},
                 {"motes","Dragonwrath" },
                {"fragments","Valanyr" }
               
            };

            const int minMaterialQty = 250;
            for (int i = 0; i < materialsArr.Length; i += 2)
            {
                int currentMaterialQty = int.Parse(materialsArr[i]);
                string currentMaterial = materialsArr[i + 1];
                if (keyMaterials.ContainsKey(currentMaterial))
                {
                    keyMaterials[currentMaterial] += currentMaterialQty;
                    if (keyMaterials[currentMaterial] >= minMaterialQty)
                    {
                        itemObtained = craftTable[currentMaterial];
                        keyMaterials[currentMaterial] -= minMaterialQty;

                        break;
                    }
                }
                else
                {
                    if (!junk.ContainsKey(currentMaterial))
                    {
                        junk[currentMaterial] = 0;
                    }
                    junk[currentMaterial] += currentMaterialQty;
                }
            }

        }
        static void PrintOutput(Dictionary<string, int> keyMaterialLeft, 
            Dictionary<string, int> junk,string itemObtainde)
        {
            Console.WriteLine($"{itemObtainde} obtained!");
            foreach(var kvp in keyMaterialLeft)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            foreach(var kvp in junk)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}

