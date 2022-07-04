using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();
            ProcessInput(courses, command);
            PrintOutput(courses);

        }
        static void ProcessInput(Dictionary<string, List<string>>courses,string input)
        {
            while (input != "end")
            {
                string[] coursesArgs = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string coursesName = coursesArgs[0];
                string studentName = coursesArgs[1];
                AddCoursesAndStudents(courses, coursesName, studentName);
                input = Console.ReadLine();
            }

        }
        static void AddCoursesAndStudents(Dictionary<string, List<string>> courses,
            string cousesName,string studentName)
        {
            if (!courses.ContainsKey(cousesName))
            {
                List<string> student = new List<string>();
                student.Add(studentName);
                courses.Add(cousesName, student);
            }
            else if (courses.ContainsKey(cousesName))
            {
                courses[cousesName].Add(studentName);
            }
        }
        static void PrintOutput(Dictionary<string, List<string>> courses)
        {
            foreach(var kvp in courses)
            {
                string courseName = kvp.Key;
                List<string> students = kvp.Value;
                Console.WriteLine($"{courseName.Trim()}: {students.Count}".Trim());
                foreach(string studentName in students)
                {
                    Console.WriteLine($"--{studentName}");
                }
            }
        }
    }
}
