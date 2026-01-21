using LabsSchoolDBApp.Data;
using LabsSchoolDBApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabsSchoolDBApp
{
    internal class Helper
    {

        public static void AddStudent()
        {
            using var context = new LabsSchoolDBContext();

            var newStudent = new Student();
            Console.Write("Ange förnamn: ");
            newStudent.FirstName = Console.ReadLine();
            Console.Write("Ange efternamn: ");
            newStudent.LastName = Console.ReadLine();
            Console.Write("Ange personnummer (ÅÅMMDDXXXX): ");
            newStudent.PersonalNr = Console.ReadLine();
            Console.Write("Ange klass: ");
            newStudent.ClassCode = Console.ReadLine();

            if (context.Students.Any(s => s.PersonalNr == newStudent.PersonalNr))
            {
                Console.WriteLine();
                Console.WriteLine("En elev med detta personnummer finns redan.");
                Console.ReadKey();
                return;
            }
            else
            {
                context.Students.Add(newStudent);
                context.SaveChanges();
            }

            if (context.Students.Any(s => s.PersonalNr == newStudent.PersonalNr))
            {
                Console.WriteLine();
                Console.WriteLine("Eleven har lagts till.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Något gick fel, eleven kunde inte läggas till.");
                Console.ReadKey();
                return;
            }


        }

        public static void ShowClasses()
        {
            using var context = new LabsSchoolDBContext();
            var classes = context.Classes.ToList();
            Console.WriteLine("Klasser:");
            foreach (var c in classes)
            {
                Console.WriteLine($"{c.ClassCode}");
            }
            Console.WriteLine("Vilken klass vill du visa?");
            var classToView = Console.ReadLine();
            
            if (context.Classes.Any(c => c.ClassCode == classToView))
            {
                ShowStudents(classToView);
                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Klassen finns inte.");
            }

            Console.ReadKey();
        }

        

        public static void ShowStudents()
        {
            Console.WriteLine("Välj sortering:");
            Console.WriteLine("1. Förnamn");
            Console.WriteLine("2. Efternamn");
            string? sortChoice = Console.ReadLine();
            if (sortChoice != null)
            {
                using var context = new LabsSchoolDBContext();
                List<Student> students;
                switch (sortChoice)
                {
                    case "1":
                        students = context.Students
                            .OrderBy(s => s.FirstName)
                            .ToList();
                        foreach (var s in students)
                        {
                            Console.WriteLine($"{s.FirstName} {s.LastName} - {s.PersonalNr} - {s.ClassCode}");
                        }
                        break;
                    case "2":
                        students = context.Students
                            .OrderBy(s => s.LastName)
                            .ToList();
                        foreach (var s in students)
                        {
                            Console.WriteLine($"{s.LastName}, {s.FirstName} - {s.PersonalNr} - {s.ClassCode}");
                        }
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent för att gå tillbaka.");
                        Console.ReadKey();
                        return;
                }

                Console.WriteLine();
                Console.WriteLine("Tryck på valfri tangent för att gå tillbaka.");
                Console.ReadKey();
            }
        }

        private static void ShowStudents(string? classToView)
        {
            Console.WriteLine("Välj sortering:");
            Console.WriteLine("1. Förnamn");
            Console.WriteLine("2. Efternamn");
            string? sortChoice = Console.ReadLine();
            if (sortChoice != null)
            {
                using var context = new LabsSchoolDBContext();
                List<Student> students;
                switch (sortChoice)
                {
                    case "1":
                        students = context.Students
                            .Where(s => s.ClassCode == classToView)
                            .OrderBy(s => s.FirstName)
                            .ToList();
                        foreach (var s in students)
                        {
                            Console.WriteLine($"{s.FirstName} {s.LastName} - {s.PersonalNr} - {s.ClassCode}");
                        }
                        break;
                    case "2":
                        students = context.Students
                            .Where(s => s.ClassCode == classToView)
                            .OrderBy(s => s.LastName)
                            .ToList();
                        foreach (var s in students)
                        {
                            Console.WriteLine($"{s.LastName}, {s.FirstName} - {s.PersonalNr} - {s.ClassCode}");
                        }
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Ogiltigt val. Tryck på valfri tangent för att gå tillbaka.");
                        Console.ReadKey();
                        return;
                }

                Console.WriteLine();
                Console.WriteLine("Tryck på valfri tangent för att gå tillbaka.");
                Console.ReadKey();
            }
        }



        public static void AddStaff()
        {

        }

        public static void ShowDepartments()
        {

        }

        public static void ShowStaff()
        {

        }


    }
}
