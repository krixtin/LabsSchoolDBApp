using LabsSchoolDBApp.Data;
using LabsSchoolDBApp.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
            if (newStudent.PersonalNr.Length != 10)
            {
                Console.WriteLine();
                Console.WriteLine("Fel. Personnumret måste anges i formatet ÅÅMMDDXXXX.");
                Console.ReadKey();
                return;
            }
            Console.Write("Ange klass: ");
            newStudent.ClassCode = Console.ReadLine();
            if (newStudent.ClassCode.Length != 4)
            {
                Console.WriteLine();
                Console.WriteLine("Fel. Klasskoden måste ha exakt fyra (4) tecken.");
                Console.ReadKey();
                return;
            }
            if (!context.Classes.Any(c => c.ClassCode == newStudent.ClassCode))
            {
                Console.WriteLine();
                Console.WriteLine("Fel. Det finns ingen klass med det namnet.");
                Console.ReadKey();
                return;
            }

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
                Console.WriteLine("Det finns ingen klass med det namnet.");
            }

            Console.ReadKey();
        }

        

        public static void ShowStudents()
        {
            Console.WriteLine("Välj sortering:");
            Console.WriteLine("1. Förnamn");
            Console.WriteLine("2. Efternamn");
            string? sortName = Console.ReadLine();
            Console.WriteLine("1. Stigande");
            Console.WriteLine("2. Fallande");
            string? sortDesc = Console.ReadLine();
            Console.Clear();
            if (sortName != null)
            {
                using var context = new LabsSchoolDBContext();
                List<Student> students;
                switch (sortName)
                {
                    case "1":
                        if (sortDesc == "1")
                        {
                            students = context.Students
                                .OrderBy(s => s.FirstName)
                                .ToList();
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.FirstName} {s.LastName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }   
                        }
                        else if (sortDesc == "2")
                        {
                            students = context.Students
                                .OrderByDescending(s => s.FirstName)
                                .ToList();

                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.FirstName} {s.LastName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        break;
                    case "2":
                        if (sortDesc == "1")
                        {
                            students = context.Students
                                .OrderBy(s => s.LastName)
                                .ToList();
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.LastName}, {s.FirstName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        else if (sortDesc == "2")
                        {
                            students = context.Students
                            .OrderByDescending(s => s.LastName)
                            .ToList();
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.LastName}, {s.FirstName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
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
            string? sortName = Console.ReadLine();
            Console.WriteLine("1. Stigande");
            Console.WriteLine("2. Fallande");
            string? sortDesc = Console.ReadLine();
            Console.Clear();
            if (sortName != null)
            {
                using var context = new LabsSchoolDBContext();
                List<Student> students;
                switch (sortName)
                {
                    case "1":
                        if (sortDesc == "1")
                        {
                            students = context.Students
                                .Where(students => students.ClassCode== classToView)
                                .OrderBy(s => s.FirstName)
                                .ToList();
                            Console.WriteLine($"Klass: {classToView}");
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.FirstName} {s.LastName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        else if (sortDesc == "2")
                        {
                            students = context.Students
                                .Where(students => students.ClassCode == classToView)
                                .OrderByDescending(s => s.FirstName)
                                .ToList();
                            Console.WriteLine($"Klass: {classToView}");
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.FirstName} {s.LastName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        break;
                    case "2":
                        if (sortDesc == "1")
                        {
                            students = context.Students
                                .Where(students => students.ClassCode == classToView)
                                .OrderBy(s => s.LastName)
                                .ToList();
                            Console.WriteLine($"Klass: {classToView}");
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.LastName}, {s.FirstName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
                        }
                        else if (sortDesc == "2")
                        {
                            students = context.Students
                            .Where(students => students.ClassCode == classToView)
                            .OrderByDescending(s => s.LastName)
                            .ToList();
                            Console.WriteLine($"Klass: {classToView}");
                            foreach (var s in students)
                            {
                                Console.WriteLine($"Namn: {s.LastName}, {s.FirstName} - Personnummer: {s.PersonalNr} - Klass: {s.ClassCode}");
                            }
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
