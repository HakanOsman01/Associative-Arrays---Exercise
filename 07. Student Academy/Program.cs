using System;
using System.Linq;
using System.Collections.Generic;
namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>>academyStudents = new Dictionary<string,List<double>>();
            int n = int.Parse(Console.ReadLine());
            ProcessInput(academyStudents, n);
            Dictionary<string, double> avaregeGrades = GetAvaregeGrades(academyStudents);
            foreach(var kvp in avaregeGrades)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:f2}");
            }
        }
        static void ProcessInput(Dictionary<string, List<double>> academyStudents,int n)
        {
            for (int cur = 1; cur <= n; cur++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                AddGrades(academyStudents, name, grade);

            }
        }
        static void AddGrades(Dictionary<string,List<double>>academyStudents,string name,double grade)
        {
            if (!academyStudents.ContainsKey(name))
            {
                List<double> currentGrade = new List<double>();
                currentGrade.Add(grade);
                academyStudents.Add(name, currentGrade);
            }
            else
            {
                academyStudents[name].Add(grade);
            }
        }
        static Dictionary<string,double>GetAvaregeGrades(Dictionary<string, List<double>> academyStudents)
        {
            Dictionary<string, double> studentsAndGrades = new Dictionary<string, double>();
            foreach(var kvp in academyStudents)
            {
                string name = kvp.Key;
                List<double> grades = kvp.Value;
                int countGrades = grades.Count;
                double avaregeGrade = 0.00;
                foreach(double curGrade in grades)
                {
                     avaregeGrade+= curGrade;
                }
                avaregeGrade/= (countGrades*1.00);
                if (avaregeGrade >= 4.50)
                {
                    studentsAndGrades.Add(name, avaregeGrade);
                }

            }
            return studentsAndGrades;
        }
    }
}
